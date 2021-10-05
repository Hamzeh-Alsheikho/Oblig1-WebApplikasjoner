using System;
using System.Collections;
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
        public async Task<ActionResult<int>> Lagre(Kunde innKunde) //Kunde/Lagre
        {
            if (ModelState.IsValid)
            {
                int kundeId = await _kundeDB.Lagre(innKunde);
                if (kundeId == 0)
                {
                    _kundeLog.LogInformation("Kunne ikke lagre kunden");
                    return BadRequest("Kunne ikke lagre kunden");
                }
                return kundeId;
            }

            _kundeLog.LogInformation("Feil i inputValidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        public async Task<ActionResult<Kunde>> HentAlle()
        {
            List<Kunde> alleKunder = await _kundeDB.HentAlle();
            return Ok(alleKunder);
        } 
        
        public async Task<ActionResult<Billett>> HentAlleBilletter()
        {
            List<Billett> alleBilletter = await _kundeDB.HentAlleBilletter();
            return Ok(alleBilletter);
        }

        public async Task<ActionResult<Billett>> HentEnBillett(int kundeId) {
            Billett billett = await _kundeDB.HentEnBillett(kundeId);
            if (billett == null) {
                _kundeLog.LogInformation("Kunne ikke finne kunden");
                return NotFound("Kunne ikke finne kunden");
            }
            return Ok(billett);
		 }

        public async Task<ActionResult<Destinasjon>> HentAlleDestinasjon()
        {
            List<Destinasjon> alleDestinasjon = await _kundeDB.HentAlleDestinasjon();
            return Ok(alleDestinasjon);
        }

        public IEnumerable HentGyldigDestinasjoner(int destinasjonId) {
            IEnumerable destinasjoner = _kundeDB.HentGyldigDestinasjoner(destinasjonId);
            return destinasjoner;
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

        public async Task<ActionResult> SlettAlle()
        {
            bool returnOk = await _kundeDB.SlettAlle();
               if (!returnOk) { 
                _kundeLog.LogInformation("Kunne ikke slette alle");
                return NotFound("Kunne ikke slette alle");
            }
            return Ok("Alle ble slettet");
        }

         public async Task<ActionResult> LagreKreditt(Kreditt kredittInfo)
        {
                bool returnOk = await _kundeDB.LagreKreditt(kredittInfo);
                if (!returnOk)
                {
                    _kundeLog.LogInformation("Kunne ikke lagre kredittinfo");
                    return BadRequest("Kunne ikke lagre kredittinfo");
                }
                return Ok("Kredittinfo ble lagret");
        }

        public async Task<ActionResult> LagreBillett(Billett billett)
        {
            bool returnOk = await _kundeDB.LagreBillett(billett);
            if (!returnOk)
            {
                _kundeLog.LogInformation("Kunne ikke lagre Billett");
                return BadRequest("Kunne ikke lagre Billett");
            }
            return Ok("Billett ble lagret");

        }

    }
}