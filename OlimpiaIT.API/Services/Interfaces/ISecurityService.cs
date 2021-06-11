using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpiaIT.API.Services.Interfaces
{
    public interface ISecurityService
    {
        Guid ValidarUsuario(string prmUsername, string prmPassword);
    }
}
