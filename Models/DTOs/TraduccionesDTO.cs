using Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class TraduccionesDTO
    {
        public string Etiqueta { get; set; }
        public string Traduccion { get; set; }

        public static TraduccionesDTO FillObject(Traduccion traduccion)
        {
            return new TraduccionesDTO
            {
                Etiqueta = traduccion.Etiqueta.Nombre,
                Traduccion = traduccion.Texto
            };
        }

        public static List<TraduccionesDTO> FillListDTO(List<Traduccion> traducciones)
        {
            List<TraduccionesDTO> traduccionesDTO = new List<TraduccionesDTO>();

            if (traducciones != null)
            {
                foreach (Traduccion traduccion in traducciones)
                {
                    traduccionesDTO.Add(FillObject(traduccion));
                }
            }

            return traduccionesDTO;
        }
    }
}
