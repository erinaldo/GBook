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

        #region Métodos CRUD
        public int AltaIdioma(Models.Observer.Idioma idioma)
        {
            try
            {
                ValidarIdioma(idioma);
                return _idiomaDAL.AltaIdioma(idioma);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AltaTraduccion(Models.Observer.IIdioma idioma, Models.Observer.Traduccion traduccion)
        {
            try
            {
                ValidarIdioma(idioma);
                ValidarTraduccion(traduccion);
                return _idiomaDAL.AltaTraduccion(idioma, traduccion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public List<Models.Observer.Etiqueta> GetEtiquetas()
        {
            try
            {
                List<Models.Observer.Etiqueta> etiquetas = _idiomaDAL.GetEtiquetas();
                return etiquetas;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener las etiquetas."); }
        }

        public List<Models.Observer.Traduccion> GetTraduccionesPorIdioma(int idiomaId)
        {
            try
            {
                List<Models.Observer.Traduccion> traducciones = _idiomaDAL.GetTraduccionesPorIdioma(idiomaId);
                return traducciones;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los idiomas."); }
        }
        #endregion

        #region Tools
        private void ValidarTraduccion(Models.Observer.Traduccion traduccion)
        {
            if (string.IsNullOrWhiteSpace(traduccion.Texto)) throw new Exception("La traducción no puede estar vacía.");
        }

        private void ValidarIdioma(Models.Observer.IIdioma idioma)
        {
            if (string.IsNullOrWhiteSpace(idioma.Nombre)) throw new Exception("El idioma no puede estar vacío.");
        }
        #endregion
    }
}
