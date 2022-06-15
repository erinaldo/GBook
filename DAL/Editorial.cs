using DAL.Conexion;
using DAL.Tools;
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
    public class Editorial : Acceso, IEditorial
    {
        #region Inyección de dependencias
        private readonly Fill _fill;
        public Editorial()
        {
            _fill = new Fill();
        }
        #endregion

        #region Querys
        private const string ALTA_EDITORIAL = "INSERT INTO Editorial (Nombre, Activo) OUTPUT inserted.Id VALUES (@parNombre, @parActivo)";
        private const string MODIFICAR_EDITORIAL = "UPDATE Editorial SET Nombre = @parNombre, Activo = @parActivo OUTPUT inserted.Id WHERE Id = @parId";
        private const string BAJA_EDITORIAL = "UPDATE Editorial SET Activo = false OUTPUT inserted.Id WHERE Id = @parId";
        private const string GET_EDITORIALES = "SELECT * FROM Editorial";
        private const string GET_EDITORIAL = "SELECT TOP 1 * FROM Editorial WHERE Id = {0}";
        #endregion

        #region Métodos CRUD
        public int AltaEditorial(Models.Editorial editorial)
        {
            try
            {
                ExecuteCommandText = ALTA_EDITORIAL;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parNombre", editorial.Nombre);
                ExecuteParameters.Parameters.AddWithValue("@parActivo", true);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int ModificarEditorial(Models.Editorial editorial)
        {
            try
            {
                ExecuteCommandText = MODIFICAR_EDITORIAL;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parId", editorial.Id);
                ExecuteParameters.Parameters.AddWithValue("@parNombre", editorial.Nombre);
                ExecuteParameters.Parameters.AddWithValue("@parActivo", true);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int BajaEditorial(Models.Editorial editorial)
        {
            try
            {
                ExecuteCommandText = BAJA_EDITORIAL;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parId", editorial.Id);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Métodos View
        public List<Models.Editorial> GetEditoriales()
        {
            try
            {
                SelectCommandText = String.Format(GET_EDITORIALES);
                DataSet ds = ExecuteNonReader();

                List<Models.Editorial> editoriales = new List<Models.Editorial>();

                if (ds.Tables[0].Rows.Count > 0)
                    editoriales = _fill.FillListEditorial(ds);

                return editoriales;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public Models.Editorial GetEditorial(int editorialId)
        {
            try
            {
                SelectCommandText = String.Format(GET_EDITORIAL, editorialId);

                DataSet ds = ExecuteNonReader();
                Models.Editorial editorial = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillObjectEditorial(ds.Tables[0].Rows[0]);

                return editorial;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
    }
}
