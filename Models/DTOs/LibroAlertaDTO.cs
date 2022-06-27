using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class LibroAlertaDTO
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

        public static LibroAlertaDTO FillObject(Libro libro)
        {
            LibroAlertaDTO productoAlertaDTO = new LibroAlertaDTO()
            {
                Id = libro.Id,
                ISBN = libro.ISBN,
                Nombre = libro.Nombre,
                Autor = libro.Autor.Seudonimo,
                Genero = libro.Genero.Nombre,
                Editorial = libro.Editorial.Nombre,
                Stock = libro.Stock.Cantidad,
                CantidadStockAviso = libro.Alerta.CantidadStockAviso,
            };

            if (libro.Alerta.Activo == true) productoAlertaDTO.AlertaActiva = "Si";
            else productoAlertaDTO.AlertaActiva = "No";

            return productoAlertaDTO;
        }

        public static List<LibroAlertaDTO> FillListDTO(List<Libro> libros)
        {
            List<LibroAlertaDTO> productosDTO = new List<LibroAlertaDTO>();
            foreach (Libro libro in libros)
            {
                productosDTO.Add(FillObject(libro));
            }
            return productosDTO;
        }
    }
}
