using Interfaces;
using Interfaces.Observer;
using Models;
using Models.DTOs;
using Models.Observer;
using Servicios;
using Servicios.Observer;
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
    public partial class RealizarVenta : Form, IObserver
    {
        private readonly IProducto _productoService;
        private readonly IVenta _ventaService;
        private readonly ITraductor _traductorService;

        private List<DetalleComprobante> _carrito;

        public RealizarVenta(IProducto productoService, IVenta ventaService, ITraductor traductorService)
        {
            InitializeComponent();
            _productoService = productoService;
            _ventaService = ventaService;
            _traductorService = traductorService;

            _carrito = new List<DetalleComprobante>();
        }

        private void RealizarVenta_Load(object sender, EventArgs e)
        {
            CargarProductos();

            Sesion.SuscribirObservador(this);
            UpdateLanguage(Sesion.GetInstance().Idioma);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }

        private void Traducir(IIdioma idioma)
        {
            Traductor.Traducir(_traductorService, idioma, this.Controls);
        }

        private string TraducirMensaje(string msgTag)
        {
            return Traductor.TraducirMensaje(_traductorService, msgTag);
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
                if (datagridProductosVenta.CurrentRow == null) throw new Exception(TraducirMensaje("msg_CarritoNoProductos"));
                if (string.IsNullOrWhiteSpace(txtCantidad.Text)) throw new Exception(TraducirMensaje("msg_CarritoNoCantidad"));

                Producto producto = _productoService.GetProducto((int)datagridProductosVenta.CurrentRow.Cells["Id"].Value);
                if (_carrito != null)
                {
                    foreach (var item in _carrito)
                    {
                        if (item.Producto.Id == producto.Id) throw new Exception(TraducirMensaje("msg_CarritoProductoExistente"));
                    }
                }
                if (Convert.ToInt32(txtCantidad.Text) > producto.Stock.Cantidad) throw new Exception(TraducirMensaje("msg_StockInsuficiente"));

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
            try
            {
                if (_carrito.Count() == 0) throw new Exception(TraducirMensaje("msg_CarritoVacio"));

                ComprobanteVenta comprobante = new ComprobanteVenta()
                {
                    Fecha = DateTime.Now,
                    Items = _carrito,
                    Detalle = txtDetalle.Text,
                    Total = Convert.ToDouble(_carrito.Sum(x => x.Total)),
                };

                int ventaId = _ventaService.RealizarVenta(comprobante);
                MessageBox.Show(TraducirMensaje("msg_VentaExito"));                
                VentaComprobante ventaComprobante = new VentaComprobante(_ventaService, ventaId);
                ventaComprobante.Show();

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

        private void LimpiarCarrito()
        {
            txtDetalle.Text = "";
            _carrito = null;
        }

        private void RealizarVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }

        private void datagridProductosVenta_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datagridProductosVenta.ClearSelection();
        }

        private void datagridCarrito_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datagridCarrito.ClearSelection();
        }
    }
}
