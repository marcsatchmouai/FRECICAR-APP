namespace Vista
{
    partial class Ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventas));
            this.BTNImprimir = new System.Windows.Forms.Button();
            this.Filtrarpor = new System.Windows.Forms.GroupBox();
            this.RBCodigo = new System.Windows.Forms.RadioButton();
            this.RBFecha = new System.Windows.Forms.RadioButton();
            this.RBProveedor = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTFiltrar = new System.Windows.Forms.TextBox();
            this.BTNConsulta = new System.Windows.Forms.Button();
            this.GrillaVentas = new System.Windows.Forms.DataGridView();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.BTNAnular = new System.Windows.Forms.Button();
            this.Filtrarpor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNImprimir
            // 
            this.BTNImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNImprimir.Location = new System.Drawing.Point(174, 397);
            this.BTNImprimir.Name = "BTNImprimir";
            this.BTNImprimir.Size = new System.Drawing.Size(75, 23);
            this.BTNImprimir.TabIndex = 5;
            this.BTNImprimir.Text = "Imprimir";
            this.BTNImprimir.UseVisualStyleBackColor = true;
            this.BTNImprimir.Click += new System.EventHandler(this.BTNImprimir_Click);
            // 
            // Filtrarpor
            // 
            this.Filtrarpor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Filtrarpor.Controls.Add(this.RBCodigo);
            this.Filtrarpor.Controls.Add(this.RBFecha);
            this.Filtrarpor.Controls.Add(this.RBProveedor);
            this.Filtrarpor.Location = new System.Drawing.Point(12, 38);
            this.Filtrarpor.Name = "Filtrarpor";
            this.Filtrarpor.Size = new System.Drawing.Size(741, 36);
            this.Filtrarpor.TabIndex = 1;
            this.Filtrarpor.TabStop = false;
            this.Filtrarpor.Text = "Filtrar por";
            // 
            // RBCodigo
            // 
            this.RBCodigo.AutoSize = true;
            this.RBCodigo.Location = new System.Drawing.Point(596, 13);
            this.RBCodigo.Name = "RBCodigo";
            this.RBCodigo.Size = new System.Drawing.Size(58, 17);
            this.RBCodigo.TabIndex = 2;
            this.RBCodigo.Text = "Codigo";
            this.RBCodigo.UseVisualStyleBackColor = true;
            // 
            // RBFecha
            // 
            this.RBFecha.AutoSize = true;
            this.RBFecha.Location = new System.Drawing.Point(317, 13);
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
            this.RBProveedor.Size = new System.Drawing.Size(57, 17);
            this.RBProveedor.TabIndex = 0;
            this.RBProveedor.TabStop = true;
            this.RBProveedor.Text = "Cliente";
            this.RBProveedor.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Buscar:";
            // 
            // TXTFiltrar
            // 
            this.TXTFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTFiltrar.Location = new System.Drawing.Point(58, 12);
            this.TXTFiltrar.Name = "TXTFiltrar";
            this.TXTFiltrar.Size = new System.Drawing.Size(695, 20);
            this.TXTFiltrar.TabIndex = 0;
            this.TXTFiltrar.TextChanged += new System.EventHandler(this.TXTFiltrar_TextChanged);
            // 
            // BTNConsulta
            // 
            this.BTNConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNConsulta.Location = new System.Drawing.Point(93, 397);
            this.BTNConsulta.Name = "BTNConsulta";
            this.BTNConsulta.Size = new System.Drawing.Size(75, 23);
            this.BTNConsulta.TabIndex = 4;
            this.BTNConsulta.Text = "Consultar";
            this.BTNConsulta.UseVisualStyleBackColor = true;
            this.BTNConsulta.Click += new System.EventHandler(this.BTNConsulta_Click);
            // 
            // GrillaVentas
            // 
            this.GrillaVentas.AllowUserToAddRows = false;
            this.GrillaVentas.AllowUserToDeleteRows = false;
            this.GrillaVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaVentas.Location = new System.Drawing.Point(9, 80);
            this.GrillaVentas.MultiSelect = false;
            this.GrillaVentas.Name = "GrillaVentas";
            this.GrillaVentas.ReadOnly = true;
            this.GrillaVentas.RowHeadersVisible = false;
            this.GrillaVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaVentas.Size = new System.Drawing.Size(744, 311);
            this.GrillaVentas.TabIndex = 2;
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCancelar.Location = new System.Drawing.Point(678, 397);
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
            this.BTNAnular.Location = new System.Drawing.Point(12, 397);
            this.BTNAnular.Name = "BTNAnular";
            this.BTNAnular.Size = new System.Drawing.Size(75, 23);
            this.BTNAnular.TabIndex = 3;
            this.BTNAnular.Text = "Anular";
            this.BTNAnular.UseVisualStyleBackColor = true;
            this.BTNAnular.Click += new System.EventHandler(this.BTNAnular_Click);
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 432);
            this.Controls.Add(this.BTNImprimir);
            this.Controls.Add(this.Filtrarpor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTFiltrar);
            this.Controls.Add(this.BTNConsulta);
            this.Controls.Add(this.GrillaVentas);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNAnular);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ventas";
            this.Text = "FrmGestionarVentas";
            this.Filtrarpor.ResumeLayout(false);
            this.Filtrarpor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNImprimir;
        private System.Windows.Forms.GroupBox Filtrarpor;
        private System.Windows.Forms.RadioButton RBCodigo;
        private System.Windows.Forms.RadioButton RBFecha;
        private System.Windows.Forms.RadioButton RBProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTFiltrar;
        private System.Windows.Forms.Button BTNConsulta;
        private System.Windows.Forms.DataGridView GrillaVentas;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.Button BTNAnular;
    }
}