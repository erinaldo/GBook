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
    public partial class ModificarAutor : Form, IObserver
    {
        private readonly IAutor _autorService;
        private readonly ITraductor _traductorService;
        
        public ModificarAutor(IAutor autorService, ITraductor traductorService)
        {
            _autorService = autorService;
            _traductorService = traductorService;
            InitializeComponent();
        }

        private void ModificarAutor_Load(object sender, EventArgs e)
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridAutores.CurrentRow == null) throw new Exception(TraducirMensaje("msg_AutorNoSeleccionado"));

                Models.Autor autor = new Models.Autor()
                {
                    Id = int.Parse(datagridAutores.CurrentRow.Cells[0].Value.ToString()),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Seudonimo = txtSeudonimo.Text,
                    Activo = Convert.ToBoolean(datagridAutores.CurrentRow.Cells[4].Value.ToString()),
                };

                _autorService.ModificarAutor(autor);

                CargarGridAutores();
                Limpiar();
                MessageBox.Show(TraducirMensaje("msg_AutorModificadoExito"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void datagridAutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = datagridAutores.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellido.Text = datagridAutores.CurrentRow.Cells["Apellido"].Value.ToString();
            txtSeudonimo.Text = datagridAutores.CurrentRow.Cells["Seudonimo"].Value.ToString();
        }

        private void ModificarAutor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }
    }
}
