using Interfaces;
using Interfaces.Observer;
using Models.Observer;
using Servicios;
using Servicios.Observer;
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
    public partial class AltaGenero : Form, IObserver
    {
        private readonly IGenero _generoService;
        private readonly ITraductor _traductorService;

        public AltaGenero(IGenero generoService, ITraductor traductorService)
        {
            InitializeComponent();
            _generoService = generoService;
            _traductorService = traductorService;
        }

        private void AltaGenero_Load(object sender, EventArgs e)
        {
            CargarGridGeneros();

            Sesion.SuscribirObservador(this);
            UpdateLanguage(Sesion.GetInstance().Idioma);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }

        private void Traducir(IIdioma idioma)
        {
            IDictionary<string, ITraduccion> traducciones = _traductorService.ObtenerTraducciones(idioma);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Tag != null && traducciones.ContainsKey(ctrl.Tag.ToString()))
                    ctrl.Text = traducciones[ctrl.Tag.ToString()].Texto;

                else if (ctrl.Tag != null && !traducciones.ContainsKey(ctrl.Tag.ToString()))
                    ctrl.Text = ctrl.Text = $"PLACEHOLDER_{ctrl.Tag}_NO_TRADUCTION";

                else ctrl.Text = ctrl.Text = "PLACEHOLDER_TAG_NOT_ASSIGNED";

                if (ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(ComboBox))
                {
                    ctrl.Text = "";
                }
            }
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

        private void AltaGenero_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }
    }
}
