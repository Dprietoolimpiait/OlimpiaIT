using OlimpiaIT.Entidades.Concrete.Invoice;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlimpiaIT.Negocio.Interfaces
{
    public interface IInvoiceNegocio
    {
        decimal CalcularValorFactura(List<Invoice> prmInvoices);
        decimal CalcularValorIva(decimal prmValor, decimal prmIva);
    }
}
