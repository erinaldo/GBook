using Interfaces;
using Models;
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
    public partial class Registro : Form
    {
        private readonly IUsuario _usuarioService;

        public Registro(IUsuario usuarioService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Email = txtEmail.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Password = txtPassword.Text,
                };

                _usuarioService.RegistrarUsuario(usuario);

                MessageBox.Show("Usuario registrado con éxito.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void Registro_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarForm();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CerrarForm()
        {
            Login login = new Login(_usuarioService);
            login.Show();
        }
    }
}
