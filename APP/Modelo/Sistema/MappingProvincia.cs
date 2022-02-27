using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapping.Sistema
{
    public class MappingProvincia
    {
        private List<Entidades.Sistema.Provincia> _Lista;
        private static MappingProvincia _Instancia;
        public static MappingProvincia ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new MappingProvincia();
            return _Instancia;
        }

        private MappingProvincia()
        {
            _Lista = new List<Entidades.Sistema.Provincia>();
            RecuperarProvincias();
        }

        public List<Entidades.Sistema.Provincia> ListarProvincias()
        {
            return _Lista;
        }
        private void RecuperarProvincias()
        {
            Utilidades.Conexion Conexion = new Utilidades.Conexion();
            Conexion.Conectar("Sistema");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.RetornarConexion();
                cmd.CommandText = "SP_ListProvincias";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entidades.Sistema.Provincia Provincia = new Entidades.Sistema.Provincia();
                    int codigo = Convert.ToInt32(dr["id_provincia"]);
                    Provincia.Nombre = dr["NombreProvincia"].ToString();
                    SqlCommand cmdloc = new SqlCommand();
                    cmdloc.Connection = Conexion.RetornarConexion();
                    cmdloc.CommandText = "sp_ListLocalidadesProvincias";
                    cmdloc.Parameters.Add("@id_Provincia", System.Data.SqlDbType.Int).Value = codigo;
                    cmdloc.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader drloc = cmdloc.ExecuteReader();
                    while (drloc.Read())
                    {
                        Entidades.Sistema.Ciudad ciudad = new Entidades.Sistema.Ciudad();
                        ciudad.Nombre = drloc["NombreLocalidad"].ToString();
                        Provincia.Agregar(ciudad);
                    }
                    _Lista.Add(Provincia);
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
