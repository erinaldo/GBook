using Interfaces;
using Interfaces.Composite;
using Interfaces.Observer;
using Models.Composite;
using Models.Observer;
using Servicios;
using Servicios.Observer;
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
    public partial class GestionFamiliaPatente : Form, IObserver
    {
        private readonly IPermiso _permisoService;
        private readonly ITraductor _traductorService;

        private Familia _seleccionFamilia;

        public GestionFamiliaPatente(IPermiso permisoService, ITraductor traductorService)
        {
            InitializeComponent();
            _permisoService = permisoService;
            _traductorService = traductorService;
        }

        private void GestionFamiliaPatente_Load(object sender, EventArgs e)
        {
            Sesion.SuscribirObservador(this);
            UpdateLanguage(Sesion.GetInstance().Idioma);
            CargarCombos();
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }

        private void Traducir(IIdioma idioma)
        {
            Traductor.Traducir(_traductorService, idioma, this.Controls);
        }

        private string TraducirMensaje(string msgTag)
        {
            return Traductor.TraducirMensaje(_traductorService, msgTag);
        }

        private void CargarCombos()
        {
            IList<Familia> familias = _permisoService.GetFamilias();
            IList<Familia> familiasAgregar = _permisoService.GetFamilias();
            Array permisos = _permisoService.TraerPermisos();
            IList<Patente> patentes = _permisoService.GetPatentes();

            cbxFamilia.DataSource = familias;
            cbxFamilia.ValueMember = "Id";
            cbxFamilia.DisplayMember = "Nombre";
            cbxFamilia.SelectedIndex = -1;

            cbxPatente.DataSource = permisos;
            cbxPatente.SelectedIndex = -1;

            cbxPatenteAgregar.DataSource = patentes;
            cbxPatenteAgregar.ValueMember = "Id";
            cbxPatenteAgregar.DisplayMember = "Nombre";
            cbxPatenteAgregar.SelectedIndex = -1;

            cbxFamiliaAgregar.DataSource = familiasAgregar;
            cbxFamiliaAgregar.ValueMember = "Id";
            cbxFamiliaAgregar.DisplayMember = "Nombre";
            cbxFamiliaAgregar.SelectedIndex = -1;

            Limpiar();
        }

        private void Limpiar()
        {
            txtNombreFamilia.Text = "";
            txtNombrePatente.Text = "";
            cbxFamilia.SelectedIndex = -1;
            cbxPatente.SelectedIndex = -1;
            cbxPatenteAgregar.SelectedIndex = -1;
            cbxFamiliaAgregar.SelectedIndex = -1;
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

                MessageBox.Show(TraducirMensaje("msg_FamiliaCreadaExito"));
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
                MessageBox.Show(TraducirMensaje("msg_PatenteCreadaExito"));
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
                if (tempFamilia != null)
                {
                    _seleccionFamilia = new Familia();
                    _seleccionFamilia.Id = tempFamilia.Id;
                    _seleccionFamilia.Nombre = tempFamilia.Nombre;

                    CargarTreeFamilia(true);
                }
            }
            catch
            {
                MessageBox.Show(TraducirMensaje("msg_ErrorCargarArbol"));
            }
        }

        private void CargarTreeFamilia(bool familia)
        {
            if (_seleccionFamilia == null) return;

            IList<Componente> _familia = null;
            IList<Componente> _hijo = null;

            if (familia)
            {
                _familia = _permisoService.TraerFamiliaPatentes(_seleccionFamilia.Id);
                foreach (var i in _familia)
                {
                    if (i.GetType() == typeof(Familia))
                    {
                        _seleccionFamilia.AgregarHijo(i);
                    }
                    else if (i.GetType() == typeof(Patente))
                    {
                        _hijo = _permisoService.TraerFamiliaPatentes(i.Id);
                        foreach (var j in _hijo)
                        {
                            if (_hijo.Count == 0)
                            {
                                i.AgregarHijo(j);
                            }
                        }

                        _seleccionFamilia.AgregarHijo(i);
                    }
                }
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
                MessageBox.Show(TraducirMensaje("msg_ErrorCargarArbol"));
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
                            MessageBox.Show(TraducirMensaje("msg_PatenteYaCargada"));

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
                MessageBox.Show(TraducirMensaje("msg_ErrorCargarPatente"));
            }
        }

        private void btnGuardarFamiliaModificada_Click(object sender, EventArgs e)
        {
            try
            {
                _permisoService.GuardarFamiliaCreada(_seleccionFamilia);

                treePatenteFamilia.Nodes.Clear();
                MessageBox.Show(TraducirMensaje("msg_FamiliaGuardadaExito"));
                CargarCombos();
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

                foreach (var item in familia)
                {
                    if (treePatenteFamilia.SelectedNode.Text == item.Nombre)
                    {
                        _seleccionFamilia.BorrarHijo(item);
                    }
                }

                CargarTreeFamilia(false);
            }
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (_seleccionFamilia != null)
                {
                    ValidarArbol();

                    Familia familia = (Familia)cbxFamiliaAgregar.SelectedItem;
                    var f = _permisoService.TraerFamiliaPatentes(familia.Id);
                    foreach (var item in f)
                    {
                        familia.AgregarHijo(item);
                    }

                    if (familia != null)
                    {
                        bool existeComponente = _permisoService.ExisteComponente(_seleccionFamilia, familia.Id);

                        if (existeComponente)
                            MessageBox.Show(TraducirMensaje("msg_PatenteYaCargada"));

                        else
                        {
                            IList<Componente> _familia = _permisoService.TraerFamiliaPatentes(_seleccionFamilia.Id);
                            _seleccionFamilia.AgregarHijo(familia);
                            CargarTreeFamilia(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidarArbol()
        {
            var _familia = _seleccionFamilia;
            var _familiaComparacion = _permisoService.TraerFamiliaPatentes((int)cbxFamiliaAgregar.SelectedValue);
            

            foreach (var item in _familiaComparacion)
            {
                if (item.Permiso == Permiso.EsFamilia && _familia.Permiso == Permiso.EsFamilia)
                {
                    if (item.Id == _familia.Id) throw new Exception(TraducirMensaje("msg_Recursividad"));
                }

                foreach (var item2 in _familia.Hijos)
                {
                    if (item2.Permiso == Permiso.EsFamilia && item.Permiso == Permiso.EsFamilia)
                    {
                        if (item2.Id == item.Id) throw new Exception(TraducirMensaje("msg_Recursividad"));
                    }
                }
            }

        }

        private void GestionFamiliaPatente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }
    }
}
