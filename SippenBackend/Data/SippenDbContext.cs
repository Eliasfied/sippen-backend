namespace SippenBackend.Data
{
    using Microsoft.EntityFrameworkCore;
    using SippenBackend.Models;

    public class SippenDbContext : DbContext
    {
        public DbSet<Frage> Frage { get; set; }
        public DbSet<Antwort> Antwort { get; set; }
        public DbSet<Schwierigkeitsgrad> Schwierigkeitsgrad { get; set; }
        public DbSet<Kategorie> Kategorie { get; set; }

        public SippenDbContext(DbContextOptions<SippenDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Hier kannst du weitere Konfigurationen für deine Modelle definieren, z.B. Beziehungen zwischen Tabellen.

        }
    }
}
