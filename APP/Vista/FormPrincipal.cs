using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Drawing;
using System.Diagnostics;

namespace Vista
{
    public partial class FormPrincipal : Form
    {
        public delegate void ActualizaSeguridad();
        private Entidades.Seguridad.Usuario _Usuario;      
        public FormPrincipal(Entidades.Seguridad.Usuario usuario)
        {
            
            CultureInfo MyCulture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentCulture = MyCulture;
            _Usuario = usuario;
            InitializeComponent();
            Controladora.Seguridad.ControladoraCasoDeUsoIniciarSesion.ObtenerInstancia().AldetectarCambio += new Controladora.Seguridad.ControladoraCasoDeUsoIniciarSesion.ActualizarCambios(FormPrincipal_AldetectarCambio);
            AsignarPermisosAFormPrincipal();
            foreach (Entidades.Seguridad.Grupo grupo in _Usuario.Grupos)
            {
                if (grupo.Nombre == System.Configuration.ConfigurationManager.AppSettings["SuperGroup"].ToString())
                {
                    this.seguridadToolStripMenuItem.Enabled = true;
                    this.auditoriaToolStripMenuItem.Enabled = true;
                    break;
                }
            }
            this.barraEstadoLabelUsuario.Text = "Usuario: "+ _Usuario.NombreUsuario;

            this.FormClosed += new FormClosedEventHandler(FormPrincipal_FormClosed);
        }

        

        private void FormPrincipal_AldetectarCambio()
        {
            if (!this.InvokeRequired) AsignarPermisosAFormPrincipal();
            else
            {
                ActualizaSeguridad carga = new ActualizaSeguridad(AsignarPermisosAFormPrincipal);
                this.Invoke(carga);
            }
        }
            
        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
        }
        
        //private void Application_ApplicationExit(object sender, EventArgs e)
        //{
        //    Controladora.Seguridad.ControladoraCasoDeUsoCerrarSesion.ObtenerInstancia().CerrarSesion(_Usuario);
        //}

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seguridad.FormSeguridad FormSeg = new Seguridad.FormSeguridad();
            FormSeg.Show();
        }

        private void logInLogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auditoria.FormAuditoriaLogs oFormLog = new Auditoria.FormAuditoriaLogs();
            oFormLog.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seguridad.FormCambiarClave oFormCambiarClave = new Seguridad.FormCambiarClave(this._Usuario);
            oFormCambiarClave.Show();
        }

                private void servidorDeCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seguridad.FormConfigurarMail oConfigurarMail = new Seguridad.FormConfigurarMail();
            oConfigurarMail.Show();
        }

        public static List<ToolStripMenuItem> GetItems(MenuStrip menuStrip)
        {
            List<ToolStripMenuItem> myItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem i in menuStrip.Items)
            {
                GetMenuItems(i, myItems);
            }
            return myItems;
        }
        
        private static void GetMenuItems(ToolStripMenuItem item, List<ToolStripMenuItem> items)
        {
            items.Add(item);
            foreach (ToolStripItem i in item.DropDownItems)
            {
                if (i is ToolStripMenuItem)
                {
                    GetMenuItems((ToolStripMenuItem)i, items);
                }
            }
        }
        ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles;
        public void AsignarPermisosAFormPrincipal()
        {
           perfiles = (ReadOnlyCollection<Entidades.Seguridad.Perfil>)Controladora.Seguridad.ControladoraCasoDeUsoIniciarSesion.ObtenerInstancia().RecuperarPerfilesUsuario(_Usuario);
            foreach (Entidades.Seguridad.Perfil oPerfil in perfiles)
            {
                foreach (Entidades.Seguridad.Formulario oForm in oPerfil.Formularios)
                {
                    List<ToolStripMenuItem> myItems = GetItems(this.menuPrincipal);
                    foreach (var item in myItems)
                    {
                        if(oForm.Nombre == item.Text)
                            item.Enabled= false;
                    }
                }
                foreach (Entidades.Seguridad.Formulario oForm in oPerfil.Formularios)
                {

                    foreach (Entidades.Seguridad.Permiso oPermiso in oForm.Permisos)
                    {
                        if ("Acceso" == oPermiso.Nombre)
                        {
                            List<ToolStripMenuItem> myItems = GetItems(this.menuPrincipal);
                            foreach (var item in myItems)
                            {
                                if (oForm.Nombre == item.Text) item.Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        private void gestionarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categorias oFrmCategorias = new Categorias(perfiles);
            oFrmCategorias.ShowDialog();
        }

        private void gestionarFormaDeEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
             FormaEnvios oFrmFormasdeEnvios = new FormaEnvios(perfiles);
            oFrmFormasdeEnvios.ShowDialog();
        }

        private void gestionarFormaDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaPagos oFrmFormasdePago = new FormaPagos(perfiles);
            oFrmFormasdePago.ShowDialog();
        }

        private void gestionarMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriasPrimas oFrmMateriasPrimas = new MateriasPrimas(perfiles);
            oFrmMateriasPrimas.ShowDialog();
        }

        private void gestionarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores oFrmProveedores = new Proveedores(perfiles,false);
            oFrmProveedores.ShowDialog();
        }

        private void gestionarOrdenCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenesCompras oFrmOrdenesCompras = new OrdenesCompras(perfiles,false);
            oFrmOrdenesCompras.ShowDialog();
        }

        private void realizarOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarOrden oFrmOrdenCompra = new RealizarOrden(perfiles,_Usuario);
            oFrmOrdenCompra.ShowDialog();
        }

        private void realizarRemitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarRemito oFrmRemito = new RealizarRemito(perfiles, _Usuario);
            oFrmRemito.ShowDialog();
        }

        private void remitosProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemitosProveedores oFrmRemitos = new RemitosProveedores(perfiles);
            oFrmRemitos.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes oFrmClientes = new Clientes(perfiles,false);
            oFrmClientes.ShowDialog();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Controladora.Seguridad.ControladoraCasoDeUsoCerrarSesion.ObtenerInstancia().CerrarSesion(_Usuario);
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pagos oFormPago = new Pagos(perfiles);
            oFormPago.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos oFrmProducto = new Productos(perfiles);
            oFrmProducto.ShowDialog();
        }

        private void categoriasProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriasP oFrmCategoriasProducto = new CategoriasP(perfiles);
            oFrmCategoriasProducto.ShowDialog();
        }

        private void realizarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarVenta oFrmVenta = new RealizarVenta(perfiles);
            oFrmVenta.ShowDialog();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas oFrmVentas = new Ventas(perfiles);
            oFrmVentas.ShowDialog();
        }

        private void registrarPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarPago oFrmRegistrarPago = new Vista.RegistrarPago(perfiles);
            oFrmRegistrarPago.ShowDialog();
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"D:\BackupRestore\bin\Release\BackupRestore.exe");
        }

        private void materiasPrimasPedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteMPP oFrmReporteMPP = new Vista.FrmReporteMPP();
            oFrmReporteMPP.ShowDialog();
        }
        private void productosMasVendidosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //FRMReporteProductoMasVendido oFrmReportePMV = new FRMReporteProductoMasVendido();
            //oFrmReportePMV.ShowDialog();
            ReporteProductos oFrmReportePMV = new ReporteProductos();
            oFrmReportePMV.ShowDialog();
        }
    }
}
