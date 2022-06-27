using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class LibroDTO
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

        public static LibroDTO FillObject(Libro libro)
        {
            LibroDTO productoDTO = new LibroDTO()
            {
                Id = libro.Id,
                ISBN = libro.ISBN,
                Nombre = libro.Nombre,
                Precio = libro.Precio,
                CantidadPaginas = libro.CantidadPaginas,
                Autor = libro.Autor.Seudonimo,
                Genero = libro.Genero.Nombre,
                Editorial = libro.Editorial.Nombre,
                Stock = libro.Stock.Cantidad,
            };

            if (libro.EnVenta == true) productoDTO.EnVenta = "Si"; 
            else productoDTO.EnVenta = "No";

            if (libro.Activo == true) productoDTO.Activo = "Si";
            else productoDTO.Activo = "No";

            return productoDTO;
        }

        public static List<LibroDTO> FillListDTO(List<Libro> libros)
        {
            List<LibroDTO> productosDTO = new List<LibroDTO>();
            foreach (Libro libro in libros)
            {
                productosDTO.Add(FillObject(libro));
            }
            return productosDTO;
        }
    }
}
