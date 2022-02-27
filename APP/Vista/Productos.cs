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
    public partial class Productos : Form
    {
        Controladora.Sistema.ControladoraProducto _Controladora = Controladora.Sistema.ControladoraProducto.ObtenerInstancia();
        private ReadOnlyCollection<Perfil> perfiles;
        public Productos(ReadOnlyCollection<Perfil> oPerfiles)
        {
            this.perfiles = oPerfiles;
            InitializeComponent();
            Iniciacion();
            CargarPermisos();
            RBCodigo.Checked = true;
            Cargar();
        }

        private void Iniciacion()
        {
            BTNAgregar.Enabled = false;
            BTNEliminar.Enabled = false;
            BTNModificar.Enabled = false;
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
                            if (item3.Nombre == BTNModificar.Text) BTNModificar.Enabled = true;
                            if (item3.Nombre == BTNEliminar.Text) BTNEliminar.Enabled = true;
                        }
                    }
                }
            }
        }

        public void Cargar()
        {
            DGVProducto.DataSource = null;
            DGVProducto.DataSource = _Controladora.RecuperarProducto();
        }

        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            FrmProducto FrmProducto = new Vista.FrmProducto();
            FrmProducto.Show();
            FrmProducto.FormClosed += FrmProducto_FormClosed;
        }

        private void FrmProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Producto oProducto = (Entidades.Sistema.Producto) DGVProducto.CurrentRow.DataBoundItem;
            if (oProducto == null)
            {
                MessageBox.Show("Por favor seleccione un producto.");
                return;
            }
            else
            {
                FrmProducto FrmProducto = new Vista.FrmProducto(oProducto);
                FrmProducto.Show();
                FrmProducto.FormClosed += FrmProducto_FormClosed;
            }
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Producto oProducto = (Entidades.Sistema.Producto)DGVProducto.CurrentRow.DataBoundItem;
            if (oProducto == null)
            {
                MessageBox.Show("Por favor seleccione un producto.");
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show("¿Desea eliminar el producto?","Eliminar Producto",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    _Controladora.Eliminar(oProducto);
                    MessageBox.Show("Se ha eliminado el Producto Correctamente");
                    Cargar();
                }
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TXTBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TXTBuscar.Text == "")
            {
                Cargar();
            }
            else if (RBCodigo.Checked == true)
            {
                DGVProducto.DataSource = null;
                DGVProducto.DataSource = _Controladora.RecuperarProducto().FindAll(x => x.Codigo.ToString().ToLower().Contains(TXTBuscar.Text.ToLower()));
            }
            else if (RBCategoria.Checked == true)
            {
                DGVProducto.DataSource = null;
                DGVProducto.DataSource = _Controladora.RecuperarProducto().FindAll(x => x.Categoria.ToString().ToLower().StartsWith(TXTBuscar.Text.ToLower()));
            }
            else
            {
                DGVProducto.DataSource = null;
                DGVProducto.DataSource = _Controladora.RecuperarProducto().FindAll(x => x.Descripcion.ToString().ToLower().StartsWith(TXTBuscar.Text.ToLower()));
            }
        }
    }
}
