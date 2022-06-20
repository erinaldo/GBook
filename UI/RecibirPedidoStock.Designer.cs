namespace UI
{
    partial class RecibirPedidoStock
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
            this.datagridPedidosStock = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRecibido = new System.Windows.Forms.CheckBox();
            this.btnRecibirPedido = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPedidosStock)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridPedidosStock
            // 
            this.datagridPedidosStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagridPedidosStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.datagridPedidosStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagridPedidosStock.Location = new System.Drawing.Point(283, 12);
            this.datagridPedidosStock.Name = "datagridPedidosStock";
            this.datagridPedidosStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.datagridPedidosStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridPedidosStock.Size = new System.Drawing.Size(502, 324);
            this.datagridPedidosStock.TabIndex = 67;
            this.datagridPedidosStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridPedidosStock_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(16, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 72;
            this.label1.Tag = "lbl_PedidoRecibido";
            this.label1.Text = "Recibido";
            // 
            // chkRecibido
            // 
            this.chkRecibido.AutoSize = true;
            this.chkRecibido.Location = new System.Drawing.Point(104, 117);
            this.chkRecibido.Name = "chkRecibido";
            this.chkRecibido.Size = new System.Drawing.Size(15, 14);
            this.chkRecibido.TabIndex = 73;
            this.chkRecibido.Tag = "chk_Recibido";
            this.chkRecibido.UseVisualStyleBackColor = true;
            // 
            // btnRecibirPedido
            // 
            this.btnRecibirPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.btnRecibirPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRecibirPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecibirPedido.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecibirPedido.Location = new System.Drawing.Point(64, 163);
            this.btnRecibirPedido.Name = "btnRecibirPedido";
            this.btnRecibirPedido.Size = new System.Drawing.Size(111, 53);
            this.btnRecibirPedido.TabIndex = 81;
            this.btnRecibirPedido.Tag = "btn_RecibirPedido";
            this.btnRecibirPedido.Text = "Recibir pedido";
            this.btnRecibirPedido.UseVisualStyleBackColor = false;
            this.btnRecibirPedido.Click += new System.EventHandler(this.btnRecibirPedido_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(16, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 1);
            this.panel1.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 83;
            this.label2.Tag = "lbl_DetalleCompra";
            this.label2.Text = "Detalle";
            // 
            // txtDetalle
            // 
            this.txtDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetalle.Enabled = false;
            this.txtDetalle.Font = new System.Drawing.Font("Cascadia Mono", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalle.ForeColor = System.Drawing.Color.White;
            this.txtDetalle.Location = new System.Drawing.Point(16, 76);
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(216, 16);
            this.txtDetalle.TabIndex = 82;
            // 
            // RecibirPedidoStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(792, 342);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.btnRecibirPedido);
            this.Controls.Add(this.chkRecibido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagridPedidosStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecibirPedidoStock";
            this.Text = "RecibirPedidoStock";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RecibirPedidoStock_FormClosed);
            this.Load += new System.EventHandler(this.RecibirPedidoStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridPedidosStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridPedidosStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRecibido;
        private System.Windows.Forms.Button btnRecibirPedido;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetalle;
    }
}