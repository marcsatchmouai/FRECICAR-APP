namespace Vista
{
    partial class RealizarVenta
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
            this.BTNSeleccionarCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LBLCliente = new System.Windows.Forms.Label();
            this.DGVProductos = new System.Windows.Forms.DataGridView();
            this.BTNADD = new System.Windows.Forms.Button();
            this.BTNDEL = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.MTXTCantidad = new System.Windows.Forms.MaskedTextBox();
            this.DGVDetalle = new System.Windows.Forms.DataGridView();
            this.BTNRealizarVenta = new System.Windows.Forms.Button();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.LBLT = new System.Windows.Forms.Label();
            this.LBLTotal = new System.Windows.Forms.Label();
            this.CMBFormaPago = new System.Windows.Forms.ComboBox();
            this.CMBEnvio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LBLFecha = new System.Windows.Forms.Label();
            this.BTNDeshacer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNSeleccionarCliente
            // 
            this.BTNSeleccionarCliente.Location = new System.Drawing.Point(12, 12);
            this.BTNSeleccionarCliente.Name = "BTNSeleccionarCliente";
            this.BTNSeleccionarCliente.Size = new System.Drawing.Size(107, 23);
            this.BTNSeleccionarCliente.TabIndex = 0;
            this.BTNSeleccionarCliente.Text = "Seleccionar Cliente";
            this.BTNSeleccionarCliente.UseVisualStyleBackColor = true;
            this.BTNSeleccionarCliente.Click += new System.EventHandler(this.BTNSeleccionarCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Forma de Pago:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Envio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(592, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "----------------------------------";
            // 
            // LBLCliente
            // 
            this.LBLCliente.AutoSize = true;
            this.LBLCliente.Location = new System.Drawing.Point(60, 38);
            this.LBLCliente.Name = "LBLCliente";
            this.LBLCliente.Size = new System.Drawing.Size(0, 13);
            this.LBLCliente.TabIndex = 7;
            // 
            // DGVProductos
            // 
            this.DGVProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProductos.Location = new System.Drawing.Point(15, 67);
            this.DGVProductos.Name = "DGVProductos";
            this.DGVProductos.Size = new System.Drawing.Size(563, 109);
            this.DGVProductos.TabIndex = 8;
            // 
            // BTNADD
            // 
            this.BTNADD.Location = new System.Drawing.Point(186, 182);
            this.BTNADD.Name = "BTNADD";
            this.BTNADD.Size = new System.Drawing.Size(40, 23);
            this.BTNADD.TabIndex = 9;
            this.BTNADD.Text = "ADD";
            this.BTNADD.UseVisualStyleBackColor = true;
            this.BTNADD.Click += new System.EventHandler(this.BTNADD_Click);
            // 
            // BTNDEL
            // 
            this.BTNDEL.Location = new System.Drawing.Point(232, 182);
            this.BTNDEL.Name = "BTNDEL";
            this.BTNDEL.Size = new System.Drawing.Size(38, 23);
            this.BTNDEL.TabIndex = 10;
            this.BTNDEL.Text = "DEL";
            this.BTNDEL.UseVisualStyleBackColor = true;
            this.BTNDEL.Click += new System.EventHandler(this.BTNDEL_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cantidad:";
            // 
            // MTXTCantidad
            // 
            this.MTXTCantidad.Location = new System.Drawing.Point(70, 184);
            this.MTXTCantidad.Mask = "99999";
            this.MTXTCantidad.Name = "MTXTCantidad";
            this.MTXTCantidad.PromptChar = ' ';
            this.MTXTCantidad.Size = new System.Drawing.Size(100, 20);
            this.MTXTCantidad.TabIndex = 12;
            this.MTXTCantidad.ValidatingType = typeof(int);
            this.MTXTCantidad.Click += new System.EventHandler(this.MTXTCantidad_Click);
            // 
            // DGVDetalle
            // 
            this.DGVDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDetalle.Location = new System.Drawing.Point(12, 211);
            this.DGVDetalle.Name = "DGVDetalle";
            this.DGVDetalle.Size = new System.Drawing.Size(565, 107);
            this.DGVDetalle.TabIndex = 13;
            // 
            // BTNRealizarVenta
            // 
            this.BTNRealizarVenta.Location = new System.Drawing.Point(12, 337);
            this.BTNRealizarVenta.Name = "BTNRealizarVenta";
            this.BTNRealizarVenta.Size = new System.Drawing.Size(93, 37);
            this.BTNRealizarVenta.TabIndex = 14;
            this.BTNRealizarVenta.Text = "Realizar Venta";
            this.BTNRealizarVenta.UseVisualStyleBackColor = true;
            this.BTNRealizarVenta.Click += new System.EventHandler(this.BTNRealizarVenta_Click);
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Location = new System.Drawing.Point(503, 351);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(75, 23);
            this.BTNCancelar.TabIndex = 15;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // LBLT
            // 
            this.LBLT.AutoSize = true;
            this.LBLT.Location = new System.Drawing.Point(474, 321);
            this.LBLT.Name = "LBLT";
            this.LBLT.Size = new System.Drawing.Size(34, 13);
            this.LBLT.TabIndex = 16;
            this.LBLT.Text = "Total:";
            // 
            // LBLTotal
            // 
            this.LBLTotal.AutoSize = true;
            this.LBLTotal.Location = new System.Drawing.Point(514, 321);
            this.LBLTotal.Name = "LBLTotal";
            this.LBLTotal.Size = new System.Drawing.Size(0, 13);
            this.LBLTotal.TabIndex = 17;
            // 
            // CMBFormaPago
            // 
            this.CMBFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBFormaPago.FormattingEnabled = true;
            this.CMBFormaPago.Location = new System.Drawing.Point(276, 14);
            this.CMBFormaPago.Name = "CMBFormaPago";
            this.CMBFormaPago.Size = new System.Drawing.Size(121, 21);
            this.CMBFormaPago.TabIndex = 18;
            // 
            // CMBEnvio
            // 
            this.CMBEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBEnvio.FormattingEnabled = true;
            this.CMBEnvio.Location = new System.Drawing.Point(457, 14);
            this.CMBEnvio.Name = "CMBEnvio";
            this.CMBEnvio.Size = new System.Drawing.Size(121, 21);
            this.CMBEnvio.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Fecha:";
            // 
            // LBLFecha
            // 
            this.LBLFecha.AutoSize = true;
            this.LBLFecha.Location = new System.Drawing.Point(58, 321);
            this.LBLFecha.Name = "LBLFecha";
            this.LBLFecha.Size = new System.Drawing.Size(0, 13);
            this.LBLFecha.TabIndex = 21;
            // 
            // BTNDeshacer
            // 
            this.BTNDeshacer.Location = new System.Drawing.Point(503, 182);
            this.BTNDeshacer.Name = "BTNDeshacer";
            this.BTNDeshacer.Size = new System.Drawing.Size(75, 23);
            this.BTNDeshacer.TabIndex = 22;
            this.BTNDeshacer.Text = "Deshacer";
            this.BTNDeshacer.UseVisualStyleBackColor = true;
            this.BTNDeshacer.Click += new System.EventHandler(this.BTNDeshacer_Click);
            // 
            // RealizarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 380);
            this.Controls.Add(this.BTNDeshacer);
            this.Controls.Add(this.LBLFecha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CMBEnvio);
            this.Controls.Add(this.CMBFormaPago);
            this.Controls.Add(this.LBLTotal);
            this.Controls.Add(this.LBLT);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNRealizarVenta);
            this.Controls.Add(this.DGVDetalle);
            this.Controls.Add(this.MTXTCantidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BTNDEL);
            this.Controls.Add(this.BTNADD);
            this.Controls.Add(this.DGVProductos);
            this.Controls.Add(this.LBLCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNSeleccionarCliente);
            this.Name = "RealizarVenta";
            this.Text = "Realizar Venta";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNSeleccionarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LBLCliente;
        private System.Windows.Forms.DataGridView DGVProductos;
        private System.Windows.Forms.Button BTNADD;
        private System.Windows.Forms.Button BTNDEL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox MTXTCantidad;
        private System.Windows.Forms.DataGridView DGVDetalle;
        private System.Windows.Forms.Button BTNRealizarVenta;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.Label LBLT;
        private System.Windows.Forms.Label LBLTotal;
        private System.Windows.Forms.ComboBox CMBFormaPago;
        private System.Windows.Forms.ComboBox CMBEnvio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBLFecha;
        private System.Windows.Forms.Button BTNDeshacer;
    }
}