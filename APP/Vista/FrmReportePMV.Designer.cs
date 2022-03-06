namespace Vista
{
    partial class FrmReportePMV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportePMV));
            this.BTNCrearReporte = new System.Windows.Forms.Button();
            this.DTPFD = new System.Windows.Forms.DateTimePicker();
            this.DTPFH = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // BTNCrearReporte
            // 
            this.BTNCrearReporte.Location = new System.Drawing.Point(580, 10);
            this.BTNCrearReporte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BTNCrearReporte.Name = "BTNCrearReporte";
            this.BTNCrearReporte.Size = new System.Drawing.Size(95, 20);
            this.BTNCrearReporte.TabIndex = 0;
            this.BTNCrearReporte.Text = "Crear Reporte";
            this.BTNCrearReporte.UseVisualStyleBackColor = true;
            // 
            // DTPFD
            // 
            this.DTPFD.Location = new System.Drawing.Point(86, 12);
            this.DTPFD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DTPFD.Name = "DTPFD";
            this.DTPFD.Size = new System.Drawing.Size(186, 20);
            this.DTPFD.TabIndex = 1;
            // 
            // DTPFH
            // 
            this.DTPFH.Location = new System.Drawing.Point(364, 12);
            this.DTPFH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DTPFH.Name = "DTPFH";
            this.DTPFH.Size = new System.Drawing.Size(182, 20);
            this.DTPFH.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Hasta:";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(9, 35);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(666, 323);
            this.reportViewer1.TabIndex = 5;
            // 
            // FrmReportePMV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 367);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTPFH);
            this.Controls.Add(this.DTPFD);
            this.Controls.Add(this.BTNCrearReporte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmReportePMV";
            this.Text = "FrmReportePMV";
            this.Load += new System.EventHandler(this.FrmReportePMV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNCrearReporte;
        private System.Windows.Forms.DateTimePicker DTPFD;
        private System.Windows.Forms.DateTimePicker DTPFH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}