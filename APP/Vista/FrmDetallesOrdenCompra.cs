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
    public partial class FrmDetallesOrdenCompra : Form
    {
        public FrmDetallesOrdenCompra(Entidades.Sistema.OrdenCompra oOrdenCompra)
        {
            InitializeComponent();
            GrillaDetallesOrdenCompra.AutoGenerateColumns = false;
            GrillaDetallesOrdenCompra.DataSource = null;
            GrillaDetallesOrdenCompra.DataSource = oOrdenCompra.DetalleOrdenCompra.ToList();
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrillaDetallesOrdenCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
