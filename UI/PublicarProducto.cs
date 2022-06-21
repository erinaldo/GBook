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
    public partial class PublicarProducto : Form, IObserver
    {
        private readonly IProducto _productoService;
        private readonly ITraductor _traductorService;

        public PublicarProducto(IProducto productoService, ITraductor traductorService)
        {
            InitializeComponent();
            _productoService = productoService;
            _traductorService = traductorService;
        }

        private void PublicarProducto_Load(object sender, EventArgs e)
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
            List<ProductoDTO> productos = ProductoDTO.FillListDTO(_productoService.GetProductos());
            datagridProductos.DataSource = productos;
            datagridProductos.Columns["Id"].Visible = false;
            datagridProductos.ClearSelection();
            datagridProductos.TabStop = false;
        }

        private void datagridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto producto = _productoService.GetProducto((int)datagridProductos.CurrentRow.Cells["Id"].Value);
            txtISBN.Text = producto.ISBN;
            txtNombre.Text = producto.Nombre;
            txtPrecio.Text = producto.Precio.ToString();

            if (producto.EnVenta == true) cbxEnVenta.Text = "Si";
            else cbxEnVenta.Text = "No";
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridProductos.CurrentRow == null) throw new Exception(TraducirMensaje("msg_CarritoNoProductos"));

                if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    Producto producto = new Producto()
                    {
                        Id = (int)datagridProductos.CurrentRow.Cells["Id"].Value,
                        Precio = Convert.ToDouble(txtPrecio.Text),
                    };
                    if (cbxEnVenta.Text == "Si") producto.EnVenta = true;
                    else producto.EnVenta = false;

                    _productoService.PublicarProducto(producto);

                    CargarProductos();
                    Limpiar();
                    MessageBox.Show(TraducirMensaje("msg_ProductoPublicadoExito"));
                }
                else throw new Exception(TraducirMensaje("msg_CompletarCampos"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Limpiar()
        {
            txtISBN.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            cbxEnVenta.SelectedIndex = -1;
        }

        private void PublicarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }

        private void datagridProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datagridProductos.ClearSelection();
        }
    }
}
