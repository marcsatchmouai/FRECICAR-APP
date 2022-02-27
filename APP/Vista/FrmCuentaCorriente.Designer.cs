namespace Vista
{
    partial class FrmCuentaCorriente
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
            this.label1 = new System.Windows.Forms.Label();
            this.LBLSaldo = new System.Windows.Forms.Label();
            this.DGVMovimientos = new System.Windows.Forms.DataGridView();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.LBLCliente = new System.Windows.Forms.Label();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTFiltro = new System.Windows.Forms.TextBox();
            this.RBDebito = new System.Windows.Forms.RadioButton();
            this.RBCredito = new System.Windows.Forms.RadioButton();
            this.GBFiltro = new System.Windows.Forms.GroupBox();
            this.RBMonto = new System.Windows.Forms.RadioButton();
            this.RBDFecha = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMovimientos)).BeginInit();
            this.GBFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(231, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Saldo:";
            // 
            // LBLSaldo
            // 
            this.LBLSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBLSaldo.AutoSize = true;
            this.LBLSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLSaldo.Location = new System.Drawing.Point(290, 344);
            this.LBLSaldo.Name = "LBLSaldo";
            this.LBLSaldo.Size = new System.Drawing.Size(51, 16);
            this.LBLSaldo.TabIndex = 7;
            this.LBLSaldo.Text = "label2";
            // 
            // DGVMovimientos
            // 
            this.DGVMovimientos.AllowUserToAddRows = false;
            this.DGVMovimientos.AllowUserToDeleteRows = false;
            this.DGVMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Detalle,
            this.Importe,
            this.Fecha,
            this.TipoMovimiento});
            this.DGVMovimientos.Location = new System.Drawing.Point(12, 68);
            this.DGVMovimientos.Name = "DGVMovimientos";
            this.DGVMovimientos.ReadOnly = true;
            this.DGVMovimientos.RowHeadersVisible = false;
            this.DGVMovimientos.Size = new System.Drawing.Size(529, 251);
            this.DGVMovimientos.TabIndex = 2;
            this.DGVMovimientos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVMovimientos_CellFormatting);
            // 
            // Detalle
            // 
            this.Detalle.DataPropertyName = "Detalle";
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // TipoMovimiento
            // 
            this.TipoMovimiento.DataPropertyName = "TipoMovimiento";
            this.TipoMovimiento.HeaderText = "Tipo de Movimiento";
            this.TipoMovimiento.Name = "TipoMovimiento";
            this.TipoMovimiento.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cliente:";
            // 
            // LBLCliente
            // 
            this.LBLCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LBLCliente.AutoSize = true;
            this.LBLCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLCliente.Location = new System.Drawing.Point(77, 344);
            this.LBLCliente.Name = "LBLCliente";
            this.LBLCliente.Size = new System.Drawing.Size(51, 16);
            this.LBLCliente.TabIndex = 5;
            this.LBLCliente.Text = "label4";
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCancelar.Location = new System.Drawing.Point(444, 335);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(97, 27);
            this.BTNCancelar.TabIndex = 3;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Filtro:";
            // 
            // TXTFiltro
            // 
            this.TXTFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTFiltro.Location = new System.Drawing.Point(50, 6);
            this.TXTFiltro.Name = "TXTFiltro";
            this.TXTFiltro.Size = new System.Drawing.Size(491, 20);
            this.TXTFiltro.TabIndex = 0;
            this.TXTFiltro.TextChanged += new System.EventHandler(this.TXTFiltro_TextChanged);
            // 
            // RBDebito
            // 
            this.RBDebito.AutoSize = true;
            this.RBDebito.Location = new System.Drawing.Point(293, 13);
            this.RBDebito.Name = "RBDebito";
            this.RBDebito.Size = new System.Drawing.Size(56, 17);
            this.RBDebito.TabIndex = 2;
            this.RBDebito.TabStop = true;
            this.RBDebito.Text = "Debito";
            this.RBDebito.UseVisualStyleBackColor = true;
            this.RBDebito.CheckedChanged += new System.EventHandler(this.RBDebito_CheckedChanged);
            // 
            // RBCredito
            // 
            this.RBCredito.AutoSize = true;
            this.RBCredito.Location = new System.Drawing.Point(420, 13);
            this.RBCredito.Name = "RBCredito";
            this.RBCredito.Size = new System.Drawing.Size(58, 17);
            this.RBCredito.TabIndex = 3;
            this.RBCredito.TabStop = true;
            this.RBCredito.Text = "Credito";
            this.RBCredito.UseVisualStyleBackColor = true;
            this.RBCredito.CheckedChanged += new System.EventHandler(this.RBCredito_CheckedChanged);
            // 
            // GBFiltro
            // 
            this.GBFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GBFiltro.Controls.Add(this.RBCredito);
            this.GBFiltro.Controls.Add(this.RBMonto);
            this.GBFiltro.Controls.Add(this.RBDebito);
            this.GBFiltro.Controls.Add(this.RBDFecha);
            this.GBFiltro.Location = new System.Drawing.Point(12, 32);
            this.GBFiltro.Name = "GBFiltro";
            this.GBFiltro.Size = new System.Drawing.Size(529, 36);
            this.GBFiltro.TabIndex = 1;
            this.GBFiltro.TabStop = false;
            this.GBFiltro.Text = "Filtrar por:";
            // 
            // RBMonto
            // 
            this.RBMonto.AutoSize = true;
            this.RBMonto.Location = new System.Drawing.Point(69, 13);
            this.RBMonto.Name = "RBMonto";
            this.RBMonto.Size = new System.Drawing.Size(55, 17);
            this.RBMonto.TabIndex = 0;
            this.RBMonto.TabStop = true;
            this.RBMonto.Text = "Monto";
            this.RBMonto.UseVisualStyleBackColor = true;
            // 
            // RBDFecha
            // 
            this.RBDFecha.AutoSize = true;
            this.RBDFecha.Location = new System.Drawing.Point(171, 13);
            this.RBDFecha.Name = "RBDFecha";
            this.RBDFecha.Size = new System.Drawing.Size(55, 17);
            this.RBDFecha.TabIndex = 1;
            this.RBDFecha.TabStop = true;
            this.RBDFecha.Text = "Fecha";
            this.RBDFecha.UseVisualStyleBackColor = true;
            // 
            // FrmCuentaCorriente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(553, 374);
            this.Controls.Add(this.GBFiltro);
            this.Controls.Add(this.TXTFiltro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.LBLCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DGVMovimientos);
            this.Controls.Add(this.LBLSaldo);
            this.Controls.Add(this.label1);
            this.Name = "FrmCuentaCorriente";
            this.Text = "Cuenta Corriente";
            ((System.ComponentModel.ISupportInitialize)(this.DGVMovimientos)).EndInit();
            this.GBFiltro.ResumeLayout(false);
            this.GBFiltro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBLSaldo;
        private System.Windows.Forms.DataGridView DGVMovimientos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBLCliente;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTFiltro;
        private System.Windows.Forms.RadioButton RBDebito;
        private System.Windows.Forms.RadioButton RBCredito;
        private System.Windows.Forms.GroupBox GBFiltro;
        private System.Windows.Forms.RadioButton RBMonto;
        private System.Windows.Forms.RadioButton RBDFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoMovimiento;
    }
}