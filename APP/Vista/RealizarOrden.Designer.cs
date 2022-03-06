namespace Vista
{
    partial class RealizarOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealizarOrden));
            this.CMBFormadePago = new System.Windows.Forms.ComboBox();
            this.CMBFormadeEnvio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GrillaMateriaPrima = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTXTCantidad = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BTNADD = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.GrillaDetalle = new System.Windows.Forms.DataGridView();
            this.MateriaPrima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Faltante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTNROrdenCompra = new System.Windows.Forms.Button();
            this.BTNEDetalle = new System.Windows.Forms.Button();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.LBLTotal = new System.Windows.Forms.Label();
            this.LBLFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTProveedor = new System.Windows.Forms.Label();
            this.BTNSProveedor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaMateriaPrima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // CMBFormadePago
            // 
            this.CMBFormadePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBFormadePago.FormattingEnabled = true;
            this.CMBFormadePago.Location = new System.Drawing.Point(264, 30);
            this.CMBFormadePago.Name = "CMBFormadePago";
            this.CMBFormadePago.Size = new System.Drawing.Size(121, 21);
            this.CMBFormadePago.TabIndex = 0;
            // 
            // CMBFormadeEnvio
            // 
            this.CMBFormadeEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CMBFormadeEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBFormadeEnvio.FormattingEnabled = true;
            this.CMBFormadeEnvio.Location = new System.Drawing.Point(510, 30);
            this.CMBFormadeEnvio.Name = "CMBFormadeEnvio";
            this.CMBFormadeEnvio.Size = new System.Drawing.Size(121, 21);
            this.CMBFormadeEnvio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Forma de Pago:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Forma de Envio:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(616, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // GrillaMateriaPrima
            // 
            this.GrillaMateriaPrima.AllowUserToAddRows = false;
            this.GrillaMateriaPrima.AllowUserToDeleteRows = false;
            this.GrillaMateriaPrima.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaMateriaPrima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaMateriaPrima.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion,
            this.CostoUnitario,
            this.Cantidad,
            this.CantMin});
            this.GrillaMateriaPrima.Location = new System.Drawing.Point(15, 92);
            this.GrillaMateriaPrima.MultiSelect = false;
            this.GrillaMateriaPrima.Name = "GrillaMateriaPrima";
            this.GrillaMateriaPrima.ReadOnly = true;
            this.GrillaMateriaPrima.RowHeadersVisible = false;
            this.GrillaMateriaPrima.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaMateriaPrima.Size = new System.Drawing.Size(616, 150);
            this.GrillaMateriaPrima.TabIndex = 3;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Materia Prima";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // CostoUnitario
            // 
            this.CostoUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CostoUnitario.DataPropertyName = "CostoUnitario";
            this.CostoUnitario.HeaderText = "Costo Unitario";
            this.CostoUnitario.Name = "CostoUnitario";
            this.CostoUnitario.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // CantMin
            // 
            this.CantMin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CantMin.DataPropertyName = "CantMin";
            this.CantMin.HeaderText = "Cantidad Min";
            this.CantMin.Name = "CantMin";
            this.CantMin.ReadOnly = true;
            // 
            // MTXTCantidad
            // 
            this.MTXTCantidad.Location = new System.Drawing.Point(77, 250);
            this.MTXTCantidad.Mask = "99999";
            this.MTXTCantidad.Name = "MTXTCantidad";
            this.MTXTCantidad.PromptChar = ' ';
            this.MTXTCantidad.Size = new System.Drawing.Size(100, 20);
            this.MTXTCantidad.TabIndex = 4;
            this.MTXTCantidad.ValidatingType = typeof(int);
            this.MTXTCantidad.Click += new System.EventHandler(this.MTXTCantidad_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cantidad:";
            // 
            // BTNADD
            // 
            this.BTNADD.Location = new System.Drawing.Point(183, 248);
            this.BTNADD.Name = "BTNADD";
            this.BTNADD.Size = new System.Drawing.Size(75, 23);
            this.BTNADD.TabIndex = 5;
            this.BTNADD.Text = "Agregar";
            this.BTNADD.UseVisualStyleBackColor = true;
            this.BTNADD.Click += new System.EventHandler(this.BTNADD_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(616, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // GrillaDetalle
            // 
            this.GrillaDetalle.AllowUserToAddRows = false;
            this.GrillaDetalle.AllowUserToDeleteRows = false;
            this.GrillaDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MateriaPrima,
            this.CantidadDetalle,
            this.SubTotal,
            this.Faltante});
            this.GrillaDetalle.Location = new System.Drawing.Point(12, 289);
            this.GrillaDetalle.MultiSelect = false;
            this.GrillaDetalle.Name = "GrillaDetalle";
            this.GrillaDetalle.ReadOnly = true;
            this.GrillaDetalle.RowHeadersVisible = false;
            this.GrillaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaDetalle.Size = new System.Drawing.Size(616, 142);
            this.GrillaDetalle.TabIndex = 7;
            // 
            // MateriaPrima
            // 
            this.MateriaPrima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MateriaPrima.DataPropertyName = "MateriaPrima";
            this.MateriaPrima.HeaderText = "Materia Prima";
            this.MateriaPrima.Name = "MateriaPrima";
            this.MateriaPrima.ReadOnly = true;
            // 
            // CantidadDetalle
            // 
            this.CantidadDetalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CantidadDetalle.DataPropertyName = "Cantidad";
            this.CantidadDetalle.HeaderText = "Cantidad";
            this.CantidadDetalle.Name = "CantidadDetalle";
            this.CantidadDetalle.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubTotal.DataPropertyName = "SubTotal";
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // Faltante
            // 
            this.Faltante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Faltante.DataPropertyName = "Faltante";
            this.Faltante.HeaderText = "Faltante";
            this.Faltante.Name = "Faltante";
            this.Faltante.ReadOnly = true;
            // 
            // BTNROrdenCompra
            // 
            this.BTNROrdenCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNROrdenCompra.Location = new System.Drawing.Point(12, 464);
            this.BTNROrdenCompra.Name = "BTNROrdenCompra";
            this.BTNROrdenCompra.Size = new System.Drawing.Size(149, 23);
            this.BTNROrdenCompra.TabIndex = 8;
            this.BTNROrdenCompra.Text = "Realizar Orden de Compra";
            this.BTNROrdenCompra.UseVisualStyleBackColor = true;
            this.BTNROrdenCompra.Click += new System.EventHandler(this.BTNROrdenCompra_Click);
            // 
            // BTNEDetalle
            // 
            this.BTNEDetalle.Location = new System.Drawing.Point(264, 248);
            this.BTNEDetalle.Name = "BTNEDetalle";
            this.BTNEDetalle.Size = new System.Drawing.Size(93, 23);
            this.BTNEDetalle.TabIndex = 6;
            this.BTNEDetalle.Text = "Eliminar";
            this.BTNEDetalle.UseVisualStyleBackColor = true;
            this.BTNEDetalle.Click += new System.EventHandler(this.BTNEDetalle_Click);
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCancelar.Location = new System.Drawing.Point(535, 464);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(91, 23);
            this.BTNCancelar.TabIndex = 9;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // LBLTotal
            // 
            this.LBLTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LBLTotal.AutoSize = true;
            this.LBLTotal.Location = new System.Drawing.Point(532, 448);
            this.LBLTotal.Name = "LBLTotal";
            this.LBLTotal.Size = new System.Drawing.Size(34, 13);
            this.LBLTotal.TabIndex = 17;
            this.LBLTotal.Text = "Total:";
            // 
            // LBLFecha
            // 
            this.LBLFecha.AutoSize = true;
            this.LBLFecha.Location = new System.Drawing.Point(12, 9);
            this.LBLFecha.Name = "LBLFecha";
            this.LBLFecha.Size = new System.Drawing.Size(40, 13);
            this.LBLFecha.TabIndex = 18;
            this.LBLFecha.Text = "Fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Proveedor:";
            // 
            // TXTProveedor
            // 
            this.TXTProveedor.AutoSize = true;
            this.TXTProveedor.Location = new System.Drawing.Point(74, 33);
            this.TXTProveedor.Name = "TXTProveedor";
            this.TXTProveedor.Size = new System.Drawing.Size(0, 13);
            this.TXTProveedor.TabIndex = 20;
            // 
            // BTNSProveedor
            // 
            this.BTNSProveedor.Location = new System.Drawing.Point(22, 50);
            this.BTNSProveedor.Name = "BTNSProveedor";
            this.BTNSProveedor.Size = new System.Drawing.Size(124, 23);
            this.BTNSProveedor.TabIndex = 2;
            this.BTNSProveedor.Text = "Seleccionar Proveedor";
            this.BTNSProveedor.UseVisualStyleBackColor = true;
            this.BTNSProveedor.Click += new System.EventHandler(this.BTNSProveedor_Click);
            // 
            // RealizarOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 499);
            this.ControlBox = false;
            this.Controls.Add(this.BTNSProveedor);
            this.Controls.Add(this.TXTProveedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBLFecha);
            this.Controls.Add(this.LBLTotal);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNEDetalle);
            this.Controls.Add(this.BTNROrdenCompra);
            this.Controls.Add(this.GrillaDetalle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTNADD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MTXTCantidad);
            this.Controls.Add(this.GrillaMateriaPrima);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CMBFormadeEnvio);
            this.Controls.Add(this.CMBFormadePago);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RealizarOrden";
            this.Text = "Orden de Compra";
            this.Load += new System.EventHandler(this.FrmOrdenCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaMateriaPrima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox CMBFormadePago;
        private System.Windows.Forms.ComboBox CMBFormadeEnvio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView GrillaMateriaPrima;
        private System.Windows.Forms.MaskedTextBox MTXTCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTNADD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView GrillaDetalle;
        private System.Windows.Forms.Button BTNROrdenCompra;
        private System.Windows.Forms.Button BTNEDetalle;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.Label LBLTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stringCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stringProveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label LBLFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TXTProveedor;
        private System.Windows.Forms.Button BTNSProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn MateriaPrima;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Faltante;
    }
}