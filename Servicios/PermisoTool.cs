using Models.Composite;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios
{
    public class PermisoTool
    {
        public static bool TienePermiso(UsuarioDTO usuario, Models.Composite.Permiso permiso)
        {
            bool existePermiso = false;
            
            foreach (Componente item in usuario.Permisos)
            {
                if (item.Permiso.Equals(permiso)) return true;

                else
                {
                    existePermiso = EstaPermisoEnFamilia(item, permiso, existePermiso);
                    if (existePermiso) return true;
                }

            }

            return existePermiso;
        }

        private static bool EstaPermisoEnFamilia(Componente c, Models.Composite.Permiso permiso, bool existePermiso)
        {
            if (c.Permiso.Equals(permiso)) existePermiso = true;

            else
            {
                foreach (var item in c.Hijos)
                {
                    existePermiso = EstaPermisoEnFamilia(item, permiso, existePermiso);
                    if (existePermiso) return true;
                }
            }

            return existePermiso;
        }

        public static void HabilitarMenu(UsuarioDTO usuario, ToolStripMenuItem menu)
        {
            foreach (ToolStripMenuItem item in menu.DropDownItems)
            {
                string Nombre = item.Tag.ToString().Replace("menu_", "");
                Models.Composite.Permiso nom = (Models.Composite.Permiso)Enum.Parse(typeof(Models.Composite.Permiso), Nombre);

                item.Enabled = Servicios.PermisoTool.TienePermiso(usuario, nom);
            }
        }
    }
}
