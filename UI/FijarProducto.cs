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
    public partial class FijarProducto : Form, IObserver
    {
        private readonly IProducto _productoService;
        private readonly ILibro _libroService;
        private readonly ITraductor _traductorService;

        public FijarProducto(IProducto productoService, ILibro libroService, ITraductor traductorService)
        {
            InitializeComponent();
            _productoService = productoService;
            _traductorService = traductorService;
            _libroService = libroService;
        }

        private void FijarProducto_Load(object sender, EventArgs e)
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
            List<LibroAlertaDTO> productos = LibroAlertaDTO.FillListDTO(_libroService.GetLibros());
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
            txtCantidadStockAviso.Text = libro.Alerta.CantidadStockAviso.ToString();

            if (libro.Alerta.Activo == true) cbxActivo.Text = "Si";
            else cbxActivo.Text = "No";
        }

        private void btnFijar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCantidadStockAviso.Text))
                {
                    Alerta alerta = new Alerta()
                    {
                        CantidadStockAviso = int.Parse(txtCantidadStockAviso.Text),
                        Activo = cbxActivo.Text == "Si" ? true : false,
                    };
                    Libro libro = new Libro()
                    {
                        Id = (int)datagridProductos.CurrentRow.Cells["Id"].Value,
                        Alerta = alerta
                    };

                    _productoService.FijarProducto(libro);

                    CargarProductos();
                    Limpiar();
                    MessageBox.Show(TraducirMensaje("msg_ProductoFijarExito"));
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
            cbxActivo.SelectedIndex = -1;
            txtCantidadStockAviso.Text = "";
        }

        private void FijarProducto_FormClosed(object sender, FormClosedEventArgs e)
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
