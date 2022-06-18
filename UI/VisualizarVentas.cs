using Interfaces;
using Models;
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
    public partial class VisualizarVentas : Form
    {
        private readonly IVenta _ventaService;

        public VisualizarVentas(IVenta ventaService)
        {
            InitializeComponent();
            _ventaService = ventaService;
        }

        private void VisualizarVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
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
    }
}
