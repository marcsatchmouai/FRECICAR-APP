namespace Vista
{
    partial class RemitosProveedores
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
            this.Filtrarpor = new System.Windows.Forms.GroupBox();
            this.RBCodigo = new System.Windows.Forms.RadioButton();
            this.RBFecha = new System.Windows.Forms.RadioButton();
            this.RBProveedor = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTFiltrar = new System.Windows.Forms.TextBox();
            this.BTNConsulta = new System.Windows.Forms.Button();
            this.GrillaRemitosProveedores = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroOrdenCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.BTNImprimir = new System.Windows.Forms.Button();
            this.Filtrarpor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaRemitosProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // Filtrarpor
            // 
            this.Filtrarpor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Filtrarpor.Controls.Add(this.RBCodigo);
            this.Filtrarpor.Controls.Add(this.RBFecha);
            this.Filtrarpor.Controls.Add(this.RBProveedor);
            this.Filtrarpor.Location = new System.Drawing.Point(15, 38);
            this.Filtrarpor.Name = "Filtrarpor";
            this.Filtrarpor.Size = new System.Drawing.Size(769, 36);
            this.Filtrarpor.TabIndex = 2;
            this.Filtrarpor.TabStop = false;
            this.Filtrarpor.Text = "Filtrar por";
            this.Filtrarpor.Enter += new System.EventHandler(this.Filtrarpor_Enter);
            // 
            // RBCodigo
            // 
            this.RBCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RBCodigo.AutoSize = true;
            this.RBCodigo.Location = new System.Drawing.Point(657, 13);
            this.RBCodigo.Name = "RBCodigo";
            this.RBCodigo.Size = new System.Drawing.Size(58, 17);
            this.RBCodigo.TabIndex = 2;
            this.RBCodigo.TabStop = true;
            this.RBCodigo.Text = "Codigo";
            this.RBCodigo.UseVisualStyleBackColor = true;
            // 
            // RBFecha
            // 
            this.RBFecha.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RBFecha.AutoSize = true;
            this.RBFecha.Location = new System.Drawing.Point(328, 13);
            this.RBFecha.Name = "RBFecha";
            this.RBFecha.Size = new System.Drawing.Size(55, 17);
            this.RBFecha.TabIndex = 1;
            this.RBFecha.TabStop = true;
            this.RBFecha.Text = "Fecha";
            this.RBFecha.UseVisualStyleBackColor = true;
            // 
            // RBProveedor
            // 
            this.RBProveedor.AutoSize = true;
            this.RBProveedor.Location = new System.Drawing.Point(46, 13);
            this.RBProveedor.Name = "RBProveedor";
            this.RBProveedor.Size = new System.Drawing.Size(74, 17);
            this.RBProveedor.TabIndex = 0;
            this.RBProveedor.TabStop = true;
            this.RBProveedor.Text = "Proveedor";
            this.RBProveedor.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // TXTFiltrar
            // 
            this.TXTFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTFiltrar.Location = new System.Drawing.Point(61, 12);
            this.TXTFiltrar.Name = "TXTFiltrar";
            this.TXTFiltrar.Size = new System.Drawing.Size(723, 20);
            this.TXTFiltrar.TabIndex = 1;
            // 
            // BTNConsulta
            // 
            this.BTNConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNConsulta.Location = new System.Drawing.Point(12, 426);
            this.BTNConsulta.Name = "BTNConsulta";
            this.BTNConsulta.Size = new System.Drawing.Size(75, 23);
            this.BTNConsulta.TabIndex = 4;
            this.BTNConsulta.Text = "Consultar";
            this.BTNConsulta.UseVisualStyleBackColor = true;
            this.BTNConsulta.Click += new System.EventHandler(this.BTNConsulta_Click);
            // 
            // GrillaRemitosProveedores
            // 
            this.GrillaRemitosProveedores.AllowUserToAddRows = false;
            this.GrillaRemitosProveedores.AllowUserToDeleteRows = false;
            this.GrillaRemitosProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaRemitosProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaRemitosProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Remito,
            this.NumeroOrdenCompra,
            this.Proveedor,
            this.Total});
            this.GrillaRemitosProveedores.Location = new System.Drawing.Point(12, 80);
            this.GrillaRemitosProveedores.MultiSelect = false;
            this.GrillaRemitosProveedores.Name = "GrillaRemitosProveedores";
            this.GrillaRemitosProveedores.ReadOnly = true;
            this.GrillaRemitosProveedores.RowHeadersVisible = false;
            this.GrillaRemitosProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaRemitosProveedores.Size = new System.Drawing.Size(772, 340);
            this.GrillaRemitosProveedores.TabIndex = 3;
            this.GrillaRemitosProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaRemitosProveedores_CellContentClick);
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Remito
            // 
            this.Remito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remito.DataPropertyName = "Codigo";
            this.Remito.HeaderText = "Remito";
            this.Remito.Name = "Remito";
            this.Remito.ReadOnly = true;
            // 
            // NumeroOrdenCompra
            // 
            this.NumeroOrdenCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumeroOrdenCompra.DataPropertyName = "NumeroOrdenCompra";
            this.NumeroOrdenCompra.HeaderText = "Nº OC";
            this.NumeroOrdenCompra.Name = "NumeroOrdenCompra";
            this.NumeroOrdenCompra.ReadOnly = true;
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "Proveedor";
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCancelar.Location = new System.Drawing.Point(709, 426);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(75, 23);
            this.BTNCancelar.TabIndex = 6;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // BTNImprimir
            // 
            this.BTNImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNImprimir.Location = new System.Drawing.Point(93, 426);
            this.BTNImprimir.Name = "BTNImprimir";
            this.BTNImprimir.Size = new System.Drawing.Size(75, 23);
            this.BTNImprimir.TabIndex = 5;
            this.BTNImprimir.Text = "Imprimir";
            this.BTNImprimir.UseVisualStyleBackColor = true;
            this.BTNImprimir.Click += new System.EventHandler(this.BTNImprimir_Click);
            // 
            // RemitosProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 458);
            this.ControlBox = false;
            this.Controls.Add(this.BTNImprimir);
            this.Controls.Add(this.Filtrarpor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTFiltrar);
            this.Controls.Add(this.BTNConsulta);
            this.Controls.Add(this.GrillaRemitosProveedores);
            this.Controls.Add(this.BTNCancelar);
            this.Name = "RemitosProveedores";
            this.Text = "RemitosProveedor";
            this.Filtrarpor.ResumeLayout(false);
            this.Filtrarpor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaRemitosProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TXTFiltrar_TextChanged1(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.GroupBox Filtrarpor;
        private System.Windows.Forms.RadioButton RBCodigo;
        private System.Windows.Forms.RadioButton RBFecha;
        private System.Windows.Forms.RadioButton RBProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTFiltrar;
        private System.Windows.Forms.Button BTNConsulta;
        private System.Windows.Forms.DataGridView GrillaRemitosProveedores;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remito;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroOrdenCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button BTNImprimir;
    }
}