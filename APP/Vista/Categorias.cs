using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Seguridad;

namespace Vista
{
    public partial class Categorias : Form
    {
        
        private ReadOnlyCollection<Perfil> perfiles;

        public Categorias(ReadOnlyCollection<Perfil> perfiles)
        {

            this.perfiles = perfiles;
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
             GrillaCategoria.DataSource = Controladora.Sistema.ControladoraCategoria.ObtenerInstancia().RecuperarCategorias();
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            FrmCategoria oFrmCategoria = new FrmCategoria();
            oFrmCategoria.ShowDialog();
            ActualizarGrilla();
     //     oFrmCategoria.FormClosed += OFrmCategoria_FormClosed;
        }

        private void OFrmCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
        //    ActualizarGrilla();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Categoria oCategoria;
            if (GrillaCategoria.RowCount == 0)
            {
                MessageBox.Show("Debe seleccionar una categoria de la grilla");
                return;
            }
            oCategoria = (Entidades.Sistema.Categoria)GrillaCategoria.CurrentRow.DataBoundItem;
            FrmCategoria oFrmCategoria = new FrmCategoria(oCategoria);
            oFrmCategoria.ShowDialog();
            ActualizarGrilla();
            oFrmCategoria.FormClosed += OFrmCategoria_FormClosed;
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Categoria oCategoria;
            DialogResult Dr = MessageBox.Show("¿Desea Eliminar la Categoria?","Categoria",MessageBoxButtons.YesNo);
            if (Dr == DialogResult.Yes)
            {
                if (GrillaCategoria.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Debe seleccionar una categoria de la grilla");
                    return;
                }
                oCategoria = (Entidades.Sistema.Categoria)GrillaCategoria.CurrentRow.DataBoundItem;
                Controladora.Sistema.ControladoraCategoria.ObtenerInstancia().EliminarCategoria(oCategoria);
                MessageBox.Show("Se a eliminado Correctamente");
                ActualizarGrilla();
            }

        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFiltrar_Click(object sender, EventArgs e)
        {

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
                GrillaCategoria.DataSource = Controladora.Sistema.ControladoraCategoria.ObtenerInstancia().RecuperarCategorias().FindAll(x => x.Nombre.ToLower().StartsWith(TXTFiltro.Text.ToLower()));
            }
        }

        private void GrillaCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {

        }
    }
}
