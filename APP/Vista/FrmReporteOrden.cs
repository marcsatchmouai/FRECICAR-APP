using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace Vista
{
    public partial class FrmReporteOrden : Form
    {
        Entidades.Sistema.OrdenCompra oc;
        public FrmReporteOrden(Entidades.Sistema.OrdenCompra oc)
        {
            this.oc = oc;
            InitializeComponent();
        }

        private void FrmReporteOrden_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] parametros = new Microsoft.Reporting.WinForms.ReportParameter[7];
            parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("FormadeEnvio",oc.FormadeEnvio.Nombre);
            parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("FormadePago",oc.FormadePago.Nombre);
            parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("Proveedor", oc.Proveedor.RazonSocial);
            parametros[3] = new Microsoft.Reporting.WinForms.ReportParameter("Total", oc.Total.ToString());
            parametros[4] = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", oc.Fecha.ToString());
            parametros[5] = new Microsoft.Reporting.WinForms.ReportParameter("Estado", oc.Estado);
            parametros[6] = new Microsoft.Reporting.WinForms.ReportParameter("Codigo", oc.Codigo.ToString());

            this.reportViewer2.LocalReport.SetParameters(parametros);
         
            BindingSource bs = new BindingSource();
            bs.DataSource = oc.DetalleOrdenCompra;
            Microsoft.Reporting.WinForms.ReportDataSource rep = new Microsoft.Reporting.WinForms.ReportDataSource();
            rep.Name = "ReporteOrdenCompra";
            rep.Value = bs;
            this.reportViewer2.LocalReport.DataSources.Add(rep);
            this.reportViewer2.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
