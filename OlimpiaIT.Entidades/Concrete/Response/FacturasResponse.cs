using OlimpiaIT.Entidades.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlimpiaIT.Entidades.Concrete.Response
{
    public class FacturasResponse : AbstractResponse
    {
        public decimal Valor { get; set; }
    }
}
