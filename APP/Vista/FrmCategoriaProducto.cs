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
    public partial class FrmCategoriaProducto : Form
    {
        Controladora.Sistema.ControladoraCategoriaProducto _Controladora = Controladora.Sistema.ControladoraCategoriaProducto.ObtenerInstancia();
        Entidades.Sistema.CategoriaProducto oCategoria;
        string _Flag;
        public FrmCategoriaProducto()
        {
            InitializeComponent();
            _Flag = "Agregar";
        }

        public FrmCategoriaProducto(Entidades.Sistema.CategoriaProducto Categoria)
        {
            InitializeComponent();
            _Flag = "Modificar";
            TXTNombre.Text = Categoria.Nombre;
            TXTDescripcion.Text = Categoria.Descripcion;
            TXTNombre.Enabled = false;
            oCategoria = Categoria;
        }
        private void BTNAceptar_Click_1(object sender, EventArgs e)
        {
            if (_Flag == "Agregar")
            {
                oCategoria = new Entidades.Sistema.CategoriaProducto();
                if (string.IsNullOrEmpty(TXTNombre.Text) || string.IsNullOrEmpty(TXTDescripcion.Text))
                {
                    MessageBox.Show("Debe Completarse Todos los Campos");
                    return;
                }
                oCategoria.Nombre = TXTNombre.Text;
                oCategoria.Descripcion = TXTDescripcion.Text;
                _Controladora.Agregar(oCategoria);
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
                _Controladora.Modificar(oCategoria);
                MessageBox.Show("Se a modificado correctamente");
                this.Close();
            }
        }

        private void BTNCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
