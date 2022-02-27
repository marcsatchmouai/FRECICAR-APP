using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class EncriptacionAplicacion : EstrategiaEncriptacion
    {
        public enum AppConfigSection { AppSettings, ConnectionStrings}
        private AppConfigSection _seccion;
        private ConfigurationSection _seccionConfiguracion;
        public EncriptacionAplicacion(AppConfigSection seccion)
        {
            _seccion = seccion;
        }

        public override void Desencriptar()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            switch (_seccion)
            {
                case AppConfigSection.AppSettings:
                    _seccionConfiguracion = config.AppSettings;
                    break;
                case AppConfigSection.ConnectionStrings:
                    _seccionConfiguracion = config.ConnectionStrings;
                    break;
            }
            _seccionConfiguracion.SectionInformation.UnprotectSection();
            _seccionConfiguracion.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);
        }

        public override string Desencriptar(string encryptedPassword)
        {
            throw new InvalidOperationException("Este metodo solo puede ejecutarse cuando la estrategia es EncriptacionAplicacion");
        }

        public override void Encriptar()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            switch (_seccion)
            {
                case AppConfigSection.AppSettings:
                    _seccionConfiguracion = config.AppSettings;
                    break;
                case AppConfigSection.ConnectionStrings:
                    _seccionConfiguracion = config.ConnectionStrings;
                    break;
            }
            _seccionConfiguracion.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            _seccionConfiguracion.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);
        }

        public override string Encriptar(string unEncryptedPassword)
        {
            throw new InvalidOperationException("Este metodo solo puede ejecutarse cuando la estrategia es EncriptacionAplicacion");
        }
    }
}
