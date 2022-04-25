using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Fill
    {
        #region Usuario
        public UsuarioLoginDTO FillObjectUsuarioLoginDTO(DataRow dr)
        {
            UsuarioLoginDTO usuario = new UsuarioLoginDTO();

            try
            {
                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    usuario.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);

                if (dr.Table.Columns.Contains("Email") && !Convert.IsDBNull(dr["Email"]))
                    usuario.Email = Convert.ToString(dr["Email"]);

                if (dr.Table.Columns.Contains("Password") && !Convert.IsDBNull(dr["Password"]))
                    usuario.Password = Convert.ToString(dr["Password"]);

                if (dr.Table.Columns.Contains("Nombre") && !Convert.IsDBNull(dr["Nombre"]))
                    usuario.Nombre = Convert.ToString(dr["Nombre"]);

                if (dr.Table.Columns.Contains("Apellido") && !Convert.IsDBNull(dr["Apellido"]))
                    usuario.Apellido = Convert.ToString(dr["Apellido"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }
            return usuario;
        }

        public UsuarioDTO FillObjectUsuarioDTO(DataRow dr)
        {
            UsuarioDTO usuario = new UsuarioDTO();

            try
            {
                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    usuario.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);

                if (dr.Table.Columns.Contains("Email") && !Convert.IsDBNull(dr["Email"]))
                    usuario.Email = Convert.ToString(dr["Email"]);

                if (dr.Table.Columns.Contains("Nombre") && !Convert.IsDBNull(dr["Nombre"]))
                    usuario.Nombre = Convert.ToString(dr["Nombre"]);

                if (dr.Table.Columns.Contains("Apellido") && !Convert.IsDBNull(dr["Apellido"]))
                    usuario.Apellido = Convert.ToString(dr["Apellido"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }
            return usuario;
        }

        public List<UsuarioDTO> FillListUsuarioDTO(DataSet ds)
        {
            return (from DataRow dr in ds.Tables[0].Rows select (new Fill()).FillObjectUsuarioDTO(dr)).ToList();
        }

        #endregion
    }
}
