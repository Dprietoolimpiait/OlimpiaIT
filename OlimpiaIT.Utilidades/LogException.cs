using OlimpiaIT.Entidades.Concrete.Enum;
using OlimpiaIT.Utilidades;
using System;
using System.IO;

namespace OlimpiaIT.Exceptions
{
    public class LogException
    {
        /// <summary>
        /// Manejo de excepciones, guarda en un archivo plano configurado en el archivo de configuracion
        /// </summary>
        /// <param name="ex">Excepcion</param>
        /// <param name="source">Donde fue la excepcion</param>
        /// <param name="data">Datos enviados</param>
        /// <param name="type">Tipo de log</param>
        public static void WriteLog(Exception ex, string source, string data, TipoLog type)
        {
            var basepath = Convert.ToString(Configuration.GetLogRoute);

            string anioPath = Path.Combine(basepath, DateTime.Now.Year.ToString());

            string mesPath = Path.Combine(anioPath, DateTime.Now.Month.ToString());

            if (!Directory.Exists(mesPath))
                Directory.CreateDirectory(mesPath);

            var finalpath = Path.Combine(mesPath, String.Concat(DateTime.Now.ToString("dd"), "- Log - SIR.txt"));

            using (StreamWriter file = new StreamWriter(finalpath, true))
            {
                file.WriteLine("-----------------------------------------------------------");
                if (ex == null)
                {
                    file.WriteLine($"Tipo: {type}");
                    file.WriteLine($"Mensaje: {data}");
                    file.WriteLine($"Source: {source}");
                }
                else
                {

                    file.WriteLine($"Tipo: {type}");
                    file.WriteLine($"Hora: {DateTime.Now}");
                    file.WriteLine($"Source: {source}");
                    file.WriteLine($"Data: {data}");
                    file.WriteLine($"Error: {ex.Message}");
                    file.WriteLine($"StackTrace: {ex.StackTrace}");
                    file.WriteLine($"Inner exceptions: ");
                    var inner = ex.InnerException;

                    while (inner != null)
                    {
                        file.WriteLine($"-- Message: {inner.Message}");
                        file.WriteLine($"-- StackTrace: {inner.StackTrace}");

                        inner = inner.InnerException;
                    }
                }

                file.WriteLine("-----------------------------------------------------------");
            }
        }
    }
}
