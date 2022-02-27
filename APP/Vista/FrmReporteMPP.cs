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
    public partial class FrmReporteMPP : Form
    {
        public FrmReporteMPP()
        {
            InitializeComponent();
        }

        private void BTNCReporte_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("FechaDesde", this.DTPDesde.Value.Date.ToShortDateString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("FechaHasta", this.DTPHasta.Value.Date.ToShortDateString()));
            this.SP_ReporteMateriasPrimasTableAdapter.Fill(TrabajoFinalDataSet.SP_ReporteMateriasPrimas, DTPDesde.Value, DTPHasta.Value);
            this.reportViewer1.RefreshReport();
        }

        private void FrmReporteMPP_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'TrabajoFinalDataSet.SP_ReporteMateriasPrimas' Puede moverla o quitarla según sea necesario.
           }

        private void SP_ReporteMateriasPrimasBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
