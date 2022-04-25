using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUsuario
    {
        List<UsuarioDTO> GetUsers();
        int RegistrarUsuario(UsuarioDTO usuario, string password);
        Models.Usuario Login(string email, string password);
    }
}
