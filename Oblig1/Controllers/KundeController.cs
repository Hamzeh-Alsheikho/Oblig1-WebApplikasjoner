using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        
        public async Task<List<Kunde>> HentAlle()
        {
            try
            {
                List<Kunde> alleKundene = await _kundeDB.Kunder.Select(innKunnde => new Kunde
                {
                    Id = innKunnde.Id,
                    Fornavn = innKunnde.Fornavn,
                    Etternavn = innKunnde.Etternavn,
                    Telfonnr = innKunnde.Telfonnr,
                    Epost = innKunnde.Epost,
                    Adresse = innKunnde.Adresse,
                    Postnr = innKunnde.PostSteder.Postnr,
                    Poststed = innKunnde.PostSteder.Poststed

                }).ToListAsync();

                return alleKundene;
            }
            catch
            {
                return null;
            }
        }
    }
}