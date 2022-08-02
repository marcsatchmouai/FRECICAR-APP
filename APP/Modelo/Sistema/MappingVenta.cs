using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingVenta
    {
        private List<Entidades.Sistema.Venta> _Lista;
        private static MappingVenta _Instancia;
        public static MappingVenta ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingVenta();
            return _Instancia;
        }

        private MappingVenta()
        {
            _Lista = new List<Entidades.Sistema.Venta>();
            RecuperarVentas();
        }
        public void AgregarVenta(Entidades.Sistema.Venta Venta)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddVenta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Detalle", System.Data.SqlDbType.NVarChar, 120).Value = Venta.Detalle;
                cmd.Parameters.Add("@FormadeEnvio", System.Data.SqlDbType.NVarChar, 15).Value = Venta.Envio.Nombre;
                cmd.Parameters.Add("@FormadePago", System.Data.SqlDbType.NVarChar, 30).Value = Venta.FormadePago.Nombre;
                cmd.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt).Value = Venta.Cliente.Cuit;
                cmd.Parameters.Add("@Total", System.Data.SqlDbType.Decimal).Value = Venta.Total;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = Venta.Fecha;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.NVarChar, 12).Value = Venta.Estado.ToString();
                int CodVenta = Convert.ToInt32(cmd.ExecuteScalar());
                Venta.CodigoVenta = CodVenta;
                // Detalle de OrdenesCompras
                SqlCommand cmdDetalle = new SqlCommand();
                cmdDetalle.CommandText = "SP_AddDetalleVenta";
                cmdDetalle.Connection = Conexion.RetornarConexion();
                cmdDetalle.Transaction = Conexion.RetornarSqlTransaccion();
                cmdDetalle.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDetalle.Parameters.Add("@id_Venta", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@CodigoProducto", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@SubTotal", System.Data.SqlDbType.Decimal);
                foreach (Entidades.Sistema.DetalleVenta DetalleVenta in Venta.DetallesVentas)
                {
                    cmdDetalle.Parameters["@id_Venta"].Value = CodVenta;
                    cmdDetalle.Parameters["@Cantidad"].Value = DetalleVenta.Cantidad;
                    cmdDetalle.Parameters["@CodigoProducto"].Value = DetalleVenta.Producto.Codigo;
                    cmdDetalle.Parameters["@SubTotal"].Value = DetalleVenta.SubTotal;
                    cmdDetalle.ExecuteNonQuery();
                }

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

        public void EliminarVenta(Entidades.Sistema.Venta Venta)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_RemoveVenta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodigoVenta", System.Data.SqlDbType.Int).Value = Venta.CodigoVenta;
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

        public void ModificarVenta(Entidades.Sistema.Venta Venta)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModVenta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodigoVenta", System.Data.SqlDbType.Int).Value = Venta.CodigoVenta;
                cmd.Parameters.Add("@Detalle", System.Data.SqlDbType.NVarChar, 120).Value = Venta.Detalle;
    //            cmd.Parameters.Add("@FormadeEnvio", System.Data.SqlDbType.NVarChar, 15).Value = Venta.Envio.Nombre;
                cmd.Parameters.Add("@FormadePago", System.Data.SqlDbType.NVarChar, 30).Value = Venta.FormadePago.Nombre;
                cmd.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt).Value = Venta.Cliente.Cuit;
                cmd.Parameters.Add("@Total", System.Data.SqlDbType.Decimal).Value = Venta.Total;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = Venta.Fecha;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.NVarChar, 12).Value = Venta.Estado.ToString();
                cmd.ExecuteNonQuery();
                // Detalle de OrdenesCompras
                SqlCommand cmdDetalle = new SqlCommand();
                cmdDetalle.CommandText = "SP_AddDetalleVenta";
                cmdDetalle.Connection = Conexion.RetornarConexion();
                cmdDetalle.Transaction = Conexion.RetornarSqlTransaccion();
                cmdDetalle.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDetalle.Parameters.Add("@id_Venta", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@CodigoProducto", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@SubTotal", System.Data.SqlDbType.Decimal);
                foreach (Entidades.Sistema.DetalleVenta DetalleVenta in Venta.DetallesVentas)
                {
                    cmdDetalle.Parameters["@id_Venta"].Value = Venta.CodigoVenta;
                    cmdDetalle.Parameters["@Cantidad"].Value = DetalleVenta.Cantidad;
                    cmdDetalle.Parameters["@CodigoProducto"].Value = DetalleVenta.Producto.Codigo;
                    cmdDetalle.Parameters["@SubTotal"].Value = DetalleVenta.SubTotal;
                    cmdDetalle.ExecuteNonQuery();
                }
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

        public List<Entidades.Sistema.Venta> ListarVentas()
        {
            return _Lista;
        }
        private void RecuperarVentas()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListVentas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.Venta _Venta = new Entidades.Sistema.Venta();
                    _Venta.CodigoVenta = Convert.ToInt32(dr["id_Venta"]);
                    _Venta.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    _Venta.Detalle = dr["Detalle"].ToString();

                    string Estado = dr["Estado"].ToString();
                    if (Estado == Entidades.Sistema.Venta.EstadoVenta.Anulado.ToString())_Venta.Estado = Entidades.Sistema.Venta.EstadoVenta.Anulado;
                    else if (Estado == Entidades.Sistema.Venta.EstadoVenta.Finalizado.ToString()) _Venta.Estado = Entidades.Sistema.Venta.EstadoVenta.Finalizado;
                    else _Venta.Estado = Entidades.Sistema.Venta.EstadoVenta.Relizado;

       //             Entidades.Sistema.FormadeEnvio FormadeEnvio = MappingFormadeEnvio.ObtenerInstancia().ListarFormasEnvios().Find(x => x.Nombre == dr["FormaEnvio"].ToString());
       //             _Venta.Envio = FormadeEnvio;

                    Entidades.Sistema.FormadePago FormadePago = MappingFormadePago.ObtenerInstancia().ListarFormasPagos().Find(x => x.Nombre == dr["FormaPago"].ToString());
                    _Venta.FormadePago = FormadePago;

                    Entidades.Sistema.Cliente Cliente;
                    Cliente = MappingCliente.ObtenerInstancia().ListarClientes().Find(x => x.Cuit == Convert.ToInt64(dr["Cliente"]));
                    _Venta.Cliente = Cliente;

                    _Venta.Total = Convert.ToDecimal(dr["Total"]);

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = Conexion.RetornarConexion();
                    cmd2.CommandText = "SP_ListDetallesVentas";
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@id_Venta", System.Data.SqlDbType.Int).Value = _Venta.CodigoVenta;
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        Entidades.Sistema.DetalleVenta DetalleVenta = new Entidades.Sistema.DetalleVenta();
                        DetalleVenta.Cantidad = Convert.ToInt32(dr2["Cantidad"]);
                        DetalleVenta.SubTotal = Convert.ToDecimal(dr2["SubTotal"]);
                        DetalleVenta.Producto = MappingProducto.ObtenerInstancia().ListarProductos().Find(x => x.Codigo == Convert.ToInt32(dr2["id_Producto"]));
                        _Venta.AgregarDetalle(DetalleVenta);
                    }
                    _Lista.Add(_Venta);
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
