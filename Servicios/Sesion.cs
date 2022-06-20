using Models;
using Models.DTOs;
using Models.Observer;
using Servicios.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sesion
    {      
        private static UsuarioDTO _instance = null;
        private static object _protect = new object();
        static IList<IObserver> _observers = new List<IObserver>();

        private Sesion()
        {
        }

        public static UsuarioDTO CreateInstance(UsuarioDTO user, IIdioma idioma)
        {
            // Utilizo el lock para proteger el hilo de mi instancia.
            lock (_protect)
            {
                if (_instance == null)
                {
                    _instance = user;
                    user.Idioma = idioma;
                }
            }

            return _instance;
        }

        public static UsuarioDTO GetInstance()
        {
            return _instance;
        }

        public static UsuarioDTO RemoveInstance()
        {
            return _instance = null;
        }

        public static void SuscribirObservador(IObserver o) // Para suscribirse a un idioma.
        {
            _observers.Add(o);
        }
        public static void DesuscribirObservador(IObserver o) // Para desuscribirse de un idioma.
        {
            _observers.Remove(o);
        }
        private static void Notificar(IIdioma idioma) // Actualizo el idioma del usuario.
        {
            foreach (var o in _observers)
            {
                o.UpdateLanguage(idioma);
                _instance.Idioma = idioma;
            }
        }
        public static void CambiarIdioma(IIdioma idioma) // Cambio de idioma.
        {
            Notificar(idioma);
        }
    }
}
