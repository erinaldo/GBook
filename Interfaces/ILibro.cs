using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ILibro
    {
        Models.Libro GetLibro(int productoId);
        List<Models.Libro> GetLibros();
        List<Models.Libro> GenerarAlertaPedidoStock();
    }
}
