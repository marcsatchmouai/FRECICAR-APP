
namespace Entidades.Seguridad
{
    public class Permiso
    {
        private string _Descripcion;
        private string _Nombre;
        
        public string Nombre
        {
            get { return this._Nombre; }
            set { this._Nombre = value; }
        }
       
        public string Descripcion
        {
            get { return this._Descripcion; }
            set { this._Descripcion = value; }
        }
    }
}
