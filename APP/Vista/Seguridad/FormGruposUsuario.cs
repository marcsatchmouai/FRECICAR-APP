using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace Vista.Seguridad
{
    public partial class FormGruposUsuario : Form
    {
        private Entidades.Seguridad.Usuario _Usuario;
        private BindingSource bsGrupos;
        private ReadOnlyCollection<Entidades.Seguridad.Grupo> colgrupos;
        
        public FormGruposUsuario(Entidades.Seguridad.Usuario usuario)
        {
            _Usuario = usuario;
            InitializeComponent();
            this.lblUsuarioActual.Text = _Usuario.NombreUsuario;
        }
        
        private void FormGruposUsuario_Load(object sender, EventArgs e)
        {
            bsGrupos = new BindingSource();
            colgrupos = (ReadOnlyCollection<Entidades.Seguridad.Grupo>)Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ObtenerInstancia().ConsultarGrupos();
            bsGrupos.DataSource = colgrupos;
            cBoxGrupos.DataSource = bsGrupos;
            cBoxGrupos.DisplayMember = "NombreGrupo";
            this.lBoxGruposUsuario.DataSource = _Usuario.Grupos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _Usuario.AgregarGrupo((Entidades.Seguridad.Grupo)bsGrupos.Current);
            this.lBoxGruposUsuario.DataSource = _Usuario.Grupos;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _Usuario.EliminarGrupo((Entidades.Seguridad.Grupo)this.lBoxGruposUsuario.SelectedItem);
            this.lBoxGruposUsuario.DataSource = _Usuario.Grupos;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Controladora.Seguridad.ControladoraCasoDeUsoGestionarUsuarios.ObtenerInstancia().ModificarUsuario(this._Usuario);
            this.Close();
        }
    
    }
}
