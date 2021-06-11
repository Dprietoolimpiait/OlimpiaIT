using OlimpiaIT.API.Services.Interfaces;
using OlimpiaIT.Entidades.Concrete.Invoice;
using OlimpiaIT.Negocio.Factories;
using OlimpiaIT.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpiaIT.API.Services.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        public decimal CalcularValorFactura(List<Invoice> prmInvoices)
        {
            IInvoiceNegocio invoiceNegocio = NegocioFactory.CrearInvoiceNegocio();
            return invoiceNegocio.CalcularValorFactura(prmInvoices);
        }

        public decimal CalcularValorIva(decimal prmValor, decimal prmIva)
        {
            IInvoiceNegocio invoiceNegocio = NegocioFactory.CrearInvoiceNegocio();
            return invoiceNegocio.CalcularValorIva(prmValor, prmIva);
        }
    }
}
