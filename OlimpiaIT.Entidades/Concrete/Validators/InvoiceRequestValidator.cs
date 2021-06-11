using FluentValidation;
using OlimpiaIT.Entidades.Abstract;
using OlimpiaIT.Entidades.Concrete.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlimpiaIT.Entidades.Concrete.Validators
{
    public class InvoiceRequestValidator : ValidatorBase<InvoiceRequest>
    {
        public InvoiceRequestValidator()
        {
            this.RuleForEach(x => x.Invoices).SetValidator(new InvoiceValidator());
            this.RuleFor(x => x.Invoices).Must(ValidarFacturasRepetidas).WithMessage(Mensajes.FacturasRepetidas);
        }

        public bool ValidarFacturasRepetidas(List<Invoice.Invoice> invoices) 
        {
            return !invoices.GroupBy(x => x.IdFactura).Any(x => x.Count() > 1);
        }
    }
}
