using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingOrdenCompra
    {
        private List<Entidades.Sistema.OrdenCompra> _Lista;
        private static MappingOrdenCompra _Instancia;
        public static MappingOrdenCompra ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingOrdenCompra();
            return _Instancia;
        }

        private MappingOrdenCompra()
        {
            _Lista = new List<Entidades.Sistema.OrdenCompra>();
            RecuperarOrdenesCompras();
        }

        public void AgregarOrdenCompra(Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddPedido";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@FormadeEnvio", System.Data.SqlDbType.NVarChar, 15).Value = OrdenCompra.FormadeEnvio.Nombre;
                cmd.Parameters.Add("@FormadePago", System.Data.SqlDbType.NVarChar, 30).Value = OrdenCompra.FormadePago.Nombre;
                cmd.Parameters.Add("@Proveedor", System.Data.SqlDbType.BigInt).Value = OrdenCompra.Proveedor.Cuit;
                cmd.Parameters.Add("@Total", System.Data.SqlDbType.Decimal).Value = OrdenCompra.Total;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = OrdenCompra.Fecha;
                cmd.Parameters.Add("@Estado",System.Data.SqlDbType.NVarChar,30).Value = OrdenCompra.Estado;
                cmd.Parameters.Add("@Operacion", System.Data.SqlDbType.NVarChar, 120).Value = OrdenCompra.Operacion;
                cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.NVarChar, 60).Value = OrdenCompra.Usuario;
                cmd.Parameters.Add("@Equipo", System.Data.SqlDbType.NVarChar, 20).Value = OrdenCompra.Equipo;
                cmd.Parameters.Add("@FechaOperacion", System.Data.SqlDbType.DateTime).Value = OrdenCompra.FechaOperacion;
                int CodOrdenCompra =Convert.ToInt32(cmd.ExecuteScalar());
                OrdenCompra.Codigo = CodOrdenCompra;
                // Detalle de OrdenesCompras
                SqlCommand cmdDetalle = new SqlCommand();
                cmdDetalle.CommandText = "SP_AddDetallePedido";
                cmdDetalle.Connection = Conexion.RetornarConexion();
                cmdDetalle.Transaction = Conexion.RetornarSqlTransaccion();
                cmdDetalle.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDetalle.Parameters.Add("@OrdenCompra", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@MateriaPrima", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@SubTotal", System.Data.SqlDbType.Decimal);
                cmdDetalle.Parameters.Add("@Faltante", System.Data.SqlDbType.Int);
                foreach (Entidades.Sistema.DetalledeOrdenCompra DetalleOrdenCompra in OrdenCompra.DetalleOrdenCompra)
                {
                    cmdDetalle.Parameters["@OrdenCompra"].Value = CodOrdenCompra;
                    cmdDetalle.Parameters["@Cantidad"].Value = DetalleOrdenCompra.Cantidad;
                    cmdDetalle.Parameters["@MateriaPrima"].Value = DetalleOrdenCompra.MateriaPrima.Codigo;
                    cmdDetalle.Parameters["@SubTotal"].Value = DetalleOrdenCompra.SubTotal;
                    cmdDetalle.Parameters["@Faltante"].Value = DetalleOrdenCompra.Faltante;
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

        public void EliminarOrdenCompra(Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_RemoveOrdenCompra";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumeroOrdenCompra",System.Data.SqlDbType.Int).Value = OrdenCompra.Codigo;
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

        public void ModificarOrdenCompra(Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModPedido";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrdenCompra", System.Data.SqlDbType.Int).Value = OrdenCompra.Codigo;
                cmd.Parameters.Add("@FormadeEnvio", System.Data.SqlDbType.NVarChar, 15).Value = OrdenCompra.FormadeEnvio.Nombre;
                cmd.Parameters.Add("@FormadePago", System.Data.SqlDbType.NVarChar, 30).Value = OrdenCompra.FormadePago.Nombre;
                cmd.Parameters.Add("@Proveedor", System.Data.SqlDbType.BigInt).Value = OrdenCompra.Proveedor.Cuit;
                cmd.Parameters.Add("@Total", System.Data.SqlDbType.Decimal).Value = OrdenCompra.Total;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = OrdenCompra.Fecha;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.NVarChar, 30).Value = OrdenCompra.Estado;
                cmd.Parameters.Add("@Operacion", System.Data.SqlDbType.NVarChar, 120).Value = OrdenCompra.Operacion;
                cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.NVarChar, 60).Value = OrdenCompra.Usuario;
                cmd.Parameters.Add("@Equipo", System.Data.SqlDbType.NVarChar, 20).Value = OrdenCompra.Equipo;
                cmd.Parameters.Add("@FechaOperacion", System.Data.SqlDbType.DateTime).Value = OrdenCompra.FechaOperacion;
                cmd.ExecuteNonQuery();
                // Detalle de OrdenesCompras
                SqlCommand cmdDetalle = new SqlCommand();
                cmdDetalle.CommandText = "SP_AddDetallePedido";
                cmdDetalle.Connection = Conexion.RetornarConexion();
                cmdDetalle.Transaction = Conexion.RetornarSqlTransaccion();
                cmdDetalle.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDetalle.Parameters.Add("@OrdenCompra", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@MateriaPrima", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@SubTotal", System.Data.SqlDbType.Decimal);
                cmdDetalle.Parameters.Add("@Faltante", System.Data.SqlDbType.Int);
                foreach (Entidades.Sistema.DetalledeOrdenCompra DetalleOrdenCompra in OrdenCompra.DetalleOrdenCompra)
                {
                    cmdDetalle.Parameters["@OrdenCompra"].Value = OrdenCompra.Codigo;
                    cmdDetalle.Parameters["@Cantidad"].Value = DetalleOrdenCompra.Cantidad;
                    cmdDetalle.Parameters["@MateriaPrima"].Value = DetalleOrdenCompra.MateriaPrima.Codigo;
                    cmdDetalle.Parameters["@SubTotal"].Value = DetalleOrdenCompra.SubTotal;
                    cmdDetalle.Parameters["@Faltante"].Value = DetalleOrdenCompra.Faltante;
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

        public List<Entidades.Sistema.OrdenCompra> ListarOrdenesCompras()
        {
            return _Lista;
        }
        private void RecuperarOrdenesCompras()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListPedido";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.OrdenCompra OrdenCompra = new Entidades.Sistema.OrdenCompra();
                    OrdenCompra.Codigo = Convert.ToInt32(dr["id_Pedido"]);
                    OrdenCompra.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    OrdenCompra.Estado = dr["Estado"].ToString();
                    OrdenCompra.Usuario = dr["Usuario"].ToString();
                    OrdenCompra.Operacion = dr["Operacion"].ToString();
                    OrdenCompra.FechaOperacion = Convert.ToDateTime(dr["FechaOperacion"].ToString());

                    Entidades.Sistema.FormadeEnvio FormadeEnvio;
                    FormadeEnvio = MappingFormadeEnvio.ObtenerInstancia().ListarFormasEnvios().Find(x => x.Nombre == dr["FormaEnvio"].ToString());
                    OrdenCompra.FormadeEnvio = FormadeEnvio;

                    Entidades.Sistema.FormadePago FormadePago;
                    FormadePago = MappingFormadePago.ObtenerInstancia().ListarFormasPagos().Find(x => x.Nombre == dr["FormaPago"].ToString());
                    OrdenCompra.FormadePago = FormadePago;

                    Entidades.Sistema.Proveedor Proveedor;
                    Proveedor = MappingProveedor.ObtenerInstancia().ListarProveedores().Find(x => x.Cuit == Convert.ToInt64((dr["Proveedor"])));
                    OrdenCompra.Proveedor = Proveedor;

             
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = Conexion.RetornarConexion();
                    cmd2.CommandText = "SP_FindDetalles";
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@id_OrdenCompra",System.Data.SqlDbType.Int).Value = OrdenCompra.Codigo;
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        Entidades.Sistema.DetalledeOrdenCompra DetalledeOrdenCompra = new Entidades.Sistema.DetalledeOrdenCompra();
                        DetalledeOrdenCompra.Cantidad = Convert.ToInt32(dr2["Cantidad"]);
                        DetalledeOrdenCompra.SubTotal = Convert.ToDecimal(dr2["SubTotal"]);
                        DetalledeOrdenCompra.Faltante = Convert.ToInt32(dr2["Faltante"]);
                        DetalledeOrdenCompra.MateriaPrima = MappingMateriaPrima.ObtenerInstancia().ListarMateriasPrimas().Find(x => x.Codigo == Convert.ToInt32((dr2["MateriaPrima"])));
                        OrdenCompra.AgregarDetalle(DetalledeOrdenCompra);
                    }
                    _Lista.Add(OrdenCompra);
                }
            }
            catch (SqlException Ex)
            {
            }
            finally
            {
                Conexion.Desconectar();
            }
        }
    }
}
