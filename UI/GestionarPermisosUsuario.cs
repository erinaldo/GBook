using Interfaces;
using Interfaces.Composite;
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
    public partial class GestionarPermisosUsuario : Form
    {
        private readonly IPermiso _permisoService;
        private readonly IUsuario _usuarioService;
        private readonly Servicios.Encriptacion _encriptacionService;

        private Models.DTOs.UsuarioDTO _seleccionUsuario;
        private Models.DTOs.UsuarioDTO _usuario;

        public GestionarPermisosUsuario(IPermiso permisoService, IUsuario usuarioService)
        {
            InitializeComponent();
            _permisoService = permisoService;
            _usuarioService = usuarioService;
            _encriptacionService = new Servicios.Encriptacion();
        }

        private void GestionarPermisosUsuario_Load(object sender, EventArgs e)
        {
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
                    MessageBox.Show("El usuario ya tiene esa familia asociada.");
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
                MessageBox.Show("Primero debe seleccionar un usuario.");
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
                        MessageBox.Show("El usuario ya tiene esa patente asociada.");
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

                MessageBox.Show("Permisos del usuario guardados correctamente.");

                treeAsignacionPermisos.Nodes.Clear();
            }
            catch
            {
                MessageBox.Show("Error al querer guardar los permisos del usuario.");
            }
        }
    }
}
