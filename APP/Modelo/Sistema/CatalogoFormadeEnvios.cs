using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoFormadeEnvios
    {
        private Mapping.Sistema.MappingFormadeEnvio MappingFormadeEnvio;
        private List<Entidades.Sistema.FormadeEnvio> _FormadeEnvio;
        private static CatalogoFormadeEnvios _Instancia;

        public static CatalogoFormadeEnvios ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoFormadeEnvios();
            return _Instancia;
        }

        private CatalogoFormadeEnvios()
        {
            MappingFormadeEnvio = Mapping.Sistema.MappingFormadeEnvio.ObtenerInstancia();
            _FormadeEnvio = new List<Entidades.Sistema.FormadeEnvio>();
            _FormadeEnvio = MappingFormadeEnvio.ListarFormasEnvios();
        }

        public void AgregarFormadeEnvio(Entidades.Sistema.FormadeEnvio FormadeEnvio)
        {
            MappingFormadeEnvio.AgregarFormadeEnvio(FormadeEnvio);
            _FormadeEnvio.Add(FormadeEnvio);
        }

        public void ModificarFormadeEnvio(Entidades.Sistema.FormadeEnvio FormadeEnvio)
        {
            MappingFormadeEnvio.ModificarFormadeEnvio(FormadeEnvio);
            _FormadeEnvio.Remove(FormadeEnvio);
            _FormadeEnvio.Add(FormadeEnvio);
        }

        public void EliminarFormadeEnvio(Entidades.Sistema.FormadeEnvio FormadeEnvio)
        {
            MappingFormadeEnvio.EliminarFormadeEnvio(FormadeEnvio);
            _FormadeEnvio.Remove(FormadeEnvio);
        }

        public List<Entidades.Sistema.FormadeEnvio> RecuperarFormasdeEnvios()
        {
            return _FormadeEnvio;
        }
    }
}
