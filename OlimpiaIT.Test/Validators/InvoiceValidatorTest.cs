using FluentValidation.TestHelper;
using NUnit.Framework;

namespace OlimpiaIT.Test.Validators
{
    public class InvoiceValidatorTest
    {
        private Entidades.Concrete.Validators.InvoiceValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new Entidades.Concrete.Validators.InvoiceValidator();
        }

        [Test]
        public void Invoice_ValidatorIdFacturaZero()
        {
            var model = new Entidades.Concrete.Invoice.Invoice()
            {
                IdFactura = 0,
                NIT = 12345,
                Descripcion = "Factura 1",
                ValorTotal = 1950,
                PorcentajeIva = 19
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.IdFactura);
        }

        [Test]
        public void Invoice_ValidatorNitNegativo()
        {
            var model = new Entidades.Concrete.Invoice.Invoice()
            {
                IdFactura = 1,
                NIT = 0,
                Descripcion = "Factura 1",
                ValorTotal = 1950,
                PorcentajeIva = 19
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.NIT);
        }

        [Test]
        public void Invoice_ValidatorValorTotalNegativo()
        {
            var model = new Entidades.Concrete.Invoice.Invoice()
            {
                IdFactura = 1,
                NIT = 12321,
                Descripcion = "Factura 1",
                ValorTotal = -1,
                PorcentajeIva = 19
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.ValorTotal);
        }

        [Test]
        public void Invoice_ValidatorPorcentajeIvaNegativo()
        {
            var model = new Entidades.Concrete.Invoice.Invoice()
            {
                IdFactura = 1,
                NIT = 12321,
                Descripcion = "Factura 1",
                ValorTotal = 100,
                PorcentajeIva = -1
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PorcentajeIva);
        }
    }
}
