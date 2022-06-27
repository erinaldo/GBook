using Interfaces;
using Interfaces.Composite;
using Interfaces.Observer;
using Models;
using Models.DTOs;
using Models.Observer;
using Servicios;
using Servicios.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Main : Form, IObserver
    {
        private readonly IUsuario _usuarioService;
        private readonly IAutor _autorService;
        private readonly IEditorial _editorialService;
        private readonly IGenero _generoService;
        private readonly IProducto _productoService;
        private readonly ICompra _compraService;
        private readonly IVenta _ventaService;
        private readonly ITraductor _traductorService;
        private readonly IPermiso _permisoService;

        private readonly IList<IIdioma> _idiomas;        
        
        private bool mdiChildActivo = false;

        public Main(IUsuario UsuarioService, IAutor AutorService, IEditorial editorialService, IGenero generoService, IProducto productoService, ICompra compraService, IVenta ventaService, ITraductor traductorService, IPermiso permisoService)
        {
            InitializeComponent();
            _usuarioService = UsuarioService;
            _autorService = AutorService;
            _editorialService = editorialService;
            _generoService = generoService;
            _productoService = productoService;
            _compraService = compraService;
            _ventaService = ventaService;
            _traductorService = traductorService;
            _permisoService = permisoService;

            _idiomas = new List<IIdioma>();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Sesion.DesuscribirObservador(this);
            this.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            CambiarColorMDI();

            UsuarioDTO usuario = Sesion.GetInstance();
            
            Sesion.SuscribirObservador(this);
            MostrarIdiomasDisponibles();
            UpdateLanguage(Sesion.GetInstance().Idioma);

            GenerarAlertaPedidoStock();

            timerAlerta.Interval = int.Parse(ConfigurationManager.AppSettings["Intervalo_AlertaStock"]);
            timerAlerta.Start();
        }

        private void CambiarColorMDI()
        {
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = Color.FromArgb(30, 30, 30);
                }
                catch
                {

                }
            }
        }

        private void GenerarAlertaPedidoStock()
        {
            List<Libro> productos = _productoService.GenerarAlertaPedidoStock();
            
            if (productos.Count() > 0 && productos != null && mdiChildActivo == false)
            {
                lblAlerta.Visible = true;
                datagridProductos.Visible = true;
                CargarGridProductosAlerta();
            }
            else
            {
                lblAlerta.Visible = false;
                datagridProductos.Visible = false;
            }
        }

        private void CargarGridProductosAlerta()
        {
            List<LibroAlertaDTO> productos = LibroAlertaDTO.FillListDTO(_productoService.GenerarAlertaPedidoStock());
            datagridProductos.DataSource = productos;
            datagridProductos.Columns["Id"].Visible = false;
            datagridProductos.ClearSelection();
            datagridProductos.TabStop = false;
        }

        private void OcultarControles()
        {
            datagridProductos.Visible = false;
            lblAlerta.Visible = false;
            lblBienvenido.Visible = false;
            lblLogout.Visible = false;
        }

        private void MostrarControles()
        {
            datagridProductos.Visible = true;
            lblAlerta.Visible = true;
            lblBienvenido.Visible = true;
            lblLogout.Visible = true;
        }

        private void AbrirFormLogin()
        {
            Login login = new Login(_usuarioService, _autorService, _editorialService, _generoService, _productoService, _compraService, _ventaService, _traductorService, _permisoService);
            login.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                timerAlerta.Stop();
                _usuarioService.Logout();
                AbrirFormLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void altaAutorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AltaAutor altaAutor = new AltaAutor(_autorService, _traductorService);
            altaAutor.MdiParent = this;
            altaAutor.StartPosition = FormStartPosition.CenterScreen;
            altaAutor.Show();
        }

        private void modificarAutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarAutor modificarAutor = new ModificarAutor(_autorService, _traductorService);
            modificarAutor.MdiParent = this;
            modificarAutor.StartPosition = FormStartPosition.CenterScreen;
            modificarAutor.Show();
        }

        private void altaEditorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaEditorial altaEditorial = new AltaEditorial(_editorialService, _traductorService);
            altaEditorial.MdiParent = this;
            altaEditorial.StartPosition = FormStartPosition.CenterScreen;
            altaEditorial.Show();
        }

        private void modificarEditorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarEditorial modificarEditorial = new ModificarEditorial(_editorialService, _traductorService);
            modificarEditorial.MdiParent = this;
            modificarEditorial.StartPosition = FormStartPosition.CenterScreen;
            modificarEditorial.Show();
        }

        private void altaGéneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaGenero altaGenero = new AltaGenero(_generoService, _traductorService);
            altaGenero.MdiParent = this;
            altaGenero.StartPosition = FormStartPosition.CenterScreen;
            altaGenero.Show();
        }

        private void modificarGéneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarGenero modificarGenero = new ModificarGenero(_generoService, _traductorService);
            modificarGenero.MdiParent = this;
            modificarGenero.StartPosition = FormStartPosition.CenterScreen;
            modificarGenero.Show();
        }

        private void altaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaProducto altaProducto = new AltaProducto(_productoService, _autorService, _generoService, _editorialService, _traductorService);
            altaProducto.MdiParent = this;
            altaProducto.StartPosition = FormStartPosition.CenterScreen;
            altaProducto.Show();
        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarProducto modificarProducto = new ModificarProducto(_productoService, _autorService, _generoService, _editorialService, _traductorService);
            modificarProducto.MdiParent = this;
            modificarProducto.StartPosition = FormStartPosition.CenterScreen;
            modificarProducto.Show();
        }

        private void publicarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublicarProducto publicarProducto = new PublicarProducto(_productoService, _traductorService);
            publicarProducto.MdiParent = this;
            publicarProducto.StartPosition = FormStartPosition.CenterScreen;
            publicarProducto.Show();
        }

        private void fijarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FijarProducto fijarProducto = new FijarProducto(_productoService, _traductorService);
            fijarProducto.MdiParent = this;
            fijarProducto.StartPosition = FormStartPosition.CenterScreen;
            fijarProducto.Show();
        }

        private void generarPedidoDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerarPedidoStockManual generarPedidoStockManual = new GenerarPedidoStockManual(_productoService, _compraService, _traductorService);
            generarPedidoStockManual.MdiParent = this;
            generarPedidoStockManual.StartPosition = FormStartPosition.CenterScreen;
            generarPedidoStockManual.Show();
        }

        private void recibirPedidoDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecibirPedidoStock recibirPedidoStock = new RecibirPedidoStock(_compraService, _traductorService);
            recibirPedidoStock.MdiParent = this;
            recibirPedidoStock.StartPosition = FormStartPosition.CenterScreen;
            recibirPedidoStock.Show();
        }

        private void realizarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarVenta realizarVenta = new RealizarVenta(_productoService, _ventaService, _traductorService);
            realizarVenta.MdiParent = this;
            realizarVenta.StartPosition = FormStartPosition.CenterScreen;
            realizarVenta.Show();            
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

        private void timerAlerta_Tick(object sender, EventArgs e)
        {
            GenerarAlertaPedidoStock();
        }

        private void generarPedidoStockProductosFijadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerarPedidoStockFijados generarPedidoStockFijados = new GenerarPedidoStockFijados(_productoService, _compraService, _traductorService);
            generarPedidoStockFijados.MdiParent = this;
            generarPedidoStockFijados.StartPosition = FormStartPosition.CenterScreen;
            generarPedidoStockFijados.Show();
        }

        private void listarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarProductos listarProductos = new ListarProductos(_productoService, _traductorService);
            listarProductos.MdiParent = this;
            listarProductos.StartPosition = FormStartPosition.CenterScreen;
            listarProductos.Show();
        }

        private void visualizarPedidosDeStockRealizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizarPedidosStock visualizarPedidosStock = new VisualizarPedidosStock(_compraService, _traductorService);
            visualizarPedidosStock.MdiParent = this;
            visualizarPedidosStock.StartPosition = FormStartPosition.CenterScreen;
            visualizarPedidosStock.Show();
        }

        private void visualizarVentasHistóricasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizarVentas visualizarVentas = new VisualizarVentas(_ventaService, _traductorService);
            visualizarVentas.MdiParent = this;
            visualizarVentas.StartPosition = FormStartPosition.CenterScreen;
            visualizarVentas.Show();
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
            TraducirMenu(idioma);
        }

        private void TraducirMenu(IIdioma idioma)
        {
            Traductor.TraducirMenu(_traductorService, idioma, menuStrip1);
        }
        
        private void Traducir(IIdioma idioma)
        {
            IDictionary<string, ITraduccion> traducciones = _traductorService.ObtenerTraducciones(idioma);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Tag != null && traducciones.ContainsKey(ctrl.Tag.ToString()))
                    ctrl.Text = traducciones[ctrl.Tag.ToString()].Texto;
                
                else if (ctrl.Tag != null && !traducciones.ContainsKey(ctrl.Tag.ToString()))
                    ctrl.Text = ctrl.Text = $"PLACEHOLDER_{ctrl.Tag}_NO_TRADUCTION";
                
                else ctrl.Text = ctrl.Text = "PLACEHOLDER_TAG_NOT_ASSIGNED";
            }
        }

        private void MostrarIdiomasDisponibles()
        {
            IList<IIdioma> idiomas = _traductorService.ObtenerIdiomas();
            
            foreach (IIdioma idioma in idiomas)
            {   
                _idiomas.Add(idioma);

                ToolStripMenuItem idiomaMenu = Traductor.AgregarIdiomaMenu(idioma);
                this.menuIdioma.DropDownItems.Add(idiomaMenu);

                idiomaMenu.Click += T_Click;
            }           
        }

        private void AgregarIdiomaMenu()
        {
            IList<IIdioma> idiomas = _traductorService.ObtenerIdiomas();
            List<int> idiomasId = (from idio in idiomas select idio.Id).Except(_idiomas.Select(x => x.Id)).ToList();

            if (idiomasId.Count > 0 && idiomasId != null)
            { 
                foreach (int idiomaId in idiomasId)
                {
                    IIdioma idioma = _traductorService.ObtenerIdiomas().Where(x => x.Id == idiomaId).FirstOrDefault();
                    _idiomas.Add(idioma);

                    ToolStripMenuItem idiomaMenu = Traductor.AgregarIdiomaMenu(idioma);
                    this.menuIdioma.DropDownItems.Add(idiomaMenu);

                    idiomaMenu.Click += T_Click;
                }
            }
        }

        private void T_Click(object sender, EventArgs e)
        {
            Sesion.CambiarIdioma(((IIdioma)((ToolStripMenuItem)sender).Tag));
        }

        private void Main_MdiChildActivate(object sender, EventArgs e)
        {
            Form formEvento = (Form)sender;

            if (formEvento.ActiveMdiChild == null)
            {
                MostrarControles();
                mdiChildActivo = false;
                UpdateLanguage(Sesion.GetInstance().Idioma);
                GenerarAlertaPedidoStock();
                AgregarIdiomaMenu();
            }
            else
            {
                OcultarControles();
                mdiChildActivo = true;
            }
        }

        private void altaIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaIdioma altaIdioma = new AltaIdioma(_traductorService);
            altaIdioma.MdiParent = this;
            altaIdioma.StartPosition = FormStartPosition.CenterScreen;
            altaIdioma.Show();
        }

        private void cargarEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarEtiquetas cargarEtiquetas = new CargarEtiquetas(_traductorService);
            cargarEtiquetas.MdiParent = this;
            cargarEtiquetas.StartPosition = FormStartPosition.CenterScreen;
            cargarEtiquetas.Show();
        }

        private void modificarEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarEtiquetas modificarEtiquetas = new ModificarEtiquetas(_traductorService);
            modificarEtiquetas.MdiParent = this;
            modificarEtiquetas.StartPosition = FormStartPosition.CenterScreen;
            modificarEtiquetas.Show();
        }

        private void gestiónDeFamiliaYPatenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GestionFamiliaPatente gestionFamiliaPatente = new GestionFamiliaPatente(_permisoService, _traductorService);
            gestionFamiliaPatente.MdiParent = this;
            gestionFamiliaPatente.StartPosition = FormStartPosition.CenterScreen;
            gestionFamiliaPatente.Show();
        }

        private void gestiónPermisosDeUsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GestionarPermisosUsuario gestionarPermisosUsuario = new GestionarPermisosUsuario(_permisoService, _usuarioService, _traductorService);
            gestionarPermisosUsuario.MdiParent = this;
            gestionarPermisosUsuario.StartPosition = FormStartPosition.CenterScreen;
            gestionarPermisosUsuario.Show();
        }

        private void cambiarPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarPassword cambiarPassword = new CambiarPassword(_traductorService, _usuarioService);
            cambiarPassword.MdiParent = this;
            cambiarPassword.StartPosition = FormStartPosition.CenterScreen;
            cambiarPassword.Show();
        }
    }
}
