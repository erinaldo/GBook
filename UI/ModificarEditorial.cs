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
    public partial class ModificarEditorial : Form, IObserver
    {
        private readonly IEditorial _editorialService;
        private readonly ITraductor _traductorService;

        public ModificarEditorial(IEditorial editorialService, ITraductor traductorService)
        {
            InitializeComponent();
            _editorialService = editorialService;
            _traductorService = traductorService;
        }

        private void ModificarEditorial_Load(object sender, EventArgs e)
        {
            CargarGridEditoriales();

            Sesion.SuscribirObservador(this);
            UpdateLanguage(Sesion.GetInstance().Idioma);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }

        private void Traducir(IIdioma idioma)
        {
            IDictionary<string, ITraduccion> traducciones = _traductorService.ObtenerTraducciones(idioma);

            foreach (Control ctrl in this.Controls)
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

        private void datagridEditoriales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = datagridEditoriales.CurrentRow.Cells["Nombre"].Value.ToString();
        }
        private void CargarGridEditoriales()
        {
            datagridEditoriales.DataSource = _editorialService.GetEditoriales();
            datagridEditoriales.Columns["Id"].Visible = false;
            datagridEditoriales.Columns["Activo"].Visible = false;
            datagridEditoriales.ClearSelection();
            datagridEditoriales.TabStop = false;
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridEditoriales.CurrentRow == null) throw new Exception("No seleccionó ninguna editorial.");

                Models.Editorial editorial = new Models.Editorial()
                {
                    Id = int.Parse(datagridEditoriales.CurrentRow.Cells[0].Value.ToString()),
                    Nombre = txtNombre.Text,
                    Activo = Convert.ToBoolean(datagridEditoriales.CurrentRow.Cells[2].Value.ToString()),
                };

                _editorialService.ModificarEditorial(editorial);

                CargarGridEditoriales();
                Limpiar();
                MessageBox.Show("Editorial modificada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModificarEditorial_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }
    }
}
