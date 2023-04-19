using Microsoft.EntityFrameworkCore;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        public DbSet<Personagem> Personagem { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Habilidade> Habilidade { get; set; }
        public DbSet<ArmasPorClasses> ArmasPorClasses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) //Pode ser extendida para mas detalhes de criação do banco
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //da para passar direto mappgin aqui, ou externar é que iriemos fazer usando o IEntityTypeConfiguration.
        //    modelBuilder.Entity<Personagem>().HasKey(k => k.Id);
        //    modelBuilder.Entity<Personagem>().HasKey(n => n.Name);
        //}
    }
}
