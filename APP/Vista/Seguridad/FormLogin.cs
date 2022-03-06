using System;
using System.Windows.Forms;

namespace Vista.Seguridad
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.ActiveControl = this.txtUsuario;
            txtUsuario.Text = "userAdmin";
            txtClave.Text = "Gf93QnY3";
        }
        /// <summary>
        /// Cierra la aplicación y libera los recursos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatosLogin())
            {
                object usuario = Controladora.Seguridad.ControladoraCasoDeUsoIniciarSesion.ObtenerInstancia().IniciarSesion(this.txtUsuario.Text, this.txtClave.Text);
                if (usuario is Entidades.Seguridad.Usuario)
                {
                    Entidades.Seguridad.Usuario oUsuario = (Entidades.Seguridad.Usuario)usuario;
                    FormPrincipal formPrincipal = new FormPrincipal(oUsuario);
                    formPrincipal.Show();
                    this.Close();
                }
                if (usuario is Entidades.Seguridad.TipoAutenticacion)
                {
                    Entidades.Seguridad.TipoAutenticacion TipoValidacion = (Entidades.Seguridad.TipoAutenticacion)usuario;
                    if (TipoValidacion == Entidades.Seguridad.TipoAutenticacion.UsuarioDesconocido)
                    {
                        this.txtUsuario.Text = null;
                        this.txtUsuario.Focus();
                        MessageBox.Show("Usuario desconocido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (TipoValidacion == Entidades.Seguridad.TipoAutenticacion.PasswordErroneo)
                    {
                        this.txtClave.Text = null;
                        this.txtClave.Focus();
                        MessageBox.Show("Contraseña errónea.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (TipoValidacion == Entidades.Seguridad.TipoAutenticacion.UsuarioYaLogueado)
                    {
                        this.txtUsuario.Text = null;
                        this.txtClave.Text = null;
                        this.txtUsuario.Focus();
                        MessageBox.Show("Usuario ya logueado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (TipoValidacion == Entidades.Seguridad.TipoAutenticacion.UsuarioNoHabilitado)
                    {
                        this.txtUsuario.Text = null;
                        this.txtClave.Text = null;
                        this.txtUsuario.Focus();
                        MessageBox.Show("El usuario no tiene habilitado el inicio de sesión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (TipoValidacion == Entidades.Seguridad.TipoAutenticacion.UsuarioSinGrupo)
                    {
                        this.txtUsuario.Text = null;
                        this.txtClave.Text = null;
                        this.txtUsuario.Focus();
                        MessageBox.Show("El usuario debe tener un grupo para poder iniciar sesión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                if (usuario is Exception)
                {
                    Exception error = (Exception)usuario;
                    MessageBox.Show("Ha ocurrido un error desconocido, la aplicación se cerrará. El mensaje de error es: " + error.Message + ", los datos de error son:" + error.Data.ToString(), "Error desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }
        
        /// <summary>
        /// Metodo que verifica si los textbox están vacios.
        /// </summary>
        /// <returns>True, si los textbox contienen strings, false si alguno de los textbox está vacio.</returns>
        private bool ValidarDatosLogin()
        {
            if (string.IsNullOrEmpty(this.txtUsuario.Text))
            {
                MessageBox.Show("Ingrese el usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtUsuario.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtClave.Text))
            {
                MessageBox.Show("Ingrese la clave.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtClave.Focus();
                return false;
            }
            return true;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            this.txtUsuario.Text = this.txtUsuario.Text.Trim();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
