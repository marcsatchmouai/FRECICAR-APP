using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Vista.Seguridad
{
    public partial class FormUsuario : Form
    {
        private Entidades.Seguridad.Usuario _Usuario;
        private TipoOperacion _Operacion;
       
        public FormUsuario(TipoOperacion Operacion)
        {
            this._Operacion = Operacion;
            this.InitializeComponent();
        }

        public FormUsuario(TipoOperacion Operacion, Entidades.Seguridad.Usuario Usuario)
        {
            this._Operacion = Operacion;
            this._Usuario = Usuario;
            this.InitializeComponent();
        }

        private void PrepararFormularioAgregar()
        {
            this.btnGuardar.Text = "Agregar";
            this.btnCancelar.Text = "Cancelar";
                }

        private void PrepararFormularioModificar()
        {
            this.txtBoxNombreUsuario.Enabled = false;
            this.txtBoxNombreUsuario.Text = this._Usuario.NombreUsuario;
            this.txtNombreApellido.Text = this._Usuario.NombreApellido;
            this.txtBoxEmail.Text = this._Usuario.Email;
            this.chkBoxHabilitado.Checked = this._Usuario.Habilitado;
            this.gBoxUsuario.Text = "Modificar usuario:";
            this.btnGuardar.Text = "Modificar";
            this.btnCancelar.Text = "Cancelar";
        }

        private void PrepararFormularioConsultar()
        {
            this.txtBoxNombreUsuario.Text = this._Usuario.NombreUsuario;
            this.txtNombreApellido.Text = this._Usuario.NombreApellido;
            this.txtBoxEmail.Text = this._Usuario.Email;
            this.chkBoxHabilitado.Checked = this._Usuario.Habilitado;
            this.gBoxUsuario.Text = "Consultar usuario:";
            this.btnCancelar.Text = "Salir";
            this.btnGuardar.Visible = false;
            this.txtBoxNombreUsuario.Enabled = false;
            this.txtNombreApellido.Enabled = false;
            this.txtBoxEmail.Enabled = false;
            this.chkBoxHabilitado.Enabled = false;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            switch (_Operacion)
            {
                case TipoOperacion.Agregar:
                    this.PrepararFormularioAgregar();
                    break;
                case TipoOperacion.Modificar:
                    this.PrepararFormularioModificar();
                    break;
                default:
                    this.PrepararFormularioConsultar();
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosUsuario())
            {
                switch (_Operacion)
                {
                    case TipoOperacion.Agregar:
                         Entidades.Seguridad.Usuario Usuario = new Entidades.Seguridad.Usuario();
                         Usuario.NombreUsuario = this.txtBoxNombreUsuario.Text;
                         Usuario.NombreApellido = this.txtNombreApellido.Text;
                         Usuario.Email = this.txtBoxEmail.Text;
                         Usuario.Habilitado = this.chkBoxHabilitado.Checked;
                        if (Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ObtenerInstancia().AgregarUsuario(Usuario))
                        {
                            MessageBox.Show("El usuario se agregó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El usuario no se ha podido agregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                            
                        break;
                    case TipoOperacion.Modificar:
                        _Usuario.NombreApellido = this.txtNombreApellido.Text;
                        _Usuario.Email = this.txtBoxEmail.Text;
                        _Usuario.Habilitado = this.chkBoxHabilitado.Checked;
                        if (Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ObtenerInstancia().ModificarUsuario(_Usuario))
                        {
                            MessageBox.Show("El usuario se modificó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El usuario no se ha podido modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    default:
                        break;
                }
                this.Close();
            }
        }

        private bool ValidarDatosUsuario()
        {
            if (string.IsNullOrEmpty(this.txtBoxNombreUsuario.Text))
            {
                this.txtBoxNombreUsuario.Focus();
                MessageBox.Show("Ingrese el nombre de usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.txtBoxNombreUsuario.Text.Contains(" "))
            {
                this.txtBoxNombreUsuario.Focus();
                MessageBox.Show("El nombre de usuario no puede contener un espacio en blanco", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtNombreApellido.Text))
            {
                this.txtNombreApellido.Focus();
                MessageBox.Show("Ingrese el nombre y apellido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxEmail.Text))
            {
                this.txtBoxEmail.Focus();
                MessageBox.Show("Ingrese el email.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(this.txtBoxEmail.Text, @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.IgnoreCase))
            {
                this.txtBoxEmail.Text = "";
                this.txtBoxEmail.Focus();
                MessageBox.Show("Email incorrecto");
                return false;
            } 
            return true;
        }

        private void txtNombreApellido_TextChanged(object sender, EventArgs e)
        {
            txtNombreApellido.Text = Upper(txtNombreApellido.Text);
            this.txtNombreApellido.Select(this.txtNombreApellido.TextLength, 0);
        }
       
        public string Upper(string s) 
        { 
            System.Globalization.CultureInfo c = new System.Globalization.CultureInfo("es-es", false); 
            System.Globalization.TextInfo t = c.TextInfo; 
            return t.ToTitleCase(s); 
        }

    }
}
