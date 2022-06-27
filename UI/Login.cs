using Interfaces;
using Interfaces.Composite;
using Interfaces.Observer;
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
    public partial class Login : Form
    {
        private readonly IUsuario _usuarioService;
        private readonly IAutor _autorService;
        private readonly IEditorial _editorialService;
        private readonly IGenero _generoService;
        private readonly IProducto _productoService;
        private readonly ILibro _libroService;
        private readonly ICompra _compraService;
        private readonly IVenta _ventaService;
        private readonly ITraductor _traductorService;
        private readonly IPermiso _permisoService;

        public Login(IUsuario usuarioService, IAutor autorService, IEditorial editorialService, IGenero generoService, IProducto productoService, ILibro libroService, ICompra compraService, IVenta ventaService, ITraductor traductorService, IPermiso permisoService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _autorService = autorService;
            _editorialService = editorialService;
            _generoService = generoService;
            _productoService = productoService;
            _libroService = libroService;
            _compraService = compraService;
            _ventaService = ventaService;
            _traductorService = traductorService;
            _permisoService = permisoService;
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _usuarioService.Login(txtEmail.Text, txtPassword.Text);
                
                Limpiar();
                this.Hide();
                
                Main main = new Main(_usuarioService, _autorService, _editorialService, _generoService, _productoService, _libroService, _compraService, _ventaService, _traductorService, _permisoService);
                main.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtPassword.Clear();
            }
        }

        private void Limpiar()
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void lblRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();

            Registro formRegistro = new Registro(_usuarioService, _autorService, _editorialService, _generoService, _productoService, _libroService, _compraService, _ventaService, _traductorService, _permisoService);
            formRegistro.Show();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
