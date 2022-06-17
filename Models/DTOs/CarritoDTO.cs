using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CarritoDTO
    {
        public string Producto { get; set; }
        public string PrecioUnitario { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public static CarritoDTO FillObject(DetalleComprobante carrito)
        {
            return new CarritoDTO()
            {
                Producto = carrito.Producto.Nombre,
                PrecioUnitario = carrito.Producto.Precio.ToString(),
                Cantidad = carrito.Cantidad.ToString(),
                Total = (carrito.Producto.Precio * carrito.Cantidad).ToString()
            };
        }

        public static List<CarritoDTO> FillListDTO(List<DetalleComprobante> carrito)
        {
            List<CarritoDTO> carritoDTO = new List<CarritoDTO>();
            foreach (DetalleComprobante producto in carrito)
            {
                carritoDTO.Add(FillObject(producto));
            }
            
            return carritoDTO;
        }
    }
}
