using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class PedidosRealizadosDTO
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string Total { get; set; }

        public static PedidosRealizadosDTO FillObject(ComprobanteCompra compra)
        {
            return new PedidosRealizadosDTO
            {
                Id = compra.Id,
                Detalle = compra.Detalle,
                FechaPedido = compra.Fecha,
                FechaRecepcion = compra.FechaRecepcion,
                Total = compra.Total.ToString()
            };
        }

        public static List<PedidosRealizadosDTO> FillListDTO(List<ComprobanteCompra> comprobantes)
        {
            List<PedidosRealizadosDTO> pedidosDTO = new List<PedidosRealizadosDTO>();

            foreach (ComprobanteCompra comprobante in comprobantes)
            {
                pedidosDTO.Add(FillObject(comprobante));
            }

            return pedidosDTO;
        }
    }
}
