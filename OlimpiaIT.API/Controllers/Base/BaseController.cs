using Microsoft.AspNetCore.Mvc;
using OlimpiaIT.Entidades.Abstract;
using OlimpiaIT.Entidades.Concrete.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpiaIT.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public IActionResult GetResponse<T>(ActionResultResponse<T> prmModel) where T : AbstractResponse
        {
            IActionResult actionResult = null;

            switch (prmModel.Status)
            {
                case System.Net.HttpStatusCode.OK:
                    actionResult = this.Ok(prmModel.Response);
                    break;
                case System.Net.HttpStatusCode.BadRequest:
                    actionResult = this.BadRequest(prmModel.Response);
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    actionResult = this.Unauthorized();
                    break;
                default:
                    actionResult = this.Problem(prmModel.Message);
                    break;
            }

            return actionResult;
        }
    }
}
