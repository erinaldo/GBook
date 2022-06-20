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
    public partial class GenerarPedidoStockFijados : Form
    {
        private readonly IProducto _productoService;
        private readonly ICompra _compraService;
        private List<DetalleComprobante> _carrito;

        public GenerarPedidoStockFijados(IProducto productoService, ICompra compraService)
        {
            InitializeComponent();
            _carrito = new List<DetalleComprobante>();
            _productoService = productoService;
            _compraService = compraService;
        }

        private void GenerarPedidoStockFijados_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            List<ProductoDTO> productos = ProductoDTO.FillListDTO(_productoService.GenerarAlertaPedidoStock());
            datagridProductosCompra.DataSource = productos;
            datagridProductosCompra.Columns["Id"].Visible = false;
            datagridProductosCompra.ClearSelection();
            datagridProductosCompra.TabStop = false;
        }

        private void datagridProductosCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto producto = _productoService.GetProducto((int)datagridProductosCompra.CurrentRow.Cells["Id"].Value);
            txtISBN.Text = producto.ISBN;
            txtNombre.Text = producto.Nombre;
            txtPrecio.Text = producto.Precio.ToString();
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridProductosCompra.CurrentRow == null) throw new Exception("No seleccionó ningún producto.");
                if (string.IsNullOrWhiteSpace(txtPrecioCompra.Text)) throw new Exception("No se completó el precio de compra.");
                if (string.IsNullOrWhiteSpace(txtCantidad.Text)) throw new Exception("No se seleccionó la cantidad.");

                Producto producto = _productoService.GetProducto((int)datagridProductosCompra.CurrentRow.Cells["Id"].Value);
                if (_carrito != null)
                {
                    foreach (var item in _carrito)
                    {
                        if (item.Producto.Id == producto.Id) throw new Exception("El producto ya esta en el carrito");
                    }
                }

                DetalleComprobante carrito = new DetalleComprobante()
                {
                    Producto = producto,
                    Cantidad = int.Parse(txtCantidad.Text),
                    PrecioUnitario = Convert.ToDouble(txtPrecioCompra.Text),
                    Total = Convert.ToDouble(txtPrecioCompra.Text) * int.Parse(txtCantidad.Text)
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
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtPrecioCompra.Text = "";
        }

        private void LimpiarCarrito()
        {
            txtDomicilio.Text = "";
            txtNumero.Text = "";
            txtEntreCalles.Text = "";
            txtTelefonoContacto.Text = "";
            txtDetalle.Text = "";
            _carrito = null;
        }

        private void btnGenerarPedidoStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (_carrito.Count() == 0) throw new Exception("El carrito está vacío.");

                Models.Envio envio = new Models.Envio()
                {
                    Domicilio = txtDomicilio.Text,
                    Numero = txtNumero.Text,
                    EntreCalles = txtEntreCalles.Text,
                    TelefonoContacto = txtTelefonoContacto.Text,
                };

                ComprobanteCompra comprobante = new ComprobanteCompra()
                {
                    Fecha = DateTime.Now,
                    Envio = envio,
                    Items = _carrito,
                    Detalle = txtDetalle.Text,
                    Total = Convert.ToDouble(_carrito.Sum(x => x.Total)),
                };

                _compraService.GenerarPedidoStock(envio, comprobante);
                MessageBox.Show("Se realizó un pedido de stock correctamente.");

                Limpiar();
                LimpiarCarrito();
                CargarCarrito();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}