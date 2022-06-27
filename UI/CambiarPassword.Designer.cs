namespace UI
{
    partial class CambiarPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarPassword));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNuevaPassword = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNuevaPasswordConfirmar = new System.Windows.Forms.TextBox();
            this.btnCambiarPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(113, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 1);
            this.panel2.TabIndex = 13;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.lblPassword.Location = new System.Drawing.Point(109, 74);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(163, 21);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Tag = "lbl_PasswordActual";
            this.lblPassword.Text = "Contraseña actual";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Cascadia Mono", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(113, 98);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(216, 16);
            this.txtPassword.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(113, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 1);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(109, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 15;
            this.label1.Tag = "lbl_PasswordNueva";
            this.label1.Text = "Contraseña nueva";
            // 
            // txtNuevaPassword
            // 
            this.txtNuevaPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtNuevaPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNuevaPassword.Font = new System.Drawing.Font("Cascadia Mono", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevaPassword.ForeColor = System.Drawing.Color.White;
            this.txtNuevaPassword.Location = new System.Drawing.Point(113, 165);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.PasswordChar = '*';
            this.txtNuevaPassword.Size = new System.Drawing.Size(216, 16);
            this.txtNuevaPassword.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(113, 252);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(216, 1);
            this.panel3.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label2.Location = new System.Drawing.Point(109, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 21);
            this.label2.TabIndex = 18;
            this.label2.Tag = "lbl_PasswordNuevaConfirmar";
            this.label2.Text = "Confirmación contraseña nueva";
            // 
            // txtNuevaPasswordConfirmar
            // 
            this.txtNuevaPasswordConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtNuevaPasswordConfirmar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNuevaPasswordConfirmar.Font = new System.Drawing.Font("Cascadia Mono", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevaPasswordConfirmar.ForeColor = System.Drawing.Color.White;
            this.txtNuevaPasswordConfirmar.Location = new System.Drawing.Point(113, 234);
            this.txtNuevaPasswordConfirmar.Name = "txtNuevaPasswordConfirmar";
            this.txtNuevaPasswordConfirmar.PasswordChar = '*';
            this.txtNuevaPasswordConfirmar.Size = new System.Drawing.Size(216, 16);
            this.txtNuevaPasswordConfirmar.TabIndex = 17;
            // 
            // btnCambiarPassword
            // 
            this.btnCambiarPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnCambiarPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCambiarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarPassword.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarPassword.Location = new System.Drawing.Point(172, 275);
            this.btnCambiarPassword.Name = "btnCambiarPassword";
            this.btnCambiarPassword.Size = new System.Drawing.Size(100, 37);
            this.btnCambiarPassword.TabIndex = 20;
            this.btnCambiarPassword.Tag = "btn_CambiarPassword";
            this.btnCambiarPassword.Text = "Cambiar";
            this.btnCambiarPassword.UseVisualStyleBackColor = false;
            this.btnCambiarPassword.Click += new System.EventHandler(this.btnCambiarPassword_Click);
            // 
            // CambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(466, 397);
            this.Controls.Add(this.btnCambiarPassword);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNuevaPasswordConfirmar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNuevaPassword);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CambiarPassword";
            this.Text = "GBook - Cambiar contraseña";
            this.Load += new System.EventHandler(this.CambiarPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNuevaPassword;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNuevaPasswordConfirmar;
        private System.Windows.Forms.Button btnCambiarPassword;
    }
}