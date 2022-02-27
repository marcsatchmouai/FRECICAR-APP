using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingProducto
    {
        private List<Entidades.Sistema.Producto> _Lista;
        private static MappingProducto _Instancia;
        public static MappingProducto ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingProducto();
            return _Instancia;
        }

        private MappingProducto()
        {
            _Lista = new List<Entidades.Sistema.Producto>();
            RecuperarProductos();
        }
        public void AgregarProducto(Entidades.Sistema.Producto Producto)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddProducto";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int).Value = Producto.Cantidad;
                cmd.Parameters.Add("@CantMin", System.Data.SqlDbType.Int, 30).Value = Producto.CantMin;
                cmd.Parameters.Add("@Categoria", System.Data.SqlDbType.NVarChar, 50).Value = Producto.Categoria.Nombre;
                cmd.Parameters.Add("@CostoUnitario", System.Data.SqlDbType.Decimal).Value = Producto.Precio;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 120).Value = Producto.Descripcion;
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

        public void EliminarProducto(Entidades.Sistema.Producto Producto)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_RemoveProducto";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Codigo", System.Data.SqlDbType.Int).Value = Producto.Codigo;
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

        public void ModificarProducto(Entidades.Sistema.Producto Producto)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModProducto";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Codigo", System.Data.SqlDbType.Int).Value = Producto.Codigo;
                cmd.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int).Value = Producto.Cantidad;
                cmd.Parameters.Add("@CantMin", System.Data.SqlDbType.NVarChar, 30).Value = Producto.CantMin;
                cmd.Parameters.Add("@Categoria", System.Data.SqlDbType.NVarChar, 50).Value = Producto.Categoria.Nombre;
                cmd.Parameters.Add("@CostoUnitario", System.Data.SqlDbType.Decimal).Value = Producto.Precio;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar,120).Value = Producto.Descripcion;
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

        public List<Entidades.Sistema.Producto> ListarProductos()
        {
            return _Lista;
        }
        private void RecuperarProductos()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.Producto Producto = new Entidades.Sistema.Producto();
                    Producto.Codigo = Convert.ToInt32(dr["id_Producto"]);
                    Producto.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                    Producto.CantMin = Convert.ToInt32(dr["CantMin"]);
                    Producto.Precio = Convert.ToDecimal(dr["CostoUnitario"]);
                    Producto.Descripcion = dr["Descripcion"].ToString();

                    Entidades.Sistema.CategoriaProducto Categoria = MappingCategoriaProducto.ObtenerInstancia().DevolverLista().Find(x => x.Nombre == dr["Nombre"].ToString());
                    Producto.Categoria = Categoria;
                    _Lista.Add(Producto);
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
