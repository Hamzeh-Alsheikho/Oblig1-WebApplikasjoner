using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication24.Models;

namespace WebApplication24.Controllers
{
    [Route("[Controller]/[action]")]
    public class KundeController : ControllerBase
    {
        public List<Kunde> HentAlle()
        {
            var kundene = new List<Kunde>();

            var kunde1 = new Kunde();
            kunde1.navn = "Per Hansen";
            kunde1.adresse = "Osloveien 82";

            var kunde2 = new Kunde
            {
                navn = "Line Jensen",
                adresse = "Askerveien 82"
            };

            kundene.Add(kunde1);
            kundene.Add(kunde2);

            return kundene;
        }
    }
}