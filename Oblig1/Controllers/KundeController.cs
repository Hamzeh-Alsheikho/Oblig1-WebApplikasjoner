using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oblig1.Models;
using WebApplication24.Models;

namespace WebApplication24.Controllers
{
    [Route("[Controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly KundeContext _kundeDB;

        public KundeController(KundeContext kundeDb)
        {
            _kundeDB = kundeDb;
        }
        
        public  async Task<bool> Lagre(Kunde innKunde)
        {
            try
            {
                var nyKundeRad = new Kunder();
                nyKundeRad.Fornavn = innKunde.Fornavn;
                nyKundeRad.Etternavn = innKunde.Etternavn;
                nyKundeRad.Telfonnr = innKunde.Telfonnr;
                nyKundeRad.Epost = innKunde.Epost;
                nyKundeRad.Adresse = innKunde.Adresse;

                var sjekkPoststed = await _kundeDB.PostSteder.FindAsync(innKunde.Postnr); // await and FindAsync check later
                if (sjekkPoststed == null)
                {
                    var nyPoststedRad = new PostSteder();
                    nyPoststedRad.Postnr = innKunde.Postnr;
                    nyPoststedRad.Poststed = innKunde.Poststed;
                    nyKundeRad.PostSteder = nyPoststedRad;
                }
                else
                {
                    nyKundeRad.PostSteder = sjekkPoststed;
                }

                var nyTicket = new Ticket();
                nyTicket.Destination = innKunde.Destination;
                nyTicket.TicketType = innKunde.TicketType;
                nyTicket.TicketClass = innKunde.TicketClass;
                nyTicket.AntallAdult = innKunde.AntallAdult;
                nyTicket.AntallChild = innKunde.AntallChild;
                nyTicket.DepartureDato = innKunde.DepartureDato;
                nyTicket.ReturnDato = innKunde.ReturnDato;
                nyKundeRad.Ticket = nyTicket;

                _kundeDB.Kunder.Add(nyKundeRad);
                await _kundeDB.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
        }

        public async Task<List<Kunde>> HentAlle()
        {
            try
            {
                List<Kunde> alleKundene = await _kundeDB.Kunder.Select(innKunde => new Kunde
                {
                    Id = innKunde.Id,
                    Destination = innKunde.Ticket.Destination,
                    TicketType = innKunde.Ticket.TicketType,
                    TicketClass = innKunde.Ticket.TicketClass,
                    AntallAdult = innKunde.Ticket.AntallAdult,
                    AntallChild = innKunde.Ticket.AntallChild,
                    DepartureDato = innKunde.Ticket.DepartureDato,
                    ReturnDato = innKunde.Ticket.ReturnDato,
                    Fornavn = innKunde.Fornavn,
                    Etternavn = innKunde.Etternavn,
                    Telfonnr = innKunde.Telfonnr,
                    Epost = innKunde.Epost,
                    Adresse = innKunde.Adresse,
                    Postnr = innKunde.PostSteder.Postnr,
                    Poststed = innKunde.PostSteder.Poststed

                }).ToListAsync();

                return alleKundene;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Endre(Kunde endreKunde)
        {
            try
            {
                Kunder enKunde = await _kundeDB.Kunder.FindAsync(endreKunde.Id);
                if(enKunde.PostSteder.Postnr != endreKunde.Postnr)
                {
                    var sjekkPoststed = _kundeDB.PostSteder.Find(endreKunde.Postnr);
                    if(endreKunde.Postnr == null)
                    {
                        var nyPoststedsRad = new PostSteder();
                        nyPoststedsRad.Postnr = endreKunde.Postnr;
                        nyPoststedsRad.Poststed = endreKunde.Poststed;
                        enKunde.PostSteder = nyPoststedsRad;
                    }
                    else
                    {
                        enKunde.PostSteder = sjekkPoststed;
                    }
                }

                enKunde.Ticket.Destination = endreKunde.Destination;
                enKunde.Ticket.TicketType = endreKunde.TicketType;
                enKunde.Ticket.TicketClass = endreKunde.TicketClass;
                enKunde.Ticket.AntallAdult = endreKunde.AntallAdult;
                enKunde.Ticket.AntallChild = endreKunde.AntallChild;
                enKunde.Ticket.DepartureDato = endreKunde.DepartureDato;
                enKunde.Ticket.ReturnDato = endreKunde.ReturnDato;
                enKunde.Fornavn = endreKunde.Fornavn;
                enKunde.Etternavn = endreKunde.Etternavn;
                enKunde.Telfonnr = endreKunde.Telfonnr;
                enKunde.Epost = endreKunde.Epost;
                enKunde.Adresse = endreKunde.Adresse;

                await _kundeDB.SaveChangesAsync();
                return true;
             }
            catch
            {
                return false;
            }
        }

        public async Task<Kunde> HentEn(int id)
        {
            try
            {
                Kunder hentedKunde = await _kundeDB.Kunder.FindAsync(id);
                var enKunde = new Kunde()
                {
                    Id = hentedKunde.Id,
                    Destination = hentedKunde.Ticket.Destination,
                    TicketType = hentedKunde.Ticket.TicketType,
                    TicketClass = hentedKunde.Ticket.TicketClass,
                    AntallAdult = hentedKunde.Ticket.AntallAdult,
                    AntallChild = hentedKunde.Ticket.AntallChild,
                    DepartureDato = hentedKunde.Ticket.DepartureDato,
                    ReturnDato = hentedKunde.Ticket.ReturnDato,
                    Fornavn = hentedKunde.Fornavn,
                    Etternavn = hentedKunde.Etternavn,
                    Telfonnr = hentedKunde.Telfonnr,
                    Epost = hentedKunde.Epost,
                    Adresse = hentedKunde.Adresse,
                    Postnr = hentedKunde.PostSteder.Postnr,
                    Poststed = hentedKunde.PostSteder.Poststed
                };
                return enKunde;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Slett(int id)
        {
            try
            {
                Kunder enKunde = await _kundeDB.Kunder.FindAsync(id);
                _kundeDB.Kunder.Remove(enKunde);
                await _kundeDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}