using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IEditorial
    {
        int AltaEditorial(Models.Editorial editorial);
        int ModificarEditorial(Models.Editorial editorial);
        int BajaEditorial(Models.Editorial editorial);
        List<Models.Editorial> GetEditoriales();
        Models.Editorial GetEditorial(int editorialId);
    }
}
