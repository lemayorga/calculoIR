using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace Logica
{
    public class Configuracion  
    {
        private static IConfigurationRoot _config; 
        public static IConfigurationRoot config { get { return _config; } }        
        public static void CargaArchivosConfiguracion()
        {
            string[] archivos_config = { "variables.json" };

            ConfigurationBuilder configuracionBuilder = new ConfigurationBuilder();
            archivos_config.ToList().ForEach(archivo => {
                string ruta_archivo = Path.Combine(Directory.GetCurrentDirectory(), archivo);
                configuracionBuilder.AddJsonFile(ruta_archivo, optional: false, reloadOnChange: true);
            });

            _config = configuracionBuilder.Build();
        }        
    }  
}