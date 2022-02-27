using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoCuentasCorrientes
    {
        Mapping.Sistema.MappingCuentaCorriente _Mapping;
        List<Entidades.Sistema.CuentaCorriente> _CuentasCorrientes;
        private static CatalogoCuentasCorrientes _Instancia;
        public static CatalogoCuentasCorrientes ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoCuentasCorrientes();
            return _Instancia;
        }

        private CatalogoCuentasCorrientes()
        {
            _Mapping = Mapping.Sistema.MappingCuentaCorriente.ObtenerInstancia();
            _CuentasCorrientes = new List<Entidades.Sistema.CuentaCorriente>();
            _CuentasCorrientes = _Mapping.ListarCuentasCorrientes();
        }

        public void ModificarCuentaCorriente(Entidades.Sistema.CuentaCorriente oCuentaCorriente)
        {
            _CuentasCorrientes.Remove(oCuentaCorriente);
            _CuentasCorrientes.Add(oCuentaCorriente);
        }
        public List<Entidades.Sistema.CuentaCorriente> RecuperarCuentasCorrientes()
        {
            return _CuentasCorrientes;
        }
    }
}
