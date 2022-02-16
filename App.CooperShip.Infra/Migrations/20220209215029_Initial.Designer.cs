﻿// <auto-generated />
using System;
using App.CooperShip.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.CooperShip.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220209215029_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App.CooperShip.Domain.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VooId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VooId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("App.CooperShip.Domain.Entities.Voo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Disponibilidade")
                        .HasColumnType("int");

                    b.Property<string>("Nota")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Voos");
                });

            modelBuilder.Entity("App.CooperShip.Domain.Entities.Pessoa", b =>
                {
                    b.HasOne("App.CooperShip.Domain.Entities.Voo", "Voo")
                        .WithMany("Pessoas")
                        .HasForeignKey("VooId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Voo");
                });

            modelBuilder.Entity("App.CooperShip.Domain.Entities.Voo", b =>
                {
                    b.Navigation("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
