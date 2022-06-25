using Interfaces;
using Models.Composite;
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
    public partial class GestionFamiliaPatente : Form
    {
        private readonly IPermiso _permisoService;

        private Familia _seleccionFamilia;

        public GestionFamiliaPatente(IPermiso permisoService)
        {
            InitializeComponent();
            _permisoService = permisoService;
        }

        private void GestionFamiliaPatente_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            cbxFamilia.DataSource = _permisoService.GetFamilias();
            cbxFamilia.ValueMember = "Id";
            cbxFamilia.DisplayMember = "Nombre";
            cbxFamilia.SelectedIndex = -1;

            cbxPatente.DataSource = _permisoService.TraerPermisos();
            cbxPatente.SelectedIndex = -1;

            cbxPatenteAgregar.DataSource = _permisoService.GetPatentes();
            cbxPatenteAgregar.ValueMember = "Id";
            cbxPatenteAgregar.DisplayMember = "Nombre";
            cbxPatenteAgregar.SelectedIndex = -1;
        }

        private void btnGuardarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                Familia familia = new Familia()
                {
                    Nombre = txtNombreFamilia.Text,
                };

                _permisoService.GuardarPatenteFamilia(familia, true);

                MessageBox.Show("Familia creada con éxito");
                CargarCombos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardarPatente_Click(object sender, EventArgs e)
        {
            try
            {
                Patente patente = new Patente()
                {
                    Nombre = txtNombrePatente.Text,
                    Permiso = (Permiso)this.cbxPatente.SelectedItem,
                };

                _permisoService.GuardarPatenteFamilia(patente, false);
                MessageBox.Show("Patente cargada con éxito");
                CargarCombos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfigurarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                Familia tempFamilia = (Familia)cbxFamilia.SelectedItem;
                _seleccionFamilia = new Familia();
                _seleccionFamilia.Id = tempFamilia.Id;
                _seleccionFamilia.Nombre = tempFamilia.Nombre;

                CargarTreeFamilia(true);
            }
            catch
            {
                MessageBox.Show("Hubo un error al querer cargar el árbol.");
            }
        }

        private void CargarTreeFamilia(bool familia)
        {
            if (_seleccionFamilia == null) return;

            IList<Componente> _familia = null;
            if (familia)
            {
                _familia = _permisoService.TraerFamiliaPatentes(_seleccionFamilia.Id);
                foreach (var i in _familia) _seleccionFamilia.AgregarHijo(i);
            }
            else _familia = _seleccionFamilia.Hijos;

            treePatenteFamilia.Nodes.Clear();
            TreeNode root = new TreeNode(_seleccionFamilia.Nombre);
            root.Tag = _seleccionFamilia;
            treePatenteFamilia.Nodes.Add(root);

            foreach (var item in _familia)
            {
                MostrarEnTreePatenteFamilia(root, item);
            }
            treePatenteFamilia.ExpandAll();
        }

        private void MostrarEnTreePatenteFamilia(TreeNode treeNode, Componente componente)
        {
            try
            {
                TreeNode nodo = new TreeNode(componente.Nombre);
                treeNode.Tag = componente;
                treeNode.Nodes.Add(nodo);

                if (componente.Hijos != null)
                {
                    foreach (var item in componente.Hijos)
                    {
                        MostrarEnTreePatenteFamilia(nodo, item);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hubo un error al querer cargar el árbol.");
            }
        }

        private void btnAgregarPatente_Click(object sender, EventArgs e)
        {
            try
            {
                if (_seleccionFamilia != null)
                {
                    Patente patente = (Patente)cbxPatenteAgregar.SelectedItem;
                    if (patente != null)
                    {
                        bool existeComponente = _permisoService.ExisteComponente(_seleccionFamilia, patente.Id);
                        
                        if (existeComponente) 
                            MessageBox.Show("Esa patente ya está cargada.");

                        else
                        {
                            _seleccionFamilia.AgregarHijo(patente);
                            CargarTreeFamilia(false);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hubo un error al querer agregar la patente.");
            }
        }

        private void btnGuardarFamiliaModificada_Click(object sender, EventArgs e)
        {
            try
            {
                _permisoService.GuardarFamiliaCreada(_seleccionFamilia);

                treePatenteFamilia.Nodes.Clear();
                MessageBox.Show("Familia guardada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarPatente_Click(object sender, EventArgs e)
        {
            if (treePatenteFamilia.SelectedNode != null)
            {
                IList<Componente> familia;
                familia = _seleccionFamilia.Hijos;
                
                foreach (Familia item in familia)
                {
                    if (treePatenteFamilia.SelectedNode.Text == item.Nombre)
                    {
                        _seleccionFamilia.BorrarHijo(item);
                    }
                }

                CargarTreeFamilia(false);
            }
        }
    }
}
