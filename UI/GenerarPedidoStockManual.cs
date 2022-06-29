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
    public partial class GenerarPedidoStockManual : Form, IObserver
    {
        private readonly IProducto _productoService;
        private readonly ILibro _libroService;
        private readonly ICompra _compraService;
        private readonly ITraductor _traductorService;

        private List<DetalleComprobante> _carrito;
        string labelTotalTexto;

        public GenerarPedidoStockManual(IProducto productoService, ILibro libroService, ICompra compraService, ITraductor traductorService)
        {
            InitializeComponent();
            _carrito = new List<DetalleComprobante>();
            _productoService = productoService;
            _libroService = libroService;
            _compraService = compraService;
            _traductorService = traductorService;
        }

        private void GenerarPedidoStockManual_Load(object sender, EventArgs e)
        {
            CargarProductos();

            Sesion.SuscribirObservador(this);
            UpdateLanguage(Sesion.GetInstance().Idioma);

            labelTotalTexto = lblTotal.Text;
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
            List<LibroDTO> productos = LibroDTO.FillListDTO(_libroService.GetLibros());
            datagridProductosCompra.DataSource = productos;
            datagridProductosCompra.Columns["Id"].Visible = false;
            datagridProductosCompra.ClearSelection();
            datagridProductosCompra.TabStop = false;
            datagridProductosCompra.ReadOnly = true;
        }

        private void datagridProductosCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Libro libro = _libroService.GetLibro((int)datagridProductosCompra.CurrentRow.Cells["Id"].Value);
            txtISBN.Text = libro.ISBN;
            txtNombre.Text = libro.Nombre;
            txtPrecio.Text = libro.Precio.ToString();
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridProductosCompra.CurrentRow == null) throw new Exception(TraducirMensaje("msg_CarritoNoProductos"));
                if (string.IsNullOrWhiteSpace(txtPrecioCompra.Text)) throw new Exception(TraducirMensaje("msg_CarritoNoPrecioCompra"));
                if (string.IsNullOrWhiteSpace(txtCantidad.Text)) throw new Exception(TraducirMensaje("msg_CarritoNoCantidad"));

                Producto producto = _libroService.GetLibro((int)datagridProductosCompra.CurrentRow.Cells["Id"].Value);
                if (_carrito != null)
                {
                    foreach (var item in _carrito)
                    {
                        if (item.Producto.Id == producto.Id) throw new Exception(TraducirMensaje("msg_CarritoProductoExistente"));
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
            datagridCarrito.Columns["Id"].Visible = false;
            datagridCarrito.ReadOnly = true;

            CalcularTotal();
        }

        private void Limpiar()
        {
            txtISBN.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtPrecioCompra.Text = "";
        }

        private void btnGenerarPedidoStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (_carrito.Count() == 0) throw new Exception(TraducirMensaje("msg_CarritoVacio"));

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
                MessageBox.Show(TraducirMensaje("msg_PedidoRealizadoCorrectamente"));

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
            txtDetalle.Text = "";
            _carrito = new List<DetalleComprobante>() ;
        }

        private void GenerarPedidoStockManual_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }

        private void datagridProductosCompra_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datagridProductosCompra.ClearSelection();
        }

        private void datagridCarrito_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datagridCarrito.ClearSelection();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridCarrito.CurrentRow != null)
                {
                    int productoId = (int)datagridCarrito.CurrentRow.Cells["Id"].Value;
                    _carrito.RemoveAll(x => x.Producto.Id == productoId);

                    CargarCarrito();
                }
            }
            catch
            {
                MessageBox.Show(TraducirMensaje("msg_ErrorEliminarCarrito"));
            }
        }

        private void CalcularTotal()
        {
            if (_carrito.Count > 0)
            {
                double total = _carrito.Sum(x => x.Total);
                lblTotal.Text = $"{labelTotalTexto}: ${total}";
                lblTotal.Visible = true;
            }
            else lblTotal.Visible = false;
        }
    }
}
