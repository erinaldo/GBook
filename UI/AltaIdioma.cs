using Interfaces.Observer;
using Models.Observer;
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
    public partial class AltaIdioma : Form
    {
        private readonly ITraductor _traductorService;

        public AltaIdioma(ITraductor traductorService)
        {
            InitializeComponent();
            _traductorService = traductorService;
        }

        private void AltaIdioma_Load(object sender, EventArgs e)
        {
            CargarGridIdiomas();
        }

        private void CargarGridIdiomas()
        {
            IList<IIdioma> idiomas = _traductorService.ObtenerIdiomas();

            datagridIdiomas.DataSource = idiomas;
            datagridIdiomas.Columns["Id"].Visible = false;
            datagridIdiomas.Columns["Default"].Visible = false;
            datagridIdiomas.ClearSelection();
            datagridIdiomas.TabStop = false;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Observer.Idioma idioma = new Models.Observer.Idioma()
                {
                    Nombre = txtNombre.Text,
                };

                _traductorService.AltaIdioma(idioma);

                txtNombre.Text = "";
                MessageBox.Show("Idioma cargado con éxito.");
                CargarGridIdiomas();
                this.Refresh(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
