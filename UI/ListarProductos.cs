using Interfaces;
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
    public partial class ListarProductos : Form
    {
        private readonly IProducto _productoService;

        public ListarProductos(IProducto productoService)
        {
            InitializeComponent();
            _productoService = productoService;
        }

        private void ListarProductos_Load(object sender, EventArgs e)
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

        private void datagridProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var altura = 40;
            foreach (DataGridViewRow dr in datagridProductos.Rows)
            {
                altura += dr.Height;
            }

            datagridProductos.Height = altura;
        }
    }
}
