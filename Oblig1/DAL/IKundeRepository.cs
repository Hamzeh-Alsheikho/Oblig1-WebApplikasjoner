using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oblig1.Models;
using WebApplication24.Models;

namespace Oblig1.DAL
{
    public interface IKundeRepository
    {
        Task<int> Lagre(Kunde innKunde);
        Task<List<Kunde>> HentAlle();
        Task<bool> Endre(Kunde endreKunde);
        Task<Kunde> HentEn(int id);
        Task<bool> Slett(int id);
        Task<bool> SlettAlle();
        Task<bool> LagreKreditt(Kreditt kredittInfo);
        Task<bool> LagreBillett(Billett billett);
        Task<List<Billett>> HentAlleBilletter();
        Task<Billett> HentEnBillett(int kundeId);
        Task<List<Destinasjon>> HentAlleDestinasjon();
    }
}
