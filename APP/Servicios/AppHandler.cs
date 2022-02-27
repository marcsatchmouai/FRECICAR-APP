using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Utilidades
{   /// <remarks>Clase para controlar el App.Config</remarks>
    public static class AppHandler
    {
        public static string ObtenerStringDeAppConfig(string valor)
        {
           return ConfigurationManager.AppSettings.GetValues(valor).First();
        }
        public static void GuardarValorDeAppConfig(string key, string value)
        {
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch(ConfigurationErrorsException ex)
            {
                Utilidades.EventManager.RegistarErrores(ex);
            }
        }
    }
}
