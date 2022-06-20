using Interfaces.Observer;
using Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios
{
    public class Traductor
    {
        public static void TraducirMenu(ITraductor traductorService, IIdioma idioma, MenuStrip menu)
        {
            IDictionary<string, ITraduccion> traducciones = traductorService.ObtenerTraducciones(idioma);

            foreach (ToolStripMenuItem item in menu.Items)
            {
                if (item.Tag != null && traducciones.ContainsKey(item.Tag.ToString()))
                    item.Text = traducciones[item.Tag.ToString()].Texto;
                else item.Text = $"{item.Tag}_NO_TRADUCTION";
               
                foreach (ToolStripMenuItem subItem in item.DropDownItems)
                {
                    if (subItem.Tag != null && traducciones.ContainsKey(subItem.Tag.ToString()))
                        subItem.Text = traducciones[subItem.Tag.ToString()].Texto;
                    else if (subItem.AccessibleDescription != null && subItem.AccessibleDescription.ToString() == "idioma_agregado" && !traducciones.ContainsKey(subItem.Tag.ToString())) 
                        subItem.Text = $"{subItem.Text}";
                    else subItem.Text = $"{subItem.Tag}_NO_TRADUCTION";

                    foreach (ToolStripItem subSubItem in subItem.DropDownItems)
                    {
                        if (subSubItem.Tag != null && traducciones.ContainsKey(subSubItem.Tag.ToString()))
                            subSubItem.Text = traducciones[subSubItem.Tag.ToString()].Texto;
                        else subSubItem.Text = $"{subSubItem.Tag}_NO_TRADUCTION";
                    }
                }
            }            
        }
        
        public static void Traducir(ITraductor traductorService, IIdioma idioma, Control.ControlCollection controls)
        {
            IDictionary<string, ITraduccion> traducciones = traductorService.ObtenerTraducciones(idioma);

            foreach (Control ctrl in controls)
            {
                if (ctrl.Tag != null && traducciones.ContainsKey(ctrl.Tag.ToString()))
                    ctrl.Text = traducciones[ctrl.Tag.ToString()].Texto;

                else if (ctrl.Tag != null && !traducciones.ContainsKey(ctrl.Tag.ToString()))
                    ctrl.Text = ctrl.Text = $"PLACEHOLDER_{ctrl.Tag}_NO_TRADUCTION";

                else ctrl.Text = ctrl.Text = "PLACEHOLDER_TAG_NOT_ASSIGNED";

                if (ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(ComboBox))
                {
                    ctrl.Text = "";
                }
            }
        }

        public static string TraducirMensaje(ITraductor traductorService, string msgTag)
        {
            var traducciones = traductorService.ObtenerTraducciones(Sesion.GetInstance().Idioma);
            if (traducciones.ContainsKey(msgTag)) msgTag = traducciones[msgTag].Texto;
            else msgTag = $"PLACEHOLDER_{msgTag}_NO_TRADUCTION";

            return msgTag;
        }
    }
}
