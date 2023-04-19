using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Net6_ApiModelo.Migrations;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Data.Configurations
{
    public class PersonagemConfigMap : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {

            //colunas normais
            builder.HasKey(Key => Key.Id);
            builder.Property(n => n.Name).IsRequired().HasColumnType("varchar(100)");

            //colunas com relação de 1:1  e Configs e configs FK
            builder.HasOne(c => c.Classes)     //uma classe para...
                   .WithOne(p => p.Personagem) //um personagem
                   .HasForeignKey<Classes>(p => p.IdPersoagem);

            //nome da tabela
            builder.ToTable("Personagem");



        }
    }
}
