namespace UI
{
    partial class VisualizarPedidosStock
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
            this.lblProductos = new System.Windows.Forms.Label();
            this.datagridPedidosStock = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPedidosStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(135)))));
            this.lblProductos.Location = new System.Drawing.Point(12, 22);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(253, 21);
            this.lblProductos.TabIndex = 110;
            this.lblProductos.Tag = "lbl_PedidosStockRealizados";
            this.lblProductos.Text = "Pedidos de stock realizados";
            // 
            // datagridPedidosStock
            // 
            this.datagridPedidosStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagridPedidosStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.datagridPedidosStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridPedidosStock.Location = new System.Drawing.Point(12, 46);
            this.datagridPedidosStock.Name = "datagridPedidosStock";
            this.datagridPedidosStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.datagridPedidosStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridPedidosStock.Size = new System.Drawing.Size(941, 384);
            this.datagridPedidosStock.TabIndex = 109;
            // 
            // VisualizarPedidosStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(961, 438);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.datagridPedidosStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VisualizarPedidosStock";
            this.Text = "VisualizarPedidosStock";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VisualizarPedidosStock_FormClosed);
            this.Load += new System.EventHandler(this.VisualizarPedidosStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridPedidosStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.DataGridView datagridPedidosStock;
    }
}