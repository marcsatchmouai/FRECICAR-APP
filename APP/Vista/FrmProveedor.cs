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
    public partial class FrmProveedor : Form
    {
        Entidades.Sistema.Proveedor oProveedor;
        string _Flag;
        public FrmProveedor()
        {
            InitializeComponent();
            _Flag = "Agregar";
        }

        public FrmProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            InitializeComponent();
            oProveedor = Proveedor;
            _Flag = "Modificar";
            MTXTCuit.Text = oProveedor.Cuit.ToString();
            MTXTNumero.Text = oProveedor.DireccionNumero.ToString();
            MTXTTelefono.Text = oProveedor.Telefono.ToString();
            TXTCalle.Text = oProveedor.DireccionCalle;
            TXTEmail.Text = oProveedor.Email;
            TXTRazonSocial.Text = oProveedor.RazonSocial;
            MTXTCuit.Enabled = false;
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (_Flag == "Agregar")
            {
                oProveedor = new Entidades.Sistema.Proveedor();
                if (string.IsNullOrEmpty(MTXTCuit.Text) || string.IsNullOrEmpty(TXTCalle.Text)
                    || string.IsNullOrEmpty(MTXTNumero.Text) || string.IsNullOrEmpty(TXTEmail.Text)
                    || string.IsNullOrEmpty(TXTRazonSocial.Text) || string.IsNullOrEmpty(MTXTTelefono.Text))
                {
                    MessageBox.Show("Debe Completarse todos los campos");
                    return;
                }
                oProveedor.Cuit = Convert.ToInt64(MTXTCuit.Text.Replace("-",""));
                oProveedor.DireccionCalle = TXTCalle.Text;
                oProveedor.DireccionNumero = MTXTNumero.Text;
                oProveedor.Email = TXTEmail.Text;
                oProveedor.RazonSocial = TXTRazonSocial.Text;
                oProveedor.Telefono = MTXTTelefono.Text.Replace("-","").Replace("(","").Replace(")","");
                Controladora.Sistema.ControladoraProveedor.ObtenerInstancia().AgregarProveedor(oProveedor);
                MessageBox.Show("Se a agregado Correctamente");
                this.Close();
            }
            if (_Flag == "Modificar")
            {
                if (string.IsNullOrEmpty(MTXTCuit.Text) || string.IsNullOrEmpty(TXTCalle.Text)
                    || string.IsNullOrEmpty(MTXTNumero.Text) || string.IsNullOrEmpty(TXTEmail.Text)
                    || string.IsNullOrEmpty(TXTRazonSocial.Text) || string.IsNullOrEmpty(MTXTTelefono.Text))
                {
                    MessageBox.Show("Debe Completarse todos los campos");
                    return;
                }
                oProveedor.Cuit = Convert.ToInt64(MTXTCuit.Text.Replace("-", ""));
                oProveedor.DireccionCalle = TXTCalle.Text;
                oProveedor.DireccionNumero = MTXTNumero.Text;
                oProveedor.Email = TXTEmail.Text;
                oProveedor.RazonSocial = TXTRazonSocial.Text;
                oProveedor.Telefono = MTXTTelefono.Text.Replace("-", "").Replace("(", "").Replace(")", "");
                Controladora.Sistema.ControladoraProveedor.ObtenerInstancia().ModificarProveedor(oProveedor);
                MessageBox.Show("Se a Modificado Correctamente");
                this.Close();
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
