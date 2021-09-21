using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oblig1.DAL;
using Oblig1.Models;
using WebApplication24.Models;

namespace WebApplication24.Controllers
{
    [Route("[Controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly IKundeRepository _kundeDB;

        private ILogger<KundeController> _kundeLog;

        public KundeController(IKundeRepository kundeDB, ILogger<KundeController> kundeLog)
        {
            _kundeDB = kundeDB;
            _kundeLog = kundeLog;
        }
        public async Task<ActionResult> Lagre(Kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                bool returnOk = await _kundeDB.Lagre(innKunde);
                if (!returnOk)
                {
                    _kundeLog.LogInformation("Kunne ikke lagre kunden");
                    return BadRequest("Kunne ikke lagre kunden");
                }
                return Ok("Kunde ble lagret");
            }

            _kundeLog.LogInformation("Feil i inputValidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        public async Task<ActionResult<Kunde>> HentAlle()
        {
            List<Kunde> alleKunder = await _kundeDB.HentAlle();
            return Ok(alleKunder);
        }

        public async Task<ActionResult> Endre(Kunde endreKunde)
        {
            if(ModelState.IsValid)
            { 
            bool returnOk = await _kundeDB.Endre(endreKunde);
                if (!returnOk)
                {
                    _kundeLog.LogInformation("Kunne ikke endre kunden");
                    return NotFound("Kunne ikke endre kunden");
                }
                return Ok("Kunde ble endret");
            }
            _kundeLog.LogInformation("Feil i inputValidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        public async Task<ActionResult> HentEn(int id)
        {
            if (ModelState.IsValid)
            {
                Kunde en = await _kundeDB.HentEn(id);
                if (en == null)
                {
                    _kundeLog.LogInformation("Kunne ikke finne kunden");
                    return NotFound("Kunne ikke finne kunden");
                }
                return Ok(en);
            }
            _kundeLog.LogInformation("Feil i inputValidering");
            return BadRequest("Feil i inputValidering på server");
        }

        public async Task<ActionResult> Slett(int id)
        {
            bool returnOk = await _kundeDB.Slett(id);
            if (!returnOk)
            {
                _kundeLog.LogInformation("Kunne ikke slette kunden");
                return NotFound("Kunne ikke slette kunden");
            }
            return Ok("Kunde ble slettet");
        }

        public async Task<ActionResult> SlettAlle()
        {
            bool returnOk = await _kundeDB.SlettAlle();
               if (!returnOk) { 
                _kundeLog.LogInformation("Kunne ikke slette alle");
                return NotFound("Kunne ikke slette alle");
            }
            return Ok("Alle ble slettet");
        }
    }
}