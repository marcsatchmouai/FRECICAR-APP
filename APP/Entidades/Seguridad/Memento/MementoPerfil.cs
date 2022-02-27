using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Entidades.Seguridad.Memento
{
    public class MementoPerfil 
    {
        private List<Formulario> _Formularios;

        public List<Formulario> Formularios
        {
            get { return _Formularios; }
            
        }
        
        public MementoPerfil(List<Formulario> formularios)
        {
            _Formularios = new List<Formulario>();
            Formulario[] formularioArray = new Formulario[formularios.Count];
            for (int i = 0; i < formularios.Count; i++)
            {
                Formulario form = new Formulario();
                form.Nombre = formularios.ElementAt(i).Nombre;
                form.Descripcion = formularios.ElementAt(i).Descripcion;
                formularioArray[i] = form;
 
                for (int x = 0; x < formularios.ElementAt(i).Permisos.Count; x++)
                {
                    Permiso perm = new Permiso();
                    perm.Nombre = formularios[i].Permisos[x].Nombre;
                    perm.Descripcion = formularios[i].Permisos[x].Descripcion;
                    formularioArray[i].AgregarPermiso(perm);
                }
            }
            _Formularios = formularioArray.ToList();
        }

    }
}
