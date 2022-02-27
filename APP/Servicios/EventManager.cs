using System;
using System.Diagnostics;
using System.Data.SqlClient;
namespace Utilidades
{
    public static class EventManager
    {
       public static void RegistarErrores(Exception ex)
       {
           string encabezado = "La aplicación finalizó abruptamente, el detalle de error se describe a continuación: ";
           ex.HelpLink = "Para más ayuda o soporte, ingrese al siguiente website: http://develop.cetcom.com.ar/support";
           string sSource = "";
           Type tipo = ex.GetType();
           
           if (tipo.Name == "SqlException")
           {
               SqlException error =(SqlException)ex;
               short a = 10;
               EventLog.WriteEntry(sSource, encabezado + tipo.Name+ " :" + ex.Message + ex.HelpLink , EventLogEntryType.Error, a);
                              
           }
           if (tipo.Name == "ArgumentException")
           {
               ArgumentException error = (ArgumentException)ex;
               
           }
           
        }
    }
}
