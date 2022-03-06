using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace Mapping.Seguridad
{
    public static class MappingUsuarios
    {
        public delegate void CambiosRealizados();
        public static event CambiosRealizados AlDetectarCambios;
        

        public static List<Entidades.Seguridad.Usuario> RecuperarUsuarios()
        {
            List<Entidades.Seguridad.Usuario> ColUsuarios = new List<Entidades.Seguridad.Usuario>();
            Utilidades.Conexion conexion = new Utilidades.Conexion();
            try
            {
                SqlCommand cmd = new SqlCommand();
                conexion.Conectar("Seguridad");
                cmd.CommandText = "sp_ConsultarUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                SqlDataReader drUsuarios = cmd.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Entidades.Seguridad.Usuario oUsuario = new Entidades.Seguridad.Usuario();
                    oUsuario.NombreUsuario = drUsuarios[0].ToString();
                    oUsuario.NombreApellido = drUsuarios[1].ToString();
                    byte[] clave = (byte[])drUsuarios[2];
                    
                    oUsuario.CambiarClave(null, Encoding.ASCII.GetString(clave));
                    oUsuario.Email = drUsuarios[3].ToString();
                    oUsuario.Habilitado = Convert.ToBoolean(drUsuarios[4]);
                    oUsuario.Activo = Convert.ToBoolean(drUsuarios[5]);
                    SqlCommand cmdGrupos = new SqlCommand();
                    cmdGrupos.CommandText = "sp_ConsultarGruposUsuario";
                    cmdGrupos.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdGrupos.Connection = conexion.RetornarConexion();
                    cmdGrupos.Parameters.Add("@Usuario", System.Data.SqlDbType.VarChar, 15);
                    cmdGrupos.Parameters["@Usuario"].Value = oUsuario.NombreUsuario;
                    SqlDataReader drGrupos = cmdGrupos.ExecuteReader();
                    while (drGrupos.Read())
                    {
                        Entidades.Seguridad.Grupo oGrupo = new Entidades.Seguridad.Grupo();
                        oGrupo.Nombre = drGrupos[0].ToString();
                        oGrupo.Descripcion = drGrupos[1].ToString();
                        oUsuario.AgregarGrupo(oGrupo);
                        oGrupo = null;
                    }
                    ColUsuarios.Add(oUsuario);
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
            return ColUsuarios;
        }

        
        public static bool AgregarUsuario(Entidades.Seguridad.Usuario usuario)
        {
            bool operacion = false;
            Utilidades.Conexion conexion = new Utilidades.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_AgregarUsuario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Parameters.Add("@NombreUsuario", System.Data.SqlDbType.VarChar, 15).Value = usuario.NombreUsuario;
                cmd.Parameters.Add("@NombreApellido", System.Data.SqlDbType.VarChar, 40).Value = usuario.NombreApellido;
                cmd.Parameters.Add("@Clave", System.Data.SqlDbType.Binary).Value = Encoding.ASCII.GetBytes(usuario.Clave);
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 150).Value = usuario.Email;
                cmd.Parameters.Add("@Habilitado", System.Data.SqlDbType.Bit, 15).Value = usuario.Habilitado;
                cmd.Parameters.Add("@Activo", System.Data.SqlDbType.Bit, 15).Value = usuario.Activo;
                if (cmd.ExecuteNonQuery() >= 1) operacion = true;
                else operacion = false;
                conexion.RetornarSqlTransaccion().Commit();
            }
            catch (SqlException ex)
            {
                conexion.RetornarSqlTransaccion().Rollback();
                Utilidades.EventManager.RegistarErrores(ex);
            }
            finally
            {
                conexion.Desconectar();
            }
            return operacion;
        }
        
        public static bool ModificarUsuario(Entidades.Seguridad.Usuario usuario)
        {
            bool operacion = false;
            Utilidades.Conexion conexion = new Utilidades.Conexion();
            conexion.Conectar("Seguridad");
            try
            {   
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                if (usuario.CambioContraseña == true)
                {
                    cmd.CommandText = "sp_ModificarUsuario";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = conexion.RetornarConexion();
                    cmd.Transaction = conexion.RetornarSqlTransaccion();
                    cmd.Parameters.Add("@NombreUsuario", System.Data.SqlDbType.VarChar, 15).Value = usuario.NombreUsuario;
                    cmd.Parameters.Add("@NombreApellido", System.Data.SqlDbType.VarChar, 40).Value = usuario.NombreApellido;
                    cmd.Parameters.Add("@Clave", System.Data.SqlDbType.Binary).Value = Encoding.ASCII.GetBytes(usuario.Clave);
                    cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 150).Value = usuario.Email;
                    cmd.Parameters.Add("@Habilitado", System.Data.SqlDbType.Bit, 15).Value = usuario.Habilitado;
                    cmd.Parameters.Add("@Activo", System.Data.SqlDbType.Bit, 15).Value = usuario.Activo;
                }
                else
                {
                    cmd.CommandText = "SP_ModificarUsuariosSinContraseña";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = conexion.RetornarConexion();
                    cmd.Transaction = conexion.RetornarSqlTransaccion();
                    cmd.Parameters.Add("@NombreUsuario", System.Data.SqlDbType.VarChar, 15).Value = usuario.NombreUsuario;
                    cmd.Parameters.Add("@NombreApellido", System.Data.SqlDbType.VarChar, 40).Value = usuario.NombreApellido;
                    cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 150).Value = usuario.Email;
                    cmd.Parameters.Add("@Habilitado", System.Data.SqlDbType.Bit, 15).Value = usuario.Habilitado;
                    cmd.Parameters.Add("@Activo", System.Data.SqlDbType.Bit, 15).Value = usuario.Activo;
                }

                var exec = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() >= 1) operacion = true;
                else operacion = false;
                conexion.RetornarSqlTransaccion().Commit();
            }
            catch (SqlException ex)
            {
                Utilidades.EventManager.RegistarErrores(ex);
                conexion.RetornarSqlTransaccion().Rollback();
            }
            finally
            {
                conexion.Desconectar();
            }
            return operacion;
        }
        
        public static bool EliminarUsuario(Entidades.Seguridad.Usuario usuario)
        {
            bool operacion = false;
            Utilidades.Conexion conexion = new Utilidades.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_EliminarUsuario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Parameters.Add("@NombreUsuario", System.Data.SqlDbType.VarChar, 15).Value = usuario.NombreUsuario;
                if (cmd.ExecuteNonQuery() >= 1) operacion = true;
                else operacion = false;
                conexion.RetornarSqlTransaccion().Commit();
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
            return operacion;
        }
        
        public static bool ActualizarGrupos(Entidades.Seguridad.Usuario usuario, Entidades.Seguridad.Memento.CaretakerUsuario cuidador)
        {
            bool operacion = false;
            Utilidades.Conexion conexion = new Utilidades.Conexion();
            try
            {
                List<Entidades.Seguridad.Grupo> gruposAgregados = usuario.Grupos.Except(cuidador.Memento.Grupos).ToList();
                List<Entidades.Seguridad.Grupo> gruposEliminados = cuidador.Memento.Grupos.Except(usuario.Grupos).ToList();
                if (gruposAgregados.Count != 0 || gruposEliminados.Count != 0)
                {
                    SqlCommand cmdActualizarGrupos = new SqlCommand();
                    conexion.Conectar("Seguridad");
                    conexion.ComenzarTransaccion();
                    cmdActualizarGrupos.CommandText = "sp_EliminarGruposUsuario";
                    cmdActualizarGrupos.Connection = conexion.RetornarConexion();
                    cmdActualizarGrupos.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdActualizarGrupos.Transaction = conexion.RetornarSqlTransaccion();
                    cmdActualizarGrupos.Parameters.Add("@NombreUsuario", System.Data.SqlDbType.VarChar, 15).Value = usuario.NombreUsuario;
                    cmdActualizarGrupos.Parameters.Add("@NombreGrupo", System.Data.SqlDbType.VarChar, 20);
                    foreach (Entidades.Seguridad.Grupo grupo in gruposEliminados)
                    {
                        cmdActualizarGrupos.Parameters["@NombreGrupo"].Value = grupo.Nombre;
                        cmdActualizarGrupos.ExecuteNonQuery();
                    }
                    cmdActualizarGrupos.CommandText = "sp_AgregarGruposUsuario";
                    foreach (Entidades.Seguridad.Grupo grupo in gruposAgregados)
                    {
                        cmdActualizarGrupos.Parameters["@NombreGrupo"].Value = grupo.Nombre;
                        cmdActualizarGrupos.ExecuteNonQuery();
                    }
                    conexion.RetornarSqlTransaccion().Commit();
                    operacion = true;
                }
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
            return operacion;
        }

    }
}
