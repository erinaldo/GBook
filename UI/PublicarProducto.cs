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
    public partial class PublicarProducto : Form
    {
        private readonly IProducto _productoService;

        public PublicarProducto(IProducto productoService)
        {
            InitializeComponent();
            _productoService = productoService;
        }

        private void PublicarProducto_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            List<ProductoDTO> productos = ProductoDTO.FillListDTO(_productoService.GetProductos());
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
            txtPrecio.Text = producto.Precio.ToString();

            if (producto.EnVenta == true) cbxEnVenta.Text = "Si";
            else cbxEnVenta.Text = "No";
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Producto()
                {
                    Id = (int)datagridProductos.CurrentRow.Cells["Id"].Value,
                    Precio = Convert.ToDouble(txtPrecio.Text),
                };
                if (cbxEnVenta.Text == "Si") producto.EnVenta = true;
                else producto.EnVenta = false;

                _productoService.PublicarProducto(producto);

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
            txtPrecio.Text = "";
            cbxEnVenta.SelectedIndex = -1;
        }
    }
}
