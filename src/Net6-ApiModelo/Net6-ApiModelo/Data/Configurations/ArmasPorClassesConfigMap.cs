using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Data.Configurations
{
    public class ArmasPorClassesConfigMap //: IEntityTypeConfiguration<ArmasPorClasses>
    {
        public void Configure(EntityTypeBuilder<ArmasPorClasses> builder)
        {
            //colunas normais
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("varchar(255)");
            builder.Property(x => x.Tipo).IsRequired().HasColumnType("varchar(50)");

            //colunas com relação e configs de 1:1 e Configs FK

            //deixar comentando para testar

            builder.HasOne(x => x.Classes)
                   .WithOne(r => r.ArmasPorClasses)
                   .HasForeignKey<ArmasPorClasses>(x => x.IdClasses);

            //nome da tabela
            builder.ToTable("ArmasPorClasses");

        }
    }
}
