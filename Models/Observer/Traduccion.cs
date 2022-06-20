using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Observer
{
    public class Traduccion : ITraduccion
    {
        public int Id { get; set; }
        public IEtiqueta Etiqueta { get; set; }
        public string Texto { get; set; }
    }
}
