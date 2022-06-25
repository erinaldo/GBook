using Models.Composite;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Composite
{
    public interface IPermiso
    {
        int GuardarPatenteFamilia(Componente componente, bool familia);
        void GuardarFamiliaCreada(Familia familia);
        IList<Familia> GetFamilias();
        IList<Patente> GetPatentes();
        IList<Componente> TraerFamiliaPatentes(int familiaId);
        Array TraerPermisos();
        bool ExisteComponente(Componente componente, int Id);
        void GetComponenteUsuario(UsuarioDTO usuario);
        void GetComponenteFamilia(Familia familia);
        void GuardarPermiso(UsuarioDTO usuario);
    }
}
