using Interfaces;
using Models;
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

        public Main(IUsuario UsuarioService)
        {
            InitializeComponent();
            _usuarioService = UsuarioService;
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Sesion.RemoveInstance();
            this.Close();

            Login login = new Login(_usuarioService);
            login.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Usuario usuario = Sesion.GetInstance();

            lblBienvenido.Text = $"Hola, {usuario.Nombre} {usuario.Apellido}.";
        }
    }
}
