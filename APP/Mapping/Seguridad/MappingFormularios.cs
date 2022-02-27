using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mapping.Seguridad
{
    public static class MappingFormularios
    {
        public static List<Entidades.Seguridad.Formulario> RecuperarFormularios()
        {
            List<Entidades.Seguridad.Formulario> ColFormularios = new List<Entidades.Seguridad.Formulario>();
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_ConsultarFormularios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                SqlDataReader drFormularios = cmd.ExecuteReader();
                while (drFormularios.Read())
                {
                    Entidades.Seguridad.Formulario oFormulario = new Entidades.Seguridad.Formulario();
                    oFormulario.Nombre = drFormularios["Id_Formulario"].ToString();
                    oFormulario.Descripcion = drFormularios["Descripcion"].ToString();
                    ColFormularios.Add(oFormulario);
                    oFormulario = null;
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
            return ColFormularios;
        }
    }
}
