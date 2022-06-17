using Interfaces;
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
    public partial class ModificarEditorial : Form
    {
        private readonly IEditorial _editorialService;

        public ModificarEditorial(IEditorial editorialService)
        {
            InitializeComponent();
            _editorialService = editorialService;
        }

        private void ModificarEditorial_Load(object sender, EventArgs e)
        {
            CargarGridEditoriales();
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
    }
}
