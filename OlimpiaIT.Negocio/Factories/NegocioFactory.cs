using OlimpiaIT.Negocio.Concrete;
using OlimpiaIT.Negocio.Interfaces;

namespace OlimpiaIT.Negocio.Factories
{
    public class NegocioFactory
    {
        public static IInvoiceNegocio CrearInvoiceNegocio()
        {
            return new InvoiceNegocio();
        }
    }
}
