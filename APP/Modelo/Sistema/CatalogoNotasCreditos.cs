using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoNotasCreditos
    {
        Mapping.Sistema.MappingNotaCredito _Mapping;
        List<Entidades.Sistema.NotaCredito> _NotasCreditos;
        private static CatalogoNotasCreditos _Instancia;
        public static CatalogoNotasCreditos ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoNotasCreditos();
            return _Instancia;
        }

        private CatalogoNotasCreditos()
        {
            _Mapping = Mapping.Sistema.MappingNotaCredito.ObtenerInstancia();
            _NotasCreditos = new List<Entidades.Sistema.NotaCredito>();
            _NotasCreditos = _Mapping.ListarNotas();

        }

        public bool Agregar(Entidades.Sistema.NotaCredito oNota)
        {
            _NotasCreditos.Add(oNota);
            return _Mapping.AgregarNota(oNota);
        }
        public List<Entidades.Sistema.NotaCredito> Listar()
        {
            return _NotasCreditos;
        }
    }
}
