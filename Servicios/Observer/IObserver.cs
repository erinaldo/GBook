using Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Observer
{
    public interface IObserver
    {
        void UpdateLanguage(IIdioma idioma);
    }
}
