using Interfaces.Observer;
using Models.DTOs;
using Models.Observer;
using Servicios;
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
    public partial class CargarEtiquetas : Form
    {
        private readonly ITraductor _traductorService;
        private List<TraduccionesDTO> _traducciones;

        public CargarEtiquetas(ITraductor traductorService)
        {
            InitializeComponent();
            _traductorService = traductorService;

            _traducciones = new List<TraduccionesDTO>();
        }

        private void CargarEtiquetas_Load(object sender, EventArgs e)
        {
            CargarComboEtiquetas();
            CargarComboIdioma();
        }

        private void CargarComboEtiquetas()
        {
            cbxEtiqueta.DataSource = _traductorService.GetEtiquetas();
            cbxEtiqueta.ValueMember = "Id";
            cbxEtiqueta.DisplayMember = "Nombre";
            cbxEtiqueta.SelectedIndex = -1;
        }

        private void CargarComboIdioma()
        {
            cbxIdioma.DataSource = _traductorService.ObtenerIdiomas();
            cbxIdioma.ValueMember = "Id";
            cbxIdioma.DisplayMember = "Nombre";
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

        private void cbxIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIdioma.SelectedIndex != -1)
            {
                IIdioma idioma = _traductorService.ObtenerIdiomas().Where(i => i.Nombre == cbxIdioma.Text).FirstOrDefault();
                CargarGridTraducciones(idioma);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxEtiqueta.SelectedValue == null) throw new Exception("Se debe elegir una etiqueta");
                if (string.IsNullOrWhiteSpace(txtTraduccion.Text)) throw new Exception("Se debe completar la traducción");

                foreach (var item in _traducciones)
                {
                    if (item.Etiqueta == cbxEtiqueta.Text)
                    {
                        Limpiar();
                        throw new Exception("Esa traducción ya está cargada.");
                    }
                }

                IIdioma idioma = _traductorService.ObtenerIdiomas().Where(x => x.Id == (int)cbxIdioma.SelectedValue).FirstOrDefault();
                Etiqueta etiqueta = _traductorService.GetEtiquetas().Where(x => x.Id == (int)cbxEtiqueta.SelectedValue).FirstOrDefault();

                Traduccion traduccion = new Traduccion()
                {
                    Etiqueta = etiqueta,
                    Texto = txtTraduccion.Text,
                };

                _traductorService.AltaTraduccion(idioma, traduccion);
                MessageBox.Show("Traducción cargada con éxito.");
                CargarGridTraducciones(idioma);
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Limpiar()
        {
            txtTraduccion.Text = "";
        }
    }
}
