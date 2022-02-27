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
    public partial class FrmCuentaCorriente : Form
    {
        private Entidades.Sistema.CuentaCorriente oCuentaCorriente;
        Entidades.Sistema.Cliente oCLiente;
        Controladora.Sistema.ControladoraCuentaCorriente _Controaldora = Controladora.Sistema.ControladoraCuentaCorriente.ObtenerInstancia();
        public FrmCuentaCorriente(Entidades.Sistema.Cliente Cliente)
        {
            this.oCLiente = Cliente;
            InitializeComponent();
            DGVMovimientos.AutoGenerateColumns = false;
            CargarGrilla();
            oCuentaCorriente = _Controaldora.RecuperarCuentaCorriente(oCLiente);
            LBLCliente.Text = oCLiente.RazonSocial;
            LBLSaldo.Text = oCuentaCorriente.Saldo.ToString();
        }

        public void CargarGrilla()
        {
            DGVMovimientos.DataSource = null;
            DGVMovimientos.DataSource = _Controaldora.RecuperarCuentaCorriente(oCLiente).ListarMovimientos();
        }
        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVMovimientos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && DGVMovimientos.Columns[e.ColumnIndex] == Detalle)
            {
                e.Value = e.Value.ToString();
            }
        }
        private void TXTFiltro_TextChanged(object sender, EventArgs e)
        {
            if (RBMonto.Checked)
            {
                DGVMovimientos.DataSource = null;
                DGVMovimientos.DataSource = _Controaldora.RecuperarMovimientos(oCuentaCorriente, new Controladora.Sistema.EstrategiaMonto(), TXTFiltro.Text);
            }
            else
            {
                DGVMovimientos.DataSource = null;
                DGVMovimientos.DataSource = _Controaldora.RecuperarMovimientos(oCuentaCorriente, new Controladora.Sistema.EstrategiaFecha(), TXTFiltro.Text);
            }
        }

        private void RBDebito_CheckedChanged(object sender, EventArgs e)
        {
            if (RBDebito.Checked)
            {
                DGVMovimientos.DataSource = null;
                DGVMovimientos.DataSource = _Controaldora.RecuperarMovimientos(oCuentaCorriente, new Controladora.Sistema.EstrategiaTipoMovimiento(), RBDebito.Text);
            }
        }

        private void RBCredito_CheckedChanged(object sender, EventArgs e)
        {
            if(RBCredito.Checked)
            {
                DGVMovimientos.DataSource = null;
                DGVMovimientos.DataSource = _Controaldora.RecuperarMovimientos(oCuentaCorriente, new Controladora.Sistema.EstrategiaTipoMovimiento(), RBCredito.Text);
            }
        }
    }
}
