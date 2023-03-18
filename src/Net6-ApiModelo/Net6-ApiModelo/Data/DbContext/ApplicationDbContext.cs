using Microsoft.EntityFrameworkCore;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        public DbSet<Personagem> Personagem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) //Pode ser extendida para mas detalhes de criação do banco
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
