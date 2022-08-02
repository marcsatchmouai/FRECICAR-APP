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
    public partial class Ventas : Form
    {
        private ReadOnlyCollection<Perfil> perfiles;
        public Ventas(ReadOnlyCollection<Perfil> oPerfiles)
        {
            this.perfiles = oPerfiles;
            InitializeComponent();
            CargarGrilla();
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
                    if (item2.Nombre == this.Text)
                    {
                        foreach (var item3 in item2.Permisos)
                        {
                            if (item3.Nombre == BTNAnular.Text) BTNAnular.Enabled = true;
                        }
                    }
                }
            }
        }

        public void CargarGrilla()
        {
            GrillaVentas.DataSource = null;
            GrillaVentas.DataSource = Controladora.Sistema.ControladoraVenta.ObtenerInstancia().RecuperarVentas();
        }
        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNAnular_Click(object sender, EventArgs e)
        {
            if (GrillaVentas.RowCount == 0)
            {
                MessageBox.Show("No existe venta a anular");
                return;
            }
            Entidades.Sistema.Venta oVenta = (Entidades.Sistema.Venta)GrillaVentas.CurrentRow.DataBoundItem;
            if (oVenta == null)
            {
                MessageBox.Show("Debe seleccionar una Venta para Anular");
                return;
            }
            if (oVenta.Estado == Entidades.Sistema.Venta.EstadoVenta.Anulado)
            {
                MessageBox.Show("La venta seleccionada ya se encunetra anulada");
                return;
            }
            if (Controladora.Sistema.ControladoraVenta.ObtenerInstancia().Modificar(oVenta) == false)
            {
                MessageBox.Show("No se puedo crear la nota de credito, la venta no se anulara");
                return;
            }
            MessageBox.Show("Se anulo la venta correctamente");
            CargarGrilla();
        }

        private void BTNConsulta_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Venta oVenta = (Entidades.Sistema.Venta)GrillaVentas.CurrentRow.DataBoundItem;
            if (oVenta == null)
            {
                MessageBox.Show("Debe seleccionar una Venta para Consultar");
                return;
            }
            FrmDetallesVentas oFrmDVentas = new FrmDetallesVentas(oVenta);
            oFrmDVentas.ShowDialog();
        }

        private void BTNImprimir_Click(object sender, EventArgs e)
        {

        }

        private void TXTFiltrar_TextChanged(object sender, EventArgs e)
        {
            if (TXTFiltrar.Text == "")
            {
                CargarGrilla();
            }
            else
            {
                if (RBProveedor.Checked == true)
                {
                    GrillaVentas.DataSource = null;
                    GrillaVentas.DataSource = Controladora.Sistema.ControladoraVenta.ObtenerInstancia().RecuperarVentas().FindAll(x => x.Cliente.RazonSocial.ToLower().StartsWith(TXTFiltrar.Text.ToLower()));
                }
                if (RBCodigo.Checked == true)
                {
                    GrillaVentas.DataSource = null;
                    GrillaVentas.DataSource = Controladora.Sistema.ControladoraVenta.ObtenerInstancia().RecuperarVentas().FindAll(x => x.CodigoVenta.ToString().StartsWith(TXTFiltrar.Text));
                }
                if (RBFecha.Checked == true)
                {
                    GrillaVentas.DataSource = null;
                    GrillaVentas.DataSource = Controladora.Sistema.ControladoraVenta.ObtenerInstancia().RecuperarVentas().FindAll(x => x.Fecha.ToString().StartsWith(TXTFiltrar.Text));
                }
            }
        }
    }
}
