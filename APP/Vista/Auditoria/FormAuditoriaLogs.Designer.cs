namespace Vista.Auditoria
{
    partial class FormAuditoriaLogs
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
            this.dgvAuditoriaLogs = new System.Windows.Forms.DataGridView();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFiltrarLogs = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAuditoriaLogs
            // 
            this.dgvAuditoriaLogs.AllowUserToAddRows = false;
            this.dgvAuditoriaLogs.AllowUserToDeleteRows = false;
            this.dgvAuditoriaLogs.AllowUserToResizeColumns = false;
            this.dgvAuditoriaLogs.AllowUserToResizeRows = false;
            this.dgvAuditoriaLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuditoriaLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoriaLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFechaHora,
            this.colUsuario,
            this.colOperacion,
            this.colEquipo});
            this.dgvAuditoriaLogs.Location = new System.Drawing.Point(12, 40);
            this.dgvAuditoriaLogs.MultiSelect = false;
            this.dgvAuditoriaLogs.Name = "dgvAuditoriaLogs";
            this.dgvAuditoriaLogs.ReadOnly = true;
            this.dgvAuditoriaLogs.RowHeadersVisible = false;
            this.dgvAuditoriaLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditoriaLogs.ShowCellErrors = false;
            this.dgvAuditoriaLogs.ShowCellToolTips = false;
            this.dgvAuditoriaLogs.ShowEditingIcon = false;
            this.dgvAuditoriaLogs.ShowRowErrors = false;
            this.dgvAuditoriaLogs.Size = new System.Drawing.Size(627, 240);
            this.dgvAuditoriaLogs.TabIndex = 2;
            this.dgvAuditoriaLogs.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAuditoriaLogs_DataBindingComplete);
            // 
            // colFechaHora
            // 
            this.colFechaHora.DataPropertyName = "FechaHora";
            this.colFechaHora.HeaderText = "Fecha - Hora";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
            // 
            // colUsuario
            // 
            this.colUsuario.DataPropertyName = "Usuario";
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // colOperacion
            // 
            this.colOperacion.DataPropertyName = "Operacion";
            this.colOperacion.HeaderText = "Operación";
            this.colOperacion.Name = "colOperacion";
            this.colOperacion.ReadOnly = true;
            // 
            // colEquipo
            // 
            this.colEquipo.DataPropertyName = "Equipo";
            this.colEquipo.HeaderText = "Equipo";
            this.colEquipo.Name = "colEquipo";
            this.colEquipo.ReadOnly = true;
            // 
            // txtFiltrarLogs
            // 
            this.txtFiltrarLogs.Location = new System.Drawing.Point(12, 12);
            this.txtFiltrarLogs.Name = "txtFiltrarLogs";
            this.txtFiltrarLogs.Size = new System.Drawing.Size(546, 20);
            this.txtFiltrarLogs.TabIndex = 0;
            this.txtFiltrarLogs.TextChanged += new System.EventHandler(this.txtFiltrarLogs_TextChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(564, 10);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FormAuditoriaLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 292);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtFiltrarLogs);
            this.Controls.Add(this.dgvAuditoriaLogs);
            this.Name = "FormAuditoriaLogs";
            this.Text = "FormAuditoriaLogs";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAuditoriaLogs;
        private System.Windows.Forms.TextBox txtFiltrarLogs;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipo;
    }
}