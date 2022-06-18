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
    public partial class VisualizarPedidosStock : Form
    {
        private readonly ICompra _compraService;

        public VisualizarPedidosStock(ICompra compraService)
        {
            InitializeComponent();
            _compraService = compraService;
        }

        private void VisualizarPedidosStock_Load(object sender, EventArgs e)
        {
            CargarPedidosStockRealizados();
        }

        private void CargarPedidosStockRealizados()
        {
            List<PedidosRealizadosDTO> comprobantes = PedidosRealizadosDTO.FillListDTO(_compraService.GetComprobanteCompra());
            datagridPedidosStock.DataSource = comprobantes;
            datagridPedidosStock.Columns["Id"].Visible = false;
            datagridPedidosStock.ClearSelection();
            datagridPedidosStock.TabStop = false;
        }
    }
}
