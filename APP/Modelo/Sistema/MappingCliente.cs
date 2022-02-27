using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingCliente
    {
        private List<Entidades.Sistema.Cliente> _Lista;
        private List<Entidades.Sistema.Cliente> _ListaActivos;
        private static MappingCliente _Instancia;
        public static MappingCliente ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingCliente();
            return _Instancia;
        }

        private MappingCliente()
        {
            _Lista = new List<Entidades.Sistema.Cliente>();
            _ListaActivos = new List<Entidades.Sistema.Cliente>();
            RecuperarClientes();
            RecuperarClientesActivos();
        }

        public void AgregarCliente(Entidades.Sistema.Cliente Cliente)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_AddCliente";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt).Value = Cliente.Cuit;
                cmd.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar, 100).Value = Cliente.Domicilio;
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 120).Value = Cliente.Email;
                cmd.Parameters.Add("@RazonSocial", System.Data.SqlDbType.NVarChar, 100).Value = Cliente.RazonSocial;
                cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.BigInt).Value = Cliente.Telefono;
                cmd.Parameters.Add("@SituacionFiscal",System.Data.SqlDbType.Int).Value = Cliente.SituacionFiscal.Codigo;
                cmd.Parameters.Add("@Localidad", System.Data.SqlDbType.NVarChar,50).Value = Cliente.Ciudad.Nombre;
                cmd.Parameters.Add("@Provincia", System.Data.SqlDbType.NVarChar,50).Value = Cliente.Ciudad.Provincia.Nombre;
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

        public void ModificarCliente(Entidades.Sistema.Cliente Cliente)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_ModCliente";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Codigo", System.Data.SqlDbType.BigInt).Value = Cliente.Codigo;
                cmd.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt).Value = Cliente.Cuit;
                cmd.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar, 100).Value = Cliente.Domicilio;
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 120).Value = Cliente.Email;
                cmd.Parameters.Add("@RazonSocial", System.Data.SqlDbType.NVarChar, 100).Value = Cliente.RazonSocial;
                cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.BigInt).Value = Cliente.Telefono;
                cmd.Parameters.Add("@SituacionFiscal", System.Data.SqlDbType.Int).Value = Cliente.SituacionFiscal.Codigo;
                cmd.Parameters.Add("@Localidad", System.Data.SqlDbType.NVarChar, 50).Value = Cliente.Ciudad.Nombre;
                cmd.Parameters.Add("@Provincia", System.Data.SqlDbType.NVarChar, 50).Value = Cliente.Ciudad.Provincia.Nombre;
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

        public void EliminarCliente(Entidades.Sistema.Cliente Cliente)
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ComenzarTransaccion();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.Transaction = Conexion.RetornarSqlTransaccion();
                cmd.CommandText = "SP_RemoveCliente";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Codigo", System.Data.SqlDbType.BigInt).Value = Cliente.Codigo;
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

        public List<Entidades.Sistema.Cliente> ListarClientes()
        {
            return _Lista;
        }
        private void RecuperarClientes()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListClientes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.Cliente Cliente = new Entidades.Sistema.Cliente();
                    Cliente.Cuit = Convert.ToInt64(dr["Cuit"]);
                    Cliente.Domicilio = dr["Direccion"].ToString();
                    Cliente.Email = dr["Email"].ToString();
                    Cliente.RazonSocial = dr["RazonSocial"].ToString();
                    Cliente.Telefono = Convert.ToInt64(dr["Telefono"]);
                    Cliente.Codigo = Convert.ToInt32(dr["id_Cliente"]);
                    
                    string ciudad = dr["NombreLocalidad"].ToString();
                    string provincia = dr["NombreProvincia"].ToString();

                    Entidades.Sistema.Provincia prov = MappingProvincia.ObtenerInstancia().ListarProvincias().Find(x=>x.Nombre == provincia);
                    Cliente.Ciudad = prov.Ciudades.Find(x => x.Nombre == ciudad);
             
                    _Lista.Add(Cliente);
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

        public List<Entidades.Sistema.Cliente> ListarClientesActivos()
        {
            return _ListaActivos;
        }
        private void RecuperarClientesActivos()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListClientesActivos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.Cliente Cliente = new Entidades.Sistema.Cliente();
                    Cliente.Cuit = Convert.ToInt64(dr["Cuit"]);
                    Cliente.Domicilio = dr["Direccion"].ToString();
                    Cliente.Email = dr["Email"].ToString();
                    Cliente.RazonSocial = dr["RazonSocial"].ToString();
                    Cliente.Telefono = Convert.ToInt64(dr["Telefono"]);
                    Cliente.Codigo = Convert.ToInt32(dr["id_Cliente"]);

                    Entidades.Sistema.SituacionFiscal oSituacionFiscal = MappingSituacionFiscal.ObtenerInstancia().ListarSituacionesFiscales().Find(x => x.Codigo == Convert.ToInt32(dr["SituacionFiscal"]));
                    Cliente.SituacionFiscal = oSituacionFiscal;

                    string ciudad = dr["NombreLocalidad"].ToString();
                    string provincia = dr["NombreProvincia"].ToString();

                    Entidades.Sistema.Provincia prov = MappingProvincia.ObtenerInstancia().ListarProvincias().Find(x => x.Nombre == provincia);
                    Cliente.Ciudad = prov.Ciudades.Find(x => x.Nombre == ciudad);

                    _ListaActivos.Add(Cliente);
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
