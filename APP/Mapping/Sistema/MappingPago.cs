using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingPago
    {
        private static MappingPago _Instancia;
        public static MappingPago ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingPago();
            return _Instancia; 
        }

        private MappingPago()
        {
        }

        public void AgregarPago(Entidades.Sistema.Pago oPago)
        {
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddPagos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = oPago.Fecha;
                cmd.Parameters.Add("@Importe", System.Data.SqlDbType.Decimal).Value = oPago.Importe;
                cmd.Parameters.Add("@Detalle", System.Data.SqlDbType.NVarChar,120).Value = oPago.Detalle;
                cmd.Parameters.Add("@CodigoCliente", System.Data.SqlDbType.Decimal).Value = oPago.Cliente.Codigo;
                cmd.Parameters.Add("@CodigoVenta", System.Data.SqlDbType.Decimal).Value = oPago.Venta.CodigoVenta;
                int CodigoPago = Convert.ToInt32(cmd.ExecuteScalar());
                oPago.Codigo = CodigoPago;
                Conexion.RetornarSqlTransaccion().Commit();
            }
            catch (SqlException Ex)
            {
                Conexion.RetornarSqlTransaccion().Rollback();
            }
            finally
            {
                Conexion.Desconectar();
            }
        }

        public List<Entidades.Sistema.Pago> RecuperarPagos()
        {
            List<Entidades.Sistema.Pago>  _Pagos = new List<Entidades.Sistema.Pago>();
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_RecuperarPagos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.Pago oPago = new Entidades.Sistema.Pago();
                    oPago.Codigo = Convert.ToInt32(dr["id_Pago"]);
                    oPago.Detalle = dr["Detalle"].ToString();
                    oPago.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    oPago.Importe = Convert.ToDecimal(dr["Importe"]);

                    Entidades.Sistema.Cliente oCliente = MappingCliente.ObtenerInstancia().ListarClientes().Find(x => x.Codigo == Convert.ToInt32(dr["id_Cliente"]));
                    oPago.Cliente = oCliente;

                    Entidades.Sistema.Venta oVenta = MappingVenta.ObtenerInstancia().ListarVentas().Find(x => x.CodigoVenta == Convert.ToInt32(dr["id_Venta"]));
                    oPago.Venta = oVenta;

                    _Pagos.Add(oPago);

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
            return _Pagos;
        }
    }
}
