namespace UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblLogout = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarNegocioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónAutoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaAutorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarAutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónEditorialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaEditorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarEditorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónGénerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaGéneroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarGéneroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fijarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarPedidoDeStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarPedidoStockProductosFijadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recibirPedidoDeStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarPedidosDeStockRealizadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarVentasHistóricasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIdioma = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarEtiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarEtiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeFamiliaYPatenteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónPermisosDeUsuariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAlerta = new System.Windows.Forms.Label();
            this.datagridProductos = new System.Windows.Forms.DataGridView();
            this.timerAlerta = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLogout
            // 
            this.lblLogout.AutoSize = true;
            this.lblLogout.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.lblLogout.Location = new System.Drawing.Point(1201, 872);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(127, 21);
            this.lblLogout.TabIndex = 0;
            this.lblLogout.Tag = "lbl_Logout";
            this.lblLogout.Text = "Cerrar sesión";
            this.lblLogout.Click += new System.EventHandler(this.lblLogout_Click);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.lblBienvenido.Location = new System.Drawing.Point(12, 37);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(64, 21);
            this.lblBienvenido.TabIndex = 1;
            this.lblBienvenido.Tag = "lbl_Bienvenido";
            this.lblBienvenido.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarNegocioToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.compraToolStripMenuItem,
            this.ventaToolStripMenuItem,
            this.menuIdioma,
            this.seguridadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1340, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrarNegocioToolStripMenuItem
            // 
            this.administrarNegocioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónAutoresToolStripMenuItem,
            this.gestiónEditorialesToolStripMenuItem,
            this.gestiónGénerosToolStripMenuItem});
            this.administrarNegocioToolStripMenuItem.Name = "administrarNegocioToolStripMenuItem";
            this.administrarNegocioToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.administrarNegocioToolStripMenuItem.Tag = "menu_AdministrarNegocio";
            this.administrarNegocioToolStripMenuItem.Text = "Administrar negocio";
            // 
            // gestiónAutoresToolStripMenuItem
            // 
            this.gestiónAutoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaAutorToolStripMenuItem1,
            this.modificarAutorToolStripMenuItem});
            this.gestiónAutoresToolStripMenuItem.Name = "gestiónAutoresToolStripMenuItem";
            this.gestiónAutoresToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gestiónAutoresToolStripMenuItem.Tag = "menu_GestionAutores";
            this.gestiónAutoresToolStripMenuItem.Text = "Gestión autores";
            // 
            // altaAutorToolStripMenuItem1
            // 
            this.altaAutorToolStripMenuItem1.Name = "altaAutorToolStripMenuItem1";
            this.altaAutorToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.altaAutorToolStripMenuItem1.Tag = "menu_AltaAutor";
            this.altaAutorToolStripMenuItem1.Text = "Alta autor";
            this.altaAutorToolStripMenuItem1.Click += new System.EventHandler(this.altaAutorToolStripMenuItem1_Click);
            // 
            // modificarAutorToolStripMenuItem
            // 
            this.modificarAutorToolStripMenuItem.Name = "modificarAutorToolStripMenuItem";
            this.modificarAutorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.modificarAutorToolStripMenuItem.Tag = "menu_ModificarAutor";
            this.modificarAutorToolStripMenuItem.Text = "Modificar autor";
            this.modificarAutorToolStripMenuItem.Click += new System.EventHandler(this.modificarAutorToolStripMenuItem_Click);
            // 
            // gestiónEditorialesToolStripMenuItem
            // 
            this.gestiónEditorialesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaEditorialToolStripMenuItem,
            this.modificarEditorialToolStripMenuItem});
            this.gestiónEditorialesToolStripMenuItem.Name = "gestiónEditorialesToolStripMenuItem";
            this.gestiónEditorialesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gestiónEditorialesToolStripMenuItem.Tag = "menu_GestionEditoriales";
            this.gestiónEditorialesToolStripMenuItem.Text = "Gestión editoriales";
            // 
            // altaEditorialToolStripMenuItem
            // 
            this.altaEditorialToolStripMenuItem.Name = "altaEditorialToolStripMenuItem";
            this.altaEditorialToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.altaEditorialToolStripMenuItem.Tag = "menu_AltaEditorial";
            this.altaEditorialToolStripMenuItem.Text = "Alta editorial";
            this.altaEditorialToolStripMenuItem.Click += new System.EventHandler(this.altaEditorialToolStripMenuItem_Click);
            // 
            // modificarEditorialToolStripMenuItem
            // 
            this.modificarEditorialToolStripMenuItem.Name = "modificarEditorialToolStripMenuItem";
            this.modificarEditorialToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.modificarEditorialToolStripMenuItem.Tag = "menu_ModificarEditorial";
            this.modificarEditorialToolStripMenuItem.Text = "Modificar editorial";
            this.modificarEditorialToolStripMenuItem.Click += new System.EventHandler(this.modificarEditorialToolStripMenuItem_Click);
            // 
            // gestiónGénerosToolStripMenuItem
            // 
            this.gestiónGénerosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaGéneroToolStripMenuItem,
            this.modificarGéneroToolStripMenuItem});
            this.gestiónGénerosToolStripMenuItem.Name = "gestiónGénerosToolStripMenuItem";
            this.gestiónGénerosToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gestiónGénerosToolStripMenuItem.Tag = "menu_GestionGeneros";
            this.gestiónGénerosToolStripMenuItem.Text = "Gestión géneros";
            // 
            // altaGéneroToolStripMenuItem
            // 
            this.altaGéneroToolStripMenuItem.Name = "altaGéneroToolStripMenuItem";
            this.altaGéneroToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.altaGéneroToolStripMenuItem.Tag = "menu_AltaGenero";
            this.altaGéneroToolStripMenuItem.Text = "Alta género";
            this.altaGéneroToolStripMenuItem.Click += new System.EventHandler(this.altaGéneroToolStripMenuItem_Click);
            // 
            // modificarGéneroToolStripMenuItem
            // 
            this.modificarGéneroToolStripMenuItem.Name = "modificarGéneroToolStripMenuItem";
            this.modificarGéneroToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.modificarGéneroToolStripMenuItem.Tag = "menu_ModificarGenero";
            this.modificarGéneroToolStripMenuItem.Text = "Modificar género";
            this.modificarGéneroToolStripMenuItem.Click += new System.EventHandler(this.modificarGéneroToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónProductosToolStripMenuItem,
            this.listarProductosToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Tag = "menu_Producto";
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // gestiónProductosToolStripMenuItem
            // 
            this.gestiónProductosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaProductoToolStripMenuItem,
            this.modificarProductoToolStripMenuItem,
            this.publicarProductoToolStripMenuItem,
            this.fijarProductoToolStripMenuItem});
            this.gestiónProductosToolStripMenuItem.Name = "gestiónProductosToolStripMenuItem";
            this.gestiónProductosToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gestiónProductosToolStripMenuItem.Tag = "menu_GestionProductos";
            this.gestiónProductosToolStripMenuItem.Text = "Gestión productos";
            // 
            // altaProductoToolStripMenuItem
            // 
            this.altaProductoToolStripMenuItem.Name = "altaProductoToolStripMenuItem";
            this.altaProductoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.altaProductoToolStripMenuItem.Tag = "menu_AltaProducto";
            this.altaProductoToolStripMenuItem.Text = "Alta producto";
            this.altaProductoToolStripMenuItem.Click += new System.EventHandler(this.altaProductoToolStripMenuItem_Click);
            // 
            // modificarProductoToolStripMenuItem
            // 
            this.modificarProductoToolStripMenuItem.Name = "modificarProductoToolStripMenuItem";
            this.modificarProductoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.modificarProductoToolStripMenuItem.Tag = "menu_ModificarProducto";
            this.modificarProductoToolStripMenuItem.Text = "Modificar producto";
            this.modificarProductoToolStripMenuItem.Click += new System.EventHandler(this.modificarProductoToolStripMenuItem_Click);
            // 
            // publicarProductoToolStripMenuItem
            // 
            this.publicarProductoToolStripMenuItem.Name = "publicarProductoToolStripMenuItem";
            this.publicarProductoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.publicarProductoToolStripMenuItem.Tag = "menu_PublicarProducto";
            this.publicarProductoToolStripMenuItem.Text = "Publicar producto";
            this.publicarProductoToolStripMenuItem.Click += new System.EventHandler(this.publicarProductoToolStripMenuItem_Click);
            // 
            // fijarProductoToolStripMenuItem
            // 
            this.fijarProductoToolStripMenuItem.Name = "fijarProductoToolStripMenuItem";
            this.fijarProductoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.fijarProductoToolStripMenuItem.Tag = "menu_FijarProducto";
            this.fijarProductoToolStripMenuItem.Text = "Fijar producto";
            this.fijarProductoToolStripMenuItem.Click += new System.EventHandler(this.fijarProductoToolStripMenuItem_Click);
            // 
            // listarProductosToolStripMenuItem
            // 
            this.listarProductosToolStripMenuItem.Name = "listarProductosToolStripMenuItem";
            this.listarProductosToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.listarProductosToolStripMenuItem.Tag = "menu_ListarProductos";
            this.listarProductosToolStripMenuItem.Text = "Listar productos";
            this.listarProductosToolStripMenuItem.Click += new System.EventHandler(this.listarProductosToolStripMenuItem_Click);
            // 
            // compraToolStripMenuItem
            // 
            this.compraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarPedidoDeStockToolStripMenuItem,
            this.generarPedidoStockProductosFijadosToolStripMenuItem,
            this.recibirPedidoDeStockToolStripMenuItem,
            this.visualizarPedidosDeStockRealizadosToolStripMenuItem});
            this.compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            this.compraToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.compraToolStripMenuItem.Tag = "menu_Compra";
            this.compraToolStripMenuItem.Text = "Compra";
            // 
            // generarPedidoDeStockToolStripMenuItem
            // 
            this.generarPedidoDeStockToolStripMenuItem.Name = "generarPedidoDeStockToolStripMenuItem";
            this.generarPedidoDeStockToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.generarPedidoDeStockToolStripMenuItem.Tag = "menu_GenerarPedidoStock";
            this.generarPedidoDeStockToolStripMenuItem.Text = "Generar pedido de stock";
            this.generarPedidoDeStockToolStripMenuItem.Click += new System.EventHandler(this.generarPedidoDeStockToolStripMenuItem_Click);
            // 
            // generarPedidoStockProductosFijadosToolStripMenuItem
            // 
            this.generarPedidoStockProductosFijadosToolStripMenuItem.Name = "generarPedidoStockProductosFijadosToolStripMenuItem";
            this.generarPedidoStockProductosFijadosToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.generarPedidoStockProductosFijadosToolStripMenuItem.Tag = "menu_GenerarPedidoStockFijados";
            this.generarPedidoStockProductosFijadosToolStripMenuItem.Text = "Generar pedido stock productos fijados";
            this.generarPedidoStockProductosFijadosToolStripMenuItem.Click += new System.EventHandler(this.generarPedidoStockProductosFijadosToolStripMenuItem_Click);
            // 
            // recibirPedidoDeStockToolStripMenuItem
            // 
            this.recibirPedidoDeStockToolStripMenuItem.Name = "recibirPedidoDeStockToolStripMenuItem";
            this.recibirPedidoDeStockToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.recibirPedidoDeStockToolStripMenuItem.Tag = "menu_RecibirPedidoStock";
            this.recibirPedidoDeStockToolStripMenuItem.Text = "Recibir pedido de stock";
            this.recibirPedidoDeStockToolStripMenuItem.Click += new System.EventHandler(this.recibirPedidoDeStockToolStripMenuItem_Click);
            // 
            // visualizarPedidosDeStockRealizadosToolStripMenuItem
            // 
            this.visualizarPedidosDeStockRealizadosToolStripMenuItem.Name = "visualizarPedidosDeStockRealizadosToolStripMenuItem";
            this.visualizarPedidosDeStockRealizadosToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.visualizarPedidosDeStockRealizadosToolStripMenuItem.Tag = "menu_VisualizarPedidosStock";
            this.visualizarPedidosDeStockRealizadosToolStripMenuItem.Text = "Visualizar pedidos de stock realizados";
            this.visualizarPedidosDeStockRealizadosToolStripMenuItem.Click += new System.EventHandler(this.visualizarPedidosDeStockRealizadosToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realizarVentaToolStripMenuItem,
            this.visualizarVentasHistóricasToolStripMenuItem});
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ventaToolStripMenuItem.Tag = "menu_Venta";
            this.ventaToolStripMenuItem.Text = "Venta";
            // 
            // realizarVentaToolStripMenuItem
            // 
            this.realizarVentaToolStripMenuItem.Name = "realizarVentaToolStripMenuItem";
            this.realizarVentaToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.realizarVentaToolStripMenuItem.Tag = "menu_RealizarVenta";
            this.realizarVentaToolStripMenuItem.Text = "Realizar venta";
            this.realizarVentaToolStripMenuItem.Click += new System.EventHandler(this.realizarVentaToolStripMenuItem_Click);
            // 
            // visualizarVentasHistóricasToolStripMenuItem
            // 
            this.visualizarVentasHistóricasToolStripMenuItem.Name = "visualizarVentasHistóricasToolStripMenuItem";
            this.visualizarVentasHistóricasToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.visualizarVentasHistóricasToolStripMenuItem.Tag = "menu_VisualizarVentas";
            this.visualizarVentasHistóricasToolStripMenuItem.Text = "Visualizar ventas históricas";
            this.visualizarVentasHistóricasToolStripMenuItem.Click += new System.EventHandler(this.visualizarVentasHistóricasToolStripMenuItem_Click);
            // 
            // menuIdioma
            // 
            this.menuIdioma.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónIdiomaToolStripMenuItem});
            this.menuIdioma.Name = "menuIdioma";
            this.menuIdioma.Size = new System.Drawing.Size(56, 20);
            this.menuIdioma.Tag = "menu_Idioma";
            this.menuIdioma.Text = "Idioma";
            // 
            // gestiónIdiomaToolStripMenuItem
            // 
            this.gestiónIdiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaIdiomaToolStripMenuItem,
            this.cargarEtiquetasToolStripMenuItem,
            this.modificarEtiquetasToolStripMenuItem});
            this.gestiónIdiomaToolStripMenuItem.Name = "gestiónIdiomaToolStripMenuItem";
            this.gestiónIdiomaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.gestiónIdiomaToolStripMenuItem.Tag = "menu_GestionIdioma";
            this.gestiónIdiomaToolStripMenuItem.Text = "Gestión idioma";
            // 
            // altaIdiomaToolStripMenuItem
            // 
            this.altaIdiomaToolStripMenuItem.Name = "altaIdiomaToolStripMenuItem";
            this.altaIdiomaToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.altaIdiomaToolStripMenuItem.Tag = "menu_AltaIdioma";
            this.altaIdiomaToolStripMenuItem.Text = "Alta idioma";
            this.altaIdiomaToolStripMenuItem.Click += new System.EventHandler(this.altaIdiomaToolStripMenuItem_Click);
            // 
            // cargarEtiquetasToolStripMenuItem
            // 
            this.cargarEtiquetasToolStripMenuItem.Name = "cargarEtiquetasToolStripMenuItem";
            this.cargarEtiquetasToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.cargarEtiquetasToolStripMenuItem.Tag = "menu_CargarEtiquetas";
            this.cargarEtiquetasToolStripMenuItem.Text = "Cargar etiquetas";
            this.cargarEtiquetasToolStripMenuItem.Click += new System.EventHandler(this.cargarEtiquetasToolStripMenuItem_Click);
            // 
            // modificarEtiquetasToolStripMenuItem
            // 
            this.modificarEtiquetasToolStripMenuItem.Name = "modificarEtiquetasToolStripMenuItem";
            this.modificarEtiquetasToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.modificarEtiquetasToolStripMenuItem.Tag = "menu_ModificarEtiquetas";
            this.modificarEtiquetasToolStripMenuItem.Text = "Modificar etiquetas";
            this.modificarEtiquetasToolStripMenuItem.Click += new System.EventHandler(this.modificarEtiquetasToolStripMenuItem_Click);
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.permisosToolStripMenuItem,
            this.cambiarPasswordToolStripMenuItem});
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.seguridadToolStripMenuItem.Tag = "menu_Seguridad";
            this.seguridadToolStripMenuItem.Text = "Seguridad";
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDeFamiliaYPatenteToolStripMenuItem1,
            this.gestiónPermisosDeUsuariosToolStripMenuItem1});
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.permisosToolStripMenuItem.Tag = "menu_Permisos";
            this.permisosToolStripMenuItem.Text = "Permisos";
            // 
            // gestiónDeFamiliaYPatenteToolStripMenuItem1
            // 
            this.gestiónDeFamiliaYPatenteToolStripMenuItem1.Name = "gestiónDeFamiliaYPatenteToolStripMenuItem1";
            this.gestiónDeFamiliaYPatenteToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.gestiónDeFamiliaYPatenteToolStripMenuItem1.Tag = "menu_GestionFamiliaPatente";
            this.gestiónDeFamiliaYPatenteToolStripMenuItem1.Text = "Gestión de familia y patente";
            this.gestiónDeFamiliaYPatenteToolStripMenuItem1.Click += new System.EventHandler(this.gestiónDeFamiliaYPatenteToolStripMenuItem1_Click);
            // 
            // gestiónPermisosDeUsuariosToolStripMenuItem1
            // 
            this.gestiónPermisosDeUsuariosToolStripMenuItem1.Name = "gestiónPermisosDeUsuariosToolStripMenuItem1";
            this.gestiónPermisosDeUsuariosToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.gestiónPermisosDeUsuariosToolStripMenuItem1.Tag = "menu_GestionPermisosUsuarios";
            this.gestiónPermisosDeUsuariosToolStripMenuItem1.Text = "Gestión permisos de usuarios";
            this.gestiónPermisosDeUsuariosToolStripMenuItem1.Click += new System.EventHandler(this.gestiónPermisosDeUsuariosToolStripMenuItem1_Click);
            // 
            // cambiarPasswordToolStripMenuItem
            // 
            this.cambiarPasswordToolStripMenuItem.Name = "cambiarPasswordToolStripMenuItem";
            this.cambiarPasswordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarPasswordToolStripMenuItem.Tag = "menu_CambiarPassword";
            this.cambiarPasswordToolStripMenuItem.Text = "Cambiar password";
            this.cambiarPasswordToolStripMenuItem.Click += new System.EventHandler(this.cambiarPasswordToolStripMenuItem_Click);
            // 
            // lblAlerta
            // 
            this.lblAlerta.AutoSize = true;
            this.lblAlerta.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlerta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.lblAlerta.Location = new System.Drawing.Point(12, 84);
            this.lblAlerta.Name = "lblAlerta";
            this.lblAlerta.Size = new System.Drawing.Size(64, 21);
            this.lblAlerta.TabIndex = 3;
            this.lblAlerta.Tag = "lbl_AlertaPedidoStock";
            this.lblAlerta.Text = "label1";
            this.lblAlerta.Visible = false;
            // 
            // datagridProductos
            // 
            this.datagridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagridProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.datagridProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridProductos.Location = new System.Drawing.Point(12, 108);
            this.datagridProductos.Name = "datagridProductos";
            this.datagridProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.datagridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridProductos.Size = new System.Drawing.Size(1218, 278);
            this.datagridProductos.TabIndex = 106;
            this.datagridProductos.Visible = false;
            this.datagridProductos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.datagridProductos_DataBindingComplete);
            // 
            // timerAlerta
            // 
            this.timerAlerta.Interval = 999999999;
            this.timerAlerta.Tick += new System.EventHandler(this.timerAlerta_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1340, 902);
            this.Controls.Add(this.datagridProductos);
            this.Controls.Add(this.lblAlerta);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblLogout);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GBook - Menú principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.MdiChildActivate += new System.EventHandler(this.Main_MdiChildActivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarNegocioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónAutoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaAutorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificarAutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónEditorialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaEditorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarEditorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónGénerosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaGéneroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarGéneroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fijarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarPedidoDeStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recibirPedidoDeStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizarVentaToolStripMenuItem;
        private System.Windows.Forms.Label lblAlerta;
        private System.Windows.Forms.DataGridView datagridProductos;
        private System.Windows.Forms.Timer timerAlerta;
        private System.Windows.Forms.ToolStripMenuItem generarPedidoStockProductosFijadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarPedidosDeStockRealizadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarVentasHistóricasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuIdioma;
        private System.Windows.Forms.ToolStripMenuItem gestiónIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarEtiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarEtiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeFamiliaYPatenteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gestiónPermisosDeUsuariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cambiarPasswordToolStripMenuItem;
    }
}