using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IProducto
    {
        int AltaProducto(Models.Producto producto);
        int AltaStock(int productoId);
        int AltaAlerta(int productoId);
        int ModificarProducto(Models.Producto producto);
        int PublicarProducto(Models.Producto producto);
        int FijarProducto(Models.Producto producto);
        Models.Producto GetProducto(int productoId);
    }
}
