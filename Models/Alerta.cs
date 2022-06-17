using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Alerta
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
        public int CantidadStockAviso { get; set; }
    }
}
