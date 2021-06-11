using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlimpiaIT.API.Controllers.Base;
using OlimpiaIT.API.Services.Interfaces;
using OlimpiaIT.Entidades.Concrete.Enum;
using OlimpiaIT.Entidades.Concrete.Invoice;
using OlimpiaIT.Entidades.Concrete.Response;
using OlimpiaIT.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OlimpiaIT.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        /// <summary>
        /// Metodo encargado de cargar la lista de facturas y validarla
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public async Task<IActionResult> CargarFacturas([FromBody] InvoiceRequest prmInvoices)
        {
            ActionResultResponse<FacturasResponse> response = null;

            try
            {
                var result = _service.CalcularValorFactura(prmInvoices.Invoices);
                response = new ActionResultResponse<FacturasResponse>(System.Net.HttpStatusCode.OK, "OK", new FacturasResponse() { Valor = result });
            }
            catch (Exception ex)
            {
                LogException.WriteLog(ex, "InvoiceController.CargarFacturas", JsonSerializer.Serialize(prmInvoices), TipoLog.Error);
                response = new ActionResultResponse<FacturasResponse>(System.Net.HttpStatusCode.InternalServerError, "Ha ocurrido un error en el aplicativo", null);
            }

            return this.GetResponse(response);
        }

        /// <summary>
        /// Metodo encargado de validar una factura
        /// </summary>
        /// <param name="prmInvoice">Factura</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public async Task<IActionResult> ValidarFactura([FromBody] Invoice prmInvoice)
        {
            return Ok("Factura validad correctamente");
        }

        /// <summary>
        /// Metodo encargado de calcular el iva de la factura
        /// </summary>
        /// <param name="prmInvoice"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CalcularIvaFactura([FromBody] Invoice prmInvoice)
        {
            ActionResultResponse<FacturasResponse> response = null;

            try
            {
                var result = _service.CalcularValorIva(prmInvoice.ValorTotal, prmInvoice.PorcentajeIva);
                response = new ActionResultResponse<FacturasResponse>(System.Net.HttpStatusCode.OK, "OK", new FacturasResponse() { Valor = result });
            }
            catch (Exception ex)
            {
                LogException.WriteLog(ex, "InvoiceController.CalcularIvaFactura", JsonSerializer.Serialize(prmInvoice), TipoLog.Error);
                response = new ActionResultResponse<FacturasResponse>(System.Net.HttpStatusCode.InternalServerError, "Ha ocurrido un error en el aplicativo", null);
            }

            return this.GetResponse(response);
        }
    }
}
