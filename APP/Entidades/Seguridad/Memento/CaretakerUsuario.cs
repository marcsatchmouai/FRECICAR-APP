namespace Entidades.Seguridad.Memento
{
    public class CaretakerUsuario
    {
        private MementoUsuario _Memento;

        public MementoUsuario Memento
        {
            get { return _Memento; }
            set { _Memento = value; }
        }
    }
}
