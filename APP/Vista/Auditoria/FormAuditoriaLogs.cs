using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vista.Auditoria
{
    public partial class FormAuditoriaLogs : Form
    {
        public FormAuditoriaLogs()
        {
            InitializeComponent();
            InitializeComponentAudit();
            this.bsAuditoriaIngresosEgresos = new BindingSource();
            this.CargarGrilla();
        }

        private BindingSource bsAuditoriaIngresosEgresos;
    
        private void txtFiltrarLogs_TextChanged(object sender, EventArgs e)
        {
            this.bsAuditoriaIngresosEgresos.DataSource = Controladora.Auditoria.ControladoraCasoDeUsoVisualizarListadosDeAuditoria.ObtenerInstancia().FiltrarLogInOut(this.txtFiltrarLogs.Text);
            this.dgvAuditoriaLogs.DataSource = this.bsAuditoriaIngresosEgresos;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Controladora.Auditoria.ControladoraCasoDeUsoVisualizarListadosDeAuditoria.ObtenerInstancia().Actualizar();
            
        }
        private void CargarGrilla()
        {
            this.bsAuditoriaIngresosEgresos.DataSource = Controladora.Auditoria.ControladoraCasoDeUsoVisualizarListadosDeAuditoria.ObtenerInstancia().RecuperarListadosIngresosEgresos();
            this.dgvAuditoriaLogs.AutoGenerateColumns = false;
            dgvAuditoriaLogs.DataSource = this.bsAuditoriaIngresosEgresos;
        }

        private void dgvAuditoriaLogs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dgvAuditoriaLogs.RowCount != 0)
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    foreach (DataGridViewRow fila in this.dgvAuditoriaLogs.Rows)
                    {
                        if (fila.Cells[colOperacion.Name].Value.ToString() == Entidades.Auditoria.AuditoriaInicioSesion.TipoLog.Erroneo.ToString())
                        {
                            fila.DefaultCellStyle.BackColor = Color.Red; 
                        }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuditoriaLogs));
            this.SuspendLayout();
            // 
            // FormAuditoriaLogs
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAuditoriaLogs";
            this.ResumeLayout(false);

        }
    }
}
