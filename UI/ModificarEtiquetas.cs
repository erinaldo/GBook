using Interfaces.Observer;
using Models.DTOs;
using Models.Observer;
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
    public partial class ModificarEtiquetas : Form
    {
        private readonly ITraductor _traductorService;
        private List<TraduccionesDTO> _traducciones;

        public ModificarEtiquetas(ITraductor traductorService)
        {
            InitializeComponent();
            _traductorService = traductorService;

            _traducciones = new List<TraduccionesDTO>();            
        }

        private void ModificarEtiquetas_Load(object sender, EventArgs e)
        {
            CargarComboIdioma();
            CargarComboEtiquetas();
        }

        private void CargarComboIdioma()
        {
            cbxIdioma.DataSource = _traductorService.ObtenerIdiomas();
            cbxIdioma.ValueMember = "Id";
            cbxIdioma.DisplayMember = "Nombre";
        }

        private void CargarComboEtiquetas()
        {
            cbxEtiqueta.DataSource = _traductorService.GetEtiquetas();
            cbxEtiqueta.ValueMember = "Id";
            cbxEtiqueta.DisplayMember = "Nombre";
            cbxEtiqueta.SelectedIndex = -1;
        }

        private void cbxIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarComboEtiquetas();
            LimpiarTraduccion();

            if (cbxIdioma.SelectedIndex != -1)
            {
                IIdioma idioma = _traductorService.ObtenerIdiomas().Where(i => i.Nombre == cbxIdioma.Text).FirstOrDefault();
                CargarGridTraducciones(idioma);
            }
        }

        private void LimpiarComboEtiquetas()
        {
            cbxEtiqueta.SelectedIndex = -1;
        }

        private void LimpiarTraduccion()
        {
            txtTraduccion.Text = "";
        }
        
        private void CargarGridTraducciones(IIdioma idioma)
        {
            if (idioma != null)
            {
                _traducciones = TraduccionesDTO.FillListDTO(_traductorService.GetTraduccionesPorIdioma(idioma.Id));
                datagridTraducciones.DataSource = _traducciones;
                datagridTraducciones.ClearSelection();
                datagridTraducciones.TabStop = false;
                datagridTraducciones.ReadOnly = true;
            }
        }

        private void datagridTraducciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Traduccion traduccion = _traductorService.GetTraduccionId((int)datagridTraducciones.CurrentRow.Cells["Id"].Value);
            
            txtTraduccion.Text = traduccion.Texto;
            cbxEtiqueta.SelectedValue = traduccion.Etiqueta.Id;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxEtiqueta.SelectedValue == null) throw new Exception("Se debe seleccionar una etiqueta");

                Traduccion traduccion = _traductorService.GetTraduccionId((int)datagridTraducciones.CurrentRow.Cells["Id"].Value);
                traduccion.Texto = txtTraduccion.Text;

                _traductorService.ModificarTraduccion(traduccion);
                MessageBox.Show("Traducción modificada con éxito.");

                CargarGridTraducciones(_traductorService.ObtenerIdiomas().Where(x => x.Id == (int)cbxIdioma.SelectedValue).FirstOrDefault());
                Limpiar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Limpiar()
        {
            txtTraduccion.Text = "";
            cbxEtiqueta.SelectedIndex = -1;
        }
    }
}
