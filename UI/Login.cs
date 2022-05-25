using Interfaces;
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

        public Login(IUsuario usuarioService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _usuarioService.Login(txtEmail.Text, txtPassword.Text);
                
                Limpiar();
                this.Hide();
                
                Main main = new Main(_usuarioService);
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

            Registro formRegistro = new Registro(_usuarioService);
            formRegistro.Show();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
