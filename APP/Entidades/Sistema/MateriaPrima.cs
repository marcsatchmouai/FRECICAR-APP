using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class MateriaPrima
    {
        private int _Cantidad;
        private int _CantMin;
        private Categoria _Categoria;
        private int _Codigo;
        private decimal _CostoUnitario;
        private Proveedor _Proveedor;
        private string _Descripcion;

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public int CantMin
        {
            get { return _CantMin; }
            set { _CantMin = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public Categoria Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }

        public Proveedor Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }

        public Decimal CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
