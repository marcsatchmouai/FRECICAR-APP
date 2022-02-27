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
    public partial class FrmCliente : Form
    {
        private bool Flag;
        private Entidades.Sistema.Cliente oCliente;
        public FrmCliente()
        {
            InitializeComponent();
            Flag = true;
            CMBCiudad.Enabled = false;
        }

        public FrmCliente(Entidades.Sistema.Cliente Cliente)
        {
            InitializeComponent();
            Flag = false;
            CMBCiudad.Enabled = false;
            this.oCliente = Cliente;
        }
        void CargarCombo()
        {
            CMBSFiscal.DataSource = Controladora.Sistema.ControladoraCliente.ObtenerInstancia().RecuperarSituacionesFiscales();
            CMBSFiscal.DisplayMember = "Descripcion";
            CMBProvincia.DataSource = Controladora.Sistema.ControladoraCliente.ObtenerInstancia().RecuperarProvincias();
            CMBProvincia.DisplayMember = "Nombre";
        }

        void CargarText()
        {
            TXTRSocial.Text = oCliente.RazonSocial;
            TXTDomicilio.Text = oCliente.Domicilio;
            TXTEmail.Text = oCliente.Email;
            MTXTCuil.Text = oCliente.Cuit.ToString();
            MTXTTelefono.Text = oCliente.Telefono.ToString();
            //CMBSFiscal.SelectedItem = oCliente.SituacionFiscal;
            //CMBCiudad.SelectedItem = oCliente.Ciudad;
            //CMBProvincia.SelectedItem = oCliente.Ciudad.Provincia;  
        } 

        private void BTNGuardar_Click(object sender, EventArgs e)
        {
            if (Flag == true)
            {
                oCliente = new Entidades.Sistema.Cliente();
                oCliente.RazonSocial = TXTRSocial.Text;
                oCliente.Domicilio = TXTDomicilio.Text;
                oCliente.Email = TXTEmail.Text;
                oCliente.Cuit = Convert.ToInt64(MTXTCuil.Text.Replace("-",""));
                oCliente.Telefono = Convert.ToInt64(MTXTTelefono.Text.Replace("(","").Replace("-","").Replace(")",""));
                oCliente.SituacionFiscal = (Entidades.Sistema.SituacionFiscal)CMBSFiscal.SelectedItem;
                oCliente.Ciudad =(Entidades.Sistema.Ciudad)CMBCiudad.SelectedItem;
                Controladora.Sistema.ControladoraCliente.ObtenerInstancia().Agregar(oCliente);
                MessageBox.Show("Se a agregado el cliente Correctamente");
                this.Close();
            }
            else
            {
                oCliente.RazonSocial = TXTRSocial.Text;
                oCliente.Domicilio = TXTDomicilio.Text;
                oCliente.Email = TXTEmail.Text;
                oCliente.Cuit = Convert.ToInt64(MTXTCuil.Text.Replace("-", ""));
                oCliente.Telefono = Convert.ToInt64(MTXTTelefono.Text.Replace("(", "").Replace("-", "").Replace(")", ""));
                oCliente.SituacionFiscal = (Entidades.Sistema.SituacionFiscal)CMBSFiscal.SelectedItem;
                oCliente.Ciudad = (Entidades.Sistema.Ciudad)CMBCiudad.SelectedItem;
                Controladora.Sistema.ControladoraCliente.ObtenerInstancia().Modificar(oCliente);
                MessageBox.Show("Se a modifico el cliente Correctamente");
                this.Close();
            }

        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            if (!Flag)
            {
                CargarCombo();
                CargarText();
            }
            else CargarCombo();
        }

        private void CMBProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CMBCiudad.Enabled = true;
            CMBCiudad.DataSource = ((Entidades.Sistema.Provincia)CMBProvincia.SelectedItem).Ciudades;
            CMBCiudad.DisplayMember = "Nombre";
        }
    }
}
