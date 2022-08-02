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
using System.Text.RegularExpressions;

namespace Vista
{
    public partial class RegistrarPago : Form
    {
        Controladora.Sistema.ControladoraPago _Controladora = Controladora.Sistema.ControladoraPago.ObtenerInstancia();
        private ReadOnlyCollection<Perfil> perfiles;
        public RegistrarPago(ReadOnlyCollection<Perfil> oPerfiles)
        {
            this.perfiles = oPerfiles;
            InitializeComponent();
            Iniciacion();
            CargarPermisos();
            this.MSKImporte.LostFocus += MSKImporte_LostFocus;
        }

        private void MSKImporte_LostFocus(object sender, EventArgs e)
        {
            if (!Controladora.Sistema.Validaciones.ValidarDecimal(MSKImporte.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el importe de forma correcta, Solo se Acepta valores numericos");
                MSKImporte.Text = "";
                return;
            }
        }

        private void Iniciacion()
        {
            BTNAgregar.Enabled = false;
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
                            if (item3.Nombre == BTNAgregar.Text) BTNAgregar.Enabled = true;
                        }
                    }
                }
            }
        }

        private void FrmPago_Load(object sender, EventArgs e)
        {
            CargarCombo();
        }

        private void CargarCombo()
        {
            CMBCliente.DataSource = null;
            CMBCliente.DataSource = _Controladora.ListarClientes();
            CMBVenta.DataSource = null;
            CMBVenta.DataSource = _Controladora.RecuperarVentas((Entidades.Sistema.Cliente)CMBCliente.SelectedItem);
            CMBVenta.DisplayMember = "CodigoVenta";
        }

        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Pago oPago = new Entidades.Sistema.Pago();
            if (DTPFecha.Value == null || CMBCliente.SelectedItem == null || string.IsNullOrEmpty(MSKImporte.Text)  || string.IsNullOrEmpty(TXTDetalle.Text))
            {
                MessageBox.Show("Todo los campos son requeridos, debe completarse todos los campos");
                return;
            }
            else
            {
                oPago.Fecha = DTPFecha.Value;
                oPago.Cliente = (Entidades.Sistema.Cliente)CMBCliente.SelectedItem;
                oPago.Importe = Convert.ToDecimal(MSKImporte.Text);
                oPago.Detalle = TXTDetalle.Text;
                oPago.Venta = (Entidades.Sistema.Venta)CMBVenta.SelectedItem;
                _Controladora.RegistrarPago(oPago);
                MessageBox.Show("Se agrego correctamente el Pago");
                this.Close();
                Pagos oFrmGPago = new Pagos(perfiles);
                oFrmGPago.Show();
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMBCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CMBVenta.DataSource = null;
            CMBVenta.DataSource = _Controladora.RecuperarVentas((Entidades.Sistema.Cliente)CMBCliente.SelectedItem);
            CMBVenta.DisplayMember = "CodigoVenta";
        }

        private void MSKImporte_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void BTNVerCC_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Cliente oCliente = (Entidades.Sistema.Cliente)CMBCliente.SelectedItem;
            if (oCliente == null)
            {
                MessageBox.Show("Debe seleccionar un Cliente");
                return;
            }
            FrmCuentaCorriente oFrmCC = new Vista.FrmCuentaCorriente(oCliente);
            oFrmCC.ShowDialog();
        }
    }
}
