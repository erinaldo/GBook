using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public bool EnVenta { get; set; }
        public bool Activo { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Alerta Alerta { get; set; }
    }
}
