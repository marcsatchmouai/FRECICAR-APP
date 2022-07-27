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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMReporteProductoMasVendido));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTNCR = new System.Windows.Forms.Button();
            this.DTPFD = new System.Windows.Forms.DateTimePicker();
            this.DTPFH = new System.Windows.Forms.DateTimePicker();
            this.ReportViewPMV = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sistemaDataSet1 = new Vista.SistemaDataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteProductoMasVendidoTableAdapter = new Vista.SistemaDataSetTableAdapters.Sp_ReporteProductoMasVendidoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Hasta:";
            // 
            // BTNCR
            // 
            this.BTNCR.Location = new System.Drawing.Point(511, 5);
            this.BTNCR.Margin = new System.Windows.Forms.Padding(2);
            this.BTNCR.Name = "BTNCR";
            this.BTNCR.Size = new System.Drawing.Size(80, 27);
            this.BTNCR.TabIndex = 2;
            this.BTNCR.Text = "Crear Reporte";
            this.BTNCR.UseVisualStyleBackColor = true;
            this.BTNCR.Click += new System.EventHandler(this.BTNCR_Click);
            // 
            // DTPFD
            // 
            this.DTPFD.Location = new System.Drawing.Point(92, 11);
            this.DTPFD.Margin = new System.Windows.Forms.Padding(2);
            this.DTPFD.Name = "DTPFD";
            this.DTPFD.Size = new System.Drawing.Size(170, 20);
            this.DTPFD.TabIndex = 3;
            // 
            // DTPFH
            // 
            this.DTPFH.Location = new System.Drawing.Point(340, 10);
            this.DTPFH.Margin = new System.Windows.Forms.Padding(2);
            this.DTPFH.Name = "DTPFH";
            this.DTPFH.Size = new System.Drawing.Size(171, 20);
            this.DTPFH.TabIndex = 4;
            // 
            // ReportViewPMV
            // 
            this.ReportViewPMV.LocalReport.ReportEmbeddedResource = "Vista.ReporteProductosMasVendidos.rdlc";
            this.ReportViewPMV.Location = new System.Drawing.Point(17, 36);
            this.ReportViewPMV.Margin = new System.Windows.Forms.Padding(2);
            this.ReportViewPMV.Name = "ReportViewPMV";
            this.ReportViewPMV.ServerReport.BearerToken = null;
            this.ReportViewPMV.Size = new System.Drawing.Size(574, 320);
            this.ReportViewPMV.TabIndex = 5;
            this.ReportViewPMV.Load += new System.EventHandler(this.ReportViewPMV_Load);
            // 
            // sistemaDataSet1
            // 
            this.sistemaDataSet1.DataSetName = "SistemaDataSet";
            this.sistemaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Sp_ReporteProductoMasVendido";
            this.bindingSource1.DataSource = this.sistemaDataSet1;
            // 
            // sp_ReporteProductoMasVendidoTableAdapter
            // 
            this.sp_ReporteProductoMasVendidoTableAdapter.ClearBeforeFill = true;
            // 
            // FRMReporteProductoMasVendido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.ReportViewPMV);
            this.Controls.Add(this.DTPFH);
            this.Controls.Add(this.DTPFD);
            this.Controls.Add(this.BTNCR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private SistemaDataSetTableAdapters.Sp_ReporteProductoMasVendidoTableAdapter sp_ReporteProductoMasVendidoTableAdapter;
    }
}