using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Composite
{
    public enum Permiso
    {
        EsFamilia,
        AltaProducto,
        ModificarProducto,
        BajaProducto,
        DetalleProducto,
        GenerarPedidoStock,
        GenerarPedidoStockFijados,
        FijarProducto,
        GenerarAlertaPedidoStock,
        VisualizarPedidosStock,
        DetallePedidoStock,
        RecibirPedidoStock,
        PublicarProducto,
        ListarProductos,
        RealizarVenta,
        VisualizarVentas,
        AltaAutor,
        ModificarAutor,
        BajaAutor,
        AltaEditorial,
        ModificarEditorial,
        BajaEditorial,
        AltaGenero,
        ModificarGenero,
        BajaGenero,
        AltaIdioma,
        CargarEtiquetas,
        ModificarEtiquetas,
        GestionFamiliaPatente,
        GestionPermisosUsuarios
    }
}
