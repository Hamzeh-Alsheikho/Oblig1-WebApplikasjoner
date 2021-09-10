using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication24.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string DestinationFrom { get; set; }
        public string DestinationTo { get; set; }
        public string TicketType { get; set; } //Single or Return
        public string TicketClass { get; set; } //Economic, Business, First
        public string DepartureDato { get; set; }
        public string ReturnDato { get; set; }
        public int AntallAdult { get; set; }
        public int AntallChild { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Telfonnr { get; set; }
        public string Epost { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Poststed { get; set; }
    }
}
