namespace Vista
{
    partial class Clientes
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
            this.GrillaClientes = new System.Windows.Forms.DataGridView();
            this.BTNCancelar = new System.Windows.Forms.Button();
            this.BTNEliminar = new System.Windows.Forms.Button();
            this.BTNModificar = new System.Windows.Forms.Button();
            this.BTNAceptar = new System.Windows.Forms.Button();
            this.CBTodos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar :";
            // 
            // TXTFiltro
            // 
            this.TXTFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTFiltro.Location = new System.Drawing.Point(71, 13);
            this.TXTFiltro.Name = "TXTFiltro";
            this.TXTFiltro.Size = new System.Drawing.Size(715, 20);
            this.TXTFiltro.TabIndex = 1;
            this.TXTFiltro.TextChanged += new System.EventHandler(this.TXTFiltro_TextChanged);
            // 
            // GrillaClientes
            // 
            this.GrillaClientes.AllowUserToAddRows = false;
            this.GrillaClientes.AllowUserToDeleteRows = false;
            this.GrillaClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaClientes.GridColor = System.Drawing.SystemColors.GrayText;
            this.GrillaClientes.Location = new System.Drawing.Point(12, 42);
            this.GrillaClientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GrillaClientes.MultiSelect = false;
            this.GrillaClientes.Name = "GrillaClientes";
            this.GrillaClientes.ReadOnly = true;
            this.GrillaClientes.RowHeadersVisible = false;
            this.GrillaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaClientes.Size = new System.Drawing.Size(836, 353);
            this.GrillaClientes.TabIndex = 3;
            this.GrillaClientes.DoubleClick += new System.EventHandler(this.GrillaClientes_DoubleClick);
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCancelar.Location = new System.Drawing.Point(749, 401);
            this.BTNCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(99, 28);
            this.BTNCancelar.TabIndex = 7;
            this.BTNCancelar.Text = "Cancelar";
            this.BTNCancelar.UseVisualStyleBackColor = true;
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // BTNEliminar
            // 
            this.BTNEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNEliminar.Location = new System.Drawing.Point(228, 401);
            this.BTNEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTNEliminar.Name = "BTNEliminar";
            this.BTNEliminar.Size = new System.Drawing.Size(99, 28);
            this.BTNEliminar.TabIndex = 6;
            this.BTNEliminar.Text = "Eliminar";
            this.BTNEliminar.UseVisualStyleBackColor = true;
            this.BTNEliminar.Click += new System.EventHandler(this.BTNEliminar_Click);
            // 
            // BTNModificar
            // 
            this.BTNModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNModificar.Location = new System.Drawing.Point(119, 401);
            this.BTNModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTNModificar.Name = "BTNModificar";
            this.BTNModificar.Size = new System.Drawing.Size(99, 28);
            this.BTNModificar.TabIndex = 5;
            this.BTNModificar.Text = "Modificar";
            this.BTNModificar.UseVisualStyleBackColor = true;
            this.BTNModificar.Click += new System.EventHandler(this.BTNModificar_Click);
            // 
            // BTNAceptar
            // 
            this.BTNAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNAceptar.Location = new System.Drawing.Point(12, 401);
            this.BTNAceptar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTNAceptar.Name = "BTNAceptar";
            this.BTNAceptar.Size = new System.Drawing.Size(99, 28);
            this.BTNAceptar.TabIndex = 4;
            this.BTNAceptar.Text = "Agregar";
            this.BTNAceptar.UseVisualStyleBackColor = true;
            this.BTNAceptar.Click += new System.EventHandler(this.BTNAceptar_Click);
            // 
            // CBTodos
            // 
            this.CBTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBTodos.AutoSize = true;
            this.CBTodos.Location = new System.Drawing.Point(792, 15);
            this.CBTodos.Name = "CBTodos";
            this.CBTodos.Size = new System.Drawing.Size(56, 17);
            this.CBTodos.TabIndex = 2;
            this.CBTodos.Text = "Todos";
            this.CBTodos.UseVisualStyleBackColor = true;
            this.CBTodos.CheckedChanged += new System.EventHandler(this.CBTodos_CheckedChanged);
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 438);
            this.Controls.Add(this.CBTodos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTFiltro);
            this.Controls.Add(this.GrillaClientes);
            this.Controls.Add(this.BTNCancelar);
            this.Controls.Add(this.BTNEliminar);
            this.Controls.Add(this.BTNModificar);
            this.Controls.Add(this.BTNAceptar);
            this.Name = "Clientes";
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTFiltro;
        private System.Windows.Forms.DataGridView GrillaClientes;
        private System.Windows.Forms.Button BTNCancelar;
        private System.Windows.Forms.Button BTNEliminar;
        private System.Windows.Forms.Button BTNModificar;
        private System.Windows.Forms.Button BTNAceptar;
        private System.Windows.Forms.CheckBox CBTodos;
    }
}