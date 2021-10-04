using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oblig1.Models;
using WebApplication24.Models;

namespace Oblig1.DAL
{
    public class KundeRepository : IKundeRepository
    {
        private readonly KundeContext _kundeDB;
        

        public KundeRepository(KundeContext kundeDb)
        {
            _kundeDB = kundeDb;

        }

        public async Task<int> Lagre(Kunde innKunde)
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
                _kundeDB.Kunder.Add(nyKundeRad);
                await _kundeDB.SaveChangesAsync();
                var kundeId = nyKundeRad.Id;
                return kundeId;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return 0;
            }
        }

        public async Task<bool> LagreKreditt(Kreditt kredittInfo) {
            try
            {
              var nyKreditt = new Kreditt();
              nyKreditt.Kortnummer = kredittInfo.Kortnummer;
              nyKreditt.KundeId = kredittInfo.KundeId;  
              nyKreditt.KortHolderNavn = kredittInfo.KortHolderNavn;
              nyKreditt.KortUtlopsdato = kredittInfo.KortUtlopsdato;
              nyKreditt.Cvc = kredittInfo.Cvc; 

              _kundeDB.Kreditt.Add(nyKreditt);
              await _kundeDB.SaveChangesAsync();
              return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
        }

        public async Task<bool> LagreBillett(Billett innBillett)
        {
            try
            {
                var nyBillett = new Billett();
                nyBillett.DestinationFrom = innBillett.DestinationFrom;
                nyBillett.KundeId = innBillett.KundeId;
                nyBillett.DestinationTo = innBillett.DestinationTo;
                nyBillett.TicketType = innBillett.TicketType;
                nyBillett.TicketClass = innBillett.TicketClass;
                nyBillett.AntallAdult = innBillett.AntallAdult;
                nyBillett.AntallChild = innBillett.AntallChild;
                nyBillett.DepartureDato = innBillett.DepartureDato;
                nyBillett.ReturnDato = innBillett.ReturnDato;
       

                _kundeDB.Billetter.Add(nyBillett);
                await _kundeDB.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
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

        public async Task<List<Billett>> HentAlleBilletter()
        {
            try
            {
                List<Billett> alleBilletter = await _kundeDB.Billetter.Select(innBillett => new Billett
                {
                    Id = innBillett.Id,
                    KundeId = innBillett.KundeId,
                    DestinationFrom = innBillett.DestinationFrom,
                    DestinationTo = innBillett.DestinationTo,
                    TicketType = innBillett.TicketType,
                    TicketClass = innBillett.TicketClass,
                    AntallAdult = innBillett.AntallAdult,
                    AntallChild = innBillett.AntallChild,
                    DepartureDato = innBillett.DepartureDato,
                    ReturnDato = innBillett.ReturnDato,
    

                }).ToListAsync();

                return alleBilletter;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Destinasjon>> HentAlleDestinasjon()
        {
            try
            {
                List<Destinasjon> alleDestinasjon = await _kundeDB.Destinasjoner.Select(innDestinasjon => new Destinasjon
                {
                    Id = innDestinasjon.Id,
                    Sted = innDestinasjon.Sted,

                }).ToListAsync();

                return alleDestinasjon;
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
                if (enKunde.PostSteder.Postnr != endreKunde.Postnr)
                {
                    var sjekkPoststed = _kundeDB.PostSteder.Find(endreKunde.Postnr);
                    if (sjekkPoststed == null)
                    {
                        var nyPoststedsRad = new PostSteder();
                        nyPoststedsRad.Postnr = endreKunde.Postnr;
                        nyPoststedsRad.Poststed = endreKunde.Poststed;
                        enKunde.PostSteder = nyPoststedsRad;
                    }
                    else
                    {
                        enKunde.PostSteder.Postnr = endreKunde.Postnr;
                    }
                }
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

        public async Task<bool> SlettAlle()
        {
            try
            {
           
                _kundeDB.Kunder.RemoveRange(_kundeDB.Kunder);
                _kundeDB.PostSteder.RemoveRange(_kundeDB.PostSteder);
                _kundeDB.Kreditt.RemoveRange(_kundeDB.Kreditt);
                _kundeDB.Billetter.RemoveRange(_kundeDB.Billetter);
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
