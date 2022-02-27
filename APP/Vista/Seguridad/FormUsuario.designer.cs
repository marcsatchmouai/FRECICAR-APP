namespace Vista.Seguridad
{
    partial class FormUsuario
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
            this.gBoxUsuario = new System.Windows.Forms.GroupBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblNombreApellido = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.txtNombreApellido = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.txtBoxNombreUsuario = new System.Windows.Forms.TextBox();
            this.gBoxUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxUsuario
            // 
            this.gBoxUsuario.Controls.Add(this.lblEmail);
            this.gBoxUsuario.Controls.Add(this.txtBoxEmail);
            this.gBoxUsuario.Controls.Add(this.btnGuardar);
            this.gBoxUsuario.Controls.Add(this.lblNombreApellido);
            this.gBoxUsuario.Controls.Add(this.btnCancelar);
            this.gBoxUsuario.Controls.Add(this.chkBoxHabilitado);
            this.gBoxUsuario.Controls.Add(this.txtNombreApellido);
            this.gBoxUsuario.Controls.Add(this.lblNombreUsuario);
            this.gBoxUsuario.Controls.Add(this.txtBoxNombreUsuario);
            this.gBoxUsuario.Location = new System.Drawing.Point(12, 12);
            this.gBoxUsuario.Name = "gBoxUsuario";
            this.gBoxUsuario.Size = new System.Drawing.Size(345, 211);
            this.gBoxUsuario.TabIndex = 5;
            this.gBoxUsuario.TabStop = false;
            this.gBoxUsuario.Text = "Usuario:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 102);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.Location = new System.Drawing.Point(113, 99);
            this.txtBoxEmail.MaxLength = 150;
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.Size = new System.Drawing.Size(208, 20);
            this.txtBoxEmail.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(9, 170);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblNombreApellido
            // 
            this.lblNombreApellido.AutoSize = true;
            this.lblNombreApellido.Location = new System.Drawing.Point(6, 66);
            this.lblNombreApellido.Name = "lblNombreApellido";
            this.lblNombreApellido.Size = new System.Drawing.Size(95, 13);
            this.lblNombreApellido.TabIndex = 8;
            this.lblNombreApellido.Text = "Nombre y Apellido:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(90, 170);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // chkBoxHabilitado
            // 
            this.chkBoxHabilitado.AutoSize = true;
            this.chkBoxHabilitado.Location = new System.Drawing.Point(113, 134);
            this.chkBoxHabilitado.Name = "chkBoxHabilitado";
            this.chkBoxHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkBoxHabilitado.TabIndex = 3;
            this.chkBoxHabilitado.Text = "Habilitado";
            this.chkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // txtNombreApellido
            // 
            this.txtNombreApellido.Location = new System.Drawing.Point(113, 63);
            this.txtNombreApellido.MaxLength = 50;
            this.txtNombreApellido.Name = "txtNombreApellido";
            this.txtNombreApellido.Size = new System.Drawing.Size(208, 20);
            this.txtNombreApellido.TabIndex = 1;
            this.txtNombreApellido.TextChanged += new System.EventHandler(this.txtNombreApellido_TextChanged);
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(6, 30);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(101, 13);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Nombre de Usuario:";
            // 
            // txtBoxNombreUsuario
            // 
            this.txtBoxNombreUsuario.Location = new System.Drawing.Point(113, 27);
            this.txtBoxNombreUsuario.MaxLength = 15;
            this.txtBoxNombreUsuario.Name = "txtBoxNombreUsuario";
            this.txtBoxNombreUsuario.Size = new System.Drawing.Size(208, 20);
            this.txtBoxNombreUsuario.TabIndex = 0;
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 234);
            this.ControlBox = false;
            this.Controls.Add(this.gBoxUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormUsuario";
            this.Text = "FormUsuario";
            this.Load += new System.EventHandler(this.FormUsuario_Load);
            this.gBoxUsuario.ResumeLayout(false);
            this.gBoxUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxUsuario;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtBoxEmail;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblNombreApellido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkBoxHabilitado;
        private System.Windows.Forms.TextBox txtNombreApellido;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtBoxNombreUsuario;

    }
}