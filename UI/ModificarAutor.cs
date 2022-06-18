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
    public partial class ModificarAutor : Form
    {
        private readonly IAutor _autorService;
        
        public ModificarAutor(IAutor autorService)
        {
            _autorService = autorService;
            InitializeComponent();
        }

        private void ModificarAutor_Load(object sender, EventArgs e)
        {
            CargarGridAutores();
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
                if (datagridAutores.CurrentRow == null) throw new Exception("No seleccionó ningún autor.");

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
                MessageBox.Show("Autor modificado con éxito.");
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
    }
}
