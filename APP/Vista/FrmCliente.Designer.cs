namespace Vista
{
    partial class FrmCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCliente));
            this.TXTRSocial = new System.Windows.Forms.TextBox();
            this.TXTDomicilio = new System.Windows.Forms.TextBox();
            this.TXTEmail = new System.Windows.Forms.TextBox();
            this.MTXTCuil = new System.Windows.Forms.MaskedTextBox();
            this.MTXTTelefono = new System.Windows.Forms.MaskedTextBox();
            this.CMBSFiscal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BTNGuardar = new System.Windows.Forms.Button();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.CMBProvincia = new System.Windows.Forms.ComboBox();
            this.CMBCiudad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TXTRSocial
            // 
            this.TXTRSocial.Location = new System.Drawing.Point(102, 12);
            this.TXTRSocial.Name = "TXTRSocial";
            this.TXTRSocial.Size = new System.Drawing.Size(304, 20);
            this.TXTRSocial.TabIndex = 0;
            // 
            // TXTDomicilio
            // 
            this.TXTDomicilio.Location = new System.Drawing.Point(102, 38);
            this.TXTDomicilio.Name = "TXTDomicilio";
            this.TXTDomicilio.Size = new System.Drawing.Size(304, 20);
            this.TXTDomicilio.TabIndex = 1;
            // 
            // TXTEmail
            // 
            this.TXTEmail.Location = new System.Drawing.Point(102, 64);
            this.TXTEmail.Name = "TXTEmail";
            this.TXTEmail.Size = new System.Drawing.Size(304, 20);
            this.TXTEmail.TabIndex = 2;
            // 
            // MTXTCuil
            // 
            this.MTXTCuil.Location = new System.Drawing.Point(102, 90);
            this.MTXTCuil.Mask = "00-00000000-0";
            this.MTXTCuil.Name = "MTXTCuil";
            this.MTXTCuil.Size = new System.Drawing.Size(304, 20);
            this.MTXTCuil.TabIndex = 3;
            // 
            // MTXTTelefono
            // 
            this.MTXTTelefono.Location = new System.Drawing.Point(102, 116);
            this.MTXTTelefono.Mask = "(999)000-0000";
            this.MTXTTelefono.Name = "MTXTTelefono";
            this.MTXTTelefono.Size = new System.Drawing.Size(304, 20);
            this.MTXTTelefono.TabIndex = 4;
            // 
            // CMBSFiscal
            // 
            this.CMBSFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBSFiscal.FormattingEnabled = true;
            this.CMBSFiscal.Location = new System.Drawing.Point(102, 142);
            this.CMBSFiscal.Name = "CMBSFiscal";
            this.CMBSFiscal.Size = new System.Drawing.Size(304, 21);
            this.CMBSFiscal.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Razon Social:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Domicilio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cuil:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Telefono:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Situacion Fiscal:";
            // 
            // BTNGuardar
            // 
            this.BTNGuardar.Location = new System.Drawing.Point(10, 224);
            this.BTNGuardar.Name = "BTNGuardar";
            this.BTNGuardar.Size = new System.Drawing.Size(75, 23);
            this.BTNGuardar.TabIndex = 8;
            this.BTNGuardar.Text = "Guardar";
            this.BTNGuardar.UseVisualStyleBackColor = true;
            this.BTNGuardar.Click += new System.EventHandler(this.BTNGuardar_Click);
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Location = new System.Drawing.Point(148, 224);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(258, 23);
            this.BTNCancelar.TabIndex = 9;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // CMBProvincia
            // 
            this.CMBProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CMBProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CMBProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBProvincia.FormattingEnabled = true;
            this.CMBProvincia.Items.AddRange(new object[] {
            "Seleccione una Provincia"});
            this.CMBProvincia.Location = new System.Drawing.Point(102, 172);
            this.CMBProvincia.Name = "CMBProvincia";
            this.CMBProvincia.Size = new System.Drawing.Size(304, 21);
            this.CMBProvincia.TabIndex = 6;
            this.CMBProvincia.SelectedIndexChanged += new System.EventHandler(this.CMBProvincia_SelectedIndexChanged);
            // 
            // CMBCiudad
            // 
            this.CMBCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBCiudad.FormattingEnabled = true;
            this.CMBCiudad.Location = new System.Drawing.Point(102, 196);
            this.CMBCiudad.Name = "CMBCiudad";
            this.CMBCiudad.Size = new System.Drawing.Size(304, 21);
            this.CMBCiudad.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Provincia:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Ciudad:";
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 259);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CMBCiudad);
            this.Controls.Add(this.CMBProvincia);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNGuardar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CMBSFiscal);
            this.Controls.Add(this.MTXTTelefono);
            this.Controls.Add(this.MTXTCuil);
            this.Controls.Add(this.TXTEmail);
            this.Controls.Add(this.TXTDomicilio);
            this.Controls.Add(this.TXTRSocial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCliente";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTRSocial;
        private System.Windows.Forms.TextBox TXTDomicilio;
        private System.Windows.Forms.TextBox TXTEmail;
        private System.Windows.Forms.MaskedTextBox MTXTCuil;
        private System.Windows.Forms.MaskedTextBox MTXTTelefono;
        private System.Windows.Forms.ComboBox CMBSFiscal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BTNGuardar;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.ComboBox CMBProvincia;
        private System.Windows.Forms.ComboBox CMBCiudad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}