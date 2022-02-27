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

namespace Vista
{
    public partial class MateriasPrimas : Form
    {
        private ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles;

        public MateriasPrimas(ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles)
        {
            this.perfiles = perfiles;
            InitializeComponent();
            GrillaMateriasPrimas.AutoGenerateColumns = false;
            Iniciacion();
            ActualizarGrilla();
            CargarPermisos();
            GrillaMateriasPrimas.DataBindingComplete += GrillaMateriasPrimas_DataBindingComplete;
        }

        private void GrillaMateriasPrimas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow item in GrillaMateriasPrimas.Rows)
            {
                if (Convert.ToInt32(item.Cells["Cantidad"].Value) == 0)
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (Convert.ToInt32(item.Cells["Cantidad"].Value) < Convert.ToInt32(item.Cells["CantMin"].Value))
                {
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                }
                    
            }
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
            GrillaMateriasPrimas.DataSource = null;
            GrillaMateriasPrimas.DataSource = Controladora.Sistema.ControladoraMateriaPrima.ObtenerInstancia().RecuperarMateriasPrimas();
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            FrmMateriaPrima oFrmMateriaPrima = new FrmMateriaPrima();
            oFrmMateriaPrima.Show();
            oFrmMateriaPrima.FormClosed += OFrmMateriaPrima_FormClosed;
        }

        private void OFrmMateriaPrima_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActualizarGrilla();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            if (GrillaMateriasPrimas.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Debe seleccionar una Materia Prima de la grilla");
                return;
            }
            Entidades.Sistema.MateriaPrima oMateriaPrima = (Entidades.Sistema.MateriaPrima)GrillaMateriasPrimas.CurrentRow.DataBoundItem;
            FrmMateriaPrima oFrmMateriaPrima = new FrmMateriaPrima(oMateriaPrima);
            oFrmMateriaPrima.Show();
            oFrmMateriaPrima.FormClosed += OFrmMateriaPrima_FormClosed;
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("¿Desea eliminar la materia prima?","Materia Prima",MessageBoxButtons.YesNo);
            if (Dr == DialogResult.Yes)
            {
                if (GrillaMateriasPrimas.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Debe seleccionar una Materia Prima de la grilla");
                    return;
                }
                Entidades.Sistema.MateriaPrima oMateriaPrima = (Entidades.Sistema.MateriaPrima)GrillaMateriasPrimas.CurrentRow.DataBoundItem;
                Controladora.Sistema.ControladoraMateriaPrima.ObtenerInstancia().EliminarMateriaPrima(oMateriaPrima);
                MessageBox.Show("Se a eliminado correctamente");
                ActualizarGrilla();
                this.Close();
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMateriasPrimas_Load(object sender, EventArgs e)
        {
            GrillaMateriasPrimas.AutoGenerateColumns = false;
        }

        private void TXTFiltrar_TextChanged(object sender, EventArgs e)
        {
            if (TXTFiltrar.Text == "")
            {
                ActualizarGrilla();
            }
            else
            {
                GrillaMateriasPrimas.DataSource = null;
                GrillaMateriasPrimas.DataSource = Controladora.Sistema.ControladoraMateriaPrima.ObtenerInstancia().RecuperarMateriasPrimas().FindAll(x=>x.Descripcion.ToLower().StartsWith(TXTFiltrar.Text.ToLower()));
            }
        }

        private void GrillaMateriasPrimas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
