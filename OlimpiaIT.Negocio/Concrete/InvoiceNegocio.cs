using OlimpiaIT.Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OlimpiaIT.Negocio.Concrete
{
    public class InvoiceNegocio : IInvoiceNegocio
    {
        public decimal CalcularValorFactura(List<Entidades.Concrete.Invoice.Invoice> prmInvoices)
        {
            return prmInvoices.Sum(x => x.ValorTotal);
        }

        public decimal CalcularValorIva(decimal prmValor, decimal prmIva) 
        {
            return prmValor * (prmIva / 100);
        }
    }
}
