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
        private readonly IAutor _autorService;
        private readonly IEditorial _editorialService;
        private readonly IGenero _generoService;

        public Login(IUsuario usuarioService, IAutor autorService, IEditorial editorialService, IGenero generoService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _autorService = autorService;
            _editorialService = editorialService;
            _generoService = generoService;
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _usuarioService.Login(txtEmail.Text, txtPassword.Text);
                
                Limpiar();
                this.Hide();
                
                Main main = new Main(_usuarioService, _autorService, _editorialService, _generoService);
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

            Registro formRegistro = new Registro(_usuarioService, _autorService, _editorialService, _generoService);
            formRegistro.Show();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
