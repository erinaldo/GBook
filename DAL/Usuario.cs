using DAL.Conexion;
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
            SelectCommandText = String.Format(GET_USERS);
            DataSet ds = Load();

            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();

            if (ds.Tables[0].Rows.Count > 0)
               usuariosDTO = _fill.FillListUsuarioDTO(ds);

            return usuariosDTO;
        }

        public Models.Usuario Login(string email)
        {
            SelectCommandText = String.Format(LOGIN, email);

            DataSet ds = Load();
            Models.Usuario usuario = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillObjectUsuarioLoginDTO(ds.Tables[0].Rows[0]);

            return usuario;
        }
        #endregion

        #region Métodos CRUD
        public int RegistrarUsuario(Models.Usuario usuario)
        {
            this.ExecuteCommandText = REGISTRAR_USUARIO;

            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parEmail", usuario.Email);
            this.ExecuteParameters.Parameters.AddWithValue("@parPassword", usuario.Password);
            this.ExecuteParameters.Parameters.AddWithValue("@parNombre", usuario.Nombre);
            this.ExecuteParameters.Parameters.AddWithValue("@parApellido", usuario.Apellido);
            this.ExecuteParameters.Parameters.AddWithValue("@parBloqueo", usuario.Bloqueo);

            return this.ExecuteNonEscalar();
        }

        public void BloquearUsuario(string email)
        {
            this.ExecuteCommandText = BLOQUEAR_USUARIO;

            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parEmail", email);
            this.executeNonQuery();
        }
        #endregion
    }
}
