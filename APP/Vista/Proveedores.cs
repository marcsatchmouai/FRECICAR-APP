using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Sistema;
using System.Collections.ObjectModel;

namespace Vista
{
    public partial class Proveedores : Form
    {
        public Proveedor proveedor;
        bool _Flag;

        private ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles;

        public Proveedores(ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles,bool oFlag)
        {
            this._Flag = oFlag;
            this.perfiles = perfiles;
            InitializeComponent();
            GrillaProveedores.AutoGenerateColumns = false;
            ActualizarGrilla();
            CargarPermisos();
            if (_Flag == true)
            {
                Iniciacion();
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
            GrillaProveedores.DataSource = null;
            GrillaProveedores.DataSource = Controladora.Sistema.ControladoraProveedor.ObtenerInstancia().RecuperarProveedores();

        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            FrmProveedor oFrmProveedor = new FrmProveedor();
            oFrmProveedor.Show();
            oFrmProveedor.FormClosed += OFrmProveedor_FormClosed;
        }

        private void OFrmProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActualizarGrilla();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            Proveedor Proveedor = (Proveedor)GrillaProveedores.CurrentRow.DataBoundItem;
            if (Proveedor == null)
            {
                MessageBox.Show("Debe seleccionar un Proveedor de la grilla");
                return;
            }
            FrmProveedor oFrmProveedor = new FrmProveedor(Proveedor);
            oFrmProveedor.Show();
            oFrmProveedor.FormClosed += OFrmProveedor_FormClosed;
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("¿Desea Eliminar Este Proveedor","Proveedor",MessageBoxButtons.YesNo);
            if (Dr == DialogResult.Yes)
            {
                if (GrillaProveedores.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Debe seleccionar un Proveedor de la grilla");
                    return;
                }
                Entidades.Sistema.Proveedor Proveedor = (Entidades.Sistema.Proveedor)GrillaProveedores.CurrentRow.DataBoundItem;
                Controladora.Sistema.ControladoraProveedor.ObtenerInstancia().EliminarProveedor(Proveedor);
                MessageBox.Show("Se a eliminado correctamente");
                ActualizarGrilla();
            } 
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        private void GrillaProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            proveedor = (Entidades.Sistema.Proveedor)GrillaProveedores.CurrentRow.DataBoundItem;
            if (_Flag == true)
            {
                this.Close();
            }
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {

        }

        private void TXTFiltrar_TextChanged(object sender, EventArgs e)
        {
            if (TXTFiltrar.Text == "")
            {
                ActualizarGrilla();
            }
            else
            {
                GrillaProveedores.DataSource = null;
                GrillaProveedores.DataSource = Controladora.Sistema.ControladoraProveedor.ObtenerInstancia().RecuperarProveedores().FindAll(x=>x.RazonSocial.ToLower().StartsWith(TXTFiltrar.Text));
            }
        }
    }
}
