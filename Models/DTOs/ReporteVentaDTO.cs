using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ReporteVentaDTO
    {
        public int NumeroComprobante { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }

        //public static ReporteVentaDTO FillObject(ComprobanteVenta comprobante)
        //{
        //    return new ReporteVentaDTO()
        //    {
        //        NumeroComprobante = comprobante.Id,
        //        Detalle = comprobante.Detalle,
        //        Fecha = comprobante.Fecha,
        //        Total = comprobante.Total,
        //        Producto = comprobante.Items.
        //    };
        //}
    }
}
