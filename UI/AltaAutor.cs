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
    public partial class AltaAutor : Form, IObserver
    {
        private readonly IAutor _autorService;
        private readonly ITraductor _traductorService;

        public AltaAutor(IAutor autorService, ITraductor traductorService)
        {
            _autorService = autorService;
            _traductorService = traductorService;
            InitializeComponent();
        }

        private void Autor_Load(object sender, EventArgs e)
        {
            CargarGridAutores();
            
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

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Autor autor = new Models.Autor()
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Seudonimo = txtSeudonimo.Text,
                };

                _autorService.RegistrarAutor(autor);

                CargarGridAutores();
                Limpiar();
                MessageBox.Show(TraducirMensaje("msg_AutorAltaExito"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGridAutores()
        {
            datagridAutores.DataSource = _autorService.GetAutores();
            datagridAutores.Columns["Id"].Visible = false;
            datagridAutores.Columns["Activo"].Visible = false;
            datagridAutores.ClearSelection();
            datagridAutores.TabStop = false;
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtSeudonimo.Text = string.Empty;
        }

        private void AltaAutor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }
    }
}
