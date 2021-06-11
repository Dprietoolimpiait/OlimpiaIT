using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OlimpiaIT.Entidades.Concrete.Invoice
{
    [DataContract]
    public class InvoiceRequest
    {
        [DataMember]
        public List<Invoice> Invoices { get; set; }
    }
}
