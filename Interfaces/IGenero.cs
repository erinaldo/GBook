using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IGenero
    {
        int AltaGenero(Models.Genero genero);
        int ModificarGenero(Models.Genero genero);
        int BajaGenero(int id);
        List<Models.Genero> GetGeneros();
        Models.Genero GetGenero(int id);
    }
}
