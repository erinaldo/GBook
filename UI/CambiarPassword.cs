using Interfaces;
using Interfaces.Observer;
using Models.Observer;
using Servicios;
using Servicios.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class CambiarPassword : Form, IObserver
    {
        private readonly ITraductor _traductorService;
        private readonly IUsuario _usuarioService;

        public CambiarPassword(ITraductor traductorService, IUsuario usuarioService)
        {
            InitializeComponent();
            _traductorService = traductorService;
            _usuarioService = usuarioService;
        }

        private void CambiarPassword_Load(object sender, EventArgs e)
        {
            Sesion.SuscribirObservador(this);
            UpdateLanguage(Sesion.GetInstance().Idioma);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }

        private void Traducir(IIdioma idioma)
        {
            Traductor.Traducir(_traductorService, idioma, this.Controls);
        }

        private string TraducirMensaje(string msgTag)
        {
            return Traductor.TraducirMensaje(_traductorService, msgTag);
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNuevaPassword.Text != txtNuevaPasswordConfirmar.Text) throw new Exception(TraducirMensaje("msg_PasswordNoCoindice"));
                _usuarioService.CambiarPassword(Sesion.GetInstance(), txtPassword.Text, txtNuevaPassword.Text);

                MessageBox.Show(TraducirMensaje("msg_PasswordCambioExito"));
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Limpiar()
        {
            txtNuevaPassword.Text = "";
            txtNuevaPasswordConfirmar.Text = "";
            txtPassword.Text = "";
        }
    }
}
