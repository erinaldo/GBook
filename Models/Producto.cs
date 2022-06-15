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
        public string ISBN { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int CantidadPaginas { get; set; }
        public bool EnVenta { get; set; }
        public bool Activo { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Editorial Editorial { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
