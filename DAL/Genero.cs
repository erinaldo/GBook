using DAL.Conexion;
using Interfaces;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Genero : Acceso, IGenero
    {
        #region Inyección de dependencias
        private readonly Fill _fill;
        public Genero()
        {
            _fill = new Fill();
        }
        #endregion

        #region Querys
        private const string ALTA_GENERO = "INSERT INTO Genero (Nombre, Activo) OUTPUT inserted.Id VALUES (@parNombre, @parActivo)";
        private const string MODIFICAR_GENERO = "UPDATE Genero SET Nombre = @parNombre, Activo = @parActivo OUTPUT inserted.Id WHERE Id = @parId";
        private const string BAJA_GENERO = "UPDATE Genero SET Activo = false OUTPUT inserted.Id WHERE Id = @parId";
        private const string GET_GENEROS = "SELECT * FROM Genero";
        private const string GET_GENERO = "SELECT TOP 1 * FROM Genero WHERE Id = {0}";
        #endregion

        #region Métodos CRUD
        public int AltaGenero(Models.Genero genero)
        {
            try
            {
                ExecuteCommandText = ALTA_GENERO;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parNombre", genero.Nombre);
                ExecuteParameters.Parameters.AddWithValue("@parActivo", true);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int ModificarGenero(Models.Genero genero)
        {
            try
            {
                ExecuteCommandText = MODIFICAR_GENERO;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parId", genero.Id);
                ExecuteParameters.Parameters.AddWithValue("@parNombre", genero.Nombre);
                ExecuteParameters.Parameters.AddWithValue("@parActivo", true);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int BajaGenero(int id)
        {
            try
            {
                ExecuteCommandText = BAJA_GENERO;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parId", id);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Métodos View
        public List<Models.Genero> GetGeneros()
        {
            try
            {
                SelectCommandText = String.Format(GET_GENEROS);
                DataSet ds = ExecuteNonReader();

                List<Models.Genero> generos = new List<Models.Genero>();

                if (ds.Tables[0].Rows.Count > 0)
                    generos = _fill.FillListGenero(ds);

                return generos;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public Models.Genero GetGenero(int id)
        {
            try
            {
                SelectCommandText = String.Format(GET_GENERO, id);

                DataSet ds = ExecuteNonReader();
                Models.Genero genero = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillObjectGenero(ds.Tables[0].Rows[0]);

                return genero;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
    }
}
