using Interfaces;
using Interfaces.Observer;
using Models;
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
    public partial class VisualizarVentas : Form, IObserver
    {
        private readonly IVenta _ventaService;
        private readonly ITraductor _traductorService;

        public VisualizarVentas(IVenta ventaService, ITraductor traductorService)
        {
            InitializeComponent();
            _ventaService = ventaService;
            _traductorService = traductorService;
        }

        private void VisualizarVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();

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

        private void CargarVentas()
        {
            List<ComprobanteVenta> comprobantes = _ventaService.GetComprobanteVenta();
            datagridVentas.DataSource = comprobantes;
            datagridVentas.Columns["Id"].Visible = false;
            datagridVentas.ClearSelection();
            datagridVentas.TabStop = false;
        }

        private void datagridVentas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var altura = 40;
            foreach (DataGridViewRow dr in datagridVentas.Rows)
            {
                altura += dr.Height;
            }

            datagridVentas.Height = altura;
        }

        private void VisualizarVentas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }
    }
}
