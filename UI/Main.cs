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

        public Main(IUsuario UsuarioService)
        {
            InitializeComponent();
            _usuarioService = UsuarioService;
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
            Login login = new Login(_usuarioService);
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
    }
}
