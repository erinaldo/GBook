using DAL.Conexion;
using DAL.Tools;
using Models.DTOs;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Usuario : Acceso
    {
        #region Inyección de dependencias
        private readonly Fill _fill;
        public Usuario()
        {
            _fill = new Fill();
        }
        #endregion

        #region Querys
        private const string GET_USERS = @"SELECT * FROM Usuario";
        private const string REGISTRAR_USUARIO = @"INSERT INTO Usuario (Email, Password, Nombre, Apellido, Bloqueo) 
                                                   OUTPUT inserted.UsuarioId VALUES (@parEmail, @parPassword, @parNombre, @parApellido, @parBloqueo)";
        private const string LOGIN = @"SELECT TOP 1 * FROM Usuario WHERE Email = '{0}'";
        private const string BLOQUEAR_USUARIO = @"UPDATE Usuario SET Bloqueo = Bloqueo + 1 WHERE Email = @parEmail";
        #endregion

        #region Métodos View
        public List<UsuarioDTO> GetUsers()
        {
            try
            {
                SelectCommandText = String.Format(GET_USERS);
                DataSet ds = ExecuteNonReader();

                List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();

                if (ds.Tables[0].Rows.Count > 0)
                    usuariosDTO = _fill.FillListUsuarioDTO(ds);

                return usuariosDTO;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public Models.Usuario Login(string email)
        {
            try
            {
                SelectCommandText = String.Format(LOGIN, email);

                DataSet ds = ExecuteNonReader();
                Models.Usuario usuario = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillObjectUsuario(ds.Tables[0].Rows[0]);

                return usuario;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Métodos CRUD
        public int RegistrarUsuario(Models.Usuario usuario)
        {
            try
            {
                ExecuteCommandText = REGISTRAR_USUARIO;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parEmail", usuario.Email);
                ExecuteParameters.Parameters.AddWithValue("@parPassword", usuario.Password);
                ExecuteParameters.Parameters.AddWithValue("@parNombre", usuario.Nombre);
                ExecuteParameters.Parameters.AddWithValue("@parApellido", usuario.Apellido);
                ExecuteParameters.Parameters.AddWithValue("@parBloqueo", usuario.Bloqueo);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public void BloquearUsuario(string email)
        {
            try
            {
                ExecuteCommandText = BLOQUEAR_USUARIO;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parEmail", email);
                ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
    }
}
