using System;
using System.Windows.Forms;

namespace Vista.Seguridad
{
    public partial class FormCambiarClave : Form
    {
        private Entidades.Seguridad.Usuario _Usuario;
        private static FormCambiarClave _Instancia;

        public static FormCambiarClave ObtenerInstancia(Entidades.Seguridad.Usuario ousuario)
        {
            if (_Instancia == null || _Instancia.IsDisposed) _Instancia = new FormCambiarClave(ousuario);
            return _Instancia;
        }

        public FormCambiarClave(Entidades.Seguridad.Usuario ousuario)
        {
            InitializeComponent();
            this._Usuario = ousuario;
            if (this._Usuario.NombreUsuario == Controladora.Seguridad.ControladoraCasoDeUsoCambiarClave.VerificarUsuario())
            {
                this.lblUsuarioActual.Enabled = false;
                this.txtClave.Enabled = false;
                this.txtClaveNueva.Enabled = false;
                this.txtReingresoClave.Enabled = false;
                this.btnAceptar.Enabled = false;
            }
            this.lblUsuarioActual.Text = this._Usuario.NombreUsuario;
            this.txtClave.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatosClave())
            {
                object resultado =Controladora.Seguridad.ControladoraCasoDeUsoCambiarClave.CambiarClave(this._Usuario,this.txtClave.Text ,this.txtClaveNueva.Text);
                 
                if (resultado is Exception)
                {
                    Exception error = (Exception)resultado;
                    MessageBox.Show("Ha ocurrido un error desconocido, los datos de error son:" + error.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                if (resultado is bool)
                {
                    bool ok = (bool)resultado;
                    if (ok)
                    {
                        MessageBox.Show("La clave ha sido cambiada correctamente.","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La clave actual ingresada es incorrecta.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        this.txtClave.Text = "";
                        this.txtClave.Focus();
                    }
                }
            }
        }

        private bool ValidarDatosClave()
        {
            if (string.IsNullOrEmpty(this.txtClave.Text))
            {
                this.txtClave.Focus();
                MessageBox.Show("Ingrese la clave actual.","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            
            if (string.IsNullOrEmpty(this.txtClaveNueva.Text))
            {
                this.txtClaveNueva.Focus();
                MessageBox.Show("Ingrese la clave nueva.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (string.IsNullOrEmpty(this.txtReingresoClave.Text))
            {
                this.txtReingresoClave.Focus();
                MessageBox.Show("Reingrese la clave nueva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (txtClaveNueva.Text != txtReingresoClave.Text)
            {
                this.txtClaveNueva.Text = "";
                this.txtReingresoClave.Text = "";
                this.txtClave.Focus();
                MessageBox.Show("La clave nueva no coincide con el reingreso de la misma. Verifique las contraseñas escritas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;            
        }
    }
}
