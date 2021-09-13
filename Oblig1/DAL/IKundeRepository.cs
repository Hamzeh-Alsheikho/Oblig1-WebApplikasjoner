using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication24.Models;

namespace Oblig1.DAL
{
    public interface IKundeRepository
    {
        Task<bool> Lagre(Kunde innKunde);
        Task<List<Kunde>> HentAlle();
        Task<bool> Endre(Kunde endreKunde);
        Task<Kunde> HentEn(int id);
        Task<bool> Slett(int id);

    }
}
