using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication24.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        
       /* public string DestinationFrom { get; set; }
        
        public string DestinationTo { get; set; }
        
        public string TicketType { get; set; } //Single or Return
        
        public string TicketClass { get; set; } //Economic, Business, First
        
        public string DepartureDato { get; set; }
        
        public string ReturnDato { get; set; }

       
        public int AntallAdult { get; set; }

        public int AntallChild { get; set; }*/

        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string Fornavn { get; set; }

        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string Etternavn { get; set; }

        [RegularExpression(@"[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{2,7}")]
        public string Telfonnr { get; set; }

        [RegularExpression(@"[A-Za-z0-9]{1}[A-Za-z0-9_.-]*@{1}[A-Za-z0-9_.-]{1,}\.[A-Za-z0-9]{1,}")]
        public string Epost { get; set; }

        [RegularExpression(@"[a-zA-ZæøåÆØÅ0-9_]*[a-zA-Z_]?[a-zA-Z\ \.0-9_]{2,50}")]
        public string Adresse { get; set; }

        [RegularExpression(@"[0-9]{4}")]
        public string Postnr { get; set; }

        [RegularExpression(@"[0-9a-zA-ZæøåÆØÅ. \-]{2,50}")]
        public string Poststed { get; set; }
    }
}
