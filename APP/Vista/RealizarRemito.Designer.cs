namespace Vista
{
    partial class RealizarRemito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealizarRemito));
            this.TXTProveedor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LBLFecha = new System.Windows.Forms.Label();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.BTNEDetalle = new System.Windows.Forms.Button();
            this.BTNRRemito = new System.Windows.Forms.Button();
            this.GrillaDetalleRemito = new System.Windows.Forms.DataGridView();
            this.MateriaPrimaRemito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadRemito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalRemito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.BTNADD = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.MTXTCantidad = new System.Windows.Forms.MaskedTextBox();
            this.GrillaDetalleOrden = new System.Windows.Forms.DataGridView();
            this.MateriaPrima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Faltante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.BTNSOrden = new System.Windows.Forms.Button();
            this.LBLLTotal = new System.Windows.Forms.Label();
            this.LBLProveedor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetalleRemito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetalleOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTProveedor
            // 
            this.TXTProveedor.AutoSize = true;
            this.TXTProveedor.Location = new System.Drawing.Point(74, 33);
            this.TXTProveedor.Name = "TXTProveedor";
            this.TXTProveedor.Size = new System.Drawing.Size(0, 13);
            this.TXTProveedor.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Proveedor:";
            // 
            // LBLFecha
            // 
            this.LBLFecha.AutoSize = true;
            this.LBLFecha.Location = new System.Drawing.Point(12, 9);
            this.LBLFecha.Name = "LBLFecha";
            this.LBLFecha.Size = new System.Drawing.Size(40, 13);
            this.LBLFecha.TabIndex = 8;
            this.LBLFecha.Text = "Fecha:";
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCancelar.Location = new System.Drawing.Point(534, 389);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(91, 23);
            this.BTNCancelar.TabIndex = 7;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click_1);
            // 
            // BTNEDetalle
            // 
            this.BTNEDetalle.Location = new System.Drawing.Point(261, 194);
            this.BTNEDetalle.Name = "BTNEDetalle";
            this.BTNEDetalle.Size = new System.Drawing.Size(93, 23);
            this.BTNEDetalle.TabIndex = 4;
            this.BTNEDetalle.Text = "Eliminar";
            this.BTNEDetalle.UseVisualStyleBackColor = true;
            this.BTNEDetalle.Click += new System.EventHandler(this.BTNEDetalle_Click_1);
            // 
            // BTNRRemito
            // 
            this.BTNRRemito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNRRemito.Location = new System.Drawing.Point(12, 389);
            this.BTNRRemito.Name = "BTNRRemito";
            this.BTNRRemito.Size = new System.Drawing.Size(107, 23);
            this.BTNRRemito.TabIndex = 6;
            this.BTNRRemito.Text = "Realizar Remito";
            this.BTNRRemito.UseVisualStyleBackColor = true;
            this.BTNRRemito.Click += new System.EventHandler(this.BTNRRemito_Click);
            // 
            // GrillaDetalleRemito
            // 
            this.GrillaDetalleRemito.AllowUserToAddRows = false;
            this.GrillaDetalleRemito.AllowUserToDeleteRows = false;
            this.GrillaDetalleRemito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaDetalleRemito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaDetalleRemito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MateriaPrimaRemito,
            this.CantidadRemito,
            this.SubTotalRemito});
            this.GrillaDetalleRemito.Location = new System.Drawing.Point(12, 236);
            this.GrillaDetalleRemito.MultiSelect = false;
            this.GrillaDetalleRemito.Name = "GrillaDetalleRemito";
            this.GrillaDetalleRemito.ReadOnly = true;
            this.GrillaDetalleRemito.RowHeadersVisible = false;
            this.GrillaDetalleRemito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaDetalleRemito.Size = new System.Drawing.Size(613, 142);
            this.GrillaDetalleRemito.TabIndex = 5;
            // 
            // MateriaPrimaRemito
            // 
            this.MateriaPrimaRemito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MateriaPrimaRemito.DataPropertyName = "MateriaPrima";
            this.MateriaPrimaRemito.HeaderText = "Materia Prima";
            this.MateriaPrimaRemito.Name = "MateriaPrimaRemito";
            this.MateriaPrimaRemito.ReadOnly = true;
            // 
            // CantidadRemito
            // 
            this.CantidadRemito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CantidadRemito.DataPropertyName = "Cantidad";
            this.CantidadRemito.HeaderText = "Cantidad";
            this.CantidadRemito.Name = "CantidadRemito";
            this.CantidadRemito.ReadOnly = true;
            // 
            // SubTotalRemito
            // 
            this.SubTotalRemito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubTotalRemito.DataPropertyName = "SubTotal";
            this.SubTotalRemito.HeaderText = "Sub Total";
            this.SubTotalRemito.Name = "SubTotalRemito";
            this.SubTotalRemito.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(616, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // BTNADD
            // 
            this.BTNADD.Location = new System.Drawing.Point(180, 194);
            this.BTNADD.Name = "BTNADD";
            this.BTNADD.Size = new System.Drawing.Size(75, 23);
            this.BTNADD.TabIndex = 3;
            this.BTNADD.Text = "Agregar";
            this.BTNADD.UseVisualStyleBackColor = true;
            this.BTNADD.Click += new System.EventHandler(this.BTNADD_Click_1);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Cantidad:";
            // 
            // MTXTCantidad
            // 
            this.MTXTCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MTXTCantidad.Location = new System.Drawing.Point(74, 197);
            this.MTXTCantidad.Name = "MTXTCantidad";
            this.MTXTCantidad.Size = new System.Drawing.Size(100, 20);
            this.MTXTCantidad.TabIndex = 2;
            this.MTXTCantidad.Click += new System.EventHandler(this.MTXTCantidad_Click);
            // 
            // GrillaDetalleOrden
            // 
            this.GrillaDetalleOrden.AllowUserToAddRows = false;
            this.GrillaDetalleOrden.AllowUserToDeleteRows = false;
            this.GrillaDetalleOrden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaDetalleOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaDetalleOrden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MateriaPrima,
            this.Cantidad,
            this.Faltante,
            this.SubTotal});
            this.GrillaDetalleOrden.Location = new System.Drawing.Point(12, 38);
            this.GrillaDetalleOrden.MultiSelect = false;
            this.GrillaDetalleOrden.Name = "GrillaDetalleOrden";
            this.GrillaDetalleOrden.ReadOnly = true;
            this.GrillaDetalleOrden.RowHeadersVisible = false;
            this.GrillaDetalleOrden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaDetalleOrden.Size = new System.Drawing.Size(613, 150);
            this.GrillaDetalleOrden.TabIndex = 1;
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
            // Faltante
            // 
            this.Faltante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Faltante.DataPropertyName = "Faltante";
            this.Faltante.HeaderText = "Faltante";
            this.Faltante.Name = "Faltante";
            this.Faltante.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubTotal.DataPropertyName = "SubTotal";
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(616, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // BTNSOrden
            // 
            this.BTNSOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNSOrden.Location = new System.Drawing.Point(463, 4);
            this.BTNSOrden.Name = "BTNSOrden";
            this.BTNSOrden.Size = new System.Drawing.Size(162, 23);
            this.BTNSOrden.TabIndex = 0;
            this.BTNSOrden.Text = "Seleccionar Orden de Compra";
            this.BTNSOrden.UseVisualStyleBackColor = true;
            this.BTNSOrden.Click += new System.EventHandler(this.BTNSOrden_Click);
            // 
            // LBLLTotal
            // 
            this.LBLLTotal.AutoSize = true;
            this.LBLLTotal.Location = new System.Drawing.Point(566, 389);
            this.LBLLTotal.Name = "LBLLTotal";
            this.LBLLTotal.Size = new System.Drawing.Size(0, 13);
            this.LBLLTotal.TabIndex = 12;
            // 
            // LBLProveedor
            // 
            this.LBLProveedor.AutoSize = true;
            this.LBLProveedor.Location = new System.Drawing.Point(292, 9);
            this.LBLProveedor.Name = "LBLProveedor";
            this.LBLProveedor.Size = new System.Drawing.Size(0, 13);
            this.LBLProveedor.TabIndex = 42;
            // 
            // RealizarRemito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 419);
            this.ControlBox = false;
            this.Controls.Add(this.LBLProveedor);
            this.Controls.Add(this.LBLLTotal);
            this.Controls.Add(this.BTNSOrden);
            this.Controls.Add(this.TXTProveedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBLFecha);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNEDetalle);
            this.Controls.Add(this.BTNRRemito);
            this.Controls.Add(this.GrillaDetalleRemito);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTNADD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MTXTCantidad);
            this.Controls.Add(this.GrillaDetalleOrden);
            this.Controls.Add(this.label4);
            this.Name = "RealizarRemito";
            this.Text = "Remito";
            this.Load += new System.EventHandler(this.FrmRemitoProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetalleRemito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetalleOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TXTProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBLFecha;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.Button BTNEDetalle;
        private System.Windows.Forms.Button BTNRRemito;
        private System.Windows.Forms.DataGridView GrillaDetalleRemito;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BTNADD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox MTXTCantidad;
        private System.Windows.Forms.DataGridView GrillaDetalleOrden;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTNSOrden;
        private System.Windows.Forms.Label LBLLTotal;
        private System.Windows.Forms.Label LBLProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn MateriaPrima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Faltante;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn MateriaPrimaRemito;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadRemito;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalRemito;
    }
}