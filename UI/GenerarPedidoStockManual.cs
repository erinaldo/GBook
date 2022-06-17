using Interfaces;
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
    public partial class GenerarPedidoStockManual : Form
    {
        private readonly IProducto _productoService;
        private readonly ICompra _compraService;
        private List<DetalleComprobante> _carrito;

        public GenerarPedidoStockManual(IProducto productoService, ICompra compraService)
        {
            InitializeComponent();
            _carrito = new List<DetalleComprobante>();
            _productoService = productoService;
            _compraService = compraService;
        }

        private void GenerarPedidoStockManual_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            List<ProductoDTO> productos = ProductoDTO.FillListDTO(_productoService.GetProductos());
            datagridProductosCompra.DataSource = productos;
            datagridProductosCompra.Columns["Id"].Visible = false;
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
                Producto producto = _productoService.GetProducto((int)datagridProductosCompra.CurrentRow.Cells["Id"].Value);
                foreach (var item in _carrito)
                {
                    if (item.Producto.Id == producto.Id) throw new Exception("El producto ya esta en el carrito");
                }

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
        }

        private void Limpiar()
        {
            txtISBN.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }

        private void btnGenerarPedidoStock_Click(object sender, EventArgs e)
        {
            try
            {
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
                    Total = Convert.ToDouble(_carrito.Sum(x => x.Total))
                };

                _compraService.GenerarPedidoStock(envio, comprobante);
                Limpiar();
                LimpiarCarrito();
                CargarCarrito();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarCarrito()
        {
            txtDomicilio.Text = "";
            txtNumero.Text = "";
            txtEntreCalles.Text = "";
            txtTelefonoContacto.Text = "";
            _carrito = null;
        }
    }
}
