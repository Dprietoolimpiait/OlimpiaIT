using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OlimpiaIT.API.Controllers;
using OlimpiaIT.API.Services.Concrete;
using OlimpiaIT.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiaIT.Test.Invoice
{
    public class InvoiceTest
    {
        InvoiceController _controller;
        IInvoiceService _service;

        public InvoiceTest()
        {
            _service = new InvoiceService();
            _controller = new InvoiceController(_service);
        }

        [Test]
        public async Task CargarFacturas_ReturnOK()
        {
            var result = await _controller.CargarFacturas(new Entidades.Concrete.Invoice.InvoiceRequest()
            {
                Invoices = new List<Entidades.Concrete.Invoice.Invoice>()
                {
                    new Entidades.Concrete.Invoice.Invoice(){ IdFactura = 1, NIT = 12345, Descripcion = "Factura 1", ValorTotal = 1950, PorcentajeIva = 19 },
                    new Entidades.Concrete.Invoice.Invoice(){ IdFactura = 2, NIT = 54321, Descripcion = "Factura 2", ValorTotal = 1050, PorcentajeIva = 9 },
                    new Entidades.Concrete.Invoice.Invoice(){ IdFactura = 3, NIT = 32789, Descripcion = "Factura 3", ValorTotal = 1000, PorcentajeIva = 16 },
                    new Entidades.Concrete.Invoice.Invoice(){ IdFactura = 4, NIT = 44422, Descripcion = "Factura 4", ValorTotal = 5000, PorcentajeIva = 3 }
                }
            });

            var status = result as ObjectResult;

            Assert.AreEqual(200, status.StatusCode);
        }

        [Test]
        public async Task ValidarFactura_ReturnOK()
        {
            var result = await _controller.ValidarFactura(new Entidades.Concrete.Invoice.Invoice(){ IdFactura = 1, NIT = 12345, Descripcion = "Factura 1", ValorTotal = 1000, PorcentajeIva = 19 });

            var status = result as ObjectResult;

            Assert.AreEqual(200, status.StatusCode);
        }

        [Test]
        public async Task Calcular_ReturnOK()
        {
            var result = await _controller.ValidarFactura(new Entidades.Concrete.Invoice.Invoice() { IdFactura = 1, NIT = 12345, Descripcion = "Factura 1", ValorTotal = 1000, PorcentajeIva = 19 });

            var status = result as ObjectResult;

            Assert.AreEqual(200, status.StatusCode);
        }
    }
}
