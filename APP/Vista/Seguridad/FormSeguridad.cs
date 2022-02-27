using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Vista.Seguridad
{

    public partial class FormSeguridad : Form
    {
        private BindingSource bsUsuarios, bsGrupos, bsPerfiles;
        private delegate void CargaGrillaGrupos();
        private delegate void CargaGrillaUsuarios();
        private delegate void CargaGrillaPerfiles();
        
        public FormSeguridad()
        {
            this.InitializeComponent();
            Controladora.Seguridad.ControladoraCasoDeUsoGestionarGrupos.ObtenerInstancia().AldetectarCambio += new Controladora.Seguridad.ControladoraCasoDeUsoGestionarGrupos.ActualizarCambios(FormSeguridad_AldetectarCambioGrupos);
            Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ObtenerInstancia().AldetectarCambio += new Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ActualizarCambios(FormSeguridad_AldetectarCambioUsuarios);
            Controladora.Seguridad.ControladoraCasoDeUsoGestionarPerfiles.ObtenerInstancia().AldetectarCambio +=new Controladora.Seguridad.ControladoraCasoDeUsoGestionarPerfiles.ActualizarCambios(FormSeguridad_AldetectarCambioPerfiles);
        }

        private void FormSeguridad_AldetectarCambioPerfiles()
        {
            if (!this.InvokeRequired) IniciarGestionPerfiles();
            else
            {
                CargaGrillaPerfiles carga = new CargaGrillaPerfiles(IniciarGestionPerfiles);
                this.Invoke(carga);
            }

        }
        
        private void FormSeguridad_AldetectarCambioGrupos()
        {
            if (!this.InvokeRequired) IniciarGestionGrupos();
            else
            {
                CargaGrillaGrupos carga = new CargaGrillaGrupos(IniciarGestionGrupos);
                this.Invoke(carga);
            }

        }

        private void FormSeguridad_AldetectarCambioUsuarios()
        {
            if (!this.InvokeRequired) IniciarGestionUsuarios();
            else
            {
                CargaGrillaUsuarios carga = new CargaGrillaUsuarios(IniciarGestionUsuarios);
                this.Invoke(carga);
            }

        }
        
        private void FormSeguridad_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtFiltradoUsuarios;
            this.IniciarGestionUsuarios();
            this.IniciarGestionGrupos();
            this.IniciarGestionPerfiles(); 
        }

        #region(Gestion de Usuarios)

        private void IniciarGestionUsuarios()
        {
            this.dgvUsuarios.AutoGenerateColumns = false;
            this.bsUsuarios = new BindingSource();
            object resultado = Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ObtenerInstancia().ConsultarUsuarios();
            if (resultado is Exception)
            {
                Exception error = (Exception)resultado;
                MessageBox.Show("Ha ocurrido un error y la aplicación se cerrará, los datos de error son:" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else if (resultado is ReadOnlyCollection<Entidades.Seguridad.Usuario>)
            {
                ReadOnlyCollection<Entidades.Seguridad.Usuario> listadoUsuarios = (ReadOnlyCollection<Entidades.Seguridad.Usuario>)resultado;
                this.bsUsuarios.DataSource = listadoUsuarios;
                this.dgvUsuarios.DataSource = this.bsUsuarios;
            }
        }
       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormUsuario oFormUsuario = new FormUsuario(TipoOperacion.Agregar);
            oFormUsuario.ShowDialog();
            this.bsUsuarios.ResetBindings(false);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Usuario oUsuarioSeleccionado = (Entidades.Seguridad.Usuario)bsUsuarios.Current;
            
            FormUsuario oFormUsuario = new FormUsuario(TipoOperacion.Modificar, oUsuarioSeleccionado);
            oFormUsuario.ShowDialog();
            this.bsUsuarios.ResetBindings(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Usuario oUsuarioSeleccionado = (Entidades.Seguridad.Usuario)bsUsuarios.Current;
            object resultado = Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ObtenerInstancia().EliminarUsuario(oUsuarioSeleccionado);
            if (resultado is Exception)
            {
                Exception error = (Exception)resultado;
                MessageBox.Show("Ha ocurrido un error y la aplicación se cerrará, los datos de error son:" + error.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }
            if (resultado is bool)
            {
                bool operacion = (bool)resultado;
                if(operacion) MessageBox.Show("El usuario se eliminó correctamente.","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else MessageBox.Show("El usuario no se pudo eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.bsUsuarios.ResetBindings(false);
            }            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Usuario oUsuarioSeleccionado = (Entidades.Seguridad.Usuario)bsUsuarios.Current;
            FormUsuario oFormUsuario = new FormUsuario(TipoOperacion.Consultar, oUsuarioSeleccionado);
            oFormUsuario.ShowDialog();
        }

        private void btnGruposUsuarios_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Usuario usuario = Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ObtenerInstancia().BuscarUsuario((Entidades.Seguridad.Usuario)this.bsUsuarios.Current);
            FormGruposUsuario oFormGruposUsuario = new FormGruposUsuario(usuario);
            oFormGruposUsuario.ShowDialog();
            this.bsUsuarios.ResetBindings(false);
        }
        
        private void btnResetearClave_Click(object sender, EventArgs e)
        {
            bool ok = Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ObtenerInstancia().ResetearContraseña(((Entidades.Seguridad.Usuario)this.bsUsuarios.Current).NombreUsuario);
            if (ok) MessageBox.Show("La clave se ha enviado al usuario correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("No se ha podido resetear la clave consulte con su administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void txtFiltradoUsuarios_TextChanged(object sender, EventArgs e)
        {
            ReadOnlyCollection<Entidades.Seguridad.Usuario> usuarios = Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ObtenerInstancia().FiltrarUsuarios(this.txtFiltradoUsuarios.Text);
            this.bsUsuarios.DataSource = usuarios;
        }
        
        #endregion

        #region (Gestion de Grupos)

        private void IniciarGestionGrupos()
        {
            this.dgvGrupos.AutoGenerateColumns = false;
            this.bsGrupos = new BindingSource();
            this.bsGrupos.DataSource = Controladora.Seguridad.ControladoraCasoDeUsoGestionarGrupos.ObtenerInstancia().ConsultarGrupos();
            this.dgvGrupos.DataSource = this.bsGrupos;
        }
        
        private void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            FormGrupo oFormGrupo = new FormGrupo(TipoOperacion.Agregar);
            oFormGrupo.ShowDialog();
            this.bsGrupos.ResetBindings(false);
        }

        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Grupo oGrupoSeleccionado = (Entidades.Seguridad.Grupo)bsGrupos.Current;
            FormGrupo oFormGrupo = new FormGrupo(TipoOperacion.Modificar, oGrupoSeleccionado);
            oFormGrupo.ShowDialog();
            this.bsGrupos.ResetBindings(false);
        }

        private void btnEliminarGrupo_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Grupo oGrupoSeleccionado = (Entidades.Seguridad.Grupo)bsGrupos.Current;
            Controladora.Seguridad.ControladoraCasoDeUsoGestionarGrupos.ObtenerInstancia().EliminarGrupo(oGrupoSeleccionado);
            this.bsGrupos.ResetBindings(false);
        }

        private void btnConsultarGrupo_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Grupo oGrupoSeleccionado = (Entidades.Seguridad.Grupo)bsGrupos.Current;
            FormGrupo oFormGrupo = new FormGrupo(TipoOperacion.Consultar, oGrupoSeleccionado);
            oFormGrupo.ShowDialog();
        }

        private void txtFiltradoGrupos_TextChanged(object sender, EventArgs e)
        {
            ReadOnlyCollection<Entidades.Seguridad.Grupo> grupos = Controladora.Seguridad.ControladoraCasoDeUsoGestionarGrupos.ObtenerInstancia().FiltrarGrupos(this.txtFiltradoGrupos.Text);
            this.bsGrupos.DataSource = grupos;
        }

        #endregion        

        #region(Gestion de perfiles)

        private void IniciarGestionPerfiles()
        {
            this.bsPerfiles = new BindingSource();
            this.bsPerfiles.DataSource = Controladora.Seguridad.ControladoraCasoDeUsoGestionarPerfiles.ObtenerInstancia().ConsultarPerfiles();
            this.listBoxGrupos.DataSource = bsPerfiles;
            this.listBoxGrupos.DisplayMember = "Grupo";
            this.listBoxFormularios.DataSource = bsPerfiles;
            this.listBoxFormularios.DisplayMember = "Formularios.Nombre";
            this.listBoxPermisos.DataSource = bsPerfiles;
            this.listBoxPermisos.DisplayMember = "Formularios.Permisos.Nombre";  
        }

        private void btnAgregarPerfil_Click(object sender, EventArgs e)
        {
            FormPerfil oFormPerfil = new FormPerfil(TipoOperacion.Agregar);
            DialogResult dr = oFormPerfil.ShowDialog();
            this.bsPerfiles.ResetBindings(false);
        }

        private void btnModificarPerfil_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Perfil perfil = (Entidades.Seguridad.Perfil)bsPerfiles.Current;
            Entidades.Seguridad.Perfil perfilEncontrado = Controladora.Seguridad.ControladoraCasoDeUsoGestionarPerfiles.ObtenerInstancia().BuscarPerfil(perfil);
            FormPerfil oFormPerfil = new FormPerfil(TipoOperacion.Modificar,perfilEncontrado);
            DialogResult dr = oFormPerfil.ShowDialog();
            this.bsPerfiles.ResetBindings(true);
        }

        private void btnEliminarPerfil_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Perfil operfil = (Entidades.Seguridad.Perfil)this.bsPerfiles.Current;
            object resultado = Controladora.Seguridad.ControladoraCasoDeUsoGestionarPerfiles.ObtenerInstancia().EliminarPerfil(operfil);
            if (resultado is Exception)
            {
                Exception error = (Exception)resultado;
                MessageBox.Show("Ha ocurrido un error y la aplicación se cerrará, los datos de error son:" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (resultado is bool)
            {
                bool operacion = (bool)resultado;
                if (operacion) MessageBox.Show("El perfil se eliminó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("El perfil no se pudo eliminar.Esto puede deberse a que ha intentado eliminar el perfil del grupo Administradores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.bsPerfiles.ResetBindings(false);
            }
        }

        private void txtFiltradoPerfiles_TextChanged(object sender, EventArgs e)
        {
            ReadOnlyCollection<Entidades.Seguridad.Perfil> perfiles = Controladora.Seguridad.ControladoraCasoDeUsoGestionarPerfiles.ObtenerInstancia().FiltrarPerfiles(this.txtFiltradoPerfiles.Text);
            this.bsPerfiles.DataSource = perfiles;
        }

        #endregion

    }
}
