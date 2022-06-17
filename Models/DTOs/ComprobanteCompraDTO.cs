using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ComprobanteCompraDTO
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Total { get; set; }

        public static ComprobanteCompraDTO FillObject(ComprobanteCompra compra)
        {
            return new ComprobanteCompraDTO
            {
                Id = compra.Id,
                Detalle = compra.Detalle,
                FechaPedido = compra.Fecha,
                Total = compra.Total.ToString()
            };
        }

        public static List<ComprobanteCompraDTO> FillListDTO(List<ComprobanteCompra> comprobantes)
        {
            List<ComprobanteCompraDTO> comprobantesDTO = new List<ComprobanteCompraDTO>();
            
            foreach (ComprobanteCompra comprobante in comprobantes)
            {
                comprobantesDTO.Add(FillObject(comprobante));
            }
            
            return comprobantesDTO;
        }
    }
}
