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
    public partial class FrmProducto : Form
    {
        Entidades.Sistema.Producto oProducto;

        Controladora.Sistema.ControladoraProducto _Controladora = Controladora.Sistema.ControladoraProducto.ObtenerInstancia();
        bool _Flag;
        public FrmProducto()
        {
            _Flag = true;
            InitializeComponent();
            this.oProducto = new Entidades.Sistema.Producto();
            this.NUDCantidad.Enabled = false;
            MTXTCodigo.Enabled = false;
            CargarCombo();
            this.MTXTCUnitario.LostFocus += MTXTCUnitario_LostFocus;
        }

        private void MTXTCUnitario_LostFocus(object sender, EventArgs e)
        {
            if (!Controladora.Sistema.Validaciones.ValidarDecimal(MTXTCUnitario.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el importe de forma correcta, Solo se Acepta valores numericos");
                MTXTCUnitario.Text = "";
                return;
            }
        }

        public FrmProducto(Entidades.Sistema.Producto Producto)
        {
            this.oProducto = Producto;
            _Flag = false;
            InitializeComponent();
            CargarCombo();
            MTXTCodigo.Text = oProducto.Codigo.ToString();
            MTXTCodigo.Enabled = false;
            TXTDescripcion.Text = oProducto.Descripcion;
            MTXTCUnitario.Text = oProducto.Precio.ToString();
            NUDCantidad.Value = oProducto.Cantidad;
            NUDCMin.Value = oProducto.CantMin;
            CBCategoria.DisplayMember = oProducto.Categoria.ToString();
            this.MTXTCUnitario.LostFocus += MTXTCUnitario_LostFocus;
        }

        private void CargarCombo()
        {
            CBCategoria.DataSource = null;
            CBCategoria.DataSource = _Controladora.RecuperarCategorias();
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MTXTCUnitario.Text) || string.IsNullOrEmpty(TXTDescripcion.Text)
                || CBCategoria.SelectedItem == null)
            {
                MessageBox.Show("Se debe completar todos los campos");
                return;
            }
            if (NUDCantidad.Value < 0 || NUDCMin.Value <= 0)
            {
                MessageBox.Show("La cantidad minima debe ser mayor a 0");
                return;
            }
            if (_Flag == true)
            {
                oProducto.Cantidad = Convert.ToInt32(NUDCantidad.Value);
                oProducto.CantMin = Convert.ToInt32(NUDCMin.Value);
                oProducto.Categoria = (Entidades.Sistema.CategoriaProducto)CBCategoria.SelectedItem;
                oProducto.Descripcion = TXTDescripcion.Text;
                oProducto.Precio = Convert.ToDecimal(MTXTCUnitario.Text);
                _Controladora.Agregar(oProducto);
                MessageBox.Show("Se agregro el producto Correctamente");
            }
            else
            {
                oProducto.Cantidad = Convert.ToInt32(NUDCantidad.Value);
                oProducto.CantMin = Convert.ToInt32(NUDCMin.Value);
                oProducto.Categoria = (Entidades.Sistema.CategoriaProducto)CBCategoria.SelectedItem;
                oProducto.Descripcion = TXTDescripcion.Text;
                oProducto.Precio = Convert.ToDecimal(MTXTCUnitario.Text);
                _Controladora.Modificar(oProducto);
                MessageBox.Show("Se modifico el producto Correctamente");
            }

            this.Close();
        }

        private void MTXTCUnitario_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
        }
    }
}
