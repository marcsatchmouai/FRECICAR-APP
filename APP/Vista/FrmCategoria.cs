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
    public partial class FrmCategoria : Form
    {
        Entidades.Sistema.Categoria oCategoria;
        string _Flag;
        public FrmCategoria()
        {
            InitializeComponent();
            _Flag = "Agregar";
        }

        public FrmCategoria(Entidades.Sistema.Categoria Categoria)
        {
            InitializeComponent();
            _Flag = "Modificar";
            TXTNombre.Text = Categoria.Nombre;
            TXTDescripcion.Text = Categoria.Descripcion;
            TXTNombre.Enabled = false;
            oCategoria = Categoria;
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {

        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (_Flag == "Agregar")
            {
                oCategoria = new Entidades.Sistema.Categoria();
                if (string.IsNullOrEmpty(TXTNombre.Text) || string.IsNullOrEmpty(TXTDescripcion.Text))
                {
                    MessageBox.Show("Debe Completarse Todos los Campos");
                    return;
                }
                oCategoria.Nombre = TXTNombre.Text;
                oCategoria.Descripcion = TXTDescripcion.Text;
                Controladora.Sistema.ControladoraCategoria.ObtenerInstancia().AgregarCategoria(oCategoria);
                MessageBox.Show("Se a agregado correctamente");
                this.Close();
            }

            if (_Flag == "Modificar")
            {
                if (string.IsNullOrEmpty(TXTNombre.Text) || string.IsNullOrEmpty(TXTDescripcion.Text))
                {
                    MessageBox.Show("Debe Completarse Todos los Campos");
                    return;
                }
                oCategoria.Nombre = TXTNombre.Text;
                oCategoria.Descripcion = TXTDescripcion.Text;
                Controladora.Sistema.ControladoraCategoria.ObtenerInstancia().ModificarCategoria(oCategoria);
                MessageBox.Show("Se a modificado correctamente");
                this.Close();
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
