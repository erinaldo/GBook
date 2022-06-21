using Interfaces;
using Microsoft.Reporting.WinForms;
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
    public partial class VentaComprobante : Form
    {
        private readonly IVenta _ventaService;
        private readonly ComprobanteVenta _comprobante;

        public VentaComprobante(IVenta ventaServices, int ventaId)
        {
            InitializeComponent();
            _ventaService = ventaServices;
            _comprobante = _ventaService.GetComprobanteVenta().Where(x => x.Id == ventaId).FirstOrDefault();
           
            List<Models.DTOs.ReporteVentaDTO> lista = new List<Models.DTOs.ReporteVentaDTO>();
            foreach (DetalleComprobante item in _comprobante.Items)
            {
                Models.DTOs.ReporteVentaDTO reporteVenta = new Models.DTOs.ReporteVentaDTO()
                {
                    Producto = item.Producto.Nombre,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario,
                    Subtotal = item.Total
                };
                reporteVenta.NumeroComprobante = _comprobante.Id;
                reporteVenta.Detalle = _comprobante.Detalle;
                reporteVenta.Total = _comprobante.Total;
                reporteVenta.Fecha = _comprobante.Fecha;

                lista.Add(reporteVenta);
            }                       

            ReportDataSource reporte = new ReportDataSource();
            reporte.Name = "DataSetVenta";
            reporte.Value = lista;
            reportViewer1.LocalReport.DataSources.Add(reporte);
            reportViewer1.LocalReport.ReportEmbeddedResource = "UI.ReporteVenta.rdlc";           
        }

        private void VentaComprobante_Load(object sender, EventArgs e)
        {            
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
