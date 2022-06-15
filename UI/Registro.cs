﻿using Interfaces;
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
        private readonly IAutor _autorService;
        private readonly IEditorial _editorialService;
        private readonly IGenero _generoService;
        private readonly IProducto _productoService;

        public Registro(IUsuario usuarioService, IAutor autorService, IEditorial editorialService, IGenero generoService, IProducto productoService)   
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _autorService = autorService;
            _editorialService = editorialService;
            _generoService = generoService;
            _productoService = productoService;
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
            Login login = new Login(_usuarioService, _autorService, _editorialService, _generoService, _productoService);
            login.Show();
        }
    }
}
