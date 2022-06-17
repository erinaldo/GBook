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
    public partial class AltaGenero : Form
    {
        private readonly IGenero _generoService;
            
        public AltaGenero(IGenero generoService)
        {
            InitializeComponent();
            _generoService = generoService;
        }

        private void AltaGenero_Load(object sender, EventArgs e)
        {
            CargarGridGeneros();
        }

        private void CargarGridGeneros()
        {
            datagridGenero.DataSource = _generoService.GetGeneros();
            datagridGenero.Columns["Id"].Visible = false;
            datagridGenero.Columns["Activo"].Visible = false;
            datagridGenero.ClearSelection();
            datagridGenero.TabStop = false;
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Genero genero = new Models.Genero()
                {
                    Nombre = txtNombre.Text,
                };

                _generoService.AltaGenero(genero);

                CargarGridGeneros();
                Limpiar();
                MessageBox.Show("Editorial cargada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
