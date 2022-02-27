using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingFormadeEnvio
    {
        private List<Entidades.Sistema.FormadeEnvio> _Lista;
        private static MappingFormadeEnvio _Instancia;
        public static MappingFormadeEnvio ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingFormadeEnvio();
            return _Instancia;
        }

        private MappingFormadeEnvio()
        {
            _Lista = new List<Entidades.Sistema.FormadeEnvio>();
            RecuperarFormadeEnvio();
        }

        public void AgregarFormadeEnvio(Entidades.Sistema.FormadeEnvio FormadeEnvio)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddFEnvios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 15).Value = FormadeEnvio.Nombre;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 30).Value = FormadeEnvio.Descripcion;
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

        public void ModificarFormadeEnvio(Entidades.Sistema.FormadeEnvio FormadeEnvio)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModFEnvio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 15).Value = FormadeEnvio.Nombre;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 30).Value = FormadeEnvio.Descripcion;
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

        public void EliminarFormadeEnvio(Entidades.Sistema.FormadeEnvio FormadeEnvio)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_RemoveFEnvio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 15).Value = FormadeEnvio.Nombre;
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

        public List<Entidades.Sistema.FormadeEnvio> ListarFormasEnvios()
        {
            return _Lista;
        }
        private void RecuperarFormadeEnvio()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListFEnvio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.FormadeEnvio FormadeEnvio = new Entidades.Sistema.FormadeEnvio();
                    FormadeEnvio.Descripcion = dr["Descripcion"].ToString();
                    FormadeEnvio.Nombre = dr["Nombre"].ToString();
                    _Lista.Add(FormadeEnvio);
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
