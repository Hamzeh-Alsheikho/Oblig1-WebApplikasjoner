﻿using System;
using System.Collections;
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
        
        public IEnumerable HentGyldigDestinasjoner(int desintasjonId) {
            IEnumerable destinasjoner = null;
            if (desintasjonId == 1)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id > 2 && d.Id < 6);
            }
            else if (desintasjonId == 2)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id == 1 || d.Id > 4 && d.Id < 8);
            }
            else if (desintasjonId == 3)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id > 0 && d.Id < 3 || d.Id > 7 && d.Id < 9);
            }
            else if (desintasjonId == 4)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id > 8 && d.Id <= 11);
            }
            else if (desintasjonId == 5)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id > 5 && d.Id < 9);
            }
            else if (desintasjonId == 6)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id > 0 && d.Id < 6);
            }
            else if (desintasjonId == 7)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id > 4 && d.Id < 7 || d.Id > 0 && d.Id < 3);
            }
            else if (desintasjonId == 8)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id > 0 && d.Id < 5 || d.Id > 9 && d.Id <= 11);
            }
            else if (desintasjonId == 9)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id > 2 && d.Id < 9);
            }
            else if (desintasjonId == 10)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id > 0 && d.Id < 6);
            }
            else if (desintasjonId == 11)
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id > 2 && d.Id < 9);
            }
            else
            {
                destinasjoner = _kundeDB.Destinasjoner.Where(d => d.Id < 5);
            }

            return destinasjoner;
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

        public async Task<Billett> HentEnBillett(int kundeId) {
            try
            {
                Billett enBillett = await _kundeDB.Billetter.FindAsync(kundeId);
                var hentetBillett = new Billett()
                {
                    Id = enBillett.Id,
                    KundeId = enBillett.KundeId,
                    DestinationTo = enBillett.DestinationTo,
                    DestinationFrom = enBillett.DestinationFrom,
                    TicketType = enBillett.TicketType,
                    TicketClass = enBillett.TicketClass,
                    DepartureDato = enBillett.DepartureDato,
                    ReturnDato = enBillett.ReturnDato,
                    AntallAdult = enBillett.AntallAdult,
                    AntallChild = enBillett.AntallChild

                };
                return hentetBillett;
            }
            catch
            {
                return null;
            }
        }
    }
}
