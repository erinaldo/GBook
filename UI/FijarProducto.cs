using Interfaces;
using Models;
using Models.DTOs;
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
    public partial class FijarProducto : Form
    {
        private readonly IProducto _productoService;

        public FijarProducto(IProducto productoService)
        {
            InitializeComponent();
            _productoService = productoService;
        }

        private void FijarProducto_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            List<ProductoAlertaDTO> productos = ProductoAlertaDTO.FillListDTO(_productoService.GetProductos());
            datagridProductos.DataSource = productos;
            datagridProductos.Columns["Id"].Visible = false;
            datagridProductos.ClearSelection();
            datagridProductos.TabStop = false;
        }

        private void datagridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto producto = _productoService.GetProducto((int)datagridProductos.CurrentRow.Cells["Id"].Value);
            txtISBN.Text = producto.ISBN;
            txtNombre.Text = producto.Nombre;
            txtCantidadStockAviso.Text = producto.Alerta.CantidadStockAviso.ToString();

            if (producto.Alerta.Activo == true) cbxActivo.Text = "Si";
            else cbxActivo.Text = "No";
        }

        private void btnFijar_Click(object sender, EventArgs e)
        {
            try
            {
                Alerta alerta = new Alerta()
                {
                    CantidadStockAviso = int.Parse(txtCantidadStockAviso.Text),
                    Activo = cbxActivo.Text == "Si" ? true : false,
                };
                Producto producto = new Producto()
                {
                    Id = (int)datagridProductos.CurrentRow.Cells["Id"].Value,
                    Alerta = alerta
                };

                _productoService.FijarProducto(producto);

                CargarProductos();
                Limpiar();
                MessageBox.Show("Producto publicado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Limpiar()
        {
            txtISBN.Text = "";
            txtNombre.Text = "";
            cbxActivo.SelectedIndex = -1;
        }
    }
}
