using Interfaces;
using Models;
using Models.DTOs;
using Servicios;
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
    public partial class Main : Form
    {
        private readonly IUsuario _usuarioService;
        private readonly IAutor _autorService;
        private readonly IEditorial _editorialService;
        private readonly IGenero _generoService;
        private readonly IProducto _productoService;

        public Main(IUsuario UsuarioService, IAutor AutorService, IEditorial editorialService, IGenero generoService, IProducto productoService)
        {
            InitializeComponent();
            _usuarioService = UsuarioService;
            _autorService = AutorService;
            _editorialService = editorialService;
            _generoService = generoService;
            _productoService = productoService;
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UsuarioDTO usuario = Sesion.GetInstance();

            lblBienvenido.Text = $"Hola, {usuario.Nombre} {usuario.Apellido}.";
        }

        private void AbrirFormLogin()
        {
            Login login = new Login(_usuarioService, _autorService, _editorialService, _generoService, _productoService);
            login.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _usuarioService.Logout();
                AbrirFormLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void altaAutorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AltaAutor altaAutor = new AltaAutor(_autorService);
            altaAutor.Show();
        }

        private void modificarAutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarAutor modificarAutor = new ModificarAutor(_autorService);
            modificarAutor.Show();
        }

        private void altaEditorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaEditorial altaEditorial = new AltaEditorial(_editorialService);
            altaEditorial.Show();
        }

        private void modificarEditorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarEditorial modificarEditorial = new ModificarEditorial(_editorialService);
            modificarEditorial.Show();
        }

        private void altaGéneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaGenero altaGenero = new AltaGenero(_generoService);
            altaGenero.Show();
        }

        private void modificarGéneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarGenero modificarGenero = new ModificarGenero(_generoService);
            modificarGenero.Show();
        }

        private void altaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaProducto altaProducto = new AltaProducto(_productoService, _autorService, _generoService, _editorialService);
            altaProducto.Show();
        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarProducto modificarProducto = new ModificarProducto(_productoService, _autorService, _generoService, _editorialService);
            modificarProducto.Show();
        }

        private void publicarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublicarProducto publicarProducto = new PublicarProducto(_productoService);
            publicarProducto.Show();
        }
    }
}
