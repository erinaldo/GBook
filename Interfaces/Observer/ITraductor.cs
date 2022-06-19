using Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Observer
{
    public interface ITraductor
    {
        IList<IIdioma> ObtenerIdiomas();
        IIdioma ObtenerIdiomaDefault();
        IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma);
    }
}
