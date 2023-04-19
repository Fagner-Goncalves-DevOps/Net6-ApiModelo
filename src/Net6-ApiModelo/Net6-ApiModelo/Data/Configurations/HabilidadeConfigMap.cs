using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Data.Configurations
{
    public class HabilidadeConfigMap : IEntityTypeConfiguration<Habilidade>
    {
        public void Configure(EntityTypeBuilder<Habilidade> builder)
        {
            //colunas normais
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Tipo).IsRequired().HasColumnType("varchar(50)");

            //colunas com relação de 1:N  e Configs FK
            builder.HasOne(f => f.Classes) //tem q iniciar com hasone por q estamos falando a partir dela
                   .WithMany(r => r.Habilidade)
                   .HasForeignKey(f => f.IdClasses);

            //nome da tabela
            builder.ToTable("Habilidade");
        }
    }
}
