using FluentValidation;
using OlimpiaIT.Entidades.Abstract;
using OlimpiaIT.Entidades.Concrete;
using OlimpiaIT.Entidades.Concrete.Invoice;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlimpiaIT.Entidades.Concrete.Validators
{
    public class InvoiceValidator : ValidatorBase<OlimpiaIT.Entidades.Concrete.Invoice.Invoice>
    {
        public InvoiceValidator()
        {
            this.RuleFor(x => x.IdFactura).GreaterThan(0).WithMessage(Mensajes.IdFacturaMayorCero);
            this.RuleFor(x => x.ValorTotal).GreaterThan(0).WithMessage(Mensajes.ValorTotalMayorCero);
            this.RuleFor(x => x.NIT).GreaterThan(0).WithMessage(Mensajes.NITPositivo);
            this.RuleFor(x => x.PorcentajeIva).Must(ValidarPorcentaje).WithMessage(Mensajes.ValorPorcentajeIVA);
        }

        protected bool ValidarPorcentaje(int porcentaje) 
        {
            return porcentaje >= 0 && porcentaje <= 100;
        }
    }
}
