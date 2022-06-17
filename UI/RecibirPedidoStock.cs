using Interfaces;
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
    public partial class RecibirPedidoStock : Form
    {
        private readonly ICompra _compraService;
        
        public RecibirPedidoStock(ICompra compraService)
        {
            InitializeComponent();
            _compraService = compraService;
        }

        private void RecibirPedidoStock_Load(object sender, EventArgs e)
        {
            CargarPedidosStock();
        }

        private void CargarPedidosStock()
        {
            List<ComprobanteCompraDTO> comprobantes = ComprobanteCompraDTO.FillListDTO(_compraService.GetComprobanteCompra().Where(c => c.FechaRecepcion == DateTime.MinValue).ToList());
            datagridPedidosStock.DataSource = comprobantes;
            datagridPedidosStock.Columns["Id"].Visible = false;
            datagridPedidosStock.ClearSelection();
            datagridPedidosStock.TabStop = false;
        }

        private void btnRecibirPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkRecibido.Checked == true)
                {
                    ComprobanteCompra comprobante = _compraService.GetComprobanteCompra().Where(c => c.Id == (int)datagridPedidosStock.CurrentRow.Cells["Id"].Value).FirstOrDefault();

                    _compraService.RecibirPedidoStock(comprobante);
                    MessageBox.Show("Pedido recibido correctamente. Se actualizó el stock.");
                    Limpiar();

                    CargarPedidosStock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void datagridPedidosStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDetalle.Text = (string)datagridPedidosStock.CurrentRow.Cells["Detalle"].Value;
        }

        private void Limpiar()
        {
            txtDetalle.Text = "";
            chkRecibido.Checked = false;
        }
    }
}
