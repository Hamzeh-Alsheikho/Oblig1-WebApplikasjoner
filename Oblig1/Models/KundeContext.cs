using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication24.Models;

namespace Oblig1.Models
{
    public class Kunder
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Telfonnr { get; set; }
        public string Epost { get; set; }
        public string Adresse { get; set; }
        virtual public Ticket Ticket { get; set; }
        virtual public PostSteder PostSteder { get; set; }
    }
    public class PostSteder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Postnr { get; set; }
        public string Poststed { get; set; }
    }

    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Destination { get; set; }
        public string TicketType { get; set; } //Single or Return
        public string TicketClass { get; set; } //Economic, Business, First
        public string DepartureDato { get; set; }
        public string ReturnDato { get; set; }
        public int AntallAdult { get; set; }
        public int AntallChild { get; set; }
    }


    public class KundeContext : DbContext
    {
       
        public KundeContext(DbContextOptions<KundeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<PostSteder> PostSteder { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
