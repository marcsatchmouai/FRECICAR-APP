using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingProveedor
    {
        private List<Entidades.Sistema.Proveedor> _Lista;
        private static MappingProveedor _Instancia;
        public static MappingProveedor ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingProveedor();
            return _Instancia;
        }
        private MappingProveedor()
        {
            _Lista = new List<Entidades.Sistema.Proveedor>();
            RecuperarProveedores();
        }
        public List<Entidades.Sistema.Proveedor> ListarProveedores()
        {
            return _Lista;
        }

        public void AgregarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 120).Value = Proveedor.Email;
                cmd.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt).Value = Proveedor.Cuit;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 50).Value = Proveedor.RazonSocial;
                cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.NVarChar, 32).Value = Proveedor.Telefono;
                cmd.Parameters.Add("@Direccion_C", System.Data.SqlDbType.NVarChar, 45).Value = Proveedor.DireccionCalle;
                cmd.Parameters.Add("@Direccion_N", System.Data.SqlDbType.NVarChar, 10).Value = Proveedor.DireccionNumero;
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

        public void ModificarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 120).Value = Proveedor.Email;
                cmd.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt).Value = Proveedor.Cuit;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 50).Value = Proveedor.RazonSocial;
                cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.NVarChar, 32).Value = Proveedor.Telefono;
                cmd.Parameters.Add("@Direccion_C", System.Data.SqlDbType.NVarChar, 45).Value = Proveedor.DireccionCalle;
                cmd.Parameters.Add("@Direccion_N", System.Data.SqlDbType.NVarChar, 10).Value = Proveedor.DireccionNumero;
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

        public void EliminarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_RemoveProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt).Value = Proveedor.Cuit;
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

        private void RecuperarProveedores()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListProveedores";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.Proveedor Proveedor = new Entidades.Sistema.Proveedor();
                    Proveedor.Cuit = Convert.ToInt64(dr["Cuit"]);
                    Proveedor.Email = dr["Email"].ToString();
                    Proveedor.RazonSocial = dr["Nombre"].ToString();
                    Proveedor.Telefono = dr["Telefono"].ToString();
                    Proveedor.DireccionCalle = dr["Direccion_C"].ToString();
                    Proveedor.DireccionNumero = dr["Direccion_N"].ToString();
                    _Lista.Add(Proveedor);
                    Proveedor = null;
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
