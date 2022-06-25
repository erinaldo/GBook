using Models.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
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
    }
}
