using OlimpiaIT.Entidades.Concrete.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpiaIT.API.Services.Interfaces
{
    public interface IInvoiceService
    {
        decimal CalcularValorFactura(List<Invoice> prmInvoices);
        decimal CalcularValorIva(decimal prmValor, decimal prmIva);
    }
}
