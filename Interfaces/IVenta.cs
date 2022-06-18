using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IVenta
    {
        int AltaVenta(DetalleComprobante detalle);
        int GenerarComprobanteVenta(Models.ComprobanteVenta venta);
        int AltaDetalleComprobante(Models.DetalleComprobante detalle, int ventaId);
        int RealizarVenta(ComprobanteVenta comprobante);
        List<Models.ComprobanteVenta> GetComprobanteVenta();
        List<Models.DetalleComprobante> GetDetalleComprobanteVenta(int ventaId);
    }
}
