using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraMateriaPrima
    {
        private Modelo.Sistema.CatalogoMateriasPrimas _Modelo;
        private static ControladoraMateriaPrima _Instancia;
        public static ControladoraMateriaPrima ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraMateriaPrima();
            return _Instancia;
        }

        private ControladoraMateriaPrima()
        {
            _Modelo = Modelo.Sistema.CatalogoMateriasPrimas.ObtenerInstancia();
        }

        public void AgregarMateriaPrima(Entidades.Sistema.MateriaPrima MateriaPrima)
        {
            _Modelo.AgregarMateriaPrima(MateriaPrima);
        }

        public void ModificarMateriaPrima(Entidades.Sistema.MateriaPrima MateriaPrima)
        {
            _Modelo.ModificarMateriaPrima(MateriaPrima);
        }

        public void EliminarMateriaPrima(Entidades.Sistema.MateriaPrima MateriaPrima)
        {
            bool okO = true;
            bool okR = true;
            List<Entidades.Sistema.OrdenCompra> Ordenes = (List<Entidades.Sistema.OrdenCompra>) Modelo.Sistema.CatalogoOrdenesCompras.ObtenerInstancia().RecuperarOrdenCompra();
            foreach (Entidades.Sistema.OrdenCompra Orden in Ordenes)
            {
               Entidades.Sistema.DetalledeOrdenCompra Detalle = Orden.DetalleOrdenCompra.Find(x=>x.MateriaPrima.Codigo == MateriaPrima.Codigo);
                if (Detalle != null)
                {
                    okO = false;
                    break;
                }
            }

            List<Entidades.Sistema.RemitoProveedor> Remitos = (List<Entidades.Sistema.RemitoProveedor>)Modelo.Sistema.CatalogoRemitosProveedores.ObtenerInstancia().RecuperarRemitosProveedores();
            foreach (Entidades.Sistema.RemitoProveedor Remito in Remitos)
            {
                Entidades.Sistema.DetalledeRemitoProveedor Detalle = Remito.DetalleRemitoProveedor.Find(x => x.MateriaPrima.Codigo == MateriaPrima.Codigo);
                if (Detalle != null)
                {
                    okR = false;
                    break;
                }
            }

            if (okO && okR)
            {
                _Modelo.EliminarMateriaPrima(MateriaPrima);
            }

        }

        public List<Entidades.Sistema.MateriaPrima> RecuperarMateriasPrimas()
        {
            return _Modelo.RecuperarMateriasPrimas().ToList();
        }

        public List<Entidades.Sistema.Categoria> RecuperarCategoria()
        {
            return Modelo.Sistema.CatalogoCategorias.ObtenerInstancia().RecuperarCategorias().ToList();
        }

        public List<Entidades.Sistema.Proveedor> RecuperarProveedor()
        {
            return Modelo.Sistema.CatalogoProveedores.ObtenerInstancia().RecuperarProveedores().ToList();
        }
    }
}
