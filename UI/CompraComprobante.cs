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
    public partial class CompraComprobante : Form
    {
        private readonly ICompra _compraService;
        private readonly ComprobanteCompra _comprobante;

        public CompraComprobante(ICompra compraService, int compraId)
        {
            InitializeComponent();
            _compraService = compraService;
            _comprobante = _compraService.GetComprobanteCompra().Where(x => x.Id == compraId).FirstOrDefault();

            List<Models.DTOs.ReporteCompraDTO> lista = new List<Models.DTOs.ReporteCompraDTO>();
            foreach (DetalleComprobante item in _comprobante.Items)
            {
                Models.DTOs.ReporteCompraDTO reporteCompra = new Models.DTOs.ReporteCompraDTO()
                {
                    Producto = item.Producto.Nombre,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario,
                    Subtotal = item.Total
                };
                reporteCompra.NumeroComprobante = _comprobante.Id;
                reporteCompra.Detalle = _comprobante.Detalle;
                reporteCompra.Total = _comprobante.Total;
                reporteCompra.Fecha = _comprobante.Fecha;
                reporteCompra.FechaRecepcion = _comprobante.FechaRecepcion;
                reporteCompra.Domicilio = _comprobante.Envio.Domicilio;
                reporteCompra.Numero = _comprobante.Envio.Numero;
                reporteCompra.EntreCalles = _comprobante.Envio.EntreCalles;
                reporteCompra.TelefonoContacto = _comprobante.Envio.TelefonoContacto;

                lista.Add(reporteCompra);
            }

            ReportDataSource reporte = new ReportDataSource();
            reporte.Name = "DataSetCompra";
            reporte.Value = lista;
            reportViewer1.LocalReport.DataSources.Add(reporte);
            reportViewer1.LocalReport.ReportEmbeddedResource = "UI.ReporteCompra.rdlc";
        }

        private void CompraComprobante_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
