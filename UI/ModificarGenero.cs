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
    public partial class ModificarGenero : Form, IObserver
    {
        private readonly IGenero _generoService;
        private readonly ITraductor _traductorService;

        public ModificarGenero(IGenero generoService, ITraductor traductorService)
        {
            InitializeComponent();
            _generoService = generoService;
            _traductorService = traductorService;
        }

        private void ModificarGenero_Load(object sender, EventArgs e)
        {
            CargarGridGeneros();

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

        private void CargarGridGeneros()
        {
            datagridGenero.DataSource = _generoService.GetGeneros();
            datagridGenero.Columns["Id"].Visible = false;
            datagridGenero.Columns["Activo"].Visible = false;
            datagridGenero.ClearSelection();
            datagridGenero.TabStop = false;
            datagridGenero.ReadOnly = true;
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
        }

        private void datagridGenero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = datagridGenero.CurrentRow.Cells["Nombre"].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridGenero.CurrentRow == null) throw new Exception(TraducirMensaje("msg_GeneroNoSeleccionado"));

                Models.Genero genero = new Models.Genero()
                {
                    Id = int.Parse(datagridGenero.CurrentRow.Cells[0].Value.ToString()),
                    Nombre = txtNombre.Text,
                    Activo = Convert.ToBoolean(datagridGenero.CurrentRow.Cells[2].Value.ToString()),
                };

                _generoService.ModificarGenero(genero);

                CargarGridGeneros();
                Limpiar();
                MessageBox.Show(TraducirMensaje("msg_GeneroModificadoExito"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModificarGenero_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }

        private void datagridGenero_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datagridGenero.ClearSelection();
        }
    }
}
