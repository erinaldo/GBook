using Interfaces;
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
    public partial class Autor : Form
    {
        private readonly IAutor _autorService;
        public Autor(IAutor autorService)
        {
            _autorService = autorService;
            InitializeComponent();
        }

        private void Autor_Load(object sender, EventArgs e)
        {
            CargarGridAutores();
        }

        private void txtAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Autor autor = new Models.Autor()
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Seudonimo = txtSeudonimo.Text,
                };

                _autorService.RegistrarAutor(autor);

                CargarGridAutores();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGridAutores()
        {
            datagridAutores.DataSource = _autorService.GetAutores();
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtSeudonimo.Text = string.Empty;
        }
    }
}
