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
    public partial class RealizarVenta : Form
    {
        private Entidades.Sistema.Caretaker oCarataker;
        private Entidades.Sistema.Venta oVenta = new Entidades.Sistema.Venta();
        private bool _Flag;
        private Controladora.Sistema.ControladoraVenta _Controladora = Controladora.Sistema.ControladoraVenta.ObtenerInstancia();
        ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles;
        public RealizarVenta(ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles)
        {
            InitializeComponent();
            this.perfiles = perfiles;
            CargarPermisos();
            CargadeCombos();
            CargarGuillaProdcuto();
            LBLFecha.Text = DateTime.Now.ToString();
            LBLTotal.Text = "0";
        }


        private void CargarPermisos()
        {
            foreach (var item in perfiles)
            {
                foreach (var item2 in item.Formularios)
                {
                    if (item2.Nombre == this.Text)
                    {
                        foreach (var item3 in item2.Permisos)
                        {
                        }
                    }
                }
            }
        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            oCarataker = new Entidades.Sistema.Caretaker();
        }

        public void CargadeCombos()
        {
            CMBEnvio.DataSource = Controladora.Sistema.ControladoraFormadeEnvio.ObtenerInstancia().RecuperarFormasdeEnvios();
            CMBEnvio.DisplayMember = "Nombre";
            CMBFormaPago.DataSource = Controladora.Sistema.ControladoraFormadePago.ObtenerInstancia().RecuperarFormasdePagos();
            CMBFormaPago.DisplayMember = "Nombre";
        }

        public void CargarGuillaProdcuto()
        {
            DGVProductos.DataSource = null;
            DGVProductos.DataSource = _Controladora.RecuperarProductos();
        }
        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNSeleccionarCliente_Click(object sender, EventArgs e)
        {
            _Flag = true;
            Clientes oFrmCliente = new Clientes(perfiles,_Flag);
            oFrmCliente.ShowDialog();
            Entidades.Sistema.Cliente oClienteSeleccionado = oFrmCliente.ClienteSeleccionado;
            if (oClienteSeleccionado == null)
            {
                MessageBox.Show("No ah seleccionado Un Cliente");
                return;
            }
            else
            {
                BTNSeleccionarCliente.Enabled = false;
                oVenta.Cliente = oClienteSeleccionado;
                LBLCliente.Text = oVenta.Cliente.RazonSocial;
            }

            
        }

        private void BTNRealizarVenta_Click(object sender, EventArgs e)
        {
            if (BTNSeleccionarCliente.Enabled == true)
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;
            }
            if (oVenta.DetallesVentas.Count == 0)
            {
                MessageBox.Show("Debe cargar Detalles a la Venta");
                return;
            }
            oVenta.Estado = Entidades.Sistema.Venta.EstadoVenta.Relizado;
            oVenta.Fecha = Convert.ToDateTime(LBLFecha.Text);
            oVenta.FormadePago = (Entidades.Sistema.FormadePago)CMBFormaPago.SelectedItem;
            oVenta.Envio = (Entidades.Sistema.FormadeEnvio)CMBEnvio.SelectedItem;
            oVenta.Total = Convert.ToDecimal(LBLTotal.Text);
            _Controladora.Agregar(oVenta);
            MessageBox.Show("Se agrego la venta correctamente");
            this.Close();
            Ventas oFrmVenta = new Ventas(perfiles);
            oFrmVenta.Show();
        }

        private void BTNADD_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Producto oProducto = (Entidades.Sistema.Producto)DGVProductos.CurrentRow.DataBoundItem;
            if (oProducto == null)
            {
                MessageBox.Show("Debe seleccionar un Producto");
                return;
            }
            Entidades.Sistema.DetalleVenta oDetalle = new Entidades.Sistema.DetalleVenta();
            if (string.IsNullOrEmpty(MTXTCantidad.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad deseada");
                return;
            }
            if (oProducto.Cantidad < Convert.ToInt32(MTXTCantidad.Text))
            {
                MessageBox.Show("No hay Stock Suficiente de este Producto");
                return;
            }
            
            oDetalle.Cantidad = Convert.ToInt32(MTXTCantidad.Text);
            oDetalle.Producto = oProducto;
            oDetalle.SubTotal = oProducto.Precio * oDetalle.Cantidad;
            oCarataker.AgregarMemento(oVenta.CrearMemento());

            oVenta.AgregarDetalle(oDetalle);
            CargarGrillaDetalle();
            MTXTCantidad.Text = "";
            oVenta.Total += oDetalle.SubTotal;
            LBLTotal.Text = oVenta.Total.ToString();
        }

        public void CargarGrillaDetalle()
        {
            DGVDetalle.DataSource = null;
            DGVDetalle.DataSource = oVenta.ListarDetalles();
        }

        private void BTNDEL_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.DetalleVenta oDetalleVenta = (Entidades.Sistema.DetalleVenta)DGVDetalle.CurrentRow.DataBoundItem;
            if (oDetalleVenta == null)
            {
                MessageBox.Show("Debe seleccionar un detalle a eliminar");
                return;
            }
            oVenta.Total -= oDetalleVenta.SubTotal;
            LBLTotal.Text = oVenta.Total.ToString();
            oCarataker.AgregarMemento(oVenta.CrearMemento());
            oVenta.EliminarDetalle(oDetalleVenta);
            DGVDetalle.DataSource = null;
            DGVDetalle.DataSource = oVenta.ListarDetalles();
        }

        private void BTNDeshacer_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Memento memento = oCarataker.EliminarMemento();
            if (memento != null)
            {
                oVenta.SetMemento(memento);
                DGVDetalle.DataSource = null;
                DGVDetalle.DataSource = oVenta.DetallesVentas;
            }
        }

        private void MTXTCantidad_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }
    }
}
