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
    public partial class CategoriasP : Form
    {
        Controladora.Sistema.ControladoraCategoriaProducto _Controladora = Controladora.Sistema.ControladoraCategoriaProducto.ObtenerInstancia();
        private ReadOnlyCollection<Perfil> perfiles;
        public CategoriasP(ReadOnlyCollection<Perfil> oPerfiles)
        {
            this.perfiles = oPerfiles;
            InitializeComponent();
            GrillaCategoria.AutoGenerateColumns = false;
            Iniciacion();
            ActualizarGrilla();
            CargarPermisos();
        }

        private void Iniciacion()
        {
            BTNAceptar.Enabled = false;
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
                            if (item3.Nombre == BTNAceptar.Text) BTNAceptar.Enabled = true;
                            if (item3.Nombre == BTNModificar.Text) BTNModificar.Enabled = true;
                            if (item3.Nombre == BTNEliminar.Text) BTNEliminar.Enabled = true;
                        }
                    }
                }
            }
        }

        public void ActualizarGrilla()
        {
            GrillaCategoria.DataSource = null;
            GrillaCategoria.DataSource = _Controladora.RecuperarCategorias();
        }
        private void OFrmCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            //    ActualizarGrilla();
        }         
        private void TXTFiltro_TextChanged(object sender, EventArgs e)
        {
            if (TXTFiltro.Text == "")
            {
                ActualizarGrilla();
            }
            else
            {
                GrillaCategoria.DataSource = null;
                GrillaCategoria.DataSource = _Controladora.RecuperarCategorias().FindAll(x => x.Nombre.ToLower().StartsWith(TXTFiltro.Text.ToLower()));
            }
        }

        private void BTNCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNAceptar_Click_1(object sender, EventArgs e)
        {
            FrmCategoriaProducto oFrmCategoria = new FrmCategoriaProducto();
            oFrmCategoria.ShowDialog();
            ActualizarGrilla();
            //     oFrmCategoria.FormClosed += OFrmCategoria_FormClosed;
        }

        private void BTNModificar_Click_1(object sender, EventArgs e)
        {
            Entidades.Sistema.CategoriaProducto oCategoria = new Entidades.Sistema.CategoriaProducto();
            if (GrillaCategoria.RowCount == 0)
            {
                MessageBox.Show("Debe seleccionar una categoria de la grilla");
                return;
            }
            oCategoria = (Entidades.Sistema.CategoriaProducto)GrillaCategoria.CurrentRow.DataBoundItem;
            if (oCategoria == null)
            {
                MessageBox.Show("Debe seleccionar una categoria de la grilla");
                return;
            }
            FrmCategoriaProducto oFrmCategoria = new FrmCategoriaProducto(oCategoria);
            oFrmCategoria.ShowDialog();
            ActualizarGrilla();
            oFrmCategoria.FormClosed += OFrmCategoria_FormClosed;
        }

        private void BTNEliminar_Click_1(object sender, EventArgs e)
        {
            Entidades.Sistema.CategoriaProducto oCategoria = new Entidades.Sistema.CategoriaProducto();
            DialogResult Dr = MessageBox.Show("¿Desea Eliminar la Categoria?", "Categoria", MessageBoxButtons.YesNo);
            if (Dr == DialogResult.Yes)
            {
                oCategoria = (Entidades.Sistema.CategoriaProducto)GrillaCategoria.CurrentRow.DataBoundItem;

                if (oCategoria == null)
                {
                    MessageBox.Show("Debe seleccionar una categoria de la grilla");
                    return;
                }
                _Controladora.Eliminar(oCategoria);
                MessageBox.Show("Se a eliminado Correctamente");
                ActualizarGrilla();
            }
        }
    }
}
