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
    public partial class RealizarRemito : Form
    {
        int oFaltante;
        Entidades.Sistema.OrdenCompra oOrdendeCompra;
        Entidades.Sistema.DetalledeOrdenCompra oDetalleOrden;
        Entidades.Seguridad.Usuario _Usuario;
        ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles;
        Entidades.Sistema.RemitoProveedor oRemitoProveedor;
        private String _Flag;
        public RealizarRemito(ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles, Entidades.Seguridad.Usuario usuario)
        {
            this._Usuario = usuario;
            this.perfiles = perfiles;
            InitializeComponent();
            GrillaDetalleOrden.AutoGenerateColumns = false;
            GrillaDetalleRemito.AutoGenerateColumns = false;
            _Flag = "Agregar";
            oRemitoProveedor = new Entidades.Sistema.RemitoProveedor();
            oRemitoProveedor.Fecha = DateTime.Now;
            LBLFecha.Text = "Fecha :" + oRemitoProveedor.Fecha.ToString();
            oRemitoProveedor.Total = 0;
        }

        public RealizarRemito(string Flag, Entidades.Sistema.RemitoProveedor RemitoProveedor)
        {
            InitializeComponent();
            _Flag = Flag;
            oRemitoProveedor = RemitoProveedor;
            GrillaDetalleRemito.DataSource = oRemitoProveedor.DetalleRemitoProveedor;
            GrillaDetalleOrden.Enabled = false;
            BTNADD.Enabled = false;
            BTNCancelar.Enabled = true;
            BTNEDetalle.Enabled = false;
            BTNRRemito.Enabled = false;

        }

        private void Iniciacion()
        {
            BTNRRemito.Enabled = false;
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
                            if (item3.Nombre == BTNRRemito.Text) BTNRRemito.Enabled = true;
                        }
                    }
                }
            }
        }

        public void ArmarGrillas()
        {
            GrillaDetalleRemito.DataSource = null;
            GrillaDetalleRemito.DataSource = oRemitoProveedor.DetalleRemitoProveedor.ToList();
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOrdenCompra_Load(object sender, EventArgs e)
        {

        }

        private void BTNEDetalle_Click(object sender, EventArgs e)
        {
            if (GrillaDetalleRemito.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Debe seleccionar un detalle de remito");
                return;
            }
            Entidades.Sistema.DetalledeRemitoProveedor oDetalleRemito = (Entidades.Sistema.DetalledeRemitoProveedor)GrillaDetalleRemito.CurrentRow.DataBoundItem;
            oRemitoProveedor.EliminarDetalle(oDetalleRemito);
            ArmarGrillas();
        }

        private void BTNRRemito_Click(object sender, EventArgs e)
        {
            if (BTNSOrden.Enabled == true)
            {
                MessageBox.Show("Debe seleccionar una Orden de Compra");
                return;
            }
            if (_Flag == "Agregar")
            {
                if (oRemitoProveedor.DetalleRemitoProveedor.Count == 0)
                {
                    MessageBox.Show("Debe agregarse algun detalle para realizar el remito");
                    return;
                }
                Controladora.Sistema.ControladoraRealizarRemito.ObtenerInstancia().AgregarRemito(oRemitoProveedor,_Usuario);
                MessageBox.Show("Se a Realizado el Remito con exito");
                this.Close();
            }
        }

        private void BTNSOrden_Click(object sender, EventArgs e)
        {
            OrdenesCompras oFrmOrdenesC = new OrdenesCompras(perfiles,true);
            oFrmOrdenesC.ShowDialog();
            Entidades.Sistema.OrdenCompra OrdenSeleccionado = oFrmOrdenesC.SOrdenCompra;
            if (OrdenSeleccionado == null)
            {
                MessageBox.Show("No se a seleccionado ninguna orden de compra");
                return;
            }
            oOrdendeCompra = OrdenSeleccionado;
            oRemitoProveedor.NumeroOrdenCompra = oOrdendeCompra.Codigo;
            oRemitoProveedor.Proveedor = oOrdendeCompra.Proveedor;
            oRemitoProveedor.Total = oOrdendeCompra.Total;
            LBLProveedor.Text = oOrdendeCompra.Proveedor.RazonSocial;
            GrillaDetalleOrden.DataSource = null;
            GrillaDetalleOrden.DataSource = oOrdendeCompra.DetalleOrdenCompra.ToList();
            BTNSOrden.Enabled = false;
        }

        private void BTNCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNADD_Click_1(object sender, EventArgs e)
        {
            oDetalleOrden = (Entidades.Sistema.DetalledeOrdenCompra)GrillaDetalleOrden.CurrentRow.DataBoundItem;
            if (string.IsNullOrEmpty(MTXTCantidad.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad");
                return;
            }
            if (GrillaDetalleOrden.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Debe seleccionar un detalle de orden de compra");
                return;
            }
            if (Convert.ToInt32(MTXTCantidad.Text) > oDetalleOrden.Faltante)
            {
                MessageBox.Show("La cantidad no puede ser superior al faltante");
                return;
            }
            if (oDetalleOrden.Faltante == 0)
            {
                MessageBox.Show("No se puede agregar mas cantidad a esta materia prima.");
                return;
            }
            oFaltante = Convert.ToInt32(MTXTCantidad.Text);
            oDetalleOrden.Faltante = oDetalleOrden.Faltante - oFaltante;
            oDetalleOrden.MateriaPrima.Cantidad = oDetalleOrden.MateriaPrima.Cantidad + Convert.ToInt32(MTXTCantidad.Text);
            Entidades.Sistema.DetalledeRemitoProveedor oDetalleRemito = new Entidades.Sistema.DetalledeRemitoProveedor();
            oDetalleRemito.Cantidad =Convert.ToInt32(MTXTCantidad.Text);
            oDetalleRemito.MateriaPrima = oDetalleOrden.MateriaPrima;
            oDetalleRemito.SubTotal = oDetalleOrden.SubTotal;
            if (oRemitoProveedor.DetalleRemitoProveedor.ToList().Exists(x => x.MateriaPrima == oDetalleOrden.MateriaPrima))
            {
                MessageBox.Show("Esta Materia Prima ya se encuentra agregada");
                return;
            }
            oRemitoProveedor.AgregarDetalle(oDetalleRemito);
            GrillaDetalleRemito.DataSource = null;
            GrillaDetalleRemito.DataSource = oRemitoProveedor.DetalleRemitoProveedor.ToList();
            GrillaDetalleOrden.DataSource = null;
            GrillaDetalleOrden.DataSource = oOrdendeCompra.DetalleOrdenCompra.ToList();
            MTXTCantidad.Text = "";
        }

        private void BTNEDetalle_Click_1(object sender, EventArgs e)
        {
            if (GrillaDetalleRemito.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Debe seleccionar un detalle de Remito");
                return;
            }
            Entidades.Sistema.DetalledeRemitoProveedor oDetalleRemito = (Entidades.Sistema.DetalledeRemitoProveedor)GrillaDetalleRemito.CurrentRow.DataBoundItem;
            oDetalleOrden.Faltante = oDetalleOrden.Faltante + oFaltante;
            oDetalleOrden.MateriaPrima.Cantidad = oDetalleOrden.MateriaPrima.Cantidad - oFaltante;
            oRemitoProveedor.EliminarDetalle(oDetalleRemito);
            GrillaDetalleRemito.DataSource = null;
            GrillaDetalleRemito.DataSource = oRemitoProveedor.DetalleRemitoProveedor.ToList();
            GrillaDetalleOrden.DataSource = null;
            GrillaDetalleOrden.DataSource = oOrdendeCompra.DetalleOrdenCompra.ToList();
        }

        private void FrmRemitoProveedor_Load(object sender, EventArgs e)
        {

        }

        private void MTXTCantidad_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }
    }
}
