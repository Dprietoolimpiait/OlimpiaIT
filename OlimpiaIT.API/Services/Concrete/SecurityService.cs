using OlimpiaIT.API.Services.Interfaces;
using OlimpiaIT.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpiaIT.API.Services.Concrete
{
    public class SecurityService : ISecurityService
    {
        public Guid ValidarUsuario(string prmUsername, string prmPassword) 
        {
            Guid idUsuario = Guid.Empty;

            if (prmUsername == Configuration.GetUserNameAPI && prmPassword == Configuration.GetPasswordAPI)
                idUsuario = Guid.NewGuid();

            return idUsuario;
        }
    }
}
