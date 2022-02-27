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
    public partial class FormaPagos : Form
    {
        private ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles;

        public FormaPagos(ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles)
        {
            
            this.perfiles = perfiles;
            InitializeComponent();
            Iniciacion();
            GrillaFormadePago.AutoGenerateColumns = false;
            ActualizarGrilla();
            CargarPermisos();
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
        public void ActualizarGrilla()
        {
            GrillaFormadePago.DataSource = null;
            GrillaFormadePago.DataSource = Controladora.Sistema.ControladoraFormadePago.ObtenerInstancia().RecuperarFormasdePagos();
        }

        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            FrmFormadePago oFrmFormadePago = new FrmFormadePago();
            oFrmFormadePago.Show();
            oFrmFormadePago.FormClosed += OFrmFormadePago_FormClosed;
        }

        private void OFrmFormadePago_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActualizarGrilla();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            if (GrillaFormadePago.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Debe seleccionar una Forma de Pago de la grilla");
                return;
            }
            Entidades.Sistema.FormadePago oFormadePago = (Entidades.Sistema.FormadePago)GrillaFormadePago.CurrentRow.DataBoundItem;
            FrmFormadePago oFrmFormadePago = new FrmFormadePago(oFormadePago);
            oFrmFormadePago.Show();
            oFrmFormadePago.FormClosed += OFrmFormadePago_FormClosed;
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("¿Desea Eliminar la Forma de Pago?", "Forma de Pago", MessageBoxButtons.YesNo);
            if (Dr == DialogResult.Yes)
            {
                if (GrillaFormadePago.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Debe seleccionar una Forma de Pago de la grilla");
                    return;
                }
                Entidades.Sistema.FormadePago oFormadePago = (Entidades.Sistema.FormadePago)GrillaFormadePago.CurrentRow.DataBoundItem;
                Controladora.Sistema.ControladoraFormadePago.ObtenerInstancia().EliminarFormadePago(oFormadePago);
                MessageBox.Show("Se a eliminado Correctamente");
                ActualizarGrilla();
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TXTFiltro_TextChanged(object sender, EventArgs e)
        {
            if (TXTFiltro.Text == "")
            {
                ActualizarGrilla();
            }
            else
            {
                GrillaFormadePago.DataSource = null;
                GrillaFormadePago.DataSource = Controladora.Sistema.ControladoraFormadePago.ObtenerInstancia().RecuperarFormasdePagos().FindAll(x => x.Nombre.ToLower().StartsWith(TXTFiltro.Text.ToLower()));
            }
        }

        private void GrillaFormadePago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
