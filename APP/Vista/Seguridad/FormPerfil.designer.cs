namespace Vista.Seguridad
{
    partial class FormPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPerfil));
            this.comboBoxGrupos = new System.Windows.Forms.ComboBox();
            this.comboBoxFormularios = new System.Windows.Forms.ComboBox();
            this.comboBoxPermisos = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.listBoxFormularios = new System.Windows.Forms.ListBox();
            this.listBoxPermisos = new System.Windows.Forms.ListBox();
            this.btnAgregarFormulario = new System.Windows.Forms.Button();
            this.btnEliminarFormulario = new System.Windows.Forms.Button();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.btnEliminarPermiso = new System.Windows.Forms.Button();
            this.lblGrupos = new System.Windows.Forms.Label();
            this.lblPermisos = new System.Windows.Forms.Label();
            this.lblFormularios = new System.Windows.Forms.Label();
            this.lblGrupoSeleccionado = new System.Windows.Forms.Label();
            this.btnAceptarPerfil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxGrupos
            // 
            this.comboBoxGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupos.FormattingEnabled = true;
            this.comboBoxGrupos.Location = new System.Drawing.Point(12, 36);
            this.comboBoxGrupos.Name = "comboBoxGrupos";
            this.comboBoxGrupos.Size = new System.Drawing.Size(183, 21);
            this.comboBoxGrupos.TabIndex = 0;
            // 
            // comboBoxFormularios
            // 
            this.comboBoxFormularios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormularios.FormattingEnabled = true;
            this.comboBoxFormularios.Location = new System.Drawing.Point(201, 36);
            this.comboBoxFormularios.Name = "comboBoxFormularios";
            this.comboBoxFormularios.Size = new System.Drawing.Size(183, 21);
            this.comboBoxFormularios.TabIndex = 6;
            // 
            // comboBoxPermisos
            // 
            this.comboBoxPermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPermisos.FormattingEnabled = true;
            this.comboBoxPermisos.Location = new System.Drawing.Point(390, 36);
            this.comboBoxPermisos.Name = "comboBoxPermisos";
            this.comboBoxPermisos.Size = new System.Drawing.Size(183, 21);
            this.comboBoxPermisos.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 166);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 57);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "&Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(120, 166);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 57);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // listBoxFormularios
            // 
            this.listBoxFormularios.FormattingEnabled = true;
            this.listBoxFormularios.Location = new System.Drawing.Point(201, 63);
            this.listBoxFormularios.Name = "listBoxFormularios";
            this.listBoxFormularios.Size = new System.Drawing.Size(183, 134);
            this.listBoxFormularios.TabIndex = 7;
            this.listBoxFormularios.SelectedIndexChanged += new System.EventHandler(this.listBoxFormularios_SelectedIndexChanged);
            // 
            // listBoxPermisos
            // 
            this.listBoxPermisos.FormattingEnabled = true;
            this.listBoxPermisos.Location = new System.Drawing.Point(390, 63);
            this.listBoxPermisos.Name = "listBoxPermisos";
            this.listBoxPermisos.Size = new System.Drawing.Size(183, 134);
            this.listBoxPermisos.TabIndex = 8;
            this.listBoxPermisos.SelectedIndexChanged += new System.EventHandler(this.listBoxPermisos_SelectedIndexChanged);
            // 
            // btnAgregarFormulario
            // 
            this.btnAgregarFormulario.Location = new System.Drawing.Point(201, 200);
            this.btnAgregarFormulario.Name = "btnAgregarFormulario";
            this.btnAgregarFormulario.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarFormulario.TabIndex = 2;
            this.btnAgregarFormulario.Text = "Agregar";
            this.btnAgregarFormulario.UseVisualStyleBackColor = true;
            this.btnAgregarFormulario.Click += new System.EventHandler(this.btnAgregarFormulario_Click);
            // 
            // btnEliminarFormulario
            // 
            this.btnEliminarFormulario.Location = new System.Drawing.Point(309, 200);
            this.btnEliminarFormulario.Name = "btnEliminarFormulario";
            this.btnEliminarFormulario.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarFormulario.TabIndex = 3;
            this.btnEliminarFormulario.Text = "Eliminar";
            this.btnEliminarFormulario.UseVisualStyleBackColor = true;
            this.btnEliminarFormulario.Click += new System.EventHandler(this.btnEliminarFormulario_Click);
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.Location = new System.Drawing.Point(391, 200);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarPermiso.TabIndex = 4;
            this.btnAgregarPermiso.Text = "Agregar";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.Location = new System.Drawing.Point(499, 200);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarPermiso.TabIndex = 5;
            this.btnEliminarPermiso.Text = "Eliminar";
            this.btnEliminarPermiso.UseVisualStyleBackColor = true;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.btnEliminarPermiso_Click);
            // 
            // lblGrupos
            // 
            this.lblGrupos.AutoSize = true;
            this.lblGrupos.Location = new System.Drawing.Point(13, 17);
            this.lblGrupos.Name = "lblGrupos";
            this.lblGrupos.Size = new System.Drawing.Size(44, 13);
            this.lblGrupos.TabIndex = 13;
            this.lblGrupos.Text = "Grupos:";
            // 
            // lblPermisos
            // 
            this.lblPermisos.AutoSize = true;
            this.lblPermisos.Location = new System.Drawing.Point(391, 17);
            this.lblPermisos.Name = "lblPermisos";
            this.lblPermisos.Size = new System.Drawing.Size(52, 13);
            this.lblPermisos.TabIndex = 14;
            this.lblPermisos.Text = "Permisos:";
            // 
            // lblFormularios
            // 
            this.lblFormularios.AutoSize = true;
            this.lblFormularios.Location = new System.Drawing.Point(201, 17);
            this.lblFormularios.Name = "lblFormularios";
            this.lblFormularios.Size = new System.Drawing.Size(63, 13);
            this.lblFormularios.TabIndex = 15;
            this.lblFormularios.Text = "Formularios:";
            // 
            // lblGrupoSeleccionado
            // 
            this.lblGrupoSeleccionado.AutoSize = true;
            this.lblGrupoSeleccionado.Location = new System.Drawing.Point(13, 63);
            this.lblGrupoSeleccionado.Name = "lblGrupoSeleccionado";
            this.lblGrupoSeleccionado.Size = new System.Drawing.Size(108, 13);
            this.lblGrupoSeleccionado.TabIndex = 16;
            this.lblGrupoSeleccionado.Text = "Grupo seleccionado: ";
            // 
            // btnAceptarPerfil
            // 
            this.btnAceptarPerfil.Location = new System.Drawing.Point(12, 109);
            this.btnAceptarPerfil.Name = "btnAceptarPerfil";
            this.btnAceptarPerfil.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarPerfil.TabIndex = 1;
            this.btnAceptarPerfil.Text = "Aceptar";
            this.btnAceptarPerfil.UseVisualStyleBackColor = true;
            this.btnAceptarPerfil.Click += new System.EventHandler(this.btnAceptarPerfil_Click);
            // 
            // FormPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 235);
            this.Controls.Add(this.btnAceptarPerfil);
            this.Controls.Add(this.lblGrupoSeleccionado);
            this.Controls.Add(this.lblFormularios);
            this.Controls.Add(this.lblPermisos);
            this.Controls.Add(this.lblGrupos);
            this.Controls.Add(this.btnEliminarPermiso);
            this.Controls.Add(this.btnAgregarPermiso);
            this.Controls.Add(this.btnEliminarFormulario);
            this.Controls.Add(this.btnAgregarFormulario);
            this.Controls.Add(this.listBoxPermisos);
            this.Controls.Add(this.listBoxFormularios);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.comboBoxPermisos);
            this.Controls.Add(this.comboBoxFormularios);
            this.Controls.Add(this.comboBoxGrupos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPerfil";
            this.Text = "FormPerfil";
            this.Load += new System.EventHandler(this.FormPerfil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxGrupos;
        private System.Windows.Forms.ComboBox comboBoxFormularios;
        private System.Windows.Forms.ComboBox comboBoxPermisos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ListBox listBoxFormularios;
        private System.Windows.Forms.ListBox listBoxPermisos;
        private System.Windows.Forms.Button btnAgregarFormulario;
        private System.Windows.Forms.Button btnEliminarFormulario;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.Button btnEliminarPermiso;
        private System.Windows.Forms.Label lblGrupos;
        private System.Windows.Forms.Label lblPermisos;
        private System.Windows.Forms.Label lblFormularios;
        private System.Windows.Forms.Label lblGrupoSeleccionado;
        private System.Windows.Forms.Button btnAceptarPerfil;
    }
}