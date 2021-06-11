using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OlimpiaIT.Entidades.Concrete.Response
{
    public class ActionResultResponse<T>
    {
        #region Private properties
        private HttpStatusCode status;
        private string message;
        private T response;
        #endregion

        #region Public properties
        public HttpStatusCode Status { get { return status; } }
        public string Message { get { return message; } }
        public T Response { get { return response; } }
        #endregion

        #region Constructor
        public ActionResultResponse(HttpStatusCode prmStatus, string prmMessage, T prmResponse)
        {
            this.status = prmStatus;
            this.message = prmMessage;
            this.response = prmResponse;
        }
        #endregion
    }
}
