namespace Vista
{
    partial class ReporteProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteProductos));
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.ServerReport.ReportPath = "/ReportServer/PMV";
            this.reportViewer2.ServerReport.ReportServerUrl = new System.Uri("http://mmd/reportserver", System.UriKind.Absolute);
            this.reportViewer2.Size = new System.Drawing.Size(688, 427);
            this.reportViewer2.TabIndex = 5;
            // 
            // ReporteProductos
            // 
            this.ClientSize = new System.Drawing.Size(688, 427);
            this.Controls.Add(this.reportViewer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteProductos";
            this.Load += new System.EventHandler(this.ReporteProductos_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private SistemaDataSetTableAdapters.Sp_ReporteProductoMasVendidoTableAdapter sp_ReporteProductoMasVendidoTableAdapter1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}