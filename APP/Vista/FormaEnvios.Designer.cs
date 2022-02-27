namespace Vista
{
    partial class FormaEnvios
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
            this.GrillaFormadeEnvio = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.BTNEliminar = new System.Windows.Forms.Button();
            this.BTNModificar = new System.Windows.Forms.Button();
            this.BTNAceptar = new System.Windows.Forms.Button();
            this.TXTFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaFormadeEnvio)).BeginInit();
            this.SuspendLayout();
            // 
            // GrillaFormadeEnvio
            // 
            this.GrillaFormadeEnvio.AllowUserToAddRows = false;
            this.GrillaFormadeEnvio.AllowUserToDeleteRows = false;
            this.GrillaFormadeEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaFormadeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaFormadeEnvio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Descripcion});
            this.GrillaFormadeEnvio.Location = new System.Drawing.Point(12, 42);
            this.GrillaFormadeEnvio.MultiSelect = false;
            this.GrillaFormadeEnvio.Name = "GrillaFormadeEnvio";
            this.GrillaFormadeEnvio.ReadOnly = true;
            this.GrillaFormadeEnvio.RowHeadersVisible = false;
            this.GrillaFormadeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaFormadeEnvio.Size = new System.Drawing.Size(453, 206);
            this.GrillaFormadeEnvio.TabIndex = 2;
            this.GrillaFormadeEnvio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaFormadeEnvio_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCancelar.Location = new System.Drawing.Point(390, 254);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(75, 23);
            this.BTNCancelar.TabIndex = 6;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // BTNEliminar
            // 
            this.BTNEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNEliminar.Location = new System.Drawing.Point(174, 254);
            this.BTNEliminar.Name = "BTNEliminar";
            this.BTNEliminar.Size = new System.Drawing.Size(75, 23);
            this.BTNEliminar.TabIndex = 5;
            this.BTNEliminar.Text = "Eliminar";
            this.BTNEliminar.UseVisualStyleBackColor = true;
            this.BTNEliminar.Click += new System.EventHandler(this.BTNEliminar_Click);
            // 
            // BTNModificar
            // 
            this.BTNModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNModificar.Location = new System.Drawing.Point(93, 254);
            this.BTNModificar.Name = "BTNModificar";
            this.BTNModificar.Size = new System.Drawing.Size(75, 23);
            this.BTNModificar.TabIndex = 4;
            this.BTNModificar.Text = "Modificar";
            this.BTNModificar.UseVisualStyleBackColor = true;
            this.BTNModificar.Click += new System.EventHandler(this.BTNModificar_Click);
            // 
            // BTNAceptar
            // 
            this.BTNAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNAceptar.Location = new System.Drawing.Point(12, 254);
            this.BTNAceptar.Name = "BTNAceptar";
            this.BTNAceptar.Size = new System.Drawing.Size(75, 23);
            this.BTNAceptar.TabIndex = 3;
            this.BTNAceptar.Text = "Agregar";
            this.BTNAceptar.UseVisualStyleBackColor = true;
            this.BTNAceptar.Click += new System.EventHandler(this.BTNAceptar_Click);
            // 
            // TXTFiltro
            // 
            this.TXTFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTFiltro.Location = new System.Drawing.Point(61, 12);
            this.TXTFiltro.Name = "TXTFiltro";
            this.TXTFiltro.Size = new System.Drawing.Size(404, 20);
            this.TXTFiltro.TabIndex = 1;
            this.TXTFiltro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            // FormaEnvios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 284);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTFiltro);
            this.Controls.Add(this.GrillaFormadeEnvio);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNEliminar);
            this.Controls.Add(this.BTNModificar);
            this.Controls.Add(this.BTNAceptar);
            this.Name = "FormaEnvios";
            this.Text = "FormaEnvios";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaFormadeEnvio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GrillaFormadeEnvio;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.Button BTNEliminar;
        private System.Windows.Forms.Button BTNModificar;
        private System.Windows.Forms.Button BTNAceptar;
        private System.Windows.Forms.TextBox TXTFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
    }
}