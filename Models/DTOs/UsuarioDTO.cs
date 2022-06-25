using Models.Composite;
using Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class UsuarioDTO
    {
        List<Componente> _permisos;
        public UsuarioDTO()
        {
            _permisos = new List<Componente>();
        }

        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public IIdioma Idioma { get; set; }
        public List<Componente> Permisos
        {
            get
            {
                return _permisos;
            }
        }
    }
}
