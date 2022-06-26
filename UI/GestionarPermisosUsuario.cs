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
    public partial class GestionarPermisosUsuario : Form, IObserver
    {
        private readonly IPermiso _permisoService;
        private readonly IUsuario _usuarioService;
        private readonly ITraductor _traductorService;
        private readonly Servicios.Encriptacion _encriptacionService;

        private Models.DTOs.UsuarioDTO _seleccionUsuario;
        private Models.DTOs.UsuarioDTO _usuario;

        public GestionarPermisosUsuario(IPermiso permisoService, IUsuario usuarioService, ITraductor traductorService)
        {
            InitializeComponent();
            _permisoService = permisoService;
            _usuarioService = usuarioService;
            _traductorService = traductorService;
            _encriptacionService = new Servicios.Encriptacion();
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
        private void GestionarPermisosUsuario_Load(object sender, EventArgs e)
        {
            Sesion.SuscribirObservador(this);
            UpdateLanguage(Sesion.GetInstance().Idioma);
            CargarCombos();
        }

        private void CargarCombos()
        {
            cbxUsuarios.DataSource = _usuarioService.GetUsers();
            cbxUsuarios.ValueMember = "UsuarioId";
            cbxUsuarios.DisplayMember = "Email";
            cbxUsuarios.SelectedIndex = -1;

            cbxFamilias.DataSource = _permisoService.GetFamilias();
            cbxFamilias.ValueMember = "Id";
            cbxFamilias.DisplayMember = "Nombre";
            cbxFamilias.SelectedIndex = -1;

            cbxPatentes.DataSource = _permisoService.GetPatentes();
            cbxPatentes.ValueMember = "Id";
            cbxPatentes.DisplayMember = "Nombre";
            cbxPatentes.SelectedIndex = -1;
        }

        private void btnConfigurarUsuario_Click(object sender, EventArgs e)
        {
            _seleccionUsuario = (Models.DTOs.UsuarioDTO)cbxUsuarios.SelectedItem;

            _usuario = new Models.DTOs.UsuarioDTO()
            {
                UsuarioId = _seleccionUsuario.UsuarioId,
                Email = _seleccionUsuario.Email,
            };

            _permisoService.GetComponenteUsuario(_usuario);
            MostrarPermisosUsuario(_usuario);
        }

        private void MostrarPermisosUsuario(Models.DTOs.UsuarioDTO usuario)
        {
            treeAsignacionPermisos.Nodes.Clear();
            TreeNode root = new TreeNode(usuario.Email);
            foreach (var item in usuario.Permisos)
            {
                MostrarTreeUsuario(root, item);
            }
            treeAsignacionPermisos.Nodes.Add(root);
            treeAsignacionPermisos.ExpandAll();
        }

        private void MostrarTreeUsuario(TreeNode padre, Componente componente)
        {
            TreeNode hijo = new TreeNode(componente.Nombre);
            hijo.Tag = componente;
            padre.Nodes.Add(hijo);
            foreach (var item in componente.Hijos)
            {
                MostrarTreeUsuario(hijo, item);
            }
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            bool tieneFamilia = false;
            if (_usuario != null)
            {
                var familia = (Familia)cbxFamilias.SelectedItem;
                if (familia != null)
                {
                    foreach (var item in _usuario.Permisos)
                    {
                        if (_permisoService.ExisteComponente(item, familia.Id)) tieneFamilia = true;
                    }
                }

                if (tieneFamilia)
                {
                    MessageBox.Show(TraducirMensaje("msg_UsuarioFamiliaAsociada"));
                }
                else
                {
                    _permisoService.GetComponenteFamilia(familia);
                    _usuario.Permisos.Add(familia);
                    MostrarPermisosUsuario(_usuario);
                }
            }
            else
            {
                MessageBox.Show(TraducirMensaje("msg_SeleccionarUsuario"));
            }
        }

        private void btnAgregarPatente_Click(object sender, EventArgs e)
        {
            if (_usuario != null)
            {
                var patente = (Patente)cbxPatentes.SelectedItem;
                if (patente != null)
                {
                    bool tienePatente = false;
                    foreach (var item in _usuario.Permisos)
                    {
                        if (_permisoService.ExisteComponente(item, patente.Id)) tienePatente = true; break;
                    }

                    if (tienePatente)
                    {
                        MessageBox.Show(TraducirMensaje("msg_PatenteYaAsociada"));
                    }
                    else
                    {
                        _usuario.Permisos.Add(patente);
                        MostrarPermisosUsuario(_usuario);
                    }
                }
            }
        }

        private void btnGuardarFamiliaPatente_Click(object sender, EventArgs e)
        {
            try
            {
                _permisoService.GuardarPermiso(_usuario);

                MessageBox.Show(TraducirMensaje("msg_PermisosGuardadosExito"));

                treeAsignacionPermisos.Nodes.Clear();
            }
            catch
            {
                MessageBox.Show(TraducirMensaje("msg_PermisosGuardadosError"));
            }
        }

        private void GestionarPermisosUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Dispose();
        }
    }
}
