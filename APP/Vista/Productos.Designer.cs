namespace Vista
{
    partial class Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Productos));
            this.BTNAgregar = new System.Windows.Forms.Button();
            this.BTNModificar = new System.Windows.Forms.Button();
            this.BTNEliminar = new System.Windows.Forms.Button();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.DGVProducto = new System.Windows.Forms.DataGridView();
            this.TXTBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBDescripcion = new System.Windows.Forms.RadioButton();
            this.RBCategoria = new System.Windows.Forms.RadioButton();
            this.RBCodigo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProducto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTNAgregar
            // 
            this.BTNAgregar.Enabled = false;
            this.BTNAgregar.Location = new System.Drawing.Point(12, 263);
            this.BTNAgregar.Name = "BTNAgregar";
            this.BTNAgregar.Size = new System.Drawing.Size(75, 23);
            this.BTNAgregar.TabIndex = 0;
            this.BTNAgregar.Text = "Agregar";
            this.BTNAgregar.UseVisualStyleBackColor = true;
            this.BTNAgregar.Click += new System.EventHandler(this.BTNAgregar_Click);
            // 
            // BTNModificar
            // 
            this.BTNModificar.Enabled = false;
            this.BTNModificar.Location = new System.Drawing.Point(93, 263);
            this.BTNModificar.Name = "BTNModificar";
            this.BTNModificar.Size = new System.Drawing.Size(75, 23);
            this.BTNModificar.TabIndex = 1;
            this.BTNModificar.Text = "Modificar";
            this.BTNModificar.UseVisualStyleBackColor = true;
            this.BTNModificar.Click += new System.EventHandler(this.BTNModificar_Click);
            // 
            // BTNEliminar
            // 
            this.BTNEliminar.Enabled = false;
            this.BTNEliminar.Location = new System.Drawing.Point(174, 263);
            this.BTNEliminar.Name = "BTNEliminar";
            this.BTNEliminar.Size = new System.Drawing.Size(75, 23);
            this.BTNEliminar.TabIndex = 2;
            this.BTNEliminar.Text = "Eliminar";
            this.BTNEliminar.UseVisualStyleBackColor = true;
            this.BTNEliminar.Click += new System.EventHandler(this.BTNEliminar_Click);
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Location = new System.Drawing.Point(405, 263);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(80, 23);
            this.BTNCancelar.TabIndex = 3;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // DGVProducto
            // 
            this.DGVProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProducto.Location = new System.Drawing.Point(15, 84);
            this.DGVProducto.Name = "DGVProducto";
            this.DGVProducto.Size = new System.Drawing.Size(470, 173);
            this.DGVProducto.TabIndex = 4;
            // 
            // TXTBuscar
            // 
            this.TXTBuscar.Location = new System.Drawing.Point(64, 12);
            this.TXTBuscar.Name = "TXTBuscar";
            this.TXTBuscar.Size = new System.Drawing.Size(421, 20);
            this.TXTBuscar.TabIndex = 5;
            this.TXTBuscar.TextChanged += new System.EventHandler(this.TXTBuscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBDescripcion);
            this.groupBox1.Controls.Add(this.RBCategoria);
            this.groupBox1.Controls.Add(this.RBCodigo);
            this.groupBox1.Location = new System.Drawing.Point(15, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por";
            // 
            // RBDescripcion
            // 
            this.RBDescripcion.AutoSize = true;
            this.RBDescripcion.Location = new System.Drawing.Point(324, 17);
            this.RBDescripcion.Name = "RBDescripcion";
            this.RBDescripcion.Size = new System.Drawing.Size(81, 17);
            this.RBDescripcion.TabIndex = 10;
            this.RBDescripcion.TabStop = true;
            this.RBDescripcion.Text = "Descripcion";
            this.RBDescripcion.UseVisualStyleBackColor = true;
            // 
            // RBCategoria
            // 
            this.RBCategoria.AutoSize = true;
            this.RBCategoria.Location = new System.Drawing.Point(202, 17);
            this.RBCategoria.Name = "RBCategoria";
            this.RBCategoria.Size = new System.Drawing.Size(70, 17);
            this.RBCategoria.TabIndex = 9;
            this.RBCategoria.TabStop = true;
            this.RBCategoria.Text = "Categoria";
            this.RBCategoria.UseVisualStyleBackColor = true;
            // 
            // RBCodigo
            // 
            this.RBCodigo.AutoSize = true;
            this.RBCodigo.Location = new System.Drawing.Point(78, 17);
            this.RBCodigo.Name = "RBCodigo";
            this.RBCodigo.Size = new System.Drawing.Size(58, 17);
            this.RBCodigo.TabIndex = 8;
            this.RBCodigo.TabStop = true;
            this.RBCodigo.Text = "Codigo";
            this.RBCodigo.UseVisualStyleBackColor = true;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 298);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTBuscar);
            this.Controls.Add(this.DGVProducto);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNEliminar);
            this.Controls.Add(this.BTNModificar);
            this.Controls.Add(this.BTNAgregar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Productos";
            this.Text = "Productos";
            ((System.ComponentModel.ISupportInitialize)(this.DGVProducto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNAgregar;
        private System.Windows.Forms.Button BTNModificar;
        private System.Windows.Forms.Button BTNEliminar;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.DataGridView DGVProducto;
        private System.Windows.Forms.TextBox TXTBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBDescripcion;
        private System.Windows.Forms.RadioButton RBCategoria;
        private System.Windows.Forms.RadioButton RBCodigo;
    }
}