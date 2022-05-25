using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ComprobanteCompra : Comprobante
    {
        public DateTime FechaRecepcion { get; set; }
        public List<DetalleComprobante> Items { get; set; }
        public Envio Envio { get; set; }
    }
}
