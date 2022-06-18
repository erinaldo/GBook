﻿using Interfaces;
using Models;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class RealizarVenta : Form
    {
        private readonly IProducto _productoService;
        private readonly IVenta _ventaService;
        private List<DetalleComprobante> _carrito;

        public RealizarVenta(IProducto productoService, IVenta ventaService)
        {
            InitializeComponent();
            _productoService = productoService;
            _ventaService = ventaService;
            _carrito = new List<DetalleComprobante>();
        }

        private void RealizarVenta_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            List<ProductoDTO> productos = ProductoDTO.FillListDTO(_productoService.GetProductos().Where(p => p.Activo == true && p.EnVenta == true).ToList());
            datagridProductosVenta.DataSource = productos;
            datagridProductosVenta.Columns["Id"].Visible = false;
            datagridProductosVenta.ClearSelection();
            datagridProductosVenta.TabStop = false;
        }

        private void datagridProductosVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto producto = _productoService.GetProducto((int)datagridProductosVenta.CurrentRow.Cells["Id"].Value);
            txtISBN.Text = producto.ISBN;
            txtNombre.Text = producto.Nombre;
            txtPrecioVenta.Text = producto.Precio.ToString();
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridProductosVenta.CurrentRow == null) throw new Exception("No seleccionó ningún producto.");
                if (string.IsNullOrWhiteSpace(txtCantidad.Text)) throw new Exception("No se seleccionó la cantidad.");

                Producto producto = _productoService.GetProducto((int)datagridProductosVenta.CurrentRow.Cells["Id"].Value);
                if (_carrito != null)
                {
                    foreach (var item in _carrito)
                    {
                        if (item.Producto.Id == producto.Id) throw new Exception("El producto ya esta en el carrito");
                    }
                }
                if (Convert.ToInt32(txtCantidad.Text) > producto.Stock.Cantidad) throw new Exception("No hay suficientes unidades en stock");

                DetalleComprobante carrito = new DetalleComprobante()
                {
                    Producto = producto,
                    Cantidad = int.Parse(txtCantidad.Text),
                    PrecioUnitario = producto.Precio,
                    Total = producto.Precio * int.Parse(txtCantidad.Text)
                };
                _carrito.Add(carrito);

                CargarCarrito();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarCarrito()
        {
            List<CarritoDTO> carritoDTO = CarritoDTO.FillListDTO(_carrito);
            datagridCarrito.DataSource = carritoDTO;
            datagridCarrito.ClearSelection();
            datagridCarrito.TabStop = false;
        }

        private void Limpiar()
        {
            txtISBN.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecioVenta.Text = "";
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            if (_carrito.Count() == 0) throw new Exception("El carrito está vacío.");

            ComprobanteVenta comprobante = new ComprobanteVenta()
            {
                Fecha = DateTime.Now,
                Items = _carrito,
                Detalle = txtDetalle.Text,
                Total = Convert.ToDouble(_carrito.Sum(x => x.Total)),
            };

            _ventaService.RealizarVenta(comprobante);
            MessageBox.Show("Se realizó una venta correctamente.");

            Limpiar();
            LimpiarCarrito();
            CargarCarrito();
            CargarProductos();
        }

        private void LimpiarCarrito()
        {
            txtDetalle.Text = "";
            _carrito = null;
        }
    }
}