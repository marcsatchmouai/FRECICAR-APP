using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Sistema;

namespace Controladora.Sistema
{
    public class ControladoraCuentaCorriente
    {
        private Estrategia _estrategia;
        Modelo.Sistema.CatalogoCuentasCorrientes _Modelo;
        private static ControladoraCuentaCorriente _Instancia;
        public static ControladoraCuentaCorriente ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraCuentaCorriente();
            return _Instancia;
        }

        private ControladoraCuentaCorriente()
        {
            _Modelo = Modelo.Sistema.CatalogoCuentasCorrientes.ObtenerInstancia();
        }

        
        public CuentaCorriente RecuperarCuentaCorriente(Cliente oCLiente)
        {
            return Modelo.Sistema.CatalogoCuentasCorrientes.ObtenerInstancia().RecuperarCuentasCorrientes().Find(x=>x.Cliente.Codigo == oCLiente.Codigo);
        }

        public List<Entidades.Sistema.Movimiento> RecuperarMovimientos(Entidades.Sistema.CuentaCorriente ctacte, Estrategia estrategia, string criterio)
        {
            _estrategia = estrategia;
            _estrategia.CuentaCorriente = ctacte;
            return _estrategia.Filtrar(criterio);
        }
    }
}
