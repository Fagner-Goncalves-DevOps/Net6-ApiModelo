﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net6_ApiModelo.Data;

#nullable disable

namespace Net6_ApiModelo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230419193912_relations_1_1_e_1_N")]
    partial class relations_1_1_e_1_N
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Net6_ApiModelo.Model.Entities.ArmasPorClasses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdClasses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdClasses")
                        .IsUnique();

                    b.ToTable("ArmasPorClasses");
                });

            modelBuilder.Entity("Net6_ApiModelo.Model.Entities.Classes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdPersoagem")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdPersoagem")
                        .IsUnique();

                    b.ToTable("Classes", (string)null);
                });

            modelBuilder.Entity("Net6_ApiModelo.Model.Entities.Habilidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdClasses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdClasses");

                    b.ToTable("Habilidade", (string)null);
                });

            modelBuilder.Entity("Net6_ApiModelo.Model.Entities.Personagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Personagem", (string)null);
                });

            modelBuilder.Entity("Net6_ApiModelo.Model.Entities.ArmasPorClasses", b =>
                {
                    b.HasOne("Net6_ApiModelo.Model.Entities.Classes", "Classes")
                        .WithOne("ArmasPorClasses")
                        .HasForeignKey("Net6_ApiModelo.Model.Entities.ArmasPorClasses", "IdClasses")
                        .IsRequired();

                    b.Navigation("Classes");
                });

            modelBuilder.Entity("Net6_ApiModelo.Model.Entities.Classes", b =>
                {
                    b.HasOne("Net6_ApiModelo.Model.Entities.Personagem", "Personagem")
                        .WithOne("Classes")
                        .HasForeignKey("Net6_ApiModelo.Model.Entities.Classes", "IdPersoagem")
                        .IsRequired();

                    b.Navigation("Personagem");
                });

            modelBuilder.Entity("Net6_ApiModelo.Model.Entities.Habilidade", b =>
                {
                    b.HasOne("Net6_ApiModelo.Model.Entities.Classes", "Classes")
                        .WithMany("Habilidade")
                        .HasForeignKey("IdClasses")
                        .IsRequired();

                    b.Navigation("Classes");
                });

            modelBuilder.Entity("Net6_ApiModelo.Model.Entities.Classes", b =>
                {
                    b.Navigation("ArmasPorClasses");

                    b.Navigation("Habilidade");
                });

            modelBuilder.Entity("Net6_ApiModelo.Model.Entities.Personagem", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}
