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
    public partial class RemitosProveedores : Form
    {
        private ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles;
        public RemitosProveedores(ReadOnlyCollection<Entidades.Seguridad.Perfil> _Perfiles)
        {
            perfiles = _Perfiles;
            InitializeComponent();
            GrillaRemitosProveedores.AutoGenerateColumns = false;
            Iniciacion();
            CargarPermisos();
            ActualizarGrilla();
        }

        public void ActualizarGrilla()
        {
            GrillaRemitosProveedores.DataSource = null;
            GrillaRemitosProveedores.DataSource = Controladora.Sistema.ControladoraRemitoProveedor.ObtenerInstancia().RecuperarRemitosProveedores().ToList();
        }

        private void Iniciacion()
        {
        }

        private void CargarPermisos()
        {
            foreach (var item in perfiles)
            {
                foreach (var item2 in item.Formularios)
                {
                    if (item2.Nombre == this.Text)
                    {
                        foreach (var item3 in item2.Permisos)
                        {
                            // if (item3.Nombre == BTNAceptar.Text) BTNAceptar.Enabled = true;
                            //if (item3.Nombre == BTNAnular.Text) BTNAnular.Enabled = true;
                        }
                    }
                }
            }
        }


        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNConsulta_Click(object sender, EventArgs e)
        {
            if (GrillaRemitosProveedores.RowCount == 0)
            {
                MessageBox.Show("Debe seleccionar un Remito de la grilla");
                return;
            }
            Entidades.Sistema.RemitoProveedor oRemitoProveedor = (Entidades.Sistema.RemitoProveedor)GrillaRemitosProveedores.CurrentRow.DataBoundItem;
            FrmDetalleRemitoProveedor oFrmDetalleR = new FrmDetalleRemitoProveedor(oRemitoProveedor);
            oFrmDetalleR.ShowDialog();
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
                    GrillaRemitosProveedores.DataSource = null;
                    GrillaRemitosProveedores.DataSource = Controladora.Sistema.ControladoraRemitoProveedor.ObtenerInstancia().RecuperarRemitosProveedores().FindAll(x => x.Proveedor.RazonSocial.ToLower().StartsWith(TXTFiltrar.Text.ToLower()));
                }
                if (RBCodigo.Checked == true)
                {
                    GrillaRemitosProveedores.DataSource = null;
                    GrillaRemitosProveedores.DataSource = Controladora.Sistema.ControladoraRemitoProveedor.ObtenerInstancia().RecuperarRemitosProveedores().FindAll(x => x.Codigo.ToString().StartsWith(TXTFiltrar.Text));
                }
                if (RBFecha.Checked == true)
                {
                    GrillaRemitosProveedores.DataSource = null;
                    GrillaRemitosProveedores.DataSource = Controladora.Sistema.ControladoraRemitoProveedor.ObtenerInstancia().RecuperarRemitosProveedores().FindAll(x => x.Fecha.ToString().StartsWith(TXTFiltrar.Text));
                }
            }
        }

        private void Filtrarpor_Enter(object sender, EventArgs e)
        {

        }

        private void GrillaRemitosProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BTNImprimir_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.RemitoProveedor oRemito = (Entidades.Sistema.RemitoProveedor)GrillaRemitosProveedores.CurrentRow.DataBoundItem;
            if (oRemito == null)
            {
                MessageBox.Show("Debe seleccionar una remito de compra");
                return;
            }
            FrmReporteRemito oReporte = new FrmReporteRemito(oRemito);
            oReporte.ShowDialog();
        }
    }
}
