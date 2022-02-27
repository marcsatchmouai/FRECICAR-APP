using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
[assembly: CLSCompliant(true)]
namespace Utilidades
{
    public class Conexion
    {
        private  SqlConnection _Conexion;
        private  SqlTransaction _Transaccion;

        public string ObtenerConnectionString(string valor)
        {
            string conexion = null;
            foreach (System.Configuration.ConnectionStringSettings item in ConfigurationManager.ConnectionStrings)
            {
                
                
                    if (item.Name == valor)
                    {
                        conexion = item.ConnectionString;
                        break;
                    }
                
            }
            
            return conexion;
        }

        
        public Conexion()
        {
            _Conexion = new SqlConnection();
        }

        public void Conectar(string conexion)
        {
            foreach (System.Configuration.ConnectionStringSettings item in ConfigurationManager.ConnectionStrings)
	        {
                if (item.Name == conexion)
                {
                        _Conexion.ConnectionString = item.ConnectionString;
                        if (_Conexion.State == System.Data.ConnectionState.Closed)
                        {
                            _Conexion.Open();
                        }
                        break;
                    
                }
	        }
        }
        public void Desconectar()
        {
            _Conexion.Close();
        }
        
        public SqlConnection RetornarConexion()
        {
            return _Conexion;
        }
        public void ComenzarTransaccion()
        {
            _Transaccion = _Conexion.BeginTransaction();
        }
        public SqlTransaction RetornarSqlTransaccion()
        {
            return _Transaccion;
        }
    }
}
