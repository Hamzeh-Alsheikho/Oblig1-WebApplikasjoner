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
        public List<Kunde> HentAlle()
        {
            List<Kunde> alleKundene = _kundeDB.Kunder.ToList();

            return alleKundene;
        }
    }
}