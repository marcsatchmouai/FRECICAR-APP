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
    public partial class Clientes : Form
    {
        private bool _Flag;
        public Entidades.Sistema.Cliente ClienteSeleccionado;
        private ReadOnlyCollection<Perfil> perfiles;
        public Clientes(ReadOnlyCollection<Perfil> oPerfiles, bool Flag)
        {
            InitializeComponent();
            Iniciacion();
            this.perfiles = oPerfiles;
            CargarPermisos();
            this._Flag = Flag;
            if (Flag == true)
            {
                BTNAceptar.Enabled = false;
                BTNEliminar.Enabled = false;
                BTNModificar.Enabled = false;
            }
            CargarGrilla();
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
        void CargarGrilla()
        {
            GrillaClientes.DataSource = null;
            GrillaClientes.DataSource = Controladora.Sistema.ControladoraCliente.ObtenerInstancia().RecuperarClientesActivos();
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            FrmCliente oFrmCliente = new FrmCliente();
            oFrmCliente.ShowDialog();
            CargarGrilla();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Cliente oCliente = (Entidades.Sistema.Cliente)GrillaClientes.CurrentRow.DataBoundItem;
            if (oCliente == null)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            else {
                FrmCliente oFrmCliente = new FrmCliente(oCliente);
                oFrmCliente.ShowDialog();
                CargarGrilla();
            }
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Desea eliminar este cliente?","Eliminar Cliente",MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Entidades.Sistema.Cliente oCliente = (Entidades.Sistema.Cliente)GrillaClientes.CurrentRow.DataBoundItem;
                if (oCliente == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente.");
                    return;
                }
                else {
                    Controladora.Sistema.ControladoraCliente.ObtenerInstancia().Eliminar(oCliente);
                    MessageBox.Show("Se elimino el Cliente Correctamente");
                    CargarGrilla();
                }
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CBTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (CBTodos.Checked)
            {
                GrillaClientes.DataSource = null;
                GrillaClientes.DataSource = Controladora.Sistema.ControladoraCliente.ObtenerInstancia().RecuperarClientes();
            }
            else
            {
                CargarGrilla();
            }
        }

        private void TXTFiltro_TextChanged(object sender, EventArgs e)
        {
            if (TXTFiltro.Text == "")
            {
                if (CBTodos.Checked)
                {
                    GrillaClientes.DataSource = null;
                    GrillaClientes.DataSource = Controladora.Sistema.ControladoraCliente.ObtenerInstancia().RecuperarClientes();
                }
                else
                {
                    CargarGrilla();
                }
            }
            else
            {
                if (CBTodos.Checked)
                {
                    GrillaClientes.DataSource = null;
                    GrillaClientes.DataSource = Controladora.Sistema.ControladoraCliente.ObtenerInstancia().RecuperarClientes().FindAll(x => x.RazonSocial.ToLower().StartsWith(TXTFiltro.Text));
                }
                else
                {
                    GrillaClientes.DataSource = null;
                    GrillaClientes.DataSource = Controladora.Sistema.ControladoraCliente.ObtenerInstancia().RecuperarClientesActivos().FindAll(x => x.RazonSocial.ToLower().StartsWith(TXTFiltro.Text));

                }
            }
        }

        private void GrillaClientes_DoubleClick(object sender, EventArgs e)
        {
            Entidades.Sistema.Cliente oCliente = (Entidades.Sistema.Cliente)GrillaClientes.CurrentRow.DataBoundItem;
            if (_Flag == false)
            {
                FrmCuentaCorriente oFrmCC = new FrmCuentaCorriente(oCliente);
                oFrmCC.ShowDialog();
            }
            else
            {
                ClienteSeleccionado = oCliente;
                this.Close();
            }
        }
    }
}
