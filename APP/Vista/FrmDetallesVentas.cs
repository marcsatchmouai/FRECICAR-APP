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
    public partial class FrmDetallesVentas : Form
    {
        public FrmDetallesVentas(Entidades.Sistema.Venta oVenta)
        {
            InitializeComponent();
            DGVDetallesVentas.DataSource = null;
            DGVDetallesVentas.DataSource = oVenta.ListarDetalles();
        }
        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
