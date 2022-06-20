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
    public partial class ModificarProducto : Form, IObserver
    {
        private readonly IProducto _productoService;
        private readonly IAutor _autorService;
        private readonly IGenero _generoService;
        private readonly IEditorial _editorialService;
        private readonly ITraductor _traductorService;

        public ModificarProducto(IProducto productoService, IAutor autorService, IGenero generoService, IEditorial editorialService, ITraductor traductorService)
        {
            InitializeComponent();
            _productoService = productoService;
            _autorService = autorService;
            _generoService = generoService;
            _editorialService = editorialService;
            _traductorService = traductorService;
        }

        private void ModificarProducto_Load(object sender, EventArgs e)
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
            IDictionary<string, ITraduccion> traducciones = _traductorService.ObtenerTraducciones(idioma);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Tag != null && traducciones.ContainsKey(ctrl.Tag.ToString()))
                    ctrl.Text = traducciones[ctrl.Tag.ToString()].Texto;

                else if (ctrl.Tag != null && !traducciones.ContainsKey(ctrl.Tag.ToString()))
                    ctrl.Text = ctrl.Text = $"PLACEHOLDER_{ctrl.Tag}_NO_TRADUCTION";

                else ctrl.Text = ctrl.Text = "PLACEHOLDER_TAG_NOT_ASSIGNED";

                if (ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(ComboBox))
                {
                    ctrl.Text = "";
                }
            }
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridProductos.CurrentRow == null) throw new Exception("No seleccionó ningún producto.");

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
                    Id = (int)datagridProductos.SelectedRows[0].Cells["Id"].Value,
                    ISBN = txtISBN.Text,
                    Nombre = txtNombre.Text,
                    Precio = Convert.ToDouble(txtPrecio.Text),
                    CantidadPaginas = Convert.ToInt32(txtCantidadPaginas.Text),
                    Autor = autor,
                    Genero = genero,
                    Editorial = editorial,
                };

                _productoService.ModificarProducto(producto);

                CargarProductos();
                Limpiar();
                MessageBox.Show("Producto modificado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void datagridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto producto = _productoService.GetProducto((int)datagridProductos.CurrentRow.Cells["Id"].Value);
            txtISBN.Text = producto.ISBN;
            txtNombre.Text = producto.Nombre;
            txtPrecio.Text = producto.Precio.ToString();
            txtCantidadPaginas.Text = producto.CantidadPaginas.ToString();
            cbxAutor.SelectedValue = producto.Autor.Id;
            cbxGenero.SelectedValue = producto.Genero.Id;
            cbxEditorial.SelectedValue = producto.Editorial.Id;
        }

        private void ModificarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }
    }
}
