using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Data.Configurations
{
    public class ClassesConfigMap : IEntityTypeConfiguration<Classes>
    {
        public void Configure(EntityTypeBuilder<Classes> builder)
        {
            //colunas normais
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("varchar(100)");

            //colunas com relação e configs de 1:1 e Configs FK
            builder.HasOne(f => f.ArmasPorClasses)
                   .WithOne(r => r.Classes)
                   .HasForeignKey<ArmasPorClasses>(e => e.IdClasses);


            //nome da tabela
            builder.ToTable("Classes");
        }
    }
}
