using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;

namespace Mapping.Seguridad
{
    public static class MappingPerfiles
    {
        public delegate void CambiosRealizados();
        public static event CambiosRealizados AlDetectarCambios;

        
        public static List<Entidades.Seguridad.Perfil> RecuperarPerfiles()
        {   
            List<Entidades.Seguridad.Perfil> ColPerfiles = new List<Entidades.Seguridad.Perfil>();
            Servicios.Conexion conexion = new Servicios.Conexion();
            try
            {
                conexion.Conectar("Seguridad");
                SqlCommand cmdGrupos = new SqlCommand();
                cmdGrupos.CommandText = "sp_ConsultarGruposPerfiles";
                cmdGrupos.CommandType = System.Data.CommandType.StoredProcedure;
                cmdGrupos.Connection = conexion.RetornarConexion();
                SqlDataReader drGrupos = cmdGrupos.ExecuteReader();
                while (drGrupos.Read())
                {
                    Entidades.Seguridad.Perfil oPerfil = new Entidades.Seguridad.Perfil();
                    Entidades.Seguridad.Grupo oGrupo = new Entidades.Seguridad.Grupo();
                    oGrupo.Nombre = drGrupos["Id_Grupo"].ToString();
                    oGrupo.Descripcion = drGrupos["Descripcion"].ToString();
                    if (ColPerfiles.Find(perf => perf.Grupo.Nombre == oGrupo.Nombre) == null)
                    {
                        oPerfil.Grupo = oGrupo;
                        //Formularios
                        SqlCommand cmdFormularios = new SqlCommand();
                        cmdFormularios.CommandText = "sp_ConsultarFormulariosGrupo";
                        cmdFormularios.Parameters.Add("@NombreGrupo", System.Data.SqlDbType.VarChar, 20).Value = oGrupo.Nombre;
                        cmdFormularios.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdFormularios.Connection = conexion.RetornarConexion();
                        SqlDataReader drFormularios = cmdFormularios.ExecuteReader();
                        while (drFormularios.Read())
                        {
                            Entidades.Seguridad.Formulario oFormulario = new Entidades.Seguridad.Formulario();
                            oFormulario.Nombre = drFormularios["Id_Formulario"].ToString();
                            oFormulario.Descripcion = drFormularios["Descripcion"].ToString();
                            //Permisos
                            SqlCommand cmdPermisos = new SqlCommand();
                            cmdPermisos.CommandText = "sp_ConsultarPermisosFormulario";
                            cmdPermisos.Parameters.Add("@NombreGrupo", System.Data.SqlDbType.VarChar, 20).Value = oGrupo.Nombre;
                            cmdPermisos.Parameters.Add("@NombreFormulario", System.Data.SqlDbType.VarChar, 50).Value = oFormulario.Nombre;
                            cmdPermisos.CommandType = System.Data.CommandType.StoredProcedure;
                            cmdPermisos.Connection = conexion.RetornarConexion();
                            SqlDataReader drPermisos = cmdPermisos.ExecuteReader();
                            while (drPermisos.Read())
                            {
                                Entidades.Seguridad.Permiso oPermiso = new Entidades.Seguridad.Permiso();
                                oPermiso.Nombre = drPermisos["Id_Permiso"].ToString();
                                oPermiso.Descripcion = drPermisos["Descripcion"].ToString();
                                oFormulario.AgregarPermiso(oPermiso);
                                oPermiso = null;
                            }
                            oPerfil.AgregarFormulario(oFormulario);
                            oFormulario = null;
                        }
                        ColPerfiles.Add(oPerfil);
                    }
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
            return ColPerfiles;
        }


        public static bool AgregarPerfil(Entidades.Seguridad.Perfil perfil)
        {
            bool operacion = false;
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_AgregarPerfil";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.ComenzarTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Parameters.Add("@NombreGrupo", System.Data.SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@NombreFormulario", System.Data.SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@NombrePermiso", System.Data.SqlDbType.VarChar, 15);
                int nroCeldas = 0;        
                foreach (Entidades.Seguridad.Formulario formulario in perfil.Formularios)
                {
                    foreach (Entidades.Seguridad.Permiso permiso in formulario.Permisos)
                    {
                        cmd.Parameters["@NombreGrupo"].Value = perfil.Grupo.Nombre;
                        cmd.Parameters["@NombreFormulario"].Value = formulario.Nombre;
                        cmd.Parameters["@NombrePermiso"].Value = permiso.Nombre;
                        nroCeldas = cmd.ExecuteNonQuery();
                    }
                }
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
        
        public static bool ModificarPerfil(Entidades.Seguridad.Perfil perfil,Entidades.Seguridad.Memento.CaretakerPerfil cuidador)
        {
            List<Entidades.Seguridad.Formulario> FormulariosAgregados = new List<Entidades.Seguridad.Formulario>();
            List<Entidades.Seguridad.Formulario> FormulariosEliminados = new List<Entidades.Seguridad.Formulario>();
            FormulariosAgregados = perfil.Formularios.Except(cuidador.Memento.Formularios).ToList();
            FormulariosEliminados = cuidador.Memento.Formularios.Except(perfil.Formularios).ToList();    
            bool operacion = false;
            try
            {
                EliminarPerfil(perfil.Grupo.Nombre,FormulariosEliminados);
                AgregarPerfil(perfil.Grupo.Nombre,FormulariosAgregados);
                operacion = true;
            }
            catch (SqlException ex)
            {
                Servicios.EventManager.RegistarErrores(ex);
            }
            return operacion;
        }

        private static void AgregarPerfil(string grupo, List<Entidades.Seguridad.Formulario> FormulariosAgregados)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmdAgregar = new SqlCommand();
                cmdAgregar.CommandText = "sp_AgregarPerfil";
                cmdAgregar.Parameters.Add("@NombreGrupo", System.Data.SqlDbType.VarChar, 20).Value = grupo;
                cmdAgregar.Parameters.Add("@NombreFormulario", System.Data.SqlDbType.VarChar, 50);
                cmdAgregar.Parameters.Add("@NombrePermiso", System.Data.SqlDbType.VarChar, 15);
                cmdAgregar.CommandType = System.Data.CommandType.StoredProcedure;
                cmdAgregar.Connection = conexion.RetornarConexion();
                cmdAgregar.Transaction = conexion.RetornarSqlTransaccion();
                foreach (Entidades.Seguridad.Formulario formulario in FormulariosAgregados)
                {
                    foreach (Entidades.Seguridad.Permiso permiso in formulario.Permisos)
                    {
                        cmdAgregar.Parameters["@NombreGrupo"].Value = grupo;
                        cmdAgregar.Parameters["@NombreFormulario"].Value = formulario.Nombre;
                        cmdAgregar.Parameters["@NombrePermiso"].Value = permiso.Nombre;
                        cmdAgregar.ExecuteNonQuery();
                    }
                }
                conexion.RetornarSqlTransaccion().Commit();
            }
            catch (SqlException ex)
            {
                Servicios.EventManager.RegistarErrores(ex);
                conexion.RetornarSqlTransaccion().Rollback();
            }
            finally 
            {
                conexion.Desconectar();
            }
        }

        private static void EliminarPerfil(string grupo, List<Entidades.Seguridad.Formulario> FormulariosEliminados)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_EliminarRegistroPerfil";
                cmd.Parameters.Add("@NombreGrupo", System.Data.SqlDbType.VarChar, 20).Value = grupo;
                cmd.Parameters.Add("@NombreFormulario", System.Data.SqlDbType.VarChar,50);
                cmd.Parameters.Add("@NombrePermiso", System.Data.SqlDbType.VarChar, 15);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                foreach (Entidades.Seguridad.Formulario formulario in FormulariosEliminados)
                {
                    foreach (Entidades.Seguridad.Permiso permiso  in formulario.Permisos)
                    {
                        cmd.Parameters["@NombreGrupo"].Value = grupo;
                        cmd.Parameters["@NombreFormulario"].Value = formulario.Nombre;
                        cmd.Parameters["@NombrePermiso"].Value = permiso.Nombre;
                        cmd.ExecuteNonQuery();
                    }
                }
                conexion.RetornarSqlTransaccion().Commit();
            }
            catch(SqlException ex)
            {
                Servicios.EventManager.RegistarErrores(ex);
                conexion.RetornarSqlTransaccion().Rollback();
            }
            finally
            {
                conexion.Desconectar();
            }
        }
        
        public static bool EliminarPerfil(Entidades.Seguridad.Perfil perfil)
        {
            bool operacion = false;
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Seguridad");
            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_EliminarPerfil";
                cmd.Parameters.Add("@NombreGrupo", System.Data.SqlDbType.VarChar, 20).Value = perfil.Grupo.Nombre;
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
