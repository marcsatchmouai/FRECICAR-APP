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

namespace Vista
{
    public partial class OrdenesCompras : Form
    {
        private ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles;
        public Entidades.Sistema.OrdenCompra SOrdenCompra;
        private bool Flag;
        public OrdenesCompras(ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles,bool _Flag)
        {
            Flag = _Flag;
            this.perfiles = perfiles;
            InitializeComponent();
            GrillaOrdenesCompras.AutoGenerateColumns = false;
            Iniciacion();
            ActualizarGrilla();
            CargarPermisos();
            if (_Flag == true)
            {
                Iniciacion();
            }
        }

        private void Iniciacion()
        {
            BTNAnular.Enabled = false;
        }

        private void CargarPermisos()
        {
            foreach (var item in perfiles)
            {
                foreach (var item2 in item.Formularios)
                {
                    if (item2.Nombre == this.Name)
                    {
                        foreach (var item3 in item2.Permisos)
                        {
                           // if (item3.Nombre == BTNAceptar.Text) BTNAceptar.Enabled = true;
                            if (item3.Nombre == BTNAnular.Text) BTNAnular.Enabled = true;
                        }
                    }
                }
            }
        }


        public void ActualizarGrilla()
        {
            GrillaOrdenesCompras.DataSource = null;
            GrillaOrdenesCompras.DataSource = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenesCompras().ToList();
        }

        private void OFrmPrima_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActualizarGrilla();
        }

        private void BTNAnular_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("¿Desea Anular el OrdenCompra?","OrdenCompra",MessageBoxButtons.YesNo);
            if (Dr == DialogResult.Yes)
            {
                if (GrillaOrdenesCompras.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Debe seleccionar una Orden De Compra de la grilla");
                    return;
                }
                Entidades.Sistema.OrdenCompra _OrdenCompra = (Entidades.Sistema.OrdenCompra)GrillaOrdenesCompras.CurrentRow.DataBoundItem;
                if (_OrdenCompra.Estado != "Realizado")
                {
                    MessageBox.Show("No Puede Anular esta Orden de Compra debido a que su estado es distinto de Realizado");
                    return;
                }
                _OrdenCompra.Estado = "Anulado";
                Controladora.Sistema.ControladoraRealizarOrdenCompra.ObtenerInstancia().ModificarEstadoOrdenCompra(_OrdenCompra);
                ActualizarGrilla();
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNConsulta_Click(object sender, EventArgs e)
        {
            if (GrillaOrdenesCompras.RowCount == 0)
            {
                MessageBox.Show("Debe seleccionar un OrdenCompra de la grilla");
                return;
            }
            Entidades.Sistema.OrdenCompra oOrdenCompra = (Entidades.Sistema.OrdenCompra)GrillaOrdenesCompras.CurrentRow.DataBoundItem;
            FrmDetallesOrdenCompra oFrmDetalleOrdenCompra = new FrmDetallesOrdenCompra(oOrdenCompra);
            oFrmDetalleOrdenCompra.ShowDialog();
        }

        private void TXTFiltrar_TextChanged(object sender, EventArgs e)
        {
            if (TXTFiltrar.Text == "")
            {
                ActualizarGrilla();
            }
            else
            {
                if (RBProveedor.Checked == true)
                {
                    GrillaOrdenesCompras.DataSource = null;
                    GrillaOrdenesCompras.DataSource = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenesCompras().FindAll(x => x.Proveedor.RazonSocial.ToLower().StartsWith(TXTFiltrar.Text.ToLower()));
                }
                if (RBCodigo.Checked == true)
                {
                    GrillaOrdenesCompras.DataSource = null;
                    GrillaOrdenesCompras.DataSource = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenesCompras().FindAll(x => x.Codigo.ToString().StartsWith(TXTFiltrar.Text));
                }
                if (RBFecha.Checked == true)
                {
                    GrillaOrdenesCompras.DataSource = null;
                    GrillaOrdenesCompras.DataSource = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenesCompras().FindAll(x => x.Fecha.ToString().StartsWith(TXTFiltrar.Text));
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmOrdenesCompras_Load(object sender, EventArgs e)
        {

        }

        private void Filtrarpor_Enter(object sender, EventArgs e)
        {

        }

        private void GrillaOrdenesCompras_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SOrdenCompra = (Entidades.Sistema.OrdenCompra)GrillaOrdenesCompras.CurrentRow.DataBoundItem;
            if (Flag == true)
            {
                if(SOrdenCompra.Estado == "Finalizado" || SOrdenCompra.Estado == "Anulado")
                {
                    MessageBox.Show("La orden seleccionada ya se encuentra finalizada o Anulada.");
                    SOrdenCompra = null;
                    return;
                }
                this.Close();
            }
        }

        private void GrillaOrdenesCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void BTNImprimir_Click(object sender, EventArgs e)
        {
            if (GrillaOrdenesCompras.RowCount == 0)
            {
                MessageBox.Show("Debe seleccionar un OrdenCompra de la grilla");
                return;
            }
            Entidades.Sistema.OrdenCompra oOrdenCompra = (Entidades.Sistema.OrdenCompra) GrillaOrdenesCompras.CurrentRow.DataBoundItem;
            if (oOrdenCompra == null)
            {
                MessageBox.Show("Debe seleccionar una orden de compra");
                return;
            }
            FrmReporteOrden oReporte = new FrmReporteOrden(oOrdenCompra);
            oReporte.ShowDialog();
        }
    }
}
