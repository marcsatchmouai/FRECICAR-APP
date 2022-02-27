using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FRMReporteProductoMasVendido : Form
    {
        public FRMReporteProductoMasVendido()
        {
            InitializeComponent();

        }
        private void FRMReporteProductoMasVendido_Load(object sender, EventArgs e)
        {
        }
        Vista.SistemaDataSetTableAdapters.Sp_ReporteProductoMasVendidoTableAdapter tabla = new SistemaDataSetTableAdapters.Sp_ReporteProductoMasVendidoTableAdapter();
        private void BTNCR_Click(object sender, EventArgs e)
        {
            this.ReportViewPMV.LocalReport.SetParameters(new ReportParameter("FechaDesde", this.DTPFD.Value.Date.ToShortDateString()));
            this.ReportViewPMV.LocalReport.SetParameters(new ReportParameter("FechaHasta", this.DTPFH.Value.Date.ToShortDateString()));
            tabla.Fill(sistemaDataSet1.Sp_ReporteProductoMasVendido, DTPFD.Value, DTPFH.Value);
            this.ReportViewPMV.RefreshReport();
        }
    }
}
