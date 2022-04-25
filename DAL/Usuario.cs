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
        #region Querys
        private const string GET_USERS = @"SELECT * FROM Usuario";
        private const string REGISTRAR_USUARIO = @"INSERT INTO Usuario (Email, Password, Nombre, Apellido) 
                                                   OUTPUT inserted.UsuarioId VALUES (@parEmail, @parPassword, @parNombre, @parApellido)";
        private const string LOGIN = @"SELECT TOP 1 * FROM Usuario WHERE Email = '{0}'";
        #endregion

        Fill fill = new Fill();

        #region Métodos View
        public List<UsuarioDTO> GetUsers()
        {
            SelectCommandText = String.Format(GET_USERS);
            DataSet ds = Load();

            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();

            if (ds.Tables[0].Rows.Count > 0)
               usuariosDTO = fill.FillListUsuarioDTO(ds);

            return usuariosDTO;
        }

        public Models.Usuario Login(string email)
        {
            SelectCommandText = String.Format(LOGIN, email);

            DataSet ds = Load();
            Models.Usuario usuario = ds.Tables[0].Rows.Count <= 0 ? null : fill.FillObjectUsuarioLoginDTO(ds.Tables[0].Rows[0]);

            return usuario;
        }
        #endregion

        #region Métodos CRUD
        public int RegistrarUsuario(UsuarioDTO usuario, string password)
        {
            this.ExecuteCommandText = REGISTRAR_USUARIO;

            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parEmail", usuario.Email);
            this.ExecuteParameters.Parameters.AddWithValue("@parPassword", password);
            this.ExecuteParameters.Parameters.AddWithValue("@parNombre", usuario.Nombre);
            this.ExecuteParameters.Parameters.AddWithValue("@parApellido", usuario.Apellido);

            return this.ExecuteNonEscalar();
        }
        #endregion
    }
}
