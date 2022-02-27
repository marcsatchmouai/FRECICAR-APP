using System;
using System.Windows.Forms;

namespace Vista.Seguridad
{
    public partial class FormGrupo : Form
    {
        private Entidades.Seguridad.Grupo _Grupo;
        private TipoOperacion _Operacion;
        
        public FormGrupo(TipoOperacion Operacion)
        {
            this._Operacion = Operacion;
            this.InitializeComponent();
        }

        public FormGrupo(TipoOperacion Operacion, Entidades.Seguridad.Grupo oGrupo)
        {
            this._Grupo = oGrupo;
            this._Operacion = Operacion;
            this.InitializeComponent();
        }

        private void FormGrupo_Load(object sender, EventArgs e)
        {
            switch (this._Operacion)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatosGrupo())
            {
                switch (this._Operacion)
                {
                    case TipoOperacion.Agregar:
                        this.AgregarGrupo();
                        break;
                    case TipoOperacion.Modificar:
                        this.ModificarGrupo();
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombreGrupo_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox)sender;

            if (textbox.TextLength == 1)
            {
                textbox.Text = textbox.Text.ToUpper();
                textbox.Select(textbox.Text.Length, 1);
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox)sender;

            if (textbox.TextLength == 1)
            {
                textbox.Text = textbox.Text.ToUpper();
                textbox.Select(textbox.Text.Length, 1);
            }

        }

        #region (Metodos del Proceso)
        
        private void AgregarGrupo()
        {
            Entidades.Seguridad.Grupo oGrupo = new Entidades.Seguridad.Grupo();
            oGrupo.Nombre = this.txtNombreGrupo.Text;
            oGrupo.Descripcion = this.txtDescripcion.Text;
            Controladora.Seguridad.ControladoraCasoDeUsoGestionarGrupos.ObtenerInstancia().AgregarGrupo(oGrupo);
            this.Close();
        }

        private void ModificarGrupo()
        {
            _Grupo.Descripcion = this.txtDescripcion.Text;
            Controladora.Seguridad.ControladoraCasoDeUsoGestionarGrupos.ObtenerInstancia().ModificarGrupo(_Grupo);
            this.Close();
        }

        private bool ValidarDatosGrupo()
        {
            if (string.IsNullOrEmpty(this.txtNombreGrupo.Text))
            {
                MessageBox.Show("Ingrese el nombre del grupo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNombreGrupo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese la descripción del grupo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        private void PrepararFormularioAgregar()
        {
            this.Text = "Agregar Grupo";
            this.ActiveControl = this.txtNombreGrupo;
            this.txtNombreGrupo.Focus();
        }
        
        private void PrepararFormularioModificar()
        {
            this.Text = "Modificar Grupo";
            this.txtNombreGrupo.Enabled = false;
            this.txtNombreGrupo.Text = this._Grupo.Nombre;
            this.txtDescripcion.Text = this._Grupo.Descripcion;
            this.ActiveControl = this.txtDescripcion;
            this.txtDescripcion.Focus();
        }
        
        private void PrepararFormularioConsultar()
        {
            this.Text = "Consultar Grupo";
            this.panelGrupo.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnAceptar.Enabled = false;
            this.txtNombreGrupo.Text = this._Grupo.Nombre;
            this.txtDescripcion.Text = this._Grupo.Descripcion;
        }
        
        #endregion

        
    }
}
