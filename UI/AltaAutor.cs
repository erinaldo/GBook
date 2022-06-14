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
    public partial class AltaAutor : Form
    {
        private readonly IAutor _autorService;
        public AltaAutor(IAutor autorService)
        {
            _autorService = autorService;
            InitializeComponent();
        }

        private void Autor_Load(object sender, EventArgs e)
        {
            CargarGridAutores();
        }

        private void btnAlta_Click(object sender, EventArgs e)
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
                MessageBox.Show("Autor cargado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGridAutores()
        {
            datagridAutores.DataSource = _autorService.GetAutores();
            datagridAutores.Columns["Id"].Visible = false;
            datagridAutores.Columns["Activo"].Visible = false;
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtSeudonimo.Text = string.Empty;
        }
    }
}
