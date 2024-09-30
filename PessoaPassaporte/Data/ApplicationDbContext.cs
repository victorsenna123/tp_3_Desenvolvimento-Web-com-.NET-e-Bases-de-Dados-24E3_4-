using Microsoft.EntityFrameworkCore;
using RelacionamentoApi.Models;

namespace RelacionamentoApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Passaporte> Passaportes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento um-para-um
            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.Passaporte)
                .WithOne(p => p.Pessoa)
                .HasForeignKey<Passaporte>(p => p.PessoaId);
        }
    }
}
