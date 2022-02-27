using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingCategoriaProducto
    {
        private static MappingCategoriaProducto _Instancia;
        public static MappingCategoriaProducto ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingCategoriaProducto();
            return _Instancia;
        }
        public void AgregarCategoriaProducto(Entidades.Sistema.CategoriaProducto CategoriaProducto)
        {
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddCategoriaProducto";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 45).Value = CategoriaProducto.Nombre;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 100).Value = CategoriaProducto.Descripcion;
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

        public void ModificarCategoriaProducto(Entidades.Sistema.CategoriaProducto Categoria)
        {
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModCategoriaProducto";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 45).Value = Categoria.Nombre;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 100).Value = Categoria.Descripcion;
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

        public void EliminarCategoriaProducto(Entidades.Sistema.CategoriaProducto Categoria)
        {
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_RemoveCategoriaProducto";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 45).Value = Categoria.Nombre;
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

        public List<Entidades.Sistema.CategoriaProducto> RecuperarCategorias()
        {
            List<Entidades.Sistema.CategoriaProducto> _Categoria = new List<Entidades.Sistema.CategoriaProducto>();
            Servicios.Conexion Conexion = new Servicios.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListCategoriasProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.CategoriaProducto Categoria = new Entidades.Sistema.CategoriaProducto();
                    Categoria.Descripcion = dr["Descripcion"].ToString();
                    Categoria.Nombre = dr["Nombre"].ToString();
                    _Categoria.Add(Categoria);
                    Categoria = null;
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
            return _Categoria;
        }
    }
}
