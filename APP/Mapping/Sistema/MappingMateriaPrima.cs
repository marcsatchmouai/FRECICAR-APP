using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingMateriaPrima
    {
        private static MappingMateriaPrima _Instancia;
        public static MappingMateriaPrima ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingMateriaPrima();
            return _Instancia;
        }

        private MappingMateriaPrima()
        {

        }

        public void AgregarMateriaPrima(Entidades.Sistema.MateriaPrima MateriaPrima)
        {
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddMateriaPrima";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodigoMateriaPrima", System.Data.SqlDbType.Int).Value = MateriaPrima.Codigo;
                cmd.Parameters.Add("@Proveedor", System.Data.SqlDbType.BigInt).Value = MateriaPrima.Proveedor.Cuit;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 110).Value = MateriaPrima.Descripcion;
                cmd.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int).Value = MateriaPrima.Cantidad;
                cmd.Parameters.Add("@Categoria", System.Data.SqlDbType.NVarChar,45).Value = MateriaPrima.Categoria.Nombre;
                cmd.Parameters.Add("@CostoUnitario", System.Data.SqlDbType.Decimal).Value = MateriaPrima.CostoUnitario;
                cmd.Parameters.Add("@CantMin", System.Data.SqlDbType.Int).Value = MateriaPrima.CantMin;
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

        public void ModificarMateriaPrima(Entidades.Sistema.MateriaPrima MateriaPrima)
        {
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModMateriaPrima";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodigoMPrima", System.Data.SqlDbType.Int).Value = MateriaPrima.Codigo;
                cmd.Parameters.Add("@Proveedor", System.Data.SqlDbType.BigInt).Value = MateriaPrima.Proveedor.Cuit;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 110).Value = MateriaPrima.Descripcion;
                cmd.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int).Value = MateriaPrima.Cantidad;
                cmd.Parameters.Add("@Categoria", System.Data.SqlDbType.NVarChar,45).Value = MateriaPrima.Categoria.Nombre;
                cmd.Parameters.Add("@CostoUnitario", System.Data.SqlDbType.Decimal).Value = MateriaPrima.CostoUnitario;
                cmd.Parameters.Add("@CantMin", System.Data.SqlDbType.Int).Value = MateriaPrima.CantMin;
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

        public void EliminarMateriaPrima(Entidades.Sistema.MateriaPrima MateriaPrima)
        {
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_RemoveMateriaPrima";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodigoMateriaPrima", System.Data.SqlDbType.Int).Value = MateriaPrima.Codigo;
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

        public List<Entidades.Sistema.MateriaPrima> RecuperarMateriasPrimas()
        {
            List<Entidades.Sistema.MateriaPrima> _MateriaPrima = new List<Entidades.Sistema.MateriaPrima>();
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListMateriaPrima";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.MateriaPrima MateriaPrima = new Entidades.Sistema.MateriaPrima();
                    MateriaPrima.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                    MateriaPrima.CantMin = Convert.ToInt32(dr["CantMin"]);

                    Entidades.Sistema.Categoria Categoria = new Entidades.Sistema.Categoria();
                    Categoria = MappingCategoria.ObtenerInstancia().RecuperarCategorias().Find(x => x.Nombre == dr["Nombre"].ToString());
                    MateriaPrima.Categoria = Categoria;

                    MateriaPrima.Descripcion = dr["Descripcion"].ToString();
                    MateriaPrima.Codigo = Convert.ToInt32(dr["CodigoMateriaPrima"]);
                    MateriaPrima.CostoUnitario = Convert.ToDecimal(dr["CostoUnitario"]);

                    Entidades.Sistema.Proveedor Proveedor = new Entidades.Sistema.Proveedor();
                    Int64 proveedor = Convert.ToInt64(dr["Proveedor"]);
                    Proveedor = MappingProveedor.ObtenerInstancia().RecuperarProveedor().Find(x => x.Cuit ==proveedor );
                    MateriaPrima.Proveedor = Proveedor;
                    _MateriaPrima.Add(MateriaPrima);
                    MateriaPrima = null;
                }
            }
            catch (SqlException Ex)
            {
            }
            finally
            {
                Conexion.Desconectar();
            }
            return _MateriaPrima;
        }
    }
}
