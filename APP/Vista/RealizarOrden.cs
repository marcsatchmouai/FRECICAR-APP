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
    public partial class RealizarOrden : Form
    {
        Entidades.Sistema.Proveedor oProveedor;
        Entidades.Seguridad.Usuario _Usuario;
        ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles;
        Entidades.Sistema.OrdenCompra oOrdenCompra;
        private String _Flag;
        public RealizarOrden(ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles, Entidades.Seguridad.Usuario usuario)
        {
            this.perfiles = perfiles;
            this._Usuario = usuario;
            InitializeComponent();
            GrillaMateriaPrima.AutoGenerateColumns = false;
            GrillaDetalle.AutoGenerateColumns = false;
            GrillaDetalle.AutoGenerateColumns = false;
            GrillaMateriaPrima.AutoGenerateColumns = false;
            _Flag = "Agregar";
            oOrdenCompra = new Entidades.Sistema.OrdenCompra();
            CargarCombos();
            ArmarGrillas();
            oOrdenCompra.Fecha = DateTime.Now;
            LBLFecha.Text = "Fecha :" + oOrdenCompra.Fecha.ToString();
            oOrdenCompra.Total = 0;
            oOrdenCompra.Estado = "Realizado";
        }

        public RealizarOrden(string Flag,Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            InitializeComponent();

            _Flag = Flag;
            oOrdenCompra = OrdenCompra;
            GrillaDetalle.DataSource = oOrdenCompra.DetalleOrdenCompra;
            GrillaMateriaPrima.Enabled = false;
            BTNADD.Enabled = false;
            BTNCancelar.Enabled = true;
            BTNEDetalle.Enabled = false;
            BTNROrdenCompra.Enabled = false;
            
        }

        private void Iniciacion()
        {
            BTNROrdenCompra.Enabled = false;
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
                            if (item3.Nombre == BTNROrdenCompra.Text) BTNROrdenCompra.Enabled = true;
                        }
                    }
                }
            }
        }
        public void ArmarGrillas()
        {
            GrillaDetalle.DataSource = null;
            GrillaDetalle.DataSource = oOrdenCompra.DetalleOrdenCompra.ToList();
        }

        public void CargarCombos()
        {
            CMBFormadeEnvio.DataSource = Controladora.Sistema.ControladoraRealizarOrdenCompra.ObtenerInstancia().RecuperarFormadeEnvios();
            CMBFormadeEnvio.DisplayMember = "Nombre";
            CMBFormadePago.DataSource = Controladora.Sistema.ControladoraRealizarOrdenCompra.ObtenerInstancia().RecuperarFormasdePagos();
            CMBFormadePago.DisplayMember = "Nombre";
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNADD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MTXTCantidad.Text) || Convert.ToInt32(MTXTCantidad.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar la cantidad");
                return;
            }
            if (GrillaMateriaPrima.RowCount <= 0)
            {
                MessageBox.Show("No hay Materias Primas a Agregar");
                return;
            }
            if (GrillaMateriaPrima.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No ah seleccionado una Materia Prima a agregar");
                return;
            }

            Entidades.Sistema.MateriaPrima oMateriaPrima = (Entidades.Sistema.MateriaPrima)GrillaMateriaPrima.CurrentRow.DataBoundItem;
            Entidades.Sistema.DetalledeOrdenCompra oDetalleOrdenCompra = new Entidades.Sistema.DetalledeOrdenCompra();
            oDetalleOrdenCompra.MateriaPrima = oMateriaPrima;
            oDetalleOrdenCompra.Cantidad = Convert.ToInt32(MTXTCantidad.Text);
            oDetalleOrdenCompra.Faltante = Convert.ToInt32(MTXTCantidad.Text);
            if (oOrdenCompra.DetalleOrdenCompra.ToList().Exists(x => x.MateriaPrima == oDetalleOrdenCompra.MateriaPrima))
            {
                MessageBox.Show("Esta Materia Prima ya se encuentra agregada");
                return;
            }
            oOrdenCompra.AgregarDetalle(oDetalleOrdenCompra);
            LBLTotal.Text = "Total:" + oOrdenCompra.Total.ToString() + "$";
            MTXTCantidad.Text = "";
            ArmarGrillas();
        }

        private void BTNROrdenCompra_Click(object sender, EventArgs e)
        {
            if(_Flag == "Agregar")
            {
                if (CMBFormadeEnvio.SelectedItem == null || CMBFormadePago.SelectedItem == null)
                {
                    MessageBox.Show("Debe completar todos los combos");
                    return;
                }
                if (oOrdenCompra.DetalleOrdenCompra.Count == 0)
                {
                    MessageBox.Show("No se ah cargado ningun detalle");
                    return;
                }
                oOrdenCompra.FormadeEnvio =(Entidades.Sistema.FormadeEnvio)CMBFormadeEnvio.SelectedItem;
                oOrdenCompra.FormadePago = (Entidades.Sistema.FormadePago)CMBFormadePago.SelectedItem;
                oOrdenCompra.Proveedor = oProveedor;
                oOrdenCompra.Usuario = _Usuario.NombreUsuario;
                Controladora.Sistema.ControladoraRealizarOrdenCompra.ObtenerInstancia().AgregarOrdenCompra(oOrdenCompra);
                MessageBox.Show("Se a Realizado el OrdenCompra con exito");
                this.Close();
                OrdenesCompras oFrmOC = new OrdenesCompras(perfiles,false);
                oFrmOC.Show();
            }
        }

        private void FrmOrdenCompra_Load(object sender, EventArgs e)
        {

        }

        private void BTNEDetalle_Click(object sender, EventArgs e)
        {
            if (GrillaDetalle.RowCount <= 0)
            {
                MessageBox.Show("No hay elementos que eliminar.");
                return;
            }
            if (GrillaDetalle.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Debe seleccionar un Detalle a Eliminar");
                return;
            }
            Entidades.Sistema.DetalledeOrdenCompra oDetalleOrdenCompra = (Entidades.Sistema.DetalledeOrdenCompra)GrillaDetalle.CurrentRow.DataBoundItem;
            oOrdenCompra.EliminarDetalle(oDetalleOrdenCompra);
            LBLTotal.Text = "Total: " + oOrdenCompra.Total.ToString() + " .";
            ArmarGrillas();
        }
        private void BTNSProveedor_Click(object sender, EventArgs e)
        {
            Proveedores oFrmProveedor = new Proveedores(this.perfiles,true);
            oFrmProveedor.ShowDialog();
            Entidades.Sistema.Proveedor ProveedorSeleccionado = oFrmProveedor.proveedor;
            if (ProveedorSeleccionado == null)
            {
                MessageBox.Show("No hay un proveedor seleccionado");
            }
            else
            {
                oProveedor = ProveedorSeleccionado;
                TXTProveedor.Text = oProveedor.RazonSocial;
                GrillaMateriaPrima.DataSource = null;
                GrillaMateriaPrima.DataSource = Controladora.Sistema.ControladoraRealizarOrdenCompra.ObtenerInstancia().RecuperarMateriasPrimas(oProveedor);
                this.BTNSProveedor.Enabled = false;
            }
         }

        private void MTXTCantidad_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }
    }
}
