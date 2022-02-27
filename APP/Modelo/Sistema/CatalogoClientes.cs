using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoClientes
    {
        List<Entidades.Sistema.Cliente> _Clientes;
        private static CatalogoClientes _Instancia;
        private Mapping.Sistema.MappingCliente _Mapping;
        public static CatalogoClientes ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoClientes();
            return _Instancia;
        }

        private CatalogoClientes()
        {
            _Mapping = Mapping.Sistema.MappingCliente.ObtenerInstancia();
            _Clientes = new List<Entidades.Sistema.Cliente>();
        }

        public void Agregar(Entidades.Sistema.Cliente Cliente)
        {
            _Clientes.Add(Cliente);
            _Mapping.AgregarCliente(Cliente);
        }

        public void Eliminar(Entidades.Sistema.Cliente Cliente)
        {
            _Clientes.Remove(Cliente);
            _Clientes.Add(Cliente);
            _Mapping.EliminarCliente(Cliente);
        }

        public void Modificar(Entidades.Sistema.Cliente Cliente)
        {
            _Clientes.Remove(Cliente);
            _Clientes.Add(Cliente);
            _Mapping.ModificarCliente(Cliente);
        }

        public List<Entidades.Sistema.Cliente> RecuperarCliente()
        {
            _Clientes = null;
            _Clientes = _Mapping.ListarClientes();
            return _Clientes;
        }

        public List<Entidades.Sistema.Cliente> RecuperarClientesActivos()
        {
            _Clientes = null;
            _Clientes = _Mapping.ListarClientesActivos();
            return _Clientes;
        }
    }
}
