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
        private readonly ILibro _libroService;
        private readonly ITraductor _traductorService;

        public PublicarProducto(IProducto productoService, ILibro libroService, ITraductor traductorService)
        {
            InitializeComponent();
            _productoService = productoService;
            _libroService = libroService;
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
            List<LibroDTO> productos = LibroDTO.FillListDTO(_libroService.GetLibros());
            datagridProductos.DataSource = productos;
            datagridProductos.Columns["Id"].Visible = false;
            datagridProductos.ClearSelection();
            datagridProductos.TabStop = false;
            datagridProductos.ReadOnly = true;
        }

        private void datagridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Libro libro = _libroService.GetLibro((int)datagridProductos.CurrentRow.Cells["Id"].Value);
            txtISBN.Text = libro.ISBN;
            txtNombre.Text = libro.Nombre;
            txtPrecio.Text = libro.Precio.ToString();

            if (libro.EnVenta == true) cbxEnVenta.Text = "Si";
            else cbxEnVenta.Text = "No";
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridProductos.CurrentRow == null) throw new Exception(TraducirMensaje("msg_CarritoNoProductos"));

                if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    Libro libro = new Libro()
                    {
                        Id = (int)datagridProductos.CurrentRow.Cells["Id"].Value,
                        Precio = Convert.ToDouble(txtPrecio.Text),
                    };
                    if (cbxEnVenta.Text == "Si") libro.EnVenta = true;
                    else libro.EnVenta = false;

                    _productoService.PublicarProducto(libro);

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
