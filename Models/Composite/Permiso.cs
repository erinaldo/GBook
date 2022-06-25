using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Composite
{
    public enum Permiso
    {
        CargarProducto,
        ModificarProducto,
        BajaProducto,
        DetalleProducto,
        GenerarPedidoStockManual,
        GenerarPedidoStockFijado,
        MarcarProductoFijado,
        GenerarAlertaPedidoStock,
        VisualizarPedidosStock,
        DetallePedidoStock,
        RecibirPedidoStock,
        PublicarProductoVenta,
        ListarProductos,
        VentaProducto,
        VisualizarVentas
    }
}
