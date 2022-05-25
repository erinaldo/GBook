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
        public float Precio { get; set; }
        public int CantidadPaginas { get; set; }
        public bool EnVenta { get; set; }
        public bool Activo { get; set; }
        public Autor Autor { get; set; }
        public Genero Genero { get; set; }
        public Editorial Editorial { get; set; }
        public Stock Stock { get; set; }
    }
}
