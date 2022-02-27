using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingNotaCredito
    {
        private List<Entidades.Sistema.NotaCredito> _Lista;
        private static MappingNotaCredito _Instancia;
        public static MappingNotaCredito ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingNotaCredito();
            return _Instancia;
        }

        private MappingNotaCredito()
        {
            _Lista = new List<Entidades.Sistema.NotaCredito>();
            RecuperarNotas();
        }

        public bool AgregarNota(Entidades.Sistema.NotaCredito oNota)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddNota";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = oNota.Fecha;
                cmd.Parameters.Add("@Importe", System.Data.SqlDbType.Decimal).Value = oNota.Importe;
                cmd.Parameters.Add("@Detalle", System.Data.SqlDbType.NVarChar, 120).Value = oNota.Detalle;
                cmd.Parameters.Add("@CodigoCliente", System.Data.SqlDbType.Decimal).Value = oNota.Cliente.Codigo;
                int CodigoNota = Convert.ToInt32(cmd.ExecuteScalar());
                oNota.Codigo = CodigoNota;
                Conexion.RetornarSqlTransaccion().Commit();
                return true;
            }
            catch (SqlException Ex)
            {
                Conexion.RetornarSqlTransaccion().Rollback();
                return false;
            }
            finally
            {
                Conexion.Desconectar();
            }
        }

        public List<Entidades.Sistema.NotaCredito> ListarNotas()
        {
           return _Lista;
        }
        private void RecuperarNotas()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_RecuperarNotas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.NotaCredito oNota = new Entidades.Sistema.NotaCredito();
                    oNota.Codigo = Convert.ToInt32(dr["id_NotaCredito"]);
                    oNota.Detalle = dr["Detalle"].ToString();
                    oNota.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    oNota.Importe = Convert.ToDecimal(dr["Importe"]);

                    Entidades.Sistema.Cliente oCliente = MappingCliente.ObtenerInstancia().ListarClientes().Find(x => x.Codigo == Convert.ToInt32(dr["id_Cliente"]));
                    oNota.Cliente = oCliente;

                    _Lista.Add(oNota);

                }
            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
            finally
            {
                Conexion.Desconectar();
            }
        }
    }
}
