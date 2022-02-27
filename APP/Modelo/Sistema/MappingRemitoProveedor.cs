using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingRemitoProveedor
    {
        private List<Entidades.Sistema.RemitoProveedor> _Lista;
        private static MappingRemitoProveedor _Instancia;
        public static MappingRemitoProveedor ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingRemitoProveedor();
            return _Instancia;
        }

        private MappingRemitoProveedor()
        {
            _Lista = new List<Entidades.Sistema.RemitoProveedor>();
            RecuperarRemitosProveedor();
        }

        public void AgregarRemitoProveedor(Entidades.Sistema.RemitoProveedor RemitoProveedor)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddRemito";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Proveedor", System.Data.SqlDbType.BigInt).Value = RemitoProveedor.Proveedor.Cuit;
                cmd.Parameters.Add("@Total", System.Data.SqlDbType.Decimal).Value = RemitoProveedor.Total;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = RemitoProveedor.Fecha;
                cmd.Parameters.Add("@NumeroOrdenC", System.Data.SqlDbType.Int).Value = RemitoProveedor.NumeroOrdenCompra;
                int CodRemitoProveedor = Convert.ToInt32(cmd.ExecuteScalar());
                RemitoProveedor.Codigo = CodRemitoProveedor;
                // Detalle de RemitoProveedorsProveedores
                SqlCommand cmdDetalle = new SqlCommand();
                cmdDetalle.CommandText = "SP_AddDetalleRemito";
                cmdDetalle.Connection = Conexion.RetornarConexion();
                cmdDetalle.Transaction = Conexion.RetornarSqlTransaccion();
                cmdDetalle.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDetalle.Parameters.Add("@Remito", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@MateriaPrima", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@SubTotal", System.Data.SqlDbType.Decimal);
                foreach (Entidades.Sistema.DetalledeRemitoProveedor DetalleRemitoProveedor in RemitoProveedor.DetalleRemitoProveedor)
                {
                    cmdDetalle.Parameters["@Remito"].Value = CodRemitoProveedor;
                    cmdDetalle.Parameters["@Cantidad"].Value = DetalleRemitoProveedor.Cantidad;
                    cmdDetalle.Parameters["@MateriaPrima"].Value = DetalleRemitoProveedor.MateriaPrima.Codigo;
                    cmdDetalle.Parameters["@SubTotal"].Value = DetalleRemitoProveedor.SubTotal;
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

        public void EliminarRemitoProveedor(Entidades.Sistema.RemitoProveedor RemitoProveedor)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_RemoveRemitoProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumeroRemitoProveedor", System.Data.SqlDbType.Int).Value = RemitoProveedor.Codigo;
                cmd.ExecuteNonQuery();
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

        public void ModificarRemitoProveedor(Entidades.Sistema.RemitoProveedor RemitoProveedor)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModRemitoProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumeroRemitoProveedor",System.Data.SqlDbType.Int).Value = RemitoProveedor.Codigo;
                cmd.Parameters.Add("@Proveedor", System.Data.SqlDbType.Int).Value = RemitoProveedor.Proveedor;
                cmd.Parameters.Add("@Total", System.Data.SqlDbType.Decimal).Value = RemitoProveedor.Total;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = RemitoProveedor.Fecha;
                cmd.Parameters.Add("@NumeroOrdenC", System.Data.SqlDbType.Int).Value = RemitoProveedor.NumeroOrdenCompra;
                cmd.ExecuteNonQuery();
                // Detalle de RemitoProveedorsProveedores
                SqlCommand cmdDetalle = new SqlCommand();
                cmdDetalle.CommandText = "SP_AddDetalleRemitoProveedor";
                cmdDetalle.Connection = Conexion.RetornarConexion();
                cmdDetalle.Transaction = Conexion.RetornarSqlTransaccion();
                cmdDetalle.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDetalle.Parameters.Add("@NumeroRemitoProveedor", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@MateriaPrima", System.Data.SqlDbType.Int);
                cmdDetalle.Parameters.Add("@SubTotal", System.Data.SqlDbType.Decimal);
                foreach (Entidades.Sistema.DetalledeRemitoProveedor DetalleRemitoProveedor in RemitoProveedor.DetalleRemitoProveedor)
                {
                    cmdDetalle.Parameters["@NumeroRemitoProveedor"].Value = RemitoProveedor.Codigo;
                    cmdDetalle.Parameters["@Cantidad"].Value = DetalleRemitoProveedor.Cantidad;
                    cmdDetalle.Parameters["@MateriaPrima"].Value = DetalleRemitoProveedor.MateriaPrima.Codigo;
                    cmdDetalle.Parameters["@SubTotal"].Value = DetalleRemitoProveedor.SubTotal;
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

        public List<Entidades.Sistema.RemitoProveedor> ListarRemitosProveedor()
        {
            return _Lista;
        }

        private void RecuperarRemitosProveedor()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListRemitos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.RemitoProveedor RemitoProveedor = new Entidades.Sistema.RemitoProveedor();
                    RemitoProveedor.Codigo = Convert.ToInt32(dr["id_Remito"]);
                    RemitoProveedor.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    RemitoProveedor.NumeroOrdenCompra = Convert.ToInt32(dr["NumeroOrdenC"]);

                    Entidades.Sistema.Proveedor Proveedor = MappingProveedor.ObtenerInstancia().ListarProveedores().Find(x => x.Cuit == Convert.ToInt64(dr["Cuit"]));
                    RemitoProveedor.Proveedor = Proveedor;

                    RemitoProveedor.Total = Convert.ToDecimal(dr["Total"]);

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = Conexion.RetornarConexion();
                    cmd2.CommandText = "SP_FindDetalleRemito";
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@NumeroRemito", System.Data.SqlDbType.Int).Value = RemitoProveedor.Codigo;
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        Entidades.Sistema.DetalledeRemitoProveedor DetalledeRemitoProveedor = new Entidades.Sistema.DetalledeRemitoProveedor();
                        DetalledeRemitoProveedor.Cantidad = Convert.ToInt32(dr2["Cantidad"]);
                        DetalledeRemitoProveedor.SubTotal = Convert.ToDecimal(dr2["SubTotal"]);
                        DetalledeRemitoProveedor.MateriaPrima = MappingMateriaPrima.ObtenerInstancia().ListarMateriasPrimas().Find(x => x.Codigo ==Convert.ToInt32(dr2["CodigoMateriaPrima"]));
                        RemitoProveedor.AgregarDetalle(DetalledeRemitoProveedor);
                    }
                    _Lista.Add(RemitoProveedor);
                }

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
    }
}
