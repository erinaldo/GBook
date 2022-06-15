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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogout
            // 
            this.lblLogout.AutoSize = true;
            this.lblLogout.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.lblLogout.Location = new System.Drawing.Point(661, 420);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(127, 21);
            this.lblLogout.TabIndex = 0;
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
            this.lblBienvenido.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarNegocioToolStripMenuItem,
            this.productosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            this.administrarNegocioToolStripMenuItem.Text = "Administrar negocio";
            // 
            // gestiónAutoresToolStripMenuItem
            // 
            this.gestiónAutoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaAutorToolStripMenuItem1,
            this.modificarAutorToolStripMenuItem});
            this.gestiónAutoresToolStripMenuItem.Name = "gestiónAutoresToolStripMenuItem";
            this.gestiónAutoresToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gestiónAutoresToolStripMenuItem.Text = "Gestión autores";
            // 
            // altaAutorToolStripMenuItem1
            // 
            this.altaAutorToolStripMenuItem1.Name = "altaAutorToolStripMenuItem1";
            this.altaAutorToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.altaAutorToolStripMenuItem1.Text = "Alta autor";
            this.altaAutorToolStripMenuItem1.Click += new System.EventHandler(this.altaAutorToolStripMenuItem1_Click);
            // 
            // modificarAutorToolStripMenuItem
            // 
            this.modificarAutorToolStripMenuItem.Name = "modificarAutorToolStripMenuItem";
            this.modificarAutorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
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
            this.gestiónEditorialesToolStripMenuItem.Text = "Gestión editoriales";
            // 
            // altaEditorialToolStripMenuItem
            // 
            this.altaEditorialToolStripMenuItem.Name = "altaEditorialToolStripMenuItem";
            this.altaEditorialToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.altaEditorialToolStripMenuItem.Text = "Alta editorial";
            this.altaEditorialToolStripMenuItem.Click += new System.EventHandler(this.altaEditorialToolStripMenuItem_Click);
            // 
            // modificarEditorialToolStripMenuItem
            // 
            this.modificarEditorialToolStripMenuItem.Name = "modificarEditorialToolStripMenuItem";
            this.modificarEditorialToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
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
            this.gestiónGénerosToolStripMenuItem.Text = "Gestión géneros";
            // 
            // altaGéneroToolStripMenuItem
            // 
            this.altaGéneroToolStripMenuItem.Name = "altaGéneroToolStripMenuItem";
            this.altaGéneroToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.altaGéneroToolStripMenuItem.Text = "Alta género";
            this.altaGéneroToolStripMenuItem.Click += new System.EventHandler(this.altaGéneroToolStripMenuItem_Click);
            // 
            // modificarGéneroToolStripMenuItem
            // 
            this.modificarGéneroToolStripMenuItem.Name = "modificarGéneroToolStripMenuItem";
            this.modificarGéneroToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.modificarGéneroToolStripMenuItem.Text = "Modificar género";
            this.modificarGéneroToolStripMenuItem.Click += new System.EventHandler(this.modificarGéneroToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónProductosToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // gestiónProductosToolStripMenuItem
            // 
            this.gestiónProductosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaProductoToolStripMenuItem});
            this.gestiónProductosToolStripMenuItem.Name = "gestiónProductosToolStripMenuItem";
            this.gestiónProductosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gestiónProductosToolStripMenuItem.Text = "Gestión productos";
            // 
            // altaProductoToolStripMenuItem
            // 
            this.altaProductoToolStripMenuItem.Name = "altaProductoToolStripMenuItem";
            this.altaProductoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.altaProductoToolStripMenuItem.Text = "Alta producto";
            this.altaProductoToolStripMenuItem.Click += new System.EventHandler(this.altaProductoToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblLogout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}