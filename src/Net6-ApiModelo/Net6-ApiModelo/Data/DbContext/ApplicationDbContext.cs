using Microsoft.EntityFrameworkCore;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Construtor vazio iplementar DI depois
        public ApplicationDbContext() 
        { }


        public DbSet<Personagem> Personagem { get; set; }


        //add string de conexão direto no classe sem DI, dessa forma sem necessidade de configrar em program ou start up
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Modelo;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Pode ser extendida para mas detalhes de criação do banco
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
