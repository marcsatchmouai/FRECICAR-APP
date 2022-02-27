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
    public partial class FrmDetalleRemitoProveedor : Form
    {
        public FrmDetalleRemitoProveedor(Entidades.Sistema.RemitoProveedor _Remito)
        {
            InitializeComponent();
            GrillaDetallesRemito.AutoGenerateColumns = false;
            GrillaDetallesRemito.DataSource = null;
            GrillaDetallesRemito.DataSource = _Remito.DetalleRemitoProveedor.ToList();
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrillaDetallesRemito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
