using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAutor
    {
        int RegistrarAutor(Models.Autor autor);
        int ModificarAutor(Models.Autor autor);
        int BajaAutor(int autorId);
        List<Models.Autor> GetAutores();
        Models.Autor GetAutor(int autorId);
    }
}
