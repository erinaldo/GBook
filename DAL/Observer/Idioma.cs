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
        private const string ALTA_IDIOMA = "INSERT INTO Idioma OUTPUT inserted.Id VALUES (@parNombre, 0)";
        private const string GET_ETIQUETAS = "SELECT * FROM Etiqueta";
        private const string GET_ETIQUETA = "SELECT * FROM Etiqueta WHERE Id = {0}";
        private const string ALTA_TRADUCCION = "INSERT INTO Traduccion (IdiomaId, EtiquetaId, Traduccion) OUTPUT inserted.Id VALUES (@parIdiomaId, @parEtiquetaId, @parTraduccion)";
        private const string GET_TRADUCCIONES_POR_IDIOMA = "SELECT * FROM Traduccion WHERE IdiomaId = {0}";
        private const string MODIFICAR_TRADUCCION = "UPDATE Traduccion SET Traduccion = @parTraduccion OUTPUT inserted.Id " +
                                                    "WHERE Id = @parId";
        private const string GET_TRADUCCION_POR_ID = "SELECT * FROM Traduccion WHERE Id = {0}";
        #endregion

        #region Métodos CRUD
        public int AltaIdioma (Models.Observer.Idioma idioma)
        {
            try
            {
                ExecuteCommandText = ALTA_IDIOMA;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parNombre", idioma.Nombre);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int AltaTraduccion(Models.Observer.IIdioma idioma, Models.Observer.Traduccion traduccion)
        {
            try
            {
                ExecuteCommandText = ALTA_TRADUCCION;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parIdiomaId", idioma.Id);
                ExecuteParameters.Parameters.AddWithValue("@parEtiquetaId", traduccion.Etiqueta.Id);
                ExecuteParameters.Parameters.AddWithValue("@parTraduccion", traduccion.Texto);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int ModificarTraduccion(Models.Observer.Traduccion traduccion)
        {
            try
            {
                ExecuteCommandText = MODIFICAR_TRADUCCION;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parTraduccion", traduccion.Texto);
                ExecuteParameters.Parameters.AddWithValue("@parId", traduccion.Id);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
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

        public List<Models.Observer.Etiqueta> GetEtiquetas()
        {
            try
            {
                SelectCommandText = String.Format(GET_ETIQUETAS);
                DataSet ds = ExecuteNonReader();

                List<Models.Observer.Etiqueta> etiquetas = new List<Models.Observer.Etiqueta>();

                if (ds.Tables[0].Rows.Count > 0)
                    etiquetas = _fill.FillListEtiqueta(ds);

                return etiquetas;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public Models.Observer.Etiqueta GetEtiqueta(int etiquetaId)
        {
            try
            {
                SelectCommandText = String.Format(GET_ETIQUETA, etiquetaId);

                DataSet ds = ExecuteNonReader();
                Models.Observer.Etiqueta etiqueta = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillObjectEtiqueta(ds.Tables[0].Rows[0]);

                return etiqueta;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public Models.Observer.Traduccion GetTraduccionId(int traduccionId)
        {
            try
            {
                SelectCommandText = String.Format(GET_TRADUCCION_POR_ID, traduccionId);

                DataSet ds = ExecuteNonReader();
                Models.Observer.Traduccion traduccion = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillGridTraduccion(ds.Tables[0].Rows[0]);

                return traduccion;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<Models.Observer.Traduccion> GetTraduccionesPorIdioma(int idiomaId)
        {
            try
            {
                SelectCommandText = String.Format(GET_TRADUCCIONES_POR_IDIOMA, idiomaId);
                DataSet ds = ExecuteNonReader();

                List<Models.Observer.Traduccion> traducciones = new List<Models.Observer.Traduccion>();

                if (ds.Tables[0].Rows.Count > 0)
                    traducciones = _fill.FillListGridTraduccion(ds);

                return traducciones;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
    }
}
