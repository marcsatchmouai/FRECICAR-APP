namespace Vista
{
    partial class FrmDetalleRemitoProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleRemitoProveedor));
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.GrillaDetallesRemito = new System.Windows.Forms.DataGridView();
            this.MateriaPrima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetallesRemito)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCancelar.Location = new System.Drawing.Point(315, 168);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(75, 23);
            this.BTNCancelar.TabIndex = 1;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // GrillaDetallesRemito
            // 
            this.GrillaDetallesRemito.AllowUserToAddRows = false;
            this.GrillaDetallesRemito.AllowUserToDeleteRows = false;
            this.GrillaDetallesRemito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaDetallesRemito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaDetallesRemito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MateriaPrima,
            this.Cantidad,
            this.SubTotal});
            this.GrillaDetallesRemito.Location = new System.Drawing.Point(12, 12);
            this.GrillaDetallesRemito.MultiSelect = false;
            this.GrillaDetallesRemito.Name = "GrillaDetallesRemito";
            this.GrillaDetallesRemito.ReadOnly = true;
            this.GrillaDetallesRemito.RowHeadersVisible = false;
            this.GrillaDetallesRemito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaDetallesRemito.Size = new System.Drawing.Size(378, 150);
            this.GrillaDetallesRemito.TabIndex = 0;
            this.GrillaDetallesRemito.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaDetallesRemito_CellContentClick);
            // 
            // MateriaPrima
            // 
            this.MateriaPrima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MateriaPrima.DataPropertyName = "MateriaPrima";
            this.MateriaPrima.HeaderText = "Materia Prima";
            this.MateriaPrima.Name = "MateriaPrima";
            this.MateriaPrima.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubTotal.DataPropertyName = "SubTotal";
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // FrmDetalleRemitoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 201);
            this.ControlBox = false;
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.GrillaDetallesRemito);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDetalleRemitoProveedor";
            this.Text = "FrmDetalleRemitoProveedor";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetallesRemito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.DataGridView GrillaDetallesRemito;
        private System.Windows.Forms.DataGridViewTextBoxColumn MateriaPrima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
    }
}