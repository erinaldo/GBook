using Interfaces;
using Interfaces.Observer;
using Models;
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
    public partial class RecibirPedidoStock : Form, IObserver
    {
        private readonly ICompra _compraService;
        private readonly ITraductor _traductorService;
        
        public RecibirPedidoStock(ICompra compraService, ITraductor traductorService)
        {
            InitializeComponent();
            _compraService = compraService;
            _traductorService = traductorService;
        }

        private void RecibirPedidoStock_Load(object sender, EventArgs e)
        {
            CargarPedidosStock();

            Sesion.SuscribirObservador(this);
            UpdateLanguage(Sesion.GetInstance().Idioma);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }

        private void Traducir(IIdioma idioma)
        {
            Traductor.Traducir(_traductorService, idioma, this.Controls);
        }

        private string TraducirMensaje(string msgTag)
        {
            return Traductor.TraducirMensaje(_traductorService, msgTag);
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
                if (datagridPedidosStock.CurrentRow == null) throw new Exception(TraducirMensaje("msg_NoPedidoSeleccionado"));

                if (chkRecibido.Checked == true)
                {
                    ComprobanteCompra comprobante = _compraService.GetComprobanteCompra().Where(c => c.Id == (int)datagridPedidosStock.CurrentRow.Cells["Id"].Value).FirstOrDefault();

                    _compraService.RecibirPedidoStock(comprobante);
                    MessageBox.Show(TraducirMensaje("msg_PedidoRecibido"));
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

        private void RecibirPedidoStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }

        private void datagridPedidosStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datagridPedidosStock.ClearSelection();
        }
    }
}
