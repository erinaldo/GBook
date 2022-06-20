using DAL.Conexion;
using DAL.Tools;
using Interfaces.Observer;
using Models.Observer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Observer
{
    public class Idioma : Acceso, ITraductor
    {
        #region Inyección de dependencias
        private readonly Fill _fill;
        public Idioma()
        {
            _fill = new Fill();
        }
        #endregion

        #region Querys
        private const string GET_IDIOMAS = "SELECT * FROM Idioma";
        private const string GET_TRADUCCIONES = "SELECT t.IdiomaId, t.Traduccion as traduccion_traduccion, e.Id as EtiquetaId, NombreEtiqueta as nombre_etiqueta FROM Traduccion t" +
                                                " INNER JOIN Etiqueta e on t.EtiquetaId = e.Id WHERE t.IdiomaId = {0}";
        #endregion

        #region Métodos View
        public IList<IIdioma> ObtenerIdiomas()
        {           
            try
            {
                SelectCommandText = String.Format(GET_IDIOMAS);
                DataSet ds = ExecuteNonReader();

                IList<IIdioma> _idiomas = new List<IIdioma>();

                if (ds.Tables[0].Rows.Count > 0)
                    _idiomas = _fill.FillListIdioma(ds);

                return _idiomas;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public IIdioma ObtenerIdiomaDefault()
        {
            return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();
        }

        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma)
        {
            try
            {
                //si no hay idioma definido, traigo el idioma por default (que es el español)
                if (idioma == null) idioma = ObtenerIdiomaDefault();

                IDictionary<string, ITraduccion> _traducciones = new Dictionary<string, ITraduccion>(); // Traigo las traducciones del idioma seleccionado.
                //IList<ITraduccion> _traducciones = new List<ITraduccion>();

                SelectCommandText = String.Format(GET_TRADUCCIONES, idioma.Id);
                DataSet ds = ExecuteNonReader();

                if (ds.Tables[0].Rows.Count > 0)
                    _traducciones = _fill.FillTraducciones(ds);

                return _traducciones;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
    }
}
