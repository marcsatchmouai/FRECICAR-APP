namespace Vista
{
    partial class OrdenesCompras
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenesCompras));
            this.GrillaOrdenesCompras = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormadeEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormadePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.BTNAnular = new System.Windows.Forms.Button();
            this.BTNConsulta = new System.Windows.Forms.Button();
            this.OrdenCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TXTFiltrar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Filtrarpor = new System.Windows.Forms.GroupBox();
            this.RBCodigo = new System.Windows.Forms.RadioButton();
            this.RBFecha = new System.Windows.Forms.RadioButton();
            this.RBProveedor = new System.Windows.Forms.RadioButton();
            this.BTNImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaOrdenesCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenCompraBindingSource)).BeginInit();
            this.Filtrarpor.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrillaOrdenesCompras
            // 
            this.GrillaOrdenesCompras.AllowUserToAddRows = false;
            this.GrillaOrdenesCompras.AllowUserToDeleteRows = false;
            this.GrillaOrdenesCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaOrdenesCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaOrdenesCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Estado,
            this.Fecha,
            this.FormadeEnvio,
            this.FormadePago,
            this.Proveedor,
            this.Total});
            this.GrillaOrdenesCompras.Location = new System.Drawing.Point(12, 80);
            this.GrillaOrdenesCompras.MultiSelect = false;
            this.GrillaOrdenesCompras.Name = "GrillaOrdenesCompras";
            this.GrillaOrdenesCompras.ReadOnly = true;
            this.GrillaOrdenesCompras.RowHeadersVisible = false;
            this.GrillaOrdenesCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaOrdenesCompras.Size = new System.Drawing.Size(729, 123);
            this.GrillaOrdenesCompras.TabIndex = 2;
            this.GrillaOrdenesCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaOrdenesCompras_CellContentClick);
            this.GrillaOrdenesCompras.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaOrdenesCompras_CellContentDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // FormadeEnvio
            // 
            this.FormadeEnvio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FormadeEnvio.DataPropertyName = "FormadeEnvio";
            this.FormadeEnvio.HeaderText = "F.Envio";
            this.FormadeEnvio.Name = "FormadeEnvio";
            this.FormadeEnvio.ReadOnly = true;
            // 
            // FormadePago
            // 
            this.FormadePago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FormadePago.DataPropertyName = "FormadePago";
            this.FormadePago.HeaderText = "F.Pago";
            this.FormadePago.Name = "FormadePago";
            this.FormadePago.ReadOnly = true;
            // 
            // Proveedor
            // 
            this.Proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            this.BTNCancelar.Location = new System.Drawing.Point(666, 209);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(75, 23);
            this.BTNCancelar.TabIndex = 6;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // BTNAnular
            // 
            this.BTNAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNAnular.Location = new System.Drawing.Point(15, 209);
            this.BTNAnular.Name = "BTNAnular";
            this.BTNAnular.Size = new System.Drawing.Size(75, 23);
            this.BTNAnular.TabIndex = 3;
            this.BTNAnular.Text = "Anular";
            this.BTNAnular.UseVisualStyleBackColor = true;
            this.BTNAnular.Click += new System.EventHandler(this.BTNAnular_Click);
            // 
            // BTNConsulta
            // 
            this.BTNConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNConsulta.Location = new System.Drawing.Point(96, 209);
            this.BTNConsulta.Name = "BTNConsulta";
            this.BTNConsulta.Size = new System.Drawing.Size(75, 23);
            this.BTNConsulta.TabIndex = 4;
            this.BTNConsulta.Text = "Consultar";
            this.BTNConsulta.UseVisualStyleBackColor = true;
            this.BTNConsulta.Click += new System.EventHandler(this.BTNConsulta_Click);
            // 
            // TXTFiltrar
            // 
            this.TXTFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTFiltrar.Location = new System.Drawing.Point(61, 12);
            this.TXTFiltrar.Name = "TXTFiltrar";
            this.TXTFiltrar.Size = new System.Drawing.Size(680, 20);
            this.TXTFiltrar.TabIndex = 0;
            this.TXTFiltrar.TextChanged += new System.EventHandler(this.TXTFiltrar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Buscar:";
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
            this.Filtrarpor.Size = new System.Drawing.Size(726, 36);
            this.Filtrarpor.TabIndex = 1;
            this.Filtrarpor.TabStop = false;
            this.Filtrarpor.Text = "Filtrar por";
            this.Filtrarpor.Enter += new System.EventHandler(this.Filtrarpor_Enter);
            // 
            // RBCodigo
            // 
            this.RBCodigo.AutoSize = true;
            this.RBCodigo.Location = new System.Drawing.Point(471, 13);
            this.RBCodigo.Name = "RBCodigo";
            this.RBCodigo.Size = new System.Drawing.Size(58, 17);
            this.RBCodigo.TabIndex = 2;
            this.RBCodigo.Text = "Codigo";
            this.RBCodigo.UseVisualStyleBackColor = true;
            // 
            // RBFecha
            // 
            this.RBFecha.AutoSize = true;
            this.RBFecha.Location = new System.Drawing.Point(246, 13);
            this.RBFecha.Name = "RBFecha";
            this.RBFecha.Size = new System.Drawing.Size(55, 17);
            this.RBFecha.TabIndex = 1;
            this.RBFecha.Text = "Fecha";
            this.RBFecha.UseVisualStyleBackColor = true;
            // 
            // RBProveedor
            // 
            this.RBProveedor.AutoSize = true;
            this.RBProveedor.Checked = true;
            this.RBProveedor.Location = new System.Drawing.Point(46, 13);
            this.RBProveedor.Name = "RBProveedor";
            this.RBProveedor.Size = new System.Drawing.Size(74, 17);
            this.RBProveedor.TabIndex = 0;
            this.RBProveedor.TabStop = true;
            this.RBProveedor.Text = "Proveedor";
            this.RBProveedor.UseVisualStyleBackColor = true;
            this.RBProveedor.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // BTNImprimir
            // 
            this.BTNImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNImprimir.Location = new System.Drawing.Point(177, 209);
            this.BTNImprimir.Name = "BTNImprimir";
            this.BTNImprimir.Size = new System.Drawing.Size(75, 23);
            this.BTNImprimir.TabIndex = 5;
            this.BTNImprimir.Text = "Imprimir";
            this.BTNImprimir.UseVisualStyleBackColor = true;
            this.BTNImprimir.Click += new System.EventHandler(this.BTNImprimir_Click);
            // 
            // OrdenesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 244);
            this.ControlBox = false;
            this.Controls.Add(this.BTNImprimir);
            this.Controls.Add(this.Filtrarpor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTFiltrar);
            this.Controls.Add(this.BTNConsulta);
            this.Controls.Add(this.GrillaOrdenesCompras);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNAnular);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrdenesCompras";
            this.Text = "OrdenesCompras";
            this.Load += new System.EventHandler(this.FrmOrdenesCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaOrdenesCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenCompraBindingSource)).EndInit();
            this.Filtrarpor.ResumeLayout(false);
            this.Filtrarpor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GrillaOrdenesCompras;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.Button BTNAnular;
        private System.Windows.Forms.Button BTNConsulta;
        private System.Windows.Forms.BindingSource OrdenCompraBindingSource;
        private System.Windows.Forms.TextBox TXTFiltrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Filtrarpor;
        private System.Windows.Forms.RadioButton RBFecha;
        private System.Windows.Forms.RadioButton RBProveedor;
        private System.Windows.Forms.RadioButton RBCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormadeEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormadePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button BTNImprimir;
    }
}