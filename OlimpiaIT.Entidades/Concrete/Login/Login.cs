using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OlimpiaIT.Entidades.Concrete.Login
{
    [DataContract]
    public class Login
    {
        /// <summary>
        /// Usuario
        /// </summary>
        [DataMember]
        public string Username { get; set; }
        /// <summary>
        /// Contraseña
        /// </summary>
        [DataMember]
        public string Password { get; set; }
    }
}
