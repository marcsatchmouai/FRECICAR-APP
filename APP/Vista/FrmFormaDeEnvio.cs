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
    public partial class FrmFormaDeEnvio : Form
    {
        Entidades.Sistema.FormadeEnvio oFormadeEnvio;
        string _Flag;
        public FrmFormaDeEnvio()
        {
            InitializeComponent();
            _Flag = "Agregar";
        }

        public FrmFormaDeEnvio(Entidades.Sistema.FormadeEnvio FormadeEnvio)
        {
            InitializeComponent();
            oFormadeEnvio = FormadeEnvio;
            _Flag = "Modificar";
            TXTNombre.Text = oFormadeEnvio.Nombre;
            TXTDescripcion.Text = oFormadeEnvio.Descripcion;
            TXTNombre.Enabled = false;
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (_Flag == "Agregar")
            {
                oFormadeEnvio = new Entidades.Sistema.FormadeEnvio();
                if (string.IsNullOrEmpty(TXTNombre.Text) || string.IsNullOrEmpty(TXTDescripcion.Text))
                {
                    MessageBox.Show("Debe Completarse Todos los campos");
                    return;
                }
                oFormadeEnvio.Nombre = TXTNombre.Text;
                oFormadeEnvio.Descripcion = TXTDescripcion.Text;
                Controladora.Sistema.ControladoraFormadeEnvio.ObtenerInstancia().AgregarFormadeEnvio(oFormadeEnvio);
                MessageBox.Show("se a agregado correctamente");
                this.Close();
            }
            if (_Flag == "Modificar")
            {
                if (string.IsNullOrEmpty(TXTNombre.Text) || string.IsNullOrEmpty(TXTDescripcion.Text))
                {
                    MessageBox.Show("Debe Completarse Todos los campos");
                    return;
                }
                oFormadeEnvio.Nombre = TXTNombre.Text;
                oFormadeEnvio.Descripcion = TXTDescripcion.Text;
                Controladora.Sistema.ControladoraFormadeEnvio.ObtenerInstancia().ModificarFormadeEnvio(oFormadeEnvio);
                MessageBox.Show("se a modificado correctamente");
                this.Close();
            }
             
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
