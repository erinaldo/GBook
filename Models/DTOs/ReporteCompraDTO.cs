using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ReporteCompraDTO
    {
        public int NumeroComprobante { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public double Total { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }
        public string Domicilio { get; set; }
        public string Numero { get; set; }
        public string EntreCalles { get; set; }
        public string TelefonoContacto { get; set; }
    }
}
