using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace Mapping.Seguridad
{
    public static class MappingGrupos
    {
        public delegate void CambiosRealizados();
        public static event CambiosRealizados AlDetectarCambios;
        

        public static List<Entidades.Seguridad.Grupo> RecuperarGrupos()
        {
            List<Entidades.Seguridad.Grupo> ColGrupos = new List<Entidades.Seguridad.Grupo>();
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_ConsultarGrupos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                SqlDataReader drGrupos = cmd.ExecuteReader();
                while (drGrupos.Read())
                {
                    Entidades.Seguridad.Grupo oGrupo = new Entidades.Seguridad.Grupo();
                    oGrupo.Nombre = drGrupos["Id_Grupo"].ToString();
                    oGrupo.Descripcion = drGrupos["Descripcion"].ToString();
                    ColGrupos.Add(oGrupo);
                    oGrupo = null;
                }
            }
            catch (SqlException ex)
            {
                Servicios.EventManager.RegistarErrores(ex);   
            }
            finally
            {
                conexion.Desconectar();
            }
            return ColGrupos;
        }

        public static bool AgregarGrupo(Entidades.Seguridad.Grupo grupo)
        {
            bool operacion = false;
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_AgregarGrupo";
                cmd.Parameters.Add("@NombreGrupo", System.Data.SqlDbType.VarChar, 20).Value = grupo.Nombre;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar, 200).Value = grupo.Descripcion;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                int nroCeldas = cmd.ExecuteNonQuery();
                conexion.RetornarSqlTransaccion().Commit();
                if (nroCeldas >= 1) operacion = true;
                else operacion = false;
            }
            catch(SqlException ex)
            {
                conexion.RetornarSqlTransaccion().Rollback();
                Servicios.EventManager.RegistarErrores(ex);
            }
            finally
            {
                conexion.Desconectar();
            }
            return operacion;
        }

        public static bool ModificarGrupo(Entidades.Seguridad.Grupo grupo)
        {
            bool operacion = false;
            Servicios.Conexion conexion = new Servicios.Conexion();
            try
            {
                conexion.Conectar("Seguridad");
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_ModificarGrupo";
                cmd.Parameters.Add("@NombreGrupo", System.Data.SqlDbType.VarChar, 20).Value = grupo.Nombre;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar, 200).Value = grupo.Descripcion;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                int nroCeldas = cmd.ExecuteNonQuery();
                if (nroCeldas >= 1) operacion = true;
                else operacion = false;
                conexion.RetornarSqlTransaccion().Commit();
            }
            catch(SqlException ex)
            {
                conexion.RetornarSqlTransaccion().Rollback();
                Servicios.EventManager.RegistarErrores(ex);
            }
            finally
            {
                conexion.Desconectar();
            }
            return operacion;
        }

        public static bool EliminarGrupo(Entidades.Seguridad.Grupo grupo)
        {
            bool operacion = false;
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_EliminarGrupo";
                cmd.Parameters.Add("@NombreGrupo", System.Data.SqlDbType.VarChar, 20).Value = grupo.Nombre;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                int nroCeldas = cmd.ExecuteNonQuery();
                if (nroCeldas >= 1) operacion = true;
                else operacion = false;
                conexion.RetornarSqlTransaccion().Commit();
            }
            catch (SqlException ex)
            {
                conexion.RetornarSqlTransaccion().Rollback();
                Servicios.EventManager.RegistarErrores(ex);
            }
            finally
            {
                conexion.Desconectar();
            }
            return operacion;
        }
    
    }
}
