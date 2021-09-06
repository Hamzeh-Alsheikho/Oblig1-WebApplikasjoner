using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication24.Models;

namespace Oblig1.Models
{
    public class KundeContext :DbContext
    {
        public KundeContext(DbContextOptions<KundeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Kunde> Kunder { get; set; }

    }
}
