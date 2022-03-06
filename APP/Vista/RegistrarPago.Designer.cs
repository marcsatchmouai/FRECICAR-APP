namespace Vista
{
    partial class RegistrarPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarPago));
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MSKImporte = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CMBCliente = new System.Windows.Forms.ComboBox();
            this.BTNAgregar = new System.Windows.Forms.Button();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTDetalle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CMBVenta = new System.Windows.Forms.ComboBox();
            this.BTNVerCC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DTPFecha
            // 
            this.DTPFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTPFecha.Location = new System.Drawing.Point(58, 12);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(219, 20);
            this.DTPFecha.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Importe:";
            // 
            // MSKImporte
            // 
            this.MSKImporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MSKImporte.Location = new System.Drawing.Point(58, 38);
            this.MSKImporte.Name = "MSKImporte";
            this.MSKImporte.PromptChar = ' ';
            this.MSKImporte.Size = new System.Drawing.Size(111, 20);
            this.MSKImporte.TabIndex = 1;
            this.MSKImporte.Click += new System.EventHandler(this.MSKImporte_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cliente:";
            // 
            // CMBCliente
            // 
            this.CMBCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CMBCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBCliente.FormattingEnabled = true;
            this.CMBCliente.Location = new System.Drawing.Point(58, 64);
            this.CMBCliente.Name = "CMBCliente";
            this.CMBCliente.Size = new System.Drawing.Size(153, 21);
            this.CMBCliente.TabIndex = 2;
            this.CMBCliente.SelectedIndexChanged += new System.EventHandler(this.CMBCliente_SelectedIndexChanged);
            // 
            // BTNAgregar
            // 
            this.BTNAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNAgregar.Location = new System.Drawing.Point(10, 195);
            this.BTNAgregar.Name = "BTNAgregar";
            this.BTNAgregar.Size = new System.Drawing.Size(75, 23);
            this.BTNAgregar.TabIndex = 6;
            this.BTNAgregar.Text = "Agregar";
            this.BTNAgregar.UseVisualStyleBackColor = true;
            this.BTNAgregar.Click += new System.EventHandler(this.BTNAgregar_Click);
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCancelar.Location = new System.Drawing.Point(202, 195);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(75, 23);
            this.BTNCancelar.TabIndex = 7;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Detalle:";
            // 
            // TXTDetalle
            // 
            this.TXTDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTDetalle.Location = new System.Drawing.Point(58, 91);
            this.TXTDetalle.Multiline = true;
            this.TXTDetalle.Name = "TXTDetalle";
            this.TXTDetalle.Size = new System.Drawing.Size(219, 61);
            this.TXTDetalle.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Venta:";
            // 
            // CMBVenta
            // 
            this.CMBVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CMBVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBVenta.FormattingEnabled = true;
            this.CMBVenta.Location = new System.Drawing.Point(58, 158);
            this.CMBVenta.Name = "CMBVenta";
            this.CMBVenta.Size = new System.Drawing.Size(219, 21);
            this.CMBVenta.TabIndex = 5;
            // 
            // BTNVerCC
            // 
            this.BTNVerCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNVerCC.Location = new System.Drawing.Point(212, 64);
            this.BTNVerCC.Name = "BTNVerCC";
            this.BTNVerCC.Size = new System.Drawing.Size(65, 21);
            this.BTNVerCC.TabIndex = 3;
            this.BTNVerCC.Text = "Ver C.C";
            this.BTNVerCC.UseVisualStyleBackColor = true;
            this.BTNVerCC.Click += new System.EventHandler(this.BTNVerCC_Click);
            // 
            // RegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 230);
            this.Controls.Add(this.BTNVerCC);
            this.Controls.Add(this.CMBVenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TXTDetalle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNAgregar);
            this.Controls.Add(this.CMBCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MSKImporte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTPFecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrarPago";
            this.Text = "Pago";
            this.Load += new System.EventHandler(this.FrmPago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox MSKImporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CMBCliente;
        private System.Windows.Forms.Button BTNAgregar;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTDetalle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CMBVenta;
        private System.Windows.Forms.Button BTNVerCC;
    }
}