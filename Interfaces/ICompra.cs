using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICompra
    {
        int AltaEnvio(Models.Envio envio);
        int AltaCompra(Models.ComprobanteCompra compra, int envioId);
        int AltaDetalleComprobante(Models.DetalleComprobante detalle, int compraId);
        int GenerarPedidoStock(Models.Envio envio, Models.ComprobanteCompra compra);
        int RecibirPedidoStock(Models.ComprobanteCompra comprobante);
        int AumentarStock(Models.DetalleComprobante detalle);
        Models.Envio GetEnvio(int envioId);
        List<Models.ComprobanteCompra> GetComprobanteCompra();
        List<Models.DetalleComprobante> GetDetalleComprobanteCompra(int compraId);
    }
}
