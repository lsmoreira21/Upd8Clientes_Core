using Microsoft.EntityFrameworkCore;
using Upd8Clientes_Core.Models;

namespace Upd8Clientes_Core.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<Cidade>().ToTable("Cidade");
        }
    }
}

