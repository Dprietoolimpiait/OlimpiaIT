﻿using Microsoft.Extensions.Configuration;

namespace OlimpiaIT.Utilidades
{
    public class Configuration
    {
        /// <summary>
        /// Obtiene el valor de un item en el archivo de configuración
        /// </summary>
        /// <param name="prmSection">Seccion de la configuracion</param>
        /// <param name="prmSubSection">Subseccion de la configuracion</param>
        /// <returns></returns>
        public static string GetSectionConfiguration(string prmSection, string prmSubSection)
        {
            string result = "";

            var seccion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection(prmSection);

            if (!string.IsNullOrEmpty(prmSubSection))
            {
                seccion = seccion.GetSection(prmSubSection);
            }

            result = seccion.Value;
            return result;
        }

        /// <summary>
        /// Obtiene la ruta del log en el archivo de configuracion
        /// </summary>
        public static string GetLogRoute => GetSectionConfiguration("FileRoutes", "LogException");

        /// <summary>
        /// Obtiene el usuario de acceso a el API
        /// </summary>
        public static string GetUserNameAPI => GetSectionConfiguration("Jwt", "Username");

        /// <summary>
        /// Obtiene el password de acceso a el API
        /// </summary>
        public static string GetPasswordAPI => GetSectionConfiguration("Jwt", "Password");
    }
}
