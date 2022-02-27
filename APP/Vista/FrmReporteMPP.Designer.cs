namespace Vista
{
    partial class FrmReporteMPP
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SP_ReporteMateriasPrimasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TrabajoFinalDataSet = new Vista.TrabajoFinalDataSet();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.BTNCReporte = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_ReporteMateriasPrimasTableAdapter = new Vista.TrabajoFinalDataSetTableAdapters.SP_ReporteMateriasPrimasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_ReporteMateriasPrimasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrabajoFinalDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_ReporteMateriasPrimasBindingSource
            // 
            this.SP_ReporteMateriasPrimasBindingSource.DataMember = "SP_ReporteMateriasPrimas";
            this.SP_ReporteMateriasPrimasBindingSource.DataSource = this.TrabajoFinalDataSet;
            // 
            // TrabajoFinalDataSet
            // 
            this.TrabajoFinalDataSet.DataSetName = "TrabajoFinalDataSet";
            this.TrabajoFinalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DTPDesde
            // 
            this.DTPDesde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTPDesde.Location = new System.Drawing.Point(123, 15);
            this.DTPDesde.Margin = new System.Windows.Forms.Padding(4);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(287, 22);
            this.DTPDesde.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Desde:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta:";
            // 
            // DTPHasta
            // 
            this.DTPHasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTPHasta.Location = new System.Drawing.Point(525, 15);
            this.DTPHasta.Margin = new System.Windows.Forms.Padding(4);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(287, 22);
            this.DTPHasta.TabIndex = 3;
            // 
            // BTNCReporte
            // 
            this.BTNCReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCReporte.Location = new System.Drawing.Point(938, 11);
            this.BTNCReporte.Margin = new System.Windows.Forms.Padding(4);
            this.BTNCReporte.Name = "BTNCReporte";
            this.BTNCReporte.Size = new System.Drawing.Size(125, 28);
            this.BTNCReporte.TabIndex = 4;
            this.BTNCReporte.Text = "Crear Reporte";
            this.BTNCReporte.UseVisualStyleBackColor = true;
            this.BTNCReporte.Click += new System.EventHandler(this.BTNCReporte_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "MateriasPrimas";
            reportDataSource2.Value = this.SP_ReporteMateriasPrimasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Vista.ReporteMPP.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 47);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1043, 375);
            this.reportViewer1.TabIndex = 5;
            // 
            // SP_ReporteMateriasPrimasTableAdapter
            // 
            this.SP_ReporteMateriasPrimasTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteMPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 435);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.BTNCReporte);
            this.Controls.Add(this.DTPHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTPDesde);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmReporteMPP";
            this.Text = "FrmReporteMPP";
            this.Load += new System.EventHandler(this.FrmReporteMPP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_ReporteMateriasPrimasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrabajoFinalDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.Button BTNCReporte;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_ReporteMateriasPrimasBindingSource;
        private TrabajoFinalDataSet TrabajoFinalDataSet;
        private TrabajoFinalDataSetTableAdapters.SP_ReporteMateriasPrimasTableAdapter SP_ReporteMateriasPrimasTableAdapter;
    }
}