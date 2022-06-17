using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ProductoAlertaDTO
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string Editorial { get; set; }
        public int Stock { get; set; }
        public string AlertaActiva { get; set; }
        public int CantidadStockAviso { get; set; }

        public static ProductoAlertaDTO FillObject(Producto producto)
        {
            ProductoAlertaDTO productoAlertaDTO = new ProductoAlertaDTO()
            {
                Id = producto.Id,
                ISBN = producto.ISBN,
                Nombre = producto.Nombre,
                Autor = producto.Autor.Seudonimo,
                Genero = producto.Genero.Nombre,
                Editorial = producto.Editorial.Nombre,
                Stock = producto.Stock.Cantidad,
                CantidadStockAviso = producto.Alerta.CantidadStockAviso,
            };

            if (producto.Alerta.Activo == true) productoAlertaDTO.AlertaActiva = "Si";
            else productoAlertaDTO.AlertaActiva = "No";

            return productoAlertaDTO;
        }

        public static List<ProductoAlertaDTO> FillListDTO(List<Producto> productos)
        {
            List<ProductoAlertaDTO> productosDTO = new List<ProductoAlertaDTO>();
            foreach (Producto producto in productos)
            {
                productosDTO.Add(FillObject(producto));
            }
            return productosDTO;
        }
    }
}
