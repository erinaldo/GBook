using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Comprobante
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
    }
}
