using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int CantidadPaginas { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string Editorial { get; set; }
        public int Stock { get; set; }
        public string EnVenta { get; set; }
        public string Activo { get; set; }

        public static ProductoDTO FillObject(Producto producto)
        {
            ProductoDTO productoDTO = new ProductoDTO()
            {
                Id = producto.Id,
                ISBN = producto.ISBN,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                CantidadPaginas = producto.CantidadPaginas,
                Autor = producto.Autor.Seudonimo,
                Genero = producto.Genero.Nombre,
                Editorial = producto.Editorial.Nombre,
                Stock = producto.Stock.Cantidad,
            };

            if (producto.EnVenta == true) productoDTO.EnVenta = "Si"; 
            else productoDTO.EnVenta = "No";

            if (producto.Activo == true) productoDTO.Activo = "Si";
            else productoDTO.Activo = "No";

            return productoDTO;
        }

        public static List<ProductoDTO> FillListDTO(List<Producto> productos)
        {
            List<ProductoDTO> productosDTO = new List<ProductoDTO>();
            foreach (Producto producto in productos)
            {
                productosDTO.Add(FillObject(producto));
            }
            return productosDTO;
        }
    }
}
