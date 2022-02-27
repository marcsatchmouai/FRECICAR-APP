namespace Vista
{
    partial class CategoriasP
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
            this.TXTFiltro = new System.Windows.Forms.TextBox();
            this.GrillaCategoria = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.BTNEliminar = new System.Windows.Forms.Button();
            this.BTNModificar = new System.Windows.Forms.Button();
            this.BTNAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Buscar :";
            // 
            // TXTFiltro
            // 
            this.TXTFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTFiltro.Location = new System.Drawing.Point(60, 12);
            this.TXTFiltro.Name = "TXTFiltro";
            this.TXTFiltro.Size = new System.Drawing.Size(554, 20);
            this.TXTFiltro.TabIndex = 8;
            // 
            // GrillaCategoria
            // 
            this.GrillaCategoria.AllowUserToAddRows = false;
            this.GrillaCategoria.AllowUserToDeleteRows = false;
            this.GrillaCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Descripcion});
            this.GrillaCategoria.GridColor = System.Drawing.SystemColors.GrayText;
            this.GrillaCategoria.Location = new System.Drawing.Point(11, 41);
            this.GrillaCategoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GrillaCategoria.MultiSelect = false;
            this.GrillaCategoria.Name = "GrillaCategoria";
            this.GrillaCategoria.ReadOnly = true;
            this.GrillaCategoria.RowHeadersVisible = false;
            this.GrillaCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaCategoria.Size = new System.Drawing.Size(603, 265);
            this.GrillaCategoria.TabIndex = 9;
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
            this.BTNCancelar.Location = new System.Drawing.Point(515, 312);
            this.BTNCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(99, 28);
            this.BTNCancelar.TabIndex = 13;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click_1);
            // 
            // BTNEliminar
            // 
            this.BTNEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNEliminar.Location = new System.Drawing.Point(227, 312);
            this.BTNEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTNEliminar.Name = "BTNEliminar";
            this.BTNEliminar.Size = new System.Drawing.Size(99, 28);
            this.BTNEliminar.TabIndex = 12;
            this.BTNEliminar.Text = "Eliminar";
            this.BTNEliminar.UseVisualStyleBackColor = true;
            this.BTNEliminar.Click += new System.EventHandler(this.BTNEliminar_Click_1);
            // 
            // BTNModificar
            // 
            this.BTNModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNModificar.Location = new System.Drawing.Point(118, 312);
            this.BTNModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTNModificar.Name = "BTNModificar";
            this.BTNModificar.Size = new System.Drawing.Size(99, 28);
            this.BTNModificar.TabIndex = 11;
            this.BTNModificar.Text = "Modificar";
            this.BTNModificar.UseVisualStyleBackColor = true;
            this.BTNModificar.Click += new System.EventHandler(this.BTNModificar_Click_1);
            // 
            // BTNAceptar
            // 
            this.BTNAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNAceptar.Location = new System.Drawing.Point(11, 312);
            this.BTNAceptar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTNAceptar.Name = "BTNAceptar";
            this.BTNAceptar.Size = new System.Drawing.Size(99, 28);
            this.BTNAceptar.TabIndex = 10;
            this.BTNAceptar.Text = "Agregar";
            this.BTNAceptar.UseVisualStyleBackColor = true;
            this.BTNAceptar.Click += new System.EventHandler(this.BTNAceptar_Click_1);
            // 
            // FrmCategoriasProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 349);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTFiltro);
            this.Controls.Add(this.GrillaCategoria);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNEliminar);
            this.Controls.Add(this.BTNModificar);
            this.Controls.Add(this.BTNAceptar);
            this.Name = "CategoriasP";
            this.Text = "CategoriasProductos";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTFiltro;
        private System.Windows.Forms.DataGridView GrillaCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.Button BTNEliminar;
        private System.Windows.Forms.Button BTNModificar;
        private System.Windows.Forms.Button BTNAceptar;
    }
}