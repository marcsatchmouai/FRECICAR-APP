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
        private List<Entidades.Sistema.CategoriaProducto> _Lista;
        private static MappingCategoriaProducto _Instancia;
        public static MappingCategoriaProducto ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingCategoriaProducto();
            return _Instancia;
        }

        private MappingCategoriaProducto()
        {
            _Lista = new List<Entidades.Sistema.CategoriaProducto>();
            RecuperarCategorias();
        }
        public void AgregarCategoriaProducto(Entidades.Sistema.CategoriaProducto CategoriaProducto)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
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
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
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
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
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

        public List<Entidades.Sistema.CategoriaProducto> DevolverLista()
        {
            return _Lista;
        }

        private void RecuperarCategorias()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
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
                    _Lista.Add(Categoria);
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
        }
    }
}
