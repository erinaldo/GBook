using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ComprobanteVenta : Comprobante
    {
        public List<DetalleComprobante> Items { get; set; }
    }
}
