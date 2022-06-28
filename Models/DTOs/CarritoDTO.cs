using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CarritoDTO
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public string PrecioUnitario { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public static CarritoDTO FillObject(DetalleComprobante carrito)
        {
            return new CarritoDTO()
            {
                Id = carrito.Producto.Id,
                Producto = carrito.Producto.Nombre,
                PrecioUnitario = carrito.PrecioUnitario.ToString(),
                Cantidad = carrito.Cantidad.ToString(),
                Total = (carrito.PrecioUnitario * carrito.Cantidad).ToString()
            };
        }

        public static List<CarritoDTO> FillListDTO(List<DetalleComprobante> carrito)
        {
            List<CarritoDTO> carritoDTO = new List<CarritoDTO>();

            if (carrito != null)
            {
                foreach (DetalleComprobante producto in carrito)
                {
                    carritoDTO.Add(FillObject(producto));
                }
            }
            
            return carritoDTO;
        }
    }
}
