using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Entidades.Seguridad;

namespace Vista
{
    public partial class Pagos : Form
    {
        Controladora.Sistema.ControladoraPago _Controladora = Controladora.Sistema.ControladoraPago.ObtenerInstancia();
        private ReadOnlyCollection <Perfil> perfiles;
        public Pagos(ReadOnlyCollection<Perfil> oPerfiles)
        {
            this.perfiles = oPerfiles;
            InitializeComponent();
            CargarGrillas();
        }

        private void CargarGrillas()
        {
            DGVPagos.DataSource = null;
            DGVPagos.DataSource = _Controladora.Listar();
        }

        private void OFrmPago_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarGrillas();
            this.Close();
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TXTFiltro_TextChanged(object sender, EventArgs e)
        {
            DGVPagos.DataSource = null;
            DGVPagos.DataSource = _Controladora.Listar().Find(x => x.Codigo == Convert.ToInt32(TXTFiltro.Text));
        }
    }
}
