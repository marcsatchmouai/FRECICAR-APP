namespace Vista.Seguridad
{
    partial class FormSeguridad
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
            this.tabPerfiles = new System.Windows.Forms.TabPage();
            this.lblPermisosFormulario = new System.Windows.Forms.Label();
            this.lblFormulariosGrupo = new System.Windows.Forms.Label();
            this.lblPerfilGrupo = new System.Windows.Forms.Label();
            this.btnModificarPerfil = new System.Windows.Forms.Button();
            this.btnEliminarPerfil = new System.Windows.Forms.Button();
            this.btnAgregarPerfil = new System.Windows.Forms.Button();
            this.listBoxGrupos = new System.Windows.Forms.ListBox();
            this.listBoxFormularios = new System.Windows.Forms.ListBox();
            this.listBoxPermisos = new System.Windows.Forms.ListBox();
            this.txtFiltradoPerfiles = new System.Windows.Forms.TextBox();
            this.tabGrupos = new System.Windows.Forms.TabPage();
            this.btnModificarGrupo = new System.Windows.Forms.Button();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.btnConsultarGrupo = new System.Windows.Forms.Button();
            this.btnAgregarGrupo = new System.Windows.Forms.Button();
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFiltradoGrupos = new System.Windows.Forms.Label();
            this.txtFiltradoGrupos = new System.Windows.Forms.TextBox();
            this.tabUsuarios = new System.Windows.Forms.TabPage();
            this.btnResetearClave = new System.Windows.Forms.Button();
            this.btnGruposUsuarios = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnConsultarUsuario = new System.Windows.Forms.Button();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.NombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblUsuarioNombreApellido = new System.Windows.Forms.Label();
            this.txtFiltradoUsuarios = new System.Windows.Forms.TextBox();
            this.tabControlSeguridad = new System.Windows.Forms.TabControl();
            this.lblFiltradoPerfiles = new System.Windows.Forms.Label();
            this.tabPerfiles.SuspendLayout();
            this.tabGrupos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            this.tabUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tabControlSeguridad.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPerfiles
            // 
            this.tabPerfiles.Controls.Add(this.lblFiltradoPerfiles);
            this.tabPerfiles.Controls.Add(this.lblPermisosFormulario);
            this.tabPerfiles.Controls.Add(this.txtFiltradoPerfiles);
            this.tabPerfiles.Controls.Add(this.lblFormulariosGrupo);
            this.tabPerfiles.Controls.Add(this.lblPerfilGrupo);
            this.tabPerfiles.Controls.Add(this.btnModificarPerfil);
            this.tabPerfiles.Controls.Add(this.btnEliminarPerfil);
            this.tabPerfiles.Controls.Add(this.btnAgregarPerfil);
            this.tabPerfiles.Controls.Add(this.listBoxGrupos);
            this.tabPerfiles.Controls.Add(this.listBoxFormularios);
            this.tabPerfiles.Controls.Add(this.listBoxPermisos);
            this.tabPerfiles.Location = new System.Drawing.Point(4, 22);
            this.tabPerfiles.Name = "tabPerfiles";
            this.tabPerfiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPerfiles.Size = new System.Drawing.Size(807, 427);
            this.tabPerfiles.TabIndex = 2;
            this.tabPerfiles.Text = "Perfiles";
            this.tabPerfiles.UseVisualStyleBackColor = true;
            // 
            // lblPermisosFormulario
            // 
            this.lblPermisosFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPermisosFormulario.AutoSize = true;
            this.lblPermisosFormulario.Location = new System.Drawing.Point(480, 42);
            this.lblPermisosFormulario.Name = "lblPermisosFormulario";
            this.lblPermisosFormulario.Size = new System.Drawing.Size(162, 13);
            this.lblPermisosFormulario.TabIndex = 22;
            this.lblPermisosFormulario.Text = "Permisos asignados al formulario:";
            // 
            // lblFormulariosGrupo
            // 
            this.lblFormulariosGrupo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFormulariosGrupo.AutoSize = true;
            this.lblFormulariosGrupo.Location = new System.Drawing.Point(243, 42);
            this.lblFormulariosGrupo.Name = "lblFormulariosGrupo";
            this.lblFormulariosGrupo.Size = new System.Drawing.Size(155, 13);
            this.lblFormulariosGrupo.TabIndex = 21;
            this.lblFormulariosGrupo.Text = "Formularios asignados al grupo:";
            // 
            // lblPerfilGrupo
            // 
            this.lblPerfilGrupo.AutoSize = true;
            this.lblPerfilGrupo.Location = new System.Drawing.Point(6, 42);
            this.lblPerfilGrupo.Name = "lblPerfilGrupo";
            this.lblPerfilGrupo.Size = new System.Drawing.Size(44, 13);
            this.lblPerfilGrupo.TabIndex = 20;
            this.lblPerfilGrupo.Text = "Grupos:";
            // 
            // btnModificarPerfil
            // 
            this.btnModificarPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarPerfil.Location = new System.Drawing.Point(719, 118);
            this.btnModificarPerfil.Name = "btnModificarPerfil";
            this.btnModificarPerfil.Size = new System.Drawing.Size(75, 64);
            this.btnModificarPerfil.TabIndex = 18;
            this.btnModificarPerfil.Text = "&Modificar";
            this.btnModificarPerfil.UseVisualStyleBackColor = true;
            this.btnModificarPerfil.Click += new System.EventHandler(this.btnModificarPerfil_Click);
            // 
            // btnEliminarPerfil
            // 
            this.btnEliminarPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarPerfil.Location = new System.Drawing.Point(719, 212);
            this.btnEliminarPerfil.Name = "btnEliminarPerfil";
            this.btnEliminarPerfil.Size = new System.Drawing.Size(75, 64);
            this.btnEliminarPerfil.TabIndex = 19;
            this.btnEliminarPerfil.Text = "&Eliminar";
            this.btnEliminarPerfil.UseVisualStyleBackColor = true;
            this.btnEliminarPerfil.Click += new System.EventHandler(this.btnEliminarPerfil_Click);
            // 
            // btnAgregarPerfil
            // 
            this.btnAgregarPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarPerfil.Location = new System.Drawing.Point(719, 19);
            this.btnAgregarPerfil.Name = "btnAgregarPerfil";
            this.btnAgregarPerfil.Size = new System.Drawing.Size(75, 64);
            this.btnAgregarPerfil.TabIndex = 17;
            this.btnAgregarPerfil.Text = "&Agregar";
            this.btnAgregarPerfil.UseVisualStyleBackColor = true;
            this.btnAgregarPerfil.Click += new System.EventHandler(this.btnAgregarPerfil_Click);
            // 
            // listBoxGrupos
            // 
            this.listBoxGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxGrupos.FormattingEnabled = true;
            this.listBoxGrupos.Location = new System.Drawing.Point(6, 63);
            this.listBoxGrupos.Name = "listBoxGrupos";
            this.listBoxGrupos.Size = new System.Drawing.Size(231, 355);
            this.listBoxGrupos.TabIndex = 16;
            // 
            // listBoxFormularios
            // 
            this.listBoxFormularios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBoxFormularios.FormattingEnabled = true;
            this.listBoxFormularios.Location = new System.Drawing.Point(246, 63);
            this.listBoxFormularios.Name = "listBoxFormularios";
            this.listBoxFormularios.Size = new System.Drawing.Size(231, 355);
            this.listBoxFormularios.TabIndex = 15;
            // 
            // listBoxPermisos
            // 
            this.listBoxPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPermisos.FormattingEnabled = true;
            this.listBoxPermisos.Location = new System.Drawing.Point(483, 63);
            this.listBoxPermisos.Name = "listBoxPermisos";
            this.listBoxPermisos.Size = new System.Drawing.Size(225, 355);
            this.listBoxPermisos.TabIndex = 14;
            // 
            // txtFiltradoPerfiles
            // 
            this.txtFiltradoPerfiles.Location = new System.Drawing.Point(9, 19);
            this.txtFiltradoPerfiles.Name = "txtFiltradoPerfiles";
            this.txtFiltradoPerfiles.Size = new System.Drawing.Size(699, 20);
            this.txtFiltradoPerfiles.TabIndex = 1;
            this.txtFiltradoPerfiles.TextChanged += new System.EventHandler(this.txtFiltradoPerfiles_TextChanged);
            // 
            // tabGrupos
            // 
            this.tabGrupos.Controls.Add(this.lblFiltradoGrupos);
            this.tabGrupos.Controls.Add(this.btnModificarGrupo);
            this.tabGrupos.Controls.Add(this.txtFiltradoGrupos);
            this.tabGrupos.Controls.Add(this.btnEliminarGrupo);
            this.tabGrupos.Controls.Add(this.btnConsultarGrupo);
            this.tabGrupos.Controls.Add(this.btnAgregarGrupo);
            this.tabGrupos.Controls.Add(this.dgvGrupos);
            this.tabGrupos.Location = new System.Drawing.Point(4, 22);
            this.tabGrupos.Name = "tabGrupos";
            this.tabGrupos.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrupos.Size = new System.Drawing.Size(807, 427);
            this.tabGrupos.TabIndex = 1;
            this.tabGrupos.Text = "Grupos";
            this.tabGrupos.UseVisualStyleBackColor = true;
            // 
            // btnModificarGrupo
            // 
            this.btnModificarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarGrupo.Location = new System.Drawing.Point(711, 131);
            this.btnModificarGrupo.Name = "btnModificarGrupo";
            this.btnModificarGrupo.Size = new System.Drawing.Size(75, 64);
            this.btnModificarGrupo.TabIndex = 9;
            this.btnModificarGrupo.Text = "&Modificar";
            this.btnModificarGrupo.UseVisualStyleBackColor = true;
            this.btnModificarGrupo.Click += new System.EventHandler(this.btnModificarGrupo_Click);
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarGrupo.Location = new System.Drawing.Point(711, 243);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(75, 64);
            this.btnEliminarGrupo.TabIndex = 10;
            this.btnEliminarGrupo.Text = "&Eliminar";
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnConsultarGrupo
            // 
            this.btnConsultarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultarGrupo.Location = new System.Drawing.Point(711, 355);
            this.btnConsultarGrupo.Name = "btnConsultarGrupo";
            this.btnConsultarGrupo.Size = new System.Drawing.Size(75, 64);
            this.btnConsultarGrupo.TabIndex = 11;
            this.btnConsultarGrupo.Text = "&Consultar";
            this.btnConsultarGrupo.UseVisualStyleBackColor = true;
            this.btnConsultarGrupo.Click += new System.EventHandler(this.btnConsultarGrupo_Click);
            // 
            // btnAgregarGrupo
            // 
            this.btnAgregarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarGrupo.Location = new System.Drawing.Point(711, 19);
            this.btnAgregarGrupo.Name = "btnAgregarGrupo";
            this.btnAgregarGrupo.Size = new System.Drawing.Size(75, 64);
            this.btnAgregarGrupo.TabIndex = 8;
            this.btnAgregarGrupo.Text = "&Agregar";
            this.btnAgregarGrupo.UseVisualStyleBackColor = true;
            this.btnAgregarGrupo.Click += new System.EventHandler(this.btnAgregarGrupo_Click);
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            this.dgvGrupos.AllowUserToResizeRows = false;
            this.dgvGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvGrupos.Location = new System.Drawing.Point(6, 45);
            this.dgvGrupos.MultiSelect = false;
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.ReadOnly = true;
            this.dgvGrupos.RowHeadersVisible = false;
            this.dgvGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrupos.ShowEditingIcon = false;
            this.dgvGrupos.Size = new System.Drawing.Size(686, 376);
            this.dgvGrupos.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn1.FillWeight = 101.5228F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Grupo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn2.FillWeight = 98.47716F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // lblFiltradoGrupos
            // 
            this.lblFiltradoGrupos.AutoSize = true;
            this.lblFiltradoGrupos.Location = new System.Drawing.Point(6, 3);
            this.lblFiltradoGrupos.Name = "lblFiltradoGrupos";
            this.lblFiltradoGrupos.Size = new System.Drawing.Size(260, 13);
            this.lblFiltradoGrupos.TabIndex = 1;
            this.lblFiltradoGrupos.Text = "Ingrese el nombre del grupo o parte de la descripción:";
            // 
            // txtFiltradoGrupos
            // 
            this.txtFiltradoGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltradoGrupos.Location = new System.Drawing.Point(9, 19);
            this.txtFiltradoGrupos.Name = "txtFiltradoGrupos";
            this.txtFiltradoGrupos.Size = new System.Drawing.Size(683, 20);
            this.txtFiltradoGrupos.TabIndex = 1;
            this.txtFiltradoGrupos.TextChanged += new System.EventHandler(this.txtFiltradoGrupos_TextChanged);
            // 
            // tabUsuarios
            // 
            this.tabUsuarios.Controls.Add(this.lblUsuarioNombreApellido);
            this.tabUsuarios.Controls.Add(this.btnResetearClave);
            this.tabUsuarios.Controls.Add(this.txtFiltradoUsuarios);
            this.tabUsuarios.Controls.Add(this.btnGruposUsuarios);
            this.tabUsuarios.Controls.Add(this.btnModificarUsuario);
            this.tabUsuarios.Controls.Add(this.btnEliminarUsuario);
            this.tabUsuarios.Controls.Add(this.btnConsultarUsuario);
            this.tabUsuarios.Controls.Add(this.btnAgregarUsuario);
            this.tabUsuarios.Controls.Add(this.dgvUsuarios);
            this.tabUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tabUsuarios.Name = "tabUsuarios";
            this.tabUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsuarios.Size = new System.Drawing.Size(807, 427);
            this.tabUsuarios.TabIndex = 0;
            this.tabUsuarios.Text = "Usuarios";
            this.tabUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnResetearClave
            // 
            this.btnResetearClave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetearClave.Location = new System.Drawing.Point(712, 357);
            this.btnResetearClave.Name = "btnResetearClave";
            this.btnResetearClave.Size = new System.Drawing.Size(75, 64);
            this.btnResetearClave.TabIndex = 7;
            this.btnResetearClave.Text = "Resetear Clave";
            this.btnResetearClave.UseVisualStyleBackColor = true;
            this.btnResetearClave.Click += new System.EventHandler(this.btnResetearClave_Click);
            // 
            // btnGruposUsuarios
            // 
            this.btnGruposUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGruposUsuarios.Location = new System.Drawing.Point(712, 287);
            this.btnGruposUsuarios.Name = "btnGruposUsuarios";
            this.btnGruposUsuarios.Size = new System.Drawing.Size(75, 64);
            this.btnGruposUsuarios.TabIndex = 6;
            this.btnGruposUsuarios.Text = "&Grupos";
            this.btnGruposUsuarios.UseVisualStyleBackColor = true;
            this.btnGruposUsuarios.Click += new System.EventHandler(this.btnGruposUsuarios_Click);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarUsuario.Location = new System.Drawing.Point(712, 77);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(75, 64);
            this.btnModificarUsuario.TabIndex = 3;
            this.btnModificarUsuario.Text = "&Modificar";
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarUsuario.Location = new System.Drawing.Point(712, 147);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(75, 64);
            this.btnEliminarUsuario.TabIndex = 4;
            this.btnEliminarUsuario.Text = "&Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConsultarUsuario
            // 
            this.btnConsultarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultarUsuario.Location = new System.Drawing.Point(712, 217);
            this.btnConsultarUsuario.Name = "btnConsultarUsuario";
            this.btnConsultarUsuario.Size = new System.Drawing.Size(75, 64);
            this.btnConsultarUsuario.TabIndex = 5;
            this.btnConsultarUsuario.Text = "&Consultar";
            this.btnConsultarUsuario.UseVisualStyleBackColor = true;
            this.btnConsultarUsuario.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarUsuario.Location = new System.Drawing.Point(712, 7);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(75, 64);
            this.btnAgregarUsuario.TabIndex = 2;
            this.btnAgregarUsuario.Text = "&Agregar";
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreUsuario,
            this.NombreApellido,
            this.colMail,
            this.Habilitado,
            this.Activo});
            this.dgvUsuarios.Location = new System.Drawing.Point(7, 49);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.ShowEditingIcon = false;
            this.dgvUsuarios.Size = new System.Drawing.Size(686, 372);
            this.dgvUsuarios.TabIndex = 1;
            // 
            // NombreUsuario
            // 
            this.NombreUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NombreUsuario.DataPropertyName = "NombreUsuario";
            this.NombreUsuario.HeaderText = "Usuario";
            this.NombreUsuario.MaxInputLength = 15;
            this.NombreUsuario.Name = "NombreUsuario";
            this.NombreUsuario.ReadOnly = true;
            this.NombreUsuario.Width = 68;
            // 
            // NombreApellido
            // 
            this.NombreApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreApellido.DataPropertyName = "NombreApellido";
            this.NombreApellido.HeaderText = "Nombre y Apellido";
            this.NombreApellido.Name = "NombreApellido";
            this.NombreApellido.ReadOnly = true;
            // 
            // colMail
            // 
            this.colMail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMail.DataPropertyName = "Email";
            this.colMail.HeaderText = "Email";
            this.colMail.Name = "colMail";
            this.colMail.ReadOnly = true;
            // 
            // Habilitado
            // 
            this.Habilitado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Habilitado.DataPropertyName = "Habilitado";
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            this.Habilitado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Habilitado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Habilitado.Width = 79;
            // 
            // Activo
            // 
            this.Activo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Activo.DataPropertyName = "Activo";
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            this.Activo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Activo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Activo.Width = 62;
            // 
            // lblUsuarioNombreApellido
            // 
            this.lblUsuarioNombreApellido.AutoSize = true;
            this.lblUsuarioNombreApellido.Location = new System.Drawing.Point(6, 7);
            this.lblUsuarioNombreApellido.Name = "lblUsuarioNombreApellido";
            this.lblUsuarioNombreApellido.Size = new System.Drawing.Size(240, 13);
            this.lblUsuarioNombreApellido.TabIndex = 1;
            this.lblUsuarioNombreApellido.Text = "Ingrese el nombre de usuario o nombre y apellido:";
            // 
            // txtFiltradoUsuarios
            // 
            this.txtFiltradoUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltradoUsuarios.Location = new System.Drawing.Point(9, 23);
            this.txtFiltradoUsuarios.Name = "txtFiltradoUsuarios";
            this.txtFiltradoUsuarios.Size = new System.Drawing.Size(684, 20);
            this.txtFiltradoUsuarios.TabIndex = 1;
            this.txtFiltradoUsuarios.TextChanged += new System.EventHandler(this.txtFiltradoUsuarios_TextChanged);
            // 
            // tabControlSeguridad
            // 
            this.tabControlSeguridad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSeguridad.Controls.Add(this.tabUsuarios);
            this.tabControlSeguridad.Controls.Add(this.tabGrupos);
            this.tabControlSeguridad.Controls.Add(this.tabPerfiles);
            this.tabControlSeguridad.Location = new System.Drawing.Point(12, 12);
            this.tabControlSeguridad.Name = "tabControlSeguridad";
            this.tabControlSeguridad.SelectedIndex = 0;
            this.tabControlSeguridad.Size = new System.Drawing.Size(815, 453);
            this.tabControlSeguridad.TabIndex = 0;
            // 
            // lblFiltradoPerfiles
            // 
            this.lblFiltradoPerfiles.AutoSize = true;
            this.lblFiltradoPerfiles.Location = new System.Drawing.Point(6, 3);
            this.lblFiltradoPerfiles.Name = "lblFiltradoPerfiles";
            this.lblFiltradoPerfiles.Size = new System.Drawing.Size(358, 13);
            this.lblFiltradoPerfiles.TabIndex = 1;
            this.lblFiltradoPerfiles.Text = "Ingrese el nombre del grupo o el nombre del formulario o el tipo de permiso:";
            // 
            // FormSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 477);
            this.Controls.Add(this.tabControlSeguridad);
            this.Name = "FormSeguridad";
            this.Text = "Seguridad";
            this.Load += new System.EventHandler(this.FormSeguridad_Load);
            this.tabPerfiles.ResumeLayout(false);
            this.tabPerfiles.PerformLayout();
            this.tabGrupos.ResumeLayout(false);
            this.tabGrupos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            this.tabUsuarios.ResumeLayout(false);
            this.tabUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tabControlSeguridad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPerfiles;
        private System.Windows.Forms.TextBox txtFiltradoPerfiles;
        private System.Windows.Forms.TabPage tabGrupos;
        private System.Windows.Forms.Button btnModificarGrupo;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.Button btnConsultarGrupo;
        private System.Windows.Forms.Button btnAgregarGrupo;
        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lblFiltradoGrupos;
        private System.Windows.Forms.TextBox txtFiltradoGrupos;
        private System.Windows.Forms.TabPage tabUsuarios;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnConsultarUsuario;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblUsuarioNombreApellido;
        private System.Windows.Forms.TextBox txtFiltradoUsuarios;
        private System.Windows.Forms.TabControl tabControlSeguridad;
        private System.Windows.Forms.ListBox listBoxPermisos;
        private System.Windows.Forms.ListBox listBoxFormularios;
        private System.Windows.Forms.ListBox listBoxGrupos;
        private System.Windows.Forms.Button btnModificarPerfil;
        private System.Windows.Forms.Button btnEliminarPerfil;
        private System.Windows.Forms.Button btnAgregarPerfil;
        private System.Windows.Forms.Label lblPermisosFormulario;
        private System.Windows.Forms.Label lblFormulariosGrupo;
        private System.Windows.Forms.Label lblPerfilGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilitado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activo;
        private System.Windows.Forms.Button btnGruposUsuarios;
        private System.Windows.Forms.Button btnResetearClave;
        private System.Windows.Forms.Label lblFiltradoPerfiles;

    }
}