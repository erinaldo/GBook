namespace UI
{
    partial class GestionFamiliaPatente
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
            this.treePatenteFamilia = new System.Windows.Forms.TreeView();
            this.cbxPatente = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGuardarPatente = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombrePatente = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.btnGuardarFamilia = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxFamilia = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConfigurarFamilia = new System.Windows.Forms.Button();
            this.btnAgregarPatente = new System.Windows.Forms.Button();
            this.cbxPatenteAgregar = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGuardarFamiliaModificada = new System.Windows.Forms.Button();
            this.btnEliminarPatente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treePatenteFamilia
            // 
            this.treePatenteFamilia.Location = new System.Drawing.Point(636, 12);
            this.treePatenteFamilia.Name = "treePatenteFamilia";
            this.treePatenteFamilia.Size = new System.Drawing.Size(396, 423);
            this.treePatenteFamilia.TabIndex = 0;
            // 
            // cbxPatente
            // 
            this.cbxPatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxPatente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPatente.ForeColor = System.Drawing.Color.White;
            this.cbxPatente.FormattingEnabled = true;
            this.cbxPatente.Location = new System.Drawing.Point(16, 282);
            this.cbxPatente.Name = "cbxPatente";
            this.cbxPatente.Size = new System.Drawing.Size(216, 21);
            this.cbxPatente.TabIndex = 51;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.ForeColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(16, 305);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(216, 1);
            this.panel5.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label5.Location = new System.Drawing.Point(12, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 49;
            this.label5.Tag = "lbl_NombrePatente";
            this.label5.Text = "Patente";
            // 
            // btnGuardarPatente
            // 
            this.btnGuardarPatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnGuardarPatente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardarPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPatente.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarPatente.Location = new System.Drawing.Point(71, 382);
            this.btnGuardarPatente.Name = "btnGuardarPatente";
            this.btnGuardarPatente.Size = new System.Drawing.Size(86, 32);
            this.btnGuardarPatente.TabIndex = 52;
            this.btnGuardarPatente.Tag = "btn_GuardarPatente";
            this.btnGuardarPatente.Text = "Guardar";
            this.btnGuardarPatente.UseVisualStyleBackColor = false;
            this.btnGuardarPatente.Click += new System.EventHandler(this.btnGuardarPatente_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(16, 363);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 1);
            this.panel1.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(12, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 54;
            this.label1.Tag = "lbl_NombrePatente";
            this.label1.Text = "Nombre";
            // 
            // txtNombrePatente
            // 
            this.txtNombrePatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtNombrePatente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombrePatente.Font = new System.Drawing.Font("Cascadia Mono", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePatente.ForeColor = System.Drawing.Color.White;
            this.txtNombrePatente.Location = new System.Drawing.Point(16, 345);
            this.txtNombrePatente.Name = "txtNombrePatente";
            this.txtNombrePatente.Size = new System.Drawing.Size(216, 16);
            this.txtNombrePatente.TabIndex = 53;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(17, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 1);
            this.panel2.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 58;
            this.label2.Tag = "lbl_NombreFamilia";
            this.label2.Text = "Nombre";
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtNombreFamilia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreFamilia.Font = new System.Drawing.Font("Cascadia Mono", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreFamilia.ForeColor = System.Drawing.Color.White;
            this.txtNombreFamilia.Location = new System.Drawing.Point(17, 90);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(216, 16);
            this.txtNombreFamilia.TabIndex = 57;
            // 
            // btnGuardarFamilia
            // 
            this.btnGuardarFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnGuardarFamilia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarFamilia.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarFamilia.Location = new System.Drawing.Point(72, 127);
            this.btnGuardarFamilia.Name = "btnGuardarFamilia";
            this.btnGuardarFamilia.Size = new System.Drawing.Size(86, 32);
            this.btnGuardarFamilia.TabIndex = 56;
            this.btnGuardarFamilia.Tag = "btn_GuardarFamilia";
            this.btnGuardarFamilia.Text = "Guardar";
            this.btnGuardarFamilia.UseVisualStyleBackColor = false;
            this.btnGuardarFamilia.Click += new System.EventHandler(this.btnGuardarFamilia_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cascadia Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label9.Location = new System.Drawing.Point(11, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 25);
            this.label9.TabIndex = 95;
            this.label9.Tag = "lbl_NuevaFamilia";
            this.label9.Text = "Nueva familia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label3.Location = new System.Drawing.Point(11, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 96;
            this.label3.Tag = "lbl_NuevaPatente";
            this.label3.Text = "Nueva patente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label4.Location = new System.Drawing.Point(367, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 25);
            this.label4.TabIndex = 99;
            this.label4.Tag = "lbl_FamiliasExistentes";
            this.label4.Text = "Familias existentes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label6.Location = new System.Drawing.Point(368, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 97;
            this.label6.Tag = "lbl_NombreFamilia";
            this.label6.Text = "Familia";
            // 
            // cbxFamilia
            // 
            this.cbxFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFamilia.ForeColor = System.Drawing.Color.White;
            this.cbxFamilia.FormattingEnabled = true;
            this.cbxFamilia.Location = new System.Drawing.Point(372, 90);
            this.cbxFamilia.Name = "cbxFamilia";
            this.cbxFamilia.Size = new System.Drawing.Size(216, 21);
            this.cbxFamilia.TabIndex = 101;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(372, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(216, 1);
            this.panel3.TabIndex = 100;
            // 
            // btnConfigurarFamilia
            // 
            this.btnConfigurarFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnConfigurarFamilia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfigurarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigurarFamilia.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigurarFamilia.Location = new System.Drawing.Point(414, 127);
            this.btnConfigurarFamilia.Name = "btnConfigurarFamilia";
            this.btnConfigurarFamilia.Size = new System.Drawing.Size(116, 32);
            this.btnConfigurarFamilia.TabIndex = 102;
            this.btnConfigurarFamilia.Tag = "btn_ConfigurarFamilia";
            this.btnConfigurarFamilia.Text = "Configurar";
            this.btnConfigurarFamilia.UseVisualStyleBackColor = false;
            this.btnConfigurarFamilia.Click += new System.EventHandler(this.btnConfigurarFamilia_Click);
            // 
            // btnAgregarPatente
            // 
            this.btnAgregarPatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnAgregarPatente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAgregarPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPatente.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPatente.Location = new System.Drawing.Point(414, 329);
            this.btnAgregarPatente.Name = "btnAgregarPatente";
            this.btnAgregarPatente.Size = new System.Drawing.Size(116, 32);
            this.btnAgregarPatente.TabIndex = 107;
            this.btnAgregarPatente.Tag = "btn_AgregarPatente";
            this.btnAgregarPatente.Text = "Agregar";
            this.btnAgregarPatente.UseVisualStyleBackColor = false;
            this.btnAgregarPatente.Click += new System.EventHandler(this.btnAgregarPatente_Click);
            // 
            // cbxPatenteAgregar
            // 
            this.cbxPatenteAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxPatenteAgregar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPatenteAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPatenteAgregar.ForeColor = System.Drawing.Color.White;
            this.cbxPatenteAgregar.FormattingEnabled = true;
            this.cbxPatenteAgregar.Location = new System.Drawing.Point(372, 285);
            this.cbxPatenteAgregar.Name = "cbxPatenteAgregar";
            this.cbxPatenteAgregar.Size = new System.Drawing.Size(216, 21);
            this.cbxPatenteAgregar.TabIndex = 106;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(372, 308);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(216, 1);
            this.panel4.TabIndex = 105;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cascadia Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label7.Location = new System.Drawing.Point(367, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 25);
            this.label7.TabIndex = 104;
            this.label7.Tag = "lbl_PatentesExistentes";
            this.label7.Text = "Patentes existentes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label8.Location = new System.Drawing.Point(368, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 21);
            this.label8.TabIndex = 103;
            this.label8.Tag = "lbl_NombrePatente";
            this.label8.Text = "Patente";
            // 
            // btnGuardarFamiliaModificada
            // 
            this.btnGuardarFamiliaModificada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnGuardarFamiliaModificada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardarFamiliaModificada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarFamiliaModificada.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarFamiliaModificada.Location = new System.Drawing.Point(701, 441);
            this.btnGuardarFamiliaModificada.Name = "btnGuardarFamiliaModificada";
            this.btnGuardarFamiliaModificada.Size = new System.Drawing.Size(118, 58);
            this.btnGuardarFamiliaModificada.TabIndex = 108;
            this.btnGuardarFamiliaModificada.Tag = "btn_GuardarFamilia";
            this.btnGuardarFamiliaModificada.Text = "Guardar familia";
            this.btnGuardarFamiliaModificada.UseVisualStyleBackColor = false;
            this.btnGuardarFamiliaModificada.Click += new System.EventHandler(this.btnGuardarFamiliaModificada_Click);
            // 
            // btnEliminarPatente
            // 
            this.btnEliminarPatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnEliminarPatente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEliminarPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPatente.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPatente.Location = new System.Drawing.Point(852, 441);
            this.btnEliminarPatente.Name = "btnEliminarPatente";
            this.btnEliminarPatente.Size = new System.Drawing.Size(118, 58);
            this.btnEliminarPatente.TabIndex = 109;
            this.btnEliminarPatente.Tag = "btn_EliminarPatente";
            this.btnEliminarPatente.Text = "Eliminar patente";
            this.btnEliminarPatente.UseVisualStyleBackColor = false;
            this.btnEliminarPatente.Click += new System.EventHandler(this.btnEliminarPatente_Click);
            // 
            // GestionFamiliaPatente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1044, 506);
            this.Controls.Add(this.btnEliminarPatente);
            this.Controls.Add(this.btnGuardarFamiliaModificada);
            this.Controls.Add(this.btnAgregarPatente);
            this.Controls.Add(this.cbxPatenteAgregar);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnConfigurarFamilia);
            this.Controls.Add(this.cbxFamilia);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreFamilia);
            this.Controls.Add(this.btnGuardarFamilia);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombrePatente);
            this.Controls.Add(this.btnGuardarPatente);
            this.Controls.Add(this.cbxPatente);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.treePatenteFamilia);
            this.Name = "GestionFamiliaPatente";
            this.Text = "GestionFamiliaPatente";
            this.Load += new System.EventHandler(this.GestionFamiliaPatente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treePatenteFamilia;
        private System.Windows.Forms.ComboBox cbxPatente;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGuardarPatente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombrePatente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreFamilia;
        private System.Windows.Forms.Button btnGuardarFamilia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxFamilia;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnConfigurarFamilia;
        private System.Windows.Forms.Button btnAgregarPatente;
        private System.Windows.Forms.ComboBox cbxPatenteAgregar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGuardarFamiliaModificada;
        private System.Windows.Forms.Button btnEliminarPatente;
    }
}