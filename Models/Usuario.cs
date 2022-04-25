using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {

        private static Usuario _instance = null;
        private static object _protect = new object();

        private Usuario()
        {
        }

        public static Usuario CreateInstance()
        {
            // Utilizo el lock para proteger el hilo de mi instancia.
            lock (_protect)
            {
                if (_instance == null)
                {
                    _instance = new Usuario();
                }
            }

            return _instance;
        }

        public static Usuario GetInstance()
        {
            return _instance;
        }

        public static Usuario RemoveInstance()
        {
            return _instance = null;
        }

        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
