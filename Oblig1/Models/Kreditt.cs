using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig1.Models
{
    public class Kreditt
    {
        public int Id { get; set; }
        public int KundeId { get; set; }
        public string Kortnummer { get; set; }
        public string KortHolderNavn { get; set; }
        public string KortUtlopsdato { get; set; }
        public string Cvc { get; set; }
    }
}