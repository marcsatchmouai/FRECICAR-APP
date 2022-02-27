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
    public partial class FrmReporteRemito : Form
    {
        Entidades.Sistema.RemitoProveedor oRemito;
        public FrmReporteRemito(Entidades.Sistema.RemitoProveedor RP)
        {
            this.oRemito = RP;
            InitializeComponent();
        }


        private void FrmReporteRemito_Load(object sender, EventArgs e)
        {

            Microsoft.Reporting.WinForms.ReportParameter[] parametros = new Microsoft.Reporting.WinForms.ReportParameter[5];
            parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("Proveedor", oRemito.Proveedor.RazonSocial);
            parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("Total", oRemito.Total.ToString());
            parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", oRemito.Fecha.ToString());
            parametros[3] = new Microsoft.Reporting.WinForms.ReportParameter("NumeroOrdenCompra", oRemito.NumeroOrdenCompra.ToString());
            parametros[4] = new Microsoft.Reporting.WinForms.ReportParameter("Codigo", oRemito.Codigo.ToString());

            this.reportViewer1.LocalReport.SetParameters(parametros);

            BindingSource bs = new BindingSource();
            bs.DataSource = oRemito.DetalleRemitoProveedor;
            Microsoft.Reporting.WinForms.ReportDataSource rep = new Microsoft.Reporting.WinForms.ReportDataSource();
            RemitoProveedorBindingSource.DataSource = bs;
           
            rep.Name = "RemitoProveedor";
            rep.Value = RemitoProveedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(rep);
            this.reportViewer1.RefreshReport();
        }
    }
}
