using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingSituacionFiscal
    {
        private List<Entidades.Sistema.SituacionFiscal> _Lista;
        private static MappingSituacionFiscal _Instancia;
        public static MappingSituacionFiscal ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingSituacionFiscal();
            return _Instancia;
        }

        private MappingSituacionFiscal()
        {
            _Lista = new List<Entidades.Sistema.SituacionFiscal>();
            RecuperarSituacionFiscal();
        }
        public void Agregar(Entidades.Sistema.SituacionFiscal oSituacionFiscal)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddSituacionFiscal";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Codigo", System.Data.SqlDbType.NVarChar, 45).Value = oSituacionFiscal.Codigo;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 100).Value = oSituacionFiscal.Descripcion;
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

        public void Modificar(Entidades.Sistema.SituacionFiscal oSituacionFiscal)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModSituacionFiscal";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Codigo", System.Data.SqlDbType.NVarChar, 45).Value = oSituacionFiscal.Codigo;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 100).Value = oSituacionFiscal.Descripcion;
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

        public void Eliminar(Entidades.Sistema.SituacionFiscal oSituacionFiscal)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_RemoveSituacionFiscal";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Codigo", System.Data.SqlDbType.NVarChar, 45).Value = oSituacionFiscal.Codigo;
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

        public List<Entidades.Sistema.SituacionFiscal> ListarSituacionesFiscales()
        {
            return _Lista;
        }

        private void RecuperarSituacionFiscal()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListSituacionesFiscales";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.SituacionFiscal oSituacionFiscal = new Entidades.Sistema.SituacionFiscal();
                    oSituacionFiscal.Descripcion = dr["Descripcion"].ToString();
                    oSituacionFiscal.Codigo = Convert.ToInt32(dr["id_SituacionFiscal"]);
                    _Lista.Add(oSituacionFiscal);
                    oSituacionFiscal = null;
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
