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
    public class Autor : Acceso, IAutor
    {
        #region Inyección de dependencias
        private readonly Fill _fill;
        public Autor()
        {
            _fill = new Fill();
        }
        #endregion

        #region Querys
        private const string ALTA_AUTOR = "INSERT INTO Autor (Nombre, Apellido, Seudonimo, Activo) OUTPUT inserted.Id VALUES (@parNombre, @parApellido, @parSeudonimo, @parActivo)";
        private const string MODIFICAR_AUTOR = "UPDATE Autor SET Nombre = @parNombre, Apellido = @parApellido, Seudonimo = @parSeudonimo, Activo = @parActivo OUTPUT inserted.Id WHERE Id = @parId";
        private const string BAJA_AUTOR = "UPDATE Autor SET Activo = false OUTPUT inserted.Id WHERE Id = @parId";
        private const string GET_AUTORES = "SELECT * FROM Autor";
        private const string GET_AUTOR = "SELECT * FROM Autor WHERE Id = {0}";
        #endregion

        #region Métodos CRUD
        public int RegistrarAutor(Models.Autor autor)
        {
            try
            {
                ExecuteCommandText = ALTA_AUTOR;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parNombre", autor.Nombre);
                ExecuteParameters.Parameters.AddWithValue("@parApellido", autor.Apellido);
                ExecuteParameters.Parameters.AddWithValue("@parSeudonimo", autor.Seudonimo);
                ExecuteParameters.Parameters.AddWithValue("@parActivo", true);                

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int ModificarAutor(Models.Autor autor)
        {
            try
            {
                ExecuteCommandText = MODIFICAR_AUTOR;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parId", autor.Id);
                ExecuteParameters.Parameters.AddWithValue("@parNombre", autor.Nombre);
                ExecuteParameters.Parameters.AddWithValue("@parApellido", autor.Apellido);
                ExecuteParameters.Parameters.AddWithValue("@parSeudonimo", autor.Seudonimo);
                ExecuteParameters.Parameters.AddWithValue("@parActivo", true);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int BajaAutor(int autorId)
        {
            try
            {
                ExecuteCommandText = BAJA_AUTOR;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parId", autorId);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Métodos View
        public List<Models.Autor> GetAutores()
        {
            try
            {
                SelectCommandText = String.Format(GET_AUTORES);
                DataSet ds = ExecuteNonReader();

                List<Models.Autor> autores = new List<Models.Autor>();

                if (ds.Tables[0].Rows.Count > 0)
                    autores = _fill.FillListAutor(ds);

                return autores;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public Models.Autor GetAutor(int autorId)
        {
            try
            {
                SelectCommandText = String.Format(GET_AUTOR, autorId);

                DataSet ds = ExecuteNonReader();
                Models.Autor autor = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillObjectAutor(ds.Tables[0].Rows[0]);

                return autor;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
    }
}
