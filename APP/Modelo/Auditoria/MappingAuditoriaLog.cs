using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mapping.Auditoria
{
    public static class MappingAuditoriaLog
    {
        public static void Registrar(Entidades.Auditoria.AuditoriaInicioSesion auditoria)
        {
            Utilidades.Conexion conexion = new Utilidades.Conexion();
            conexion.Conectar("Auditoria");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                cmd.CommandText = "sp_RegistrarIngresoEgreso";
                cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.VarChar, 15).Value = auditoria.Usuario;
                cmd.Parameters.Add("@Operacion", System.Data.SqlDbType.VarChar, 10).Value = auditoria.Operacion.ToString();  
                cmd.Parameters.Add("@FechaHora", System.Data.SqlDbType.DateTime).Value = auditoria.FechaHora;
                cmd.Parameters.Add("@Equipo", System.Data.SqlDbType.VarChar, 20).Value = auditoria.Equipo;
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                conexion.RetornarSqlTransaccion().Rollback();
                Utilidades.EventManager.RegistarErrores(ex);
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public static List<Entidades.Auditoria.AuditoriaInicioSesion> RecuperarRegistrosIngresosEgresos()
        {
            List<Entidades.Auditoria.AuditoriaInicioSesion> ColeccionIngresosEgresos = new List<Entidades.Auditoria.AuditoriaInicioSesion>();
            Utilidades.Conexion conexion = new Utilidades.Conexion();
            conexion.Conectar("Auditoria");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                cmd.CommandText = "sp_ConsultarAuditoriaLogInOut";
                SqlDataReader drIngresosEgresos = cmd.ExecuteReader();
                while (drIngresosEgresos.Read())
                {
                    Entidades.Auditoria.AuditoriaInicioSesion oAudit = new Entidades.Auditoria.AuditoriaInicioSesion();
                    oAudit.Usuario = drIngresosEgresos[0].ToString();
                    switch (drIngresosEgresos[1].ToString())
	                {
		                case "Ingreso": 
                        oAudit.Operacion = Entidades.Auditoria.AuditoriaInicioSesion.TipoLog.Ingreso;
                        break;
                        case "Egreso":
                        oAudit.Operacion = Entidades.Auditoria.AuditoriaInicioSesion.TipoLog.Egreso;
                        break;
                        case "Erroneo":
                        oAudit.Operacion = Entidades.Auditoria.AuditoriaInicioSesion.TipoLog.Erroneo;
                        break;
                        default:
                        break;
	                }
                    oAudit.Equipo = drIngresosEgresos[2].ToString();
                    oAudit.FechaHora = Convert.ToDateTime(drIngresosEgresos[3]);
                    ColeccionIngresosEgresos.Add(oAudit);
                    oAudit = null;
                }
            }
            catch (SqlException ex)
            {
                Utilidades.EventManager.RegistarErrores(ex);
            }
            finally
            {
                conexion.Desconectar();
            }
            return ColeccionIngresosEgresos;
        }
    }
}
