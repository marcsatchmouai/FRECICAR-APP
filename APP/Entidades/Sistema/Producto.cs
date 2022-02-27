using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class Producto
    {
        private int _Cantidad;
        private int _CantMin;
        private int _Codigo;
        private CategoriaProducto _Categoria;
        private decimal _CostoUnitario;
        private string _Descripcion;

        public int CantMin
        {
            get { return _CantMin; }
            set { _CantMin = value; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public CategoriaProducto Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }

        public Decimal Precio
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
