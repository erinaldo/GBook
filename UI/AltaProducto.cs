using Interfaces;
using Models;
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
    public partial class AltaProducto : Form
    {
        private readonly IProducto _productoService;
        private readonly IAutor _autorService;
        private readonly IGenero _generoService;
        private readonly IEditorial _editorialService;

        public AltaProducto(IProducto productoService, IAutor autorService, IGenero generoService, IEditorial editorialService)
        {
            InitializeComponent();
            _productoService = productoService;
            _autorService = autorService;
            _generoService = generoService;
            _editorialService = editorialService;
        }

        private void AltaProducto_Load(object sender, EventArgs e)
        {
            CargarAutores();
            CargarGeneros();
            CargarEditoriales();
            CargarProductos();
        }

        private void CargarAutores()
        {
            cbxAutor.DataSource = _autorService.GetAutores().Where(a => a.Activo == true).ToList();
            cbxAutor.ValueMember = "Id";
            cbxAutor.DisplayMember = "Seudonimo";
        }

        private void CargarGeneros()
        {
            cbxGenero.DataSource = _generoService.GetGeneros().Where(g => g.Activo == true).ToList();
            cbxGenero.ValueMember = "Id";
            cbxGenero.DisplayMember = "Nombre";
        }

        private void CargarEditoriales()
        {
            cbxEditorial.DataSource = _editorialService.GetEditoriales().Where(e => e.Activo == true).ToList();
            cbxEditorial.ValueMember = "Id";
            cbxEditorial.DisplayMember = "Nombre";
        }

        private void CargarProductos()
        {
            datagridProductos.DataSource = _productoService.GetProductos();
            datagridProductos.Columns["Id"].Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
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
                MessageBox.Show("Producto cargado con éxito.");
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
    }
}
