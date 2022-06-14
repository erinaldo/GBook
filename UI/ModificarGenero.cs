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
    public partial class ModificarGenero : Form
    {
        private readonly IGenero _generoService;

        public ModificarGenero(IGenero generoService)
        {
            InitializeComponent();
            _generoService = generoService;
        }

        private void ModificarGenero_Load(object sender, EventArgs e)
        {
            CargarGridGeneros();
        }

        private void CargarGridGeneros()
        {
            datagridGenero.DataSource = _generoService.GetGeneros();
            datagridGenero.Columns["Id"].Visible = false;
            datagridGenero.Columns["Activo"].Visible = false;
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
                Models.Genero genero = new Models.Genero()
                {
                    Id = int.Parse(datagridGenero.CurrentRow.Cells[0].Value.ToString()),
                    Nombre = txtNombre.Text,
                    Activo = Convert.ToBoolean(datagridGenero.CurrentRow.Cells[2].Value.ToString()),
                };

                _generoService.ModificarGenero(genero);

                CargarGridGeneros();
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
