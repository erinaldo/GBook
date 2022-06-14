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
    public partial class AltaEditorial : Form
    {
        private readonly IEditorial _editorialService;

        public AltaEditorial(IEditorial editorialService)
        {
            InitializeComponent();
            _editorialService = editorialService;
        }

        private void AltaEditorial_Load(object sender, EventArgs e)
        {
            CargarGridEditoriales();
        }

        private void CargarGridEditoriales()
        {
            datagridEditoriales.DataSource = _editorialService.GetEditoriales();
            datagridEditoriales.Columns["Id"].Visible = false;
            datagridEditoriales.Columns["Activo"].Visible = false;
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Editorial editorial = new Models.Editorial()
                {
                    Nombre = txtNombre.Text,
                };

                _editorialService.AltaEditorial(editorial);

                CargarGridEditoriales();
                Limpiar();
                MessageBox.Show("Editorial cargada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
