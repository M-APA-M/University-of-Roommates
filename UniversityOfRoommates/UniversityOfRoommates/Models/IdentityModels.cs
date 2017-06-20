using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;

namespace UniversityOfRoommates.Models
{
    // È possibile aggiungere dati di profilo dell'utente specificando altre proprietà della classe ApplicationUser. Per ulteriori informazioni, visitare http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser 
    {
        public string nome { get; set; }
        public string cognome { get; set; }
        public bool sesso { get; set; }
        public DateTime? ddn { get; set; }
        public string cittàProvenienza { get; set; }
        public string cell { get; set; }

        public ICollection<DebitiCrediti> Debiti { get; set; }
        public ICollection<DebitiCrediti> Crediti { get; set; }
        public ICollection<Affitto> Affitto { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenere presente che il valore di authenticationType deve corrispondere a quello definito in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Aggiungere qui i reclami utente personalizzati
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

       // public DbSet<Utente> Utenti { get; set; }
        public DbSet<Proprietario> Proprietari { get; set; }
        public DbSet<Interesse> Interessi { get; set; }
        public DbSet<Casa> Case { get; set; }
        public DbSet<FotoCasa> FotoCase { get; set; }
        public DbSet<Affitto> Affitti { get; set; }
        public DbSet<Stanza> Stanze { get; set; }
        public DbSet<Evento> Eventi { get; set; }
        public DbSet<DebitiCrediti> DebitiCrediti { get; set; }
        public DbSet<GestioneCasa> GestioneCase { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}