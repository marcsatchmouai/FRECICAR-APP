using System;
using System.Linq;
using System.Windows.Forms;

namespace Vista.Seguridad
{
    public partial class FormPerfil : Form
    {
        private TipoOperacion _Operacion;
        private Entidades.Seguridad.Perfil _Perfil;
        private BindingSource bsGrupos, bsFormularios, bsPermisos, bsFormulariosPermisos;
        
        public FormPerfil(TipoOperacion operacion)
        {
            this._Operacion = operacion;
            this.InitializeComponent();
        }
        
        public FormPerfil(TipoOperacion operacion, Entidades.Seguridad.Perfil perfil)
        {
            this._Perfil = perfil;
            this._Operacion = operacion;
            this.InitializeComponent();
            this.btnAceptarPerfil.Visible = false;
        }

        private void FormPerfil_Load(object sender, EventArgs e)
        {
            Controladora.Seguridad.ControladoraCasoDeUsoGestionarPerfiles oGestionPerfiles = Controladora.Seguridad.ControladoraCasoDeUsoGestionarPerfiles.ObtenerInstancia();
            this.bsGrupos = new BindingSource();
            this.bsGrupos.DataSource = oGestionPerfiles.ConsultarGruposSinSuperGroup();
            this.comboBoxGrupos.DataSource = this.bsGrupos;
            this.comboBoxGrupos.DisplayMember = "Nombre";
            this.bsFormularios = new BindingSource();
            this.bsFormularios.DataSource = oGestionPerfiles.ConsultarFormularios();
            this.comboBoxFormularios.DataSource = this.bsFormularios;
            this.comboBoxFormularios.DisplayMember = "Nombre";
            this.bsPermisos = new BindingSource();
            this.bsPermisos.DataSource = oGestionPerfiles.ConsultarPermisos();
            this.comboBoxPermisos.DataSource = this.bsPermisos;
            this.comboBoxPermisos.DisplayMember = "Nombre";
            if (_Operacion == TipoOperacion.Agregar) this.IniciaAltaPerfil();
            else this.IniciarModificacionPerfil();
        }

        private void IniciaAltaPerfil()
        {
            this.btnAgregarFormulario.Enabled = false;
            this.btnEliminarFormulario.Enabled = false;
            this.btnAgregarPermiso.Enabled = false;
            this.btnEliminarPermiso.Enabled = false;
        }

        private void IniciarModificacionPerfil()
        {
            this.bsFormulariosPermisos = new BindingSource();
            this.bsFormulariosPermisos.DataSource = this._Perfil.Formularios;
            this.listBoxFormularios.DataSource = this.bsFormulariosPermisos;
            this.listBoxFormularios.DisplayMember = "Nombre";
            this.listBoxPermisos.DataSource = this.bsFormulariosPermisos;
            this.listBoxPermisos.DisplayMember = "Permisos.Nombre";
            this.lblGrupoSeleccionado.Text = "Grupo seleccionado :"+this._Perfil.Grupo.Nombre;
            this.comboBoxGrupos.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void btnAceptarPerfil_Click(object sender, EventArgs e)
        {
            this._Perfil = new Entidades.Seguridad.Perfil();
            this.btnAceptarPerfil.Enabled = false;
            this._Perfil.Grupo = (Entidades.Seguridad.Grupo)this.bsGrupos.Current;
            this.bsFormulariosPermisos = new BindingSource();
            this.bsFormulariosPermisos.DataSource = this._Perfil.Formularios;
            this.comboBoxGrupos.Enabled = false;
            this.btnAgregarPermiso.Enabled = true;
            this.btnAgregarFormulario.Enabled = true;
            this.btnEliminarFormulario.Enabled = true;
            this.btnEliminarPermiso.Enabled = true;
            this.lblGrupoSeleccionado.Text = "Grupo Seleccionado: " + _Perfil.Grupo.Nombre;
            this.listBoxFormularios.DataSource = this.bsFormulariosPermisos;
            this.listBoxFormularios.DisplayMember = "Nombre";
            this.listBoxPermisos.DataSource = this.bsFormulariosPermisos;
            this.listBoxPermisos.DisplayMember = "Permisos.Nombre";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                if (this._Operacion == TipoOperacion.Agregar)
                {
                    object resultado = Controladora.Seguridad.ControladoraCasoDeUsoGestionarPerfiles.ObtenerInstancia().AgregarPerfil(this._Perfil);
                    if (resultado is Exception)
                    {
                        Exception error = (Exception)resultado;
                        MessageBox.Show("Ha ocurrido un error inesperado, cierre todas las ventanas de la aplicacion, cierre el sistema y pongase en contacto con el administrador.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else if (resultado is bool)
                    {
                        bool ok = (bool)resultado;
                        if (ok)
                        {
                            MessageBox.Show("El perfil se ha asignado al grupo " + _Perfil.Grupo.Nombre + " correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("El perfil no se ha podido asignar al grupo seleccionado, el grupo ya tiene un perfil. Pruebe de modificar el perfil para realizar cambios sobre el mismo ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
                else
                {
                    object resultado = Controladora.Seguridad.ControladoraCasoDeUsoGestionarPerfiles.ObtenerInstancia().ModificarPerfil(this._Perfil);
                    if (resultado is Exception)
                    {
                        Exception error = (Exception)resultado;
                        MessageBox.Show("Ha ocurrido un error inesperado, cierre todas las ventanas de la aplicacion, cierre el sistema y pongase en contacto con el administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (resultado is bool)
                    {
                        bool ok = (bool)resultado;
                        if (ok)
                        {
                            MessageBox.Show("El perfil del grupo " + _Perfil.Grupo.Nombre + " se ha modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El perfil no se ha podido modificar, verifique que el grupo seleccionado no sea el grupo Administradores. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(comboBoxGrupos.Text))
            {
                MessageBox.Show("Debe seleccionar un grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this._Perfil.Formularios.Count == 0)
            {
                MessageBox.Show("El grupo "+ this._Perfil.Grupo.Nombre +" no posee formularios. Agreguelos para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            foreach (Entidades.Seguridad.Formulario oformulario in this._Perfil.Formularios)
            {
                if (oformulario.Permisos.Count == 0)
                {
                    MessageBox.Show("El formulario " + oformulario.Nombre + " no posee permisos. Agreguelos para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void btnAgregarFormulario_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Formulario oFormulario = (Entidades.Seguridad.Formulario)this.bsFormularios.Current;
            this._Perfil.AgregarFormulario(oFormulario);
            this.bsFormulariosPermisos.ResetBindings(false);
        }
        
        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            if (listBoxFormularios.Items.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un Formulario");
                return;
            }
            else
            {
                Entidades.Seguridad.Permiso oPermiso = (Entidades.Seguridad.Permiso)this.bsPermisos.Current;
                Entidades.Seguridad.Formulario oFormulario = (Entidades.Seguridad.Formulario)this.bsFormulariosPermisos.Current;
                oFormulario.AgregarPermiso(oPermiso);
                this.bsFormulariosPermisos.ResetBindings(false);
            }
        }

        private void btnEliminarFormulario_Click(object sender, EventArgs e)
        {
            this._Perfil.EliminarFormulario((Entidades.Seguridad.Formulario)this.bsFormulariosPermisos.Current);
            this.bsFormulariosPermisos.ResetBindings(false);
        }

        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            if (listBoxFormularios.Items.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un Formulario");
                return;
            }
            else
            {
                Entidades.Seguridad.Formulario oFormulario = (Entidades.Seguridad.Formulario)this.bsFormulariosPermisos.Current;
                oFormulario.EliminarPermiso((Entidades.Seguridad.Permiso)this.listBoxPermisos.SelectedItem);
                this.bsFormulariosPermisos.ResetBindings(false);
            }
        }

        private void listBoxFormularios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFormularios.Items.Count == 0) this.btnEliminarFormulario.Enabled = false;
            else btnEliminarFormulario.Enabled = true;
        }

        private void listBoxPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPermisos.Items.Count == 0) this.btnEliminarPermiso.Enabled = false;
            else btnEliminarPermiso.Enabled = true;
        }
    }
}
