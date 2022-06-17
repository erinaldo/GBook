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
    }
}
