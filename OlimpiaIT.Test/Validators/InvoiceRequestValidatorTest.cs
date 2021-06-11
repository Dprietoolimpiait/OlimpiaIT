using NUnit.Framework;
using System.Collections.Generic;
using FluentValidation.TestHelper;

namespace OlimpiaIT.Test.Validators
{
    public class InvoiceRequestValidatorTest
    {
        private Entidades.Concrete.Validators.InvoiceRequestValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new Entidades.Concrete.Validators.InvoiceRequestValidator();
        }

        [Test]
        public void Invoice_ValidatorFacturasRepetidas()
        {
            var model = new Entidades.Concrete.Invoice.InvoiceRequest()
            {
                Invoices = new List<Entidades.Concrete.Invoice.Invoice>()
                {
                    new Entidades.Concrete.Invoice.Invoice(){ IdFactura = 1, NIT = 12345, Descripcion = "Factura 1", ValorTotal = 1950, PorcentajeIva = 19 },
                    new Entidades.Concrete.Invoice.Invoice(){ IdFactura = 1, NIT = 54321, Descripcion = "Factura 2", ValorTotal = 1050, PorcentajeIva = 9 },
                    new Entidades.Concrete.Invoice.Invoice(){ IdFactura = 2, NIT = 32789, Descripcion = "Factura 3", ValorTotal = 1000, PorcentajeIva = 16 },
                    new Entidades.Concrete.Invoice.Invoice(){ IdFactura = 2, NIT = 44422, Descripcion = "Factura 4", ValorTotal = 5000, PorcentajeIva = 3 }
                }
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Invoices);
        }
    }
}
