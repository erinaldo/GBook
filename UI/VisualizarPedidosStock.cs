using Interfaces;
using Interfaces.Observer;
using Models.DTOs;
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
    public partial class VisualizarPedidosStock : Form, IObserver
    {
        private readonly ICompra _compraService;
        private readonly ITraductor _traductorService;

        public VisualizarPedidosStock(ICompra compraService, ITraductor traductorService)
        {
            InitializeComponent();
            _compraService = compraService;
            _traductorService = traductorService;
        }

        private void VisualizarPedidosStock_Load(object sender, EventArgs e)
        {
            CargarPedidosStockRealizados();

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

        private void CargarPedidosStockRealizados()
        {
            List<PedidosRealizadosDTO> comprobantes = PedidosRealizadosDTO.FillListDTO(_compraService.GetComprobanteCompra());
            datagridPedidosStock.DataSource = comprobantes;
            datagridPedidosStock.Columns["Id"].Visible = false;
            datagridPedidosStock.ClearSelection();
            datagridPedidosStock.TabStop = false;
        }

        private void VisualizarPedidosStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }
    }
}
