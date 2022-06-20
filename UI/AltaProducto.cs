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
    public partial class AltaProducto : Form, IObserver
    {
        private readonly IProducto _productoService;
        private readonly IAutor _autorService;
        private readonly IGenero _generoService;
        private readonly IEditorial _editorialService;
        private readonly ITraductor _traductorService;

        public AltaProducto(IProducto productoService, IAutor autorService, IGenero generoService, IEditorial editorialService, ITraductor traductorService)
        {
            InitializeComponent();
            _productoService = productoService;
            _autorService = autorService;
            _generoService = generoService;
            _editorialService = editorialService;
            _traductorService = traductorService;
        }

        private void AltaProducto_Load(object sender, EventArgs e)
        {
            CargarAutores();
            CargarGeneros();
            CargarEditoriales();
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

        private void CargarAutores()
        {
            cbxAutor.DataSource = _autorService.GetAutores().Where(a => a.Activo == true).ToList();
            cbxAutor.ValueMember = "Id";
            cbxAutor.DisplayMember = "Seudonimo";
            cbxAutor.SelectedIndex = -1;
        }

        private void CargarGeneros()
        {
            cbxGenero.DataSource = _generoService.GetGeneros().Where(g => g.Activo == true).ToList();
            cbxGenero.ValueMember = "Id";
            cbxGenero.DisplayMember = "Nombre";
            cbxGenero.SelectedIndex = -1;
        }

        private void CargarEditoriales()
        {
            cbxEditorial.DataSource = _editorialService.GetEditoriales().Where(e => e.Activo == true).ToList();
            cbxEditorial.ValueMember = "Id";
            cbxEditorial.DisplayMember = "Nombre";
            cbxEditorial.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            List<ProductoDTO> productos = ProductoDTO.FillListDTO(_productoService.GetProductos());
            datagridProductos.DataSource = productos;
            datagridProductos.Columns["Id"].Visible = false;
            datagridProductos.ClearSelection();
            datagridProductos.TabStop = false;            
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxAutor.SelectedIndex == -1) throw new Exception(TraducirMensaje("msg_ProductoAutor"));
                if (cbxGenero.SelectedIndex == -1) throw new Exception(TraducirMensaje("msg_ProductoGenero"));
                if (cbxEditorial.SelectedIndex == -1) throw new Exception(TraducirMensaje("msg_ProductoEditorial"));

                Autor autor = new Models.Autor()
                {
                    Id = (int)cbxAutor.SelectedValue,
                    Seudonimo = cbxAutor.Text
                };
                Genero genero = new Models.Genero()
                {
                    Id = (int)cbxGenero.SelectedValue,
                    Nombre = cbxGenero.Text
                };
                Editorial editorial = new Models.Editorial()
                {
                    Id = (int)cbxEditorial.SelectedValue,
                    Nombre = cbxEditorial.Text
                };

                Producto producto = new Models.Producto()
                {
                    ISBN = txtISBN.Text,
                    Nombre = txtNombre.Text,
                    Precio = Convert.ToDouble(txtPrecio.Text),
                    CantidadPaginas = Convert.ToInt32(txtCantidadPaginas.Text),
                    Autor = autor,
                    Genero = genero,
                    Editorial = editorial,
                };

                _productoService.AltaProducto(producto);

                CargarProductos();
                Limpiar();
                MessageBox.Show(TraducirMensaje("msg_ProductoAltaExito"));
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
            txtCantidadPaginas.Text = "";
            cbxAutor.SelectedIndex = -1;
            cbxGenero.SelectedIndex = -1;
            cbxEditorial.SelectedIndex = -1;
        }

        private void AltaProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }
    }
}
