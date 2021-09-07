using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication24.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Reisemål { get; set; }
        public string TurRetur { get; set; }
        public int Antall { get; set; }
        public string Dato { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Telfonnr { get; set; }
        public string Epost { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Poststed { get; set; }
    }
}
