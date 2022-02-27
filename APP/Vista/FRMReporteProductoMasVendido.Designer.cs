namespace Vista
{
    partial class FRMReporteProductoMasVendido
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTNCR = new System.Windows.Forms.Button();
            this.DTPFD = new System.Windows.Forms.DateTimePicker();
            this.DTPFH = new System.Windows.Forms.DateTimePicker();
            this.ReportViewPMV = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sistemaDataSet1 = new Vista.SistemaDataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sistemaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Hasta:";
            // 
            // BTNCR
            // 
            this.BTNCR.Location = new System.Drawing.Point(681, 6);
            this.BTNCR.Name = "BTNCR";
            this.BTNCR.Size = new System.Drawing.Size(107, 33);
            this.BTNCR.TabIndex = 2;
            this.BTNCR.Text = "Crear Reporte";
            this.BTNCR.UseVisualStyleBackColor = true;
            this.BTNCR.Click += new System.EventHandler(this.BTNCR_Click);
            // 
            // DTPFD
            // 
            this.DTPFD.Location = new System.Drawing.Point(123, 14);
            this.DTPFD.Name = "DTPFD";
            this.DTPFD.Size = new System.Drawing.Size(226, 22);
            this.DTPFD.TabIndex = 3;
            // 
            // DTPFH
            // 
            this.DTPFH.Location = new System.Drawing.Point(453, 12);
            this.DTPFH.Name = "DTPFH";
            this.DTPFH.Size = new System.Drawing.Size(227, 22);
            this.DTPFH.TabIndex = 4;
            // 
            // ReportViewPMV
            // 
            this.ReportViewPMV.LocalReport.ReportEmbeddedResource = "Vista.ReporteProductosMasVendidos.rdlc";
            this.ReportViewPMV.Location = new System.Drawing.Point(24, 45);
            this.ReportViewPMV.Name = "ReportViewPMV";
            this.ReportViewPMV.ServerReport.BearerToken = null;
            this.ReportViewPMV.Size = new System.Drawing.Size(764, 393);
            this.ReportViewPMV.TabIndex = 5;
            // 
            // sistemaDataSet1
            // 
            this.sistemaDataSet1.DataSetName = "SistemaDataSet";
            this.sistemaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.sistemaDataSet1;
            this.bindingSource1.Position = 0;
            // 
            // FRMReporteProductoMasVendido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReportViewPMV);
            this.Controls.Add(this.DTPFH);
            this.Controls.Add(this.DTPFD);
            this.Controls.Add(this.BTNCR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FRMReporteProductoMasVendido";
            this.Text = "Reporte Producto Mas Vendido";
            this.Load += new System.EventHandler(this.FRMReporteProductoMasVendido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sistemaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTNCR;
        private System.Windows.Forms.DateTimePicker DTPFD;
        private System.Windows.Forms.DateTimePicker DTPFH;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewPMV;
        private SistemaDataSet sistemaDataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}