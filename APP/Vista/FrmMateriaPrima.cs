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
    public partial class FrmMateriaPrima : Form
    {
        Entidades.Sistema.MateriaPrima oMateriaPrima;
        string _Flag;
        public FrmMateriaPrima()
        {
            InitializeComponent();
            _Flag = "Agregar";
            CargarCombos();
            MTXTCantidad.Enabled = false;
            this.MTXTCostoUnitario.LostFocus += MTXTCostoUnitario_LostFocus;
        }

        private void MTXTCostoUnitario_LostFocus(object sender, EventArgs e)
        {
            if (!Controladora.Sistema.Validaciones.ValidarDecimal(MTXTCostoUnitario.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el importe de forma correcta, Solo se Acepta valores numericos");
                MTXTCostoUnitario.Text = "";
                return;
            }
        }

        public FrmMateriaPrima(Entidades.Sistema.MateriaPrima MateriaPrima)
        {
            InitializeComponent();
            _Flag = "Modificar";
            oMateriaPrima = MateriaPrima;
            CargarCombos();
            MTXTCantidad.Text = oMateriaPrima.Cantidad.ToString();
            MTXTCantidadMinima.Text = oMateriaPrima.CantMin.ToString();
            CMBCategoria.SelectedItem = oMateriaPrima.Categoria.Nombre;
            MTXTCodigo.Text = oMateriaPrima.Codigo.ToString();
            MTXTCostoUnitario.Text = oMateriaPrima.CostoUnitario.ToString();
            TXTDescripcion.Text=oMateriaPrima.Descripcion;
            CMBProveedor.SelectedItem = oMateriaPrima.Proveedor.RazonSocial;
            MTXTCodigo.Enabled = false;
            this.MTXTCostoUnitario.LostFocus += MTXTCostoUnitario_LostFocus;
        }

        public void CargarCombos()
        {
            CMBCategoria.DataSource = Controladora.Sistema.ControladoraMateriaPrima.ObtenerInstancia().RecuperarCategoria();
            CMBCategoria.DisplayMember = "Nombre";
            CMBProveedor.DataSource = Controladora.Sistema.ControladoraMateriaPrima.ObtenerInstancia().RecuperarProveedor();
            CMBProveedor.DisplayMember = "RazonSocial";
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (_Flag=="Agregar")
            {


                if (string.IsNullOrEmpty(TXTDescripcion.Text) || string.IsNullOrEmpty(MTXTCostoUnitario.Text) || string.IsNullOrEmpty(MTXTCodigo.Text) || 
                    string.IsNullOrEmpty(MTXTCantidadMinima.Text) || CMBCategoria.SelectedItem == null || CMBProveedor.SelectedItem == null)
                {
                    MessageBox.Show("debe completarse todos los campos");
                    return;
                }
                oMateriaPrima = new Entidades.Sistema.MateriaPrima();
                oMateriaPrima.Cantidad = 0;
                oMateriaPrima.CantMin = Convert.ToInt32(MTXTCantidadMinima.Text);
                oMateriaPrima.Categoria = (Entidades.Sistema.Categoria)CMBCategoria.SelectedItem;
                oMateriaPrima.Codigo = Convert.ToInt32(MTXTCodigo.Text);
                oMateriaPrima.CostoUnitario = Convert.ToDecimal(MTXTCostoUnitario.Text);
                oMateriaPrima.Descripcion = TXTDescripcion.Text;
                oMateriaPrima.Proveedor = (Entidades.Sistema.Proveedor) CMBProveedor.SelectedItem;
                Controladora.Sistema.ControladoraMateriaPrima.ObtenerInstancia().AgregarMateriaPrima(oMateriaPrima);
                MessageBox.Show("Se a agregado correctamente");
                this.Close();
            }

            if (_Flag == "Modificar")
            {
                if (string.IsNullOrEmpty(TXTDescripcion.Text) || string.IsNullOrEmpty(MTXTCostoUnitario.Text) || string.IsNullOrEmpty(MTXTCodigo.Text) || 
                    string.IsNullOrEmpty(MTXTCantidadMinima.Text) || string.IsNullOrEmpty(MTXTCantidad.Text) || CMBCategoria.SelectedItem == null || CMBProveedor.SelectedItem == null)
                {
                    MessageBox.Show("debe completarse todos los campos");
                    return;
                }
                oMateriaPrima.Cantidad = Convert.ToInt32(MTXTCantidad.Text);
                oMateriaPrima.CantMin = Convert.ToInt32(MTXTCantidadMinima.Text);
                oMateriaPrima.Categoria = (Entidades.Sistema.Categoria)CMBCategoria.SelectedItem;
                oMateriaPrima.Codigo = Convert.ToInt32(MTXTCodigo.Text);
                oMateriaPrima.CostoUnitario = Convert.ToDecimal(MTXTCostoUnitario.Text);
                oMateriaPrima.Descripcion = TXTDescripcion.Text;
                oMateriaPrima.Proveedor = (Entidades.Sistema.Proveedor)CMBProveedor.SelectedItem;
                Controladora.Sistema.ControladoraMateriaPrima.ObtenerInstancia().ModificarMateriaPrima(oMateriaPrima);
                MessageBox.Show("Se a Modificado correctamente");
                this.Close();
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MTXTCantidadMinima_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void MTXTCostoUnitario_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void MTXTCodigo_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }
    }
}
