using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Libro : Producto
    {
        public string ISBN { get; set; }
        public int CantidadPaginas { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Editorial Editorial { get; set; }
    }
}
