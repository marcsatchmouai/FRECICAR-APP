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

namespace Vista
{
    public partial class FormaEnvios : Form
    {
        private ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles;

        public FormaEnvios(ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles)
        {

            this.perfiles = perfiles;
            InitializeComponent();
            Iniciacion();
            GrillaFormadeEnvio.AutoGenerateColumns = false;
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
            GrillaFormadeEnvio.DataSource = null;
            GrillaFormadeEnvio.DataSource = Controladora.Sistema.ControladoraFormadeEnvio.ObtenerInstancia().RecuperarFormasdeEnvios();
        }



        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            FrmFormaDeEnvio oFrmFormadeEnvio = new FrmFormaDeEnvio();
            oFrmFormadeEnvio.ShowDialog();
            ActualizarGrilla();
            oFrmFormadeEnvio.FormClosed += OFrmFormadeEnvio_FormClosed;
        }

        private void OFrmFormadeEnvio_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActualizarGrilla();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            if (GrillaFormadeEnvio.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Debe seleccionar una Forma de envio de la grilla");
                return;
            }
            Entidades.Sistema.FormadeEnvio oFormadeEnvio = (Entidades.Sistema.FormadeEnvio)GrillaFormadeEnvio.CurrentRow.DataBoundItem;
            FrmFormaDeEnvio OFrmFormadeEnvio = new FrmFormaDeEnvio(oFormadeEnvio);
            OFrmFormadeEnvio.ShowDialog();
            ActualizarGrilla();
            OFrmFormadeEnvio.FormClosed += OFrmFormadeEnvio_FormClosed;
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("¿Desea elimnar Esta Forma de Envio?","Forma de Envio",MessageBoxButtons.YesNo);
            if (Dr == DialogResult.Yes)
            {
                if (GrillaFormadeEnvio.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Debe seleccionar una Forma de envio de la grilla");
                    return;
                }
                Entidades.Sistema.FormadeEnvio oFormadeEnvio = (Entidades.Sistema.FormadeEnvio)GrillaFormadeEnvio.CurrentRow.DataBoundItem;
                Controladora.Sistema.ControladoraFormadeEnvio.ObtenerInstancia().EliminarFormadeEnvio(oFormadeEnvio);
                MessageBox.Show("Se a eliminado Correctamente");
                ActualizarGrilla();
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TXTFiltro.Text == "")
            {
                ActualizarGrilla();
            }
            else
            {
                GrillaFormadeEnvio.DataSource = null;
                GrillaFormadeEnvio.DataSource = Controladora.Sistema.ControladoraFormadeEnvio.ObtenerInstancia().RecuperarFormasdeEnvios().FindAll(x => x.Nombre.ToLower().StartsWith(TXTFiltro.Text.ToLower()));
            }
        }

        private void GrillaFormadeEnvio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
