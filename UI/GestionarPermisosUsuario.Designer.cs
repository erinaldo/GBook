namespace UI
{
    partial class GestionarPermisosUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarPermisosUsuario));
            this.cbxUsuarios = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConfigurarUsuario = new System.Windows.Forms.Button();
            this.btnAgregarFamilia = new System.Windows.Forms.Button();
            this.cbxFamilias = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarPatente = new System.Windows.Forms.Button();
            this.cbxPatentes = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.treeAsignacionPermisos = new System.Windows.Forms.TreeView();
            this.btnGuardarFamiliaPatente = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxUsuarios
            // 
            this.cbxUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxUsuarios.ForeColor = System.Drawing.Color.White;
            this.cbxUsuarios.FormattingEnabled = true;
            this.cbxUsuarios.Location = new System.Drawing.Point(12, 57);
            this.cbxUsuarios.Name = "cbxUsuarios";
            this.cbxUsuarios.Size = new System.Drawing.Size(216, 21);
            this.cbxUsuarios.TabIndex = 54;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.ForeColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(12, 80);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(216, 1);
            this.panel5.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label5.Location = new System.Drawing.Point(8, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 52;
            this.label5.Tag = "lbl_PermisoUsuario";
            this.label5.Text = "Usuario";
            // 
            // btnConfigurarUsuario
            // 
            this.btnConfigurarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnConfigurarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfigurarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigurarUsuario.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigurarUsuario.Location = new System.Drawing.Point(53, 87);
            this.btnConfigurarUsuario.Name = "btnConfigurarUsuario";
            this.btnConfigurarUsuario.Size = new System.Drawing.Size(114, 41);
            this.btnConfigurarUsuario.TabIndex = 55;
            this.btnConfigurarUsuario.Tag = "btn_ConfigurarUsuario";
            this.btnConfigurarUsuario.Text = "Configurar";
            this.btnConfigurarUsuario.UseVisualStyleBackColor = false;
            this.btnConfigurarUsuario.Click += new System.EventHandler(this.btnConfigurarUsuario_Click);
            // 
            // btnAgregarFamilia
            // 
            this.btnAgregarFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnAgregarFamilia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAgregarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarFamilia.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarFamilia.Location = new System.Drawing.Point(53, 218);
            this.btnAgregarFamilia.Name = "btnAgregarFamilia";
            this.btnAgregarFamilia.Size = new System.Drawing.Size(114, 41);
            this.btnAgregarFamilia.TabIndex = 59;
            this.btnAgregarFamilia.Tag = "btn_AgregarFamilia";
            this.btnAgregarFamilia.Text = "Agregar";
            this.btnAgregarFamilia.UseVisualStyleBackColor = false;
            this.btnAgregarFamilia.Click += new System.EventHandler(this.btnAgregarFamilia_Click);
            // 
            // cbxFamilias
            // 
            this.cbxFamilias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFamilias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFamilias.ForeColor = System.Drawing.Color.White;
            this.cbxFamilias.FormattingEnabled = true;
            this.cbxFamilias.Location = new System.Drawing.Point(12, 188);
            this.cbxFamilias.Name = "cbxFamilias";
            this.cbxFamilias.Size = new System.Drawing.Size(216, 21);
            this.cbxFamilias.TabIndex = 58;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 1);
            this.panel1.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(8, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 56;
            this.label1.Tag = "lbl_NombreFamilia";
            this.label1.Text = "Familia";
            // 
            // btnAgregarPatente
            // 
            this.btnAgregarPatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnAgregarPatente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAgregarPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPatente.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPatente.Location = new System.Drawing.Point(53, 343);
            this.btnAgregarPatente.Name = "btnAgregarPatente";
            this.btnAgregarPatente.Size = new System.Drawing.Size(114, 41);
            this.btnAgregarPatente.TabIndex = 63;
            this.btnAgregarPatente.Tag = "btn_AgregarPatente";
            this.btnAgregarPatente.Text = "Agregar";
            this.btnAgregarPatente.UseVisualStyleBackColor = false;
            this.btnAgregarPatente.Click += new System.EventHandler(this.btnAgregarPatente_Click);
            // 
            // cbxPatentes
            // 
            this.cbxPatentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxPatentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPatentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPatentes.ForeColor = System.Drawing.Color.White;
            this.cbxPatentes.FormattingEnabled = true;
            this.cbxPatentes.Location = new System.Drawing.Point(12, 313);
            this.cbxPatentes.Name = "cbxPatentes";
            this.cbxPatentes.Size = new System.Drawing.Size(216, 21);
            this.cbxPatentes.TabIndex = 62;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(12, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 1);
            this.panel2.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label2.Location = new System.Drawing.Point(8, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 60;
            this.label2.Tag = "lbl_Patente";
            this.label2.Text = "Patente";
            // 
            // treeAsignacionPermisos
            // 
            this.treeAsignacionPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeAsignacionPermisos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeAsignacionPermisos.ForeColor = System.Drawing.Color.White;
            this.treeAsignacionPermisos.Location = new System.Drawing.Point(296, 30);
            this.treeAsignacionPermisos.Name = "treeAsignacionPermisos";
            this.treeAsignacionPermisos.Size = new System.Drawing.Size(492, 325);
            this.treeAsignacionPermisos.TabIndex = 64;
            // 
            // btnGuardarFamiliaPatente
            // 
            this.btnGuardarFamiliaPatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnGuardarFamiliaPatente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardarFamiliaPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarFamiliaPatente.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarFamiliaPatente.Location = new System.Drawing.Point(421, 361);
            this.btnGuardarFamiliaPatente.Name = "btnGuardarFamiliaPatente";
            this.btnGuardarFamiliaPatente.Size = new System.Drawing.Size(114, 41);
            this.btnGuardarFamiliaPatente.TabIndex = 65;
            this.btnGuardarFamiliaPatente.Tag = "btn_GuardarFamiliaPatente";
            this.btnGuardarFamiliaPatente.Text = "Guardar";
            this.btnGuardarFamiliaPatente.UseVisualStyleBackColor = false;
            this.btnGuardarFamiliaPatente.Click += new System.EventHandler(this.btnGuardarFamiliaPatente_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(562, 361);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(114, 41);
            this.btnEliminar.TabIndex = 66;
            this.btnEliminar.Tag = "btn_EliminarPatente";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // GestionarPermisosUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 414);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardarFamiliaPatente);
            this.Controls.Add(this.treeAsignacionPermisos);
            this.Controls.Add(this.btnAgregarPatente);
            this.Controls.Add(this.cbxPatentes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregarFamilia);
            this.Controls.Add(this.cbxFamilias);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfigurarUsuario);
            this.Controls.Add(this.cbxUsuarios);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GestionarPermisosUsuario";
            this.Text = "GBook - Gestionar permisos de usuario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GestionarPermisosUsuario_FormClosed);
            this.Load += new System.EventHandler(this.GestionarPermisosUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxUsuarios;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConfigurarUsuario;
        private System.Windows.Forms.Button btnAgregarFamilia;
        private System.Windows.Forms.ComboBox cbxFamilias;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarPatente;
        private System.Windows.Forms.ComboBox cbxPatentes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeAsignacionPermisos;
        private System.Windows.Forms.Button btnGuardarFamiliaPatente;
        private System.Windows.Forms.Button btnEliminar;
    }
}