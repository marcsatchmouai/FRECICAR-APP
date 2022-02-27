using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingCuentaCorriente
    {
        private static MappingCuentaCorriente _Instancia;
        public static MappingCuentaCorriente ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingCuentaCorriente();
            return _Instancia;
        }

        private MappingCuentaCorriente()
        {
        }

        public List<Entidades.Sistema.CuentaCorriente> RecuperarCuentasCorrientes()
        {
            List<Entidades.Sistema.CuentaCorriente> _CuentasCorrientes = new List<Entidades.Sistema.CuentaCorriente>();
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_RecuperarCuentasCorrientes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.CuentaCorriente oCuentaCorriente = new Entidades.Sistema.CuentaCorriente();
                    oCuentaCorriente.NumeroCuentaCorriente = Convert.ToInt32(dr["id_CuentaCorriente"]);

                    Entidades.Sistema.Cliente oCliente = MappingCliente.ObtenerInstancia().ListarClientes().Find(x => x.Codigo == Convert.ToInt64(dr["id_Cliente"]));
                    oCuentaCorriente.Cliente = oCliente;

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = Conexion.RetornarConexion();
                    cmd2.CommandText = "SP_RecuperarMovimientos";
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@NumeroCuentaCorriente", System.Data.SqlDbType.Int).Value = oCuentaCorriente.NumeroCuentaCorriente;
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        Entidades.Sistema.Movimiento oMovimiento = new Entidades.Sistema.Movimiento();
                        oMovimiento.Importe = Convert.ToDecimal(dr2["Importe"]);
                        oMovimiento.Fecha = Convert.ToDateTime(dr2["Fecha"]);
                        Entidades.Sistema.Pago oPago = MappingPago.ObtenerInstancia().RecuperarPagos().Find(x =>x.Detalle == dr2["Detalle"].ToString());
                        if (oPago != null) oMovimiento.Detalle = oPago;
                        Entidades.Sistema.Venta oVenta = MappingVenta.ObtenerInstancia().ListarVentas().Find(x => x.Detalle == dr2["Detalle"].ToString());
                        if (oVenta != null) oMovimiento.Detalle = oVenta;
                        Entidades.Sistema.NotaCredito oNota = MappingNotaCredito.ObtenerInstancia().RecuperarNotas().Find(x => x.Detalle == dr2["Detalle"].ToString());
                        if (oNota != null) oMovimiento.Detalle = oNota;
                        oMovimiento.TipoMovimiento = dr2["TipodeMovimiento"].ToString();
                        oCuentaCorriente.AgregarMovimiento(oMovimiento);
                    }
                    _CuentasCorrientes.Add(oCuentaCorriente);
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

            return _CuentasCorrientes;
        }
    }
}
