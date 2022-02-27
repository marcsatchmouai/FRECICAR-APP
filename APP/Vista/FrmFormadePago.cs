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
    public partial class FrmFormadePago : Form
    {
        string _Flag;
        Entidades.Sistema.FormadePago oFormadePago;
        public FrmFormadePago()
        {
            InitializeComponent();
            _Flag = "Agregar";
        }
        public FrmFormadePago(Entidades.Sistema.FormadePago FormadePago)
        {
            oFormadePago = FormadePago;
            InitializeComponent();
            _Flag = "Modificar";
            TXTNombre.Text = oFormadePago.Nombre;
            TXTDescripcion.Text = oFormadePago.Descripcion;
            TXTNombre.Enabled = false;
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (_Flag == "Agregar")
            {
                oFormadePago = new Entidades.Sistema.FormadePago();
                if (string.IsNullOrEmpty(TXTNombre.Text) || string.IsNullOrEmpty(TXTDescripcion.Text))
                {
                    MessageBox.Show("Debe Completarse Todos los Campos");
                    return;
                }
                oFormadePago.Nombre = TXTNombre.Text;
                oFormadePago.Descripcion = TXTDescripcion.Text;
                Controladora.Sistema.ControladoraFormadePago.ObtenerInstancia().AgregarFormadePago(oFormadePago);
                MessageBox.Show("Se a agregado Correctamente");
                this.Close();
            }

            if (_Flag == "Modificar")
            {
                if (string.IsNullOrEmpty(TXTNombre.Text) || string.IsNullOrEmpty(TXTDescripcion.Text))
                {
                    MessageBox.Show("Debe Completarse Todos los Campos");
                    return;
                }
                oFormadePago.Nombre = TXTNombre.Text;
                oFormadePago.Descripcion = TXTDescripcion.Text;
                Controladora.Sistema.ControladoraFormadePago.ObtenerInstancia().ModificarFormadePago(oFormadePago);
                MessageBox.Show("Se a Modificado Correctamente");
                this.Close();
            }
        }
    }
}
