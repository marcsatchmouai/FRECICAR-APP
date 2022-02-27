using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraCliente
    {
        private Modelo.Sistema.CatalogoClientes oModelo;
        private static ControladoraCliente _Instancia;
        public static ControladoraCliente ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraCliente();
            return _Instancia;
        }

        private ControladoraCliente()
        {
            oModelo = Modelo.Sistema.CatalogoClientes.ObtenerInstancia();
        }

        public void Agregar(Entidades.Sistema.Cliente Cliente)
        {
            oModelo.Agregar(Cliente);
        }

        public void Modificar(Entidades.Sistema.Cliente Cliente)
        {
            oModelo.Modificar(Cliente);
        }

        public void Eliminar(Entidades.Sistema.Cliente Cliente)
        {
            oModelo.Eliminar(Cliente);
        }

        public List<Entidades.Sistema.Cliente> RecuperarClientes()
        {
            return oModelo.RecuperarCliente();
        }

        public List<Entidades.Sistema.SituacionFiscal> RecuperarSituacionesFiscales()
        {
            return Modelo.Sistema.CatalogoSituacionesFiscales.ObtenerInstancia().Recuperar();
        }

        public List<Entidades.Sistema.Provincia> RecuperarProvincias()
        {
            return Modelo.Sistema.CatalogoProvincias.ObtenerInstancia().RecuperarProvincias();
        }

        public List<Entidades.Sistema.Cliente> RecuperarClientesActivos()
        {
            return Modelo.Sistema.CatalogoClientes.ObtenerInstancia().RecuperarClientesActivos();
        }

    }
}
