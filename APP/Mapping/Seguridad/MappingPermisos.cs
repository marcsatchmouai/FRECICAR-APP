using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mapping.Seguridad
{
    public static class MappingPermisos
    {
        public static List<Entidades.Seguridad.Permiso> RecuperarPermisos()
        {
            List<Entidades.Seguridad.Permiso> ColPermisos = new List<Entidades.Seguridad.Permiso>();
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_ConsultarPermisos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                SqlDataReader drPermisos = cmd.ExecuteReader();
                while (drPermisos.Read())
                {
                    Entidades.Seguridad.Permiso oPermiso = new Entidades.Seguridad.Permiso();
                    oPermiso.Nombre = drPermisos["Id_Permiso"].ToString();
                    oPermiso.Descripcion= drPermisos["Descripcion"].ToString();
                    ColPermisos.Add(oPermiso);
                    oPermiso = null;
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
            return ColPermisos;
        }
    }
}
