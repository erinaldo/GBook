using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Observer
{
    public interface IEtiqueta
    {
        int Id { get; set; }
        string Nombre { get; set; }
    }
}
