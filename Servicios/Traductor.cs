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
