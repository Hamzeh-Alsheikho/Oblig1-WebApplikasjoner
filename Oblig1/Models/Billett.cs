﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig1.Models
{
    public class Billett
    {
        public int Id { get; set; }
        public int KundeId { get; set; }
        public string DestinationFrom { get; set; }

        public string DestinationTo { get; set; }

        public string TicketType { get; set; } //Single or Return

        public string TicketClass { get; set; } //Economic, Business, First

        public string DepartureDato { get; set; }

        public string ReturnDato { get; set; }


        public int AntallAdult { get; set; }

        public int AntallChild { get; set; }
    }
}