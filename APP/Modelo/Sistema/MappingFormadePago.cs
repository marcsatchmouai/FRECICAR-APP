using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingFormadePago
    {
        private List<Entidades.Sistema.FormadePago> _Lista;
        private static MappingFormadePago _Instancia;
        public static MappingFormadePago ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingFormadePago();
            return _Instancia;
        }

        private MappingFormadePago()
        {
            _Lista = new List<Entidades.Sistema.FormadePago>();
            RecuperarFormadePago();
        }

        public void AgregarFormadePago(Entidades.Sistema.FormadePago FormadePago)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddFPago";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 30).Value = FormadePago.Nombre;
                cmd.Parameters.Add("Descripcion", System.Data.SqlDbType.NVarChar, 140).Value = FormadePago.Descripcion;
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

        public void ModificarFormadePago(Entidades.Sistema.FormadePago FormadePago)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModFPago";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 30).Value = FormadePago.Nombre;
                cmd.Parameters.Add("Descripcion", System.Data.SqlDbType.NVarChar, 140).Value = FormadePago.Descripcion;
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

        public void EliminarFormadePago(Entidades.Sistema.FormadePago FormadePago)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_RemoveFPago";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 30).Value = FormadePago.Nombre;
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

        public List<Entidades.Sistema.FormadePago> ListarFormasPagos()
        {
            return _Lista;
        }
        private void RecuperarFormadePago()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListFPago";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.FormadePago FormadePago = new Entidades.Sistema.FormadePago();
                    FormadePago.Descripcion = dr["Descripcion"].ToString();
                    FormadePago.Nombre = dr["Nombre"].ToString();
                    _Lista.Add(FormadePago);
                    FormadePago = null;
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
