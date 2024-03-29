﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig1.Models
{
    public class DBInitialize
    {
        public static void Initialize(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            
            var context = serviceScope.ServiceProvider.GetService<KundeContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //var poststed1 = new PostSteder { Postnr = "0010", Poststed = "Oslo" };
            //var poststed2 = new PostSteder { Postnr = "0015", Poststed = "Oslo" };

            var destinasjon1 = new Destinasjon { Id = 1, Sted = "Oslo"};
            var destinasjon2 = new Destinasjon { Id = 2, Sted = "Danmark" };
            var destinasjon3 = new Destinasjon { Id = 3, Sted = "Stavanger" };
            var destinasjon4 = new Destinasjon { Id = 4, Sted = "Bergen" };
            var destinasjon5 = new Destinasjon { Id = 5, Sted = "Kiel" };
            var destinasjon6 = new Destinasjon { Id = 6, Sted = "Kristiansand" };
            var destinasjon7 = new Destinasjon { Id = 7, Sted = "Tromsø" };
            var destinasjon8 = new Destinasjon { Id = 8, Sted = "Svalbard" };
            var destinasjon9 = new Destinasjon { Id = 9, Sted = "Bodø" };
            var destinasjon10 = new Destinasjon { Id = 10, Sted = "Ålesund" };
            var destinasjon11 = new Destinasjon { Id = 11, Sted = "Lofoten" };

            //var ticket1 = new Billett { KundeId=3,DestinationFrom = "Oslo", DestinationTo = "Bergen", TicketType = "En vei", TicketClass = "Business", AntallAdult = 2, AntallChild = 0, DepartureDato = "2021-11-23", ReturnDato ="", };
            //var ticket2 = new Billett { KundeId = 4, DestinationFrom = "Stavanger", DestinationTo = "Danmark", TicketType = "Retur", TicketClass = "Economy", AntallAdult = 1, AntallChild = 1, DepartureDato = "2021-12-24", ReturnDato ="2023-01-03"};

            //var kunde1 = new Kunder { Id = 1, Fornavn = "Tor", Etternavn = "Nordman", Telfonnr = "004745142581", Epost = "xxx@oslomet.no", Adresse = "Pilestredet 35", PostSteder = poststed1, Billetter = ticket1};
            //var kunde2 = new Kunder { Id = 2, Fornavn = "Morten", Etternavn = "Nordman", Telfonnr = "004745145218", Epost = "zzz@oslomet.no", Adresse = "Pilestredet 32", PostSteder = poststed2, Billetter = ticket2};


            //context.Kunder.Add(kunde1);
            //context.Kunder.Add(kunde2);
            //context.Billetter.Add(ticket1);
            //context.Billetter.Add(ticket2);
            context.Destinasjoner.Add(destinasjon1);
            context.Destinasjoner.Add(destinasjon2);
            context.Destinasjoner.Add(destinasjon3);
            context.Destinasjoner.Add(destinasjon4);
            context.Destinasjoner.Add(destinasjon5);
            context.Destinasjoner.Add(destinasjon6);
            context.Destinasjoner.Add(destinasjon7);
            context.Destinasjoner.Add(destinasjon8);
            context.Destinasjoner.Add(destinasjon9);
            context.Destinasjoner.Add(destinasjon10);
            context.Destinasjoner.Add(destinasjon11);
        
            context.SaveChanges();
        }
    }
}
