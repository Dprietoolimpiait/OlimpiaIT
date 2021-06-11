using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OlimpiaIT.Entidades.Concrete.Invoice
{
    [DataContract]
    public class Invoice
    {
        [DataMember]
        public int IdFactura { get; set; }

        [DataMember]
        public int NIT { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public decimal ValorTotal { get; set; }

        [DataMember]
        public int PorcentajeIva { get; set; }
    }
}
