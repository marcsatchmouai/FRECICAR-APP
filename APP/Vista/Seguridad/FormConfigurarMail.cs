using System;
using System.Windows.Forms;
namespace Vista.Seguridad
{
    public partial class FormConfigurarMail : Form
    {
        Entidades.Seguridad.DatosCorreo oDatosCorreo;
        public FormConfigurarMail()
        {
           InitializeComponent();
           oDatosCorreo =  Controladora.Seguridad.ControladoraCasoDeUsoConfigurarMail.ObtenerInstancia().RecuperarDatosCorreo();
           txtMailEmisor.Text = oDatosCorreo.DireccionMail;
           txtNomEmisor.Text = oDatosCorreo.NombreEmisor;
           txtSMTP.Text = oDatosCorreo.Smtp;
           txtUsuario.Text = oDatosCorreo.Usuario;
           txtPass.Text = oDatosCorreo.Clave;
           txtPuerto.Text = oDatosCorreo.PuertoSmtp.ToString();
           cbSSL.Checked = oDatosCorreo.SSL;
           cbUDC.Checked = oDatosCorreo.UsaCredencialesDefault;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ValidarDatos())
            {
                oDatosCorreo.Usuario = txtUsuario.Text;
                oDatosCorreo.Clave = txtPass.Text;
                oDatosCorreo.DireccionMail = txtMailEmisor.Text;
                oDatosCorreo.NombreEmisor = txtNomEmisor.Text;
                oDatosCorreo.PuertoSmtp = Convert.ToInt32(txtPuerto.Text);
                oDatosCorreo.SSL = cbSSL.Checked;
                oDatosCorreo.UsaCredencialesDefault = cbUDC.Checked;
                oDatosCorreo.Smtp = txtSMTP.Text;
                if (Controladora.Seguridad.ControladoraCasoDeUsoConfigurarMail.ObtenerInstancia().ModificarDatosCorreo(oDatosCorreo))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Se realizo una prueba de envio de mail y no ha sido superada. Reingrese los datos de configuracion y vuelva a intentar.");
                }
            }
            else
            {
                MessageBox.Show("Verifique haber completado los datos obligatorios.");
            }
        }

        private bool ValidarDatos()
        {
            if(txtMailEmisor.Text==""||txtNomEmisor.Text==""||txtPass.Text==""||txtPuerto.Text==""||txtSMTP.Text==""||txtUsuario.Text=="")
            return false;
            else return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("¿Desea cancelar la operación? La configuración de Email no se llevará a cabo.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Dr == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
