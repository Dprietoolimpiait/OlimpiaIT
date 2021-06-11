using Microsoft.AspNetCore.Mvc;
using OlimpiaIT.API.Controllers.Base;
using OlimpiaIT.API.Security;
using OlimpiaIT.API.Services.Interfaces;
using OlimpiaIT.Entidades.Concrete.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpiaIT.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : BaseController
    {
        private ISecurityService _service;

        public SecurityController(ISecurityService service)
        {
            _service = service;
        }

        /// <summary>
        /// Metodo encargado de validar el acceso al servicio
        /// </summary>
        /// <param name="login">Usuario y contraseña</param>
        /// <returns>Token para funcionalidades</returns>
        /// <response code="200">Consulta de forma exitosa</response>
        /// <response code="500">Ha ocurrido un error</response>
        /// <response code="400">Error en la información enviada</response>
        /// <response code="401">No autorizado</response>
        [HttpPost]
        public async Task<IActionResult> Login(Login prmLogin)
        {
            Guid idUsuario = _service.ValidarUsuario(prmLogin.Username, prmLogin.Password);

            if (idUsuario != default(Guid))
            {
                var token = JWTManager.GenerateTokenJWT(idUsuario, prmLogin.Username);

                return Ok(token);
            }
            else
                return Unauthorized();
        }
    }
}
