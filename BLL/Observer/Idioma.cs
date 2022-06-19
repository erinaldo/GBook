using Interfaces.Observer;
using Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Observer
{
    public class Idioma : ITraductor
    {
        #region Inyección de dependencias
        private readonly DAL.Observer.Idioma _idiomaDAL;

        public Idioma()
        {
            _idiomaDAL = new DAL.Observer.Idioma();
        }
        #endregion

        #region Métodos View
        public IList<IIdioma> ObtenerIdiomas()
        {
            try
            {
                IList<IIdioma> idiomas = _idiomaDAL.ObtenerIdiomas();
                
                return idiomas;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los idiomas."); }
        }

        public IIdioma ObtenerIdiomaDefault()
        {
            try
            {
                IIdioma idioma = _idiomaDAL.ObtenerIdiomaDefault();

                return idioma;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los idiomas."); }
        }

        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma)
        {
            try
            {
                IDictionary<string, ITraduccion> traducciones = _idiomaDAL.ObtenerTraducciones(idioma);

                return traducciones;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener las traducciones."); }
        }
        #endregion
    }
}
