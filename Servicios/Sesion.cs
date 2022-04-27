using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sesion
    {      
        private static Usuario _instance = null;
        private static object _protect = new object();

        private Sesion()
        {
        }

        public static Usuario CreateInstance(Usuario user)
        {
            // Utilizo el lock para proteger el hilo de mi instancia.
            lock (_protect)
            {
                if (_instance == null)
                {
                    _instance = user;
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
    }
}
