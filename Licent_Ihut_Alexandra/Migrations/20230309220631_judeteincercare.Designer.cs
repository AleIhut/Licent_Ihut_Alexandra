﻿// <auto-generated />
using System;
using Licent_Ihut_Alexandra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    [DbContext(typeof(Licent_Ihut_AlexandraContext))]
    [Migration("20230309220631_judeteincercare")]
    partial class judeteincercare
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.Decoratiune", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Companie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locație")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaterialID")
                        .HasColumnType("int");

                    b.Property<decimal>("Telefon")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("MaterialID");

                    b.ToTable("Decoratiune");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.GenMuzical", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("GenMuzicalNume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("GenMuzical");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.Judet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Judet");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.SalaEveniment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Capacitate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Descriere")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JudetID")
                        .HasColumnType("int");

                    b.Property<string>("Localitate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("JudetID");

                    b.ToTable("SalaEveniment");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.Sonorizare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sonorizare");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.SonorizareGenMuzical", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("GenMuzicalID")
                        .HasColumnType("int");

                    b.Property<int>("SonorizareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GenMuzicalID");

                    b.HasIndex("SonorizareID");

                    b.ToTable("SonorizareGenMuzical");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.Decoratiune", b =>
                {
                    b.HasOne("Licent_Ihut_Alexandra.Models.Material", "Material")
                        .WithMany("Decoratiune")
                        .HasForeignKey("MaterialID");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.SalaEveniment", b =>
                {
                    b.HasOne("Licent_Ihut_Alexandra.Models.Judet", "Judet")
                        .WithMany("SaliEvenimente")
                        .HasForeignKey("JudetID");

                    b.Navigation("Judet");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.SonorizareGenMuzical", b =>
                {
                    b.HasOne("Licent_Ihut_Alexandra.Models.GenMuzical", "GenMuzical")
                        .WithMany("SonorizareGenuriMuzicale")
                        .HasForeignKey("GenMuzicalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Licent_Ihut_Alexandra.Models.Sonorizare", "Sonorizare")
                        .WithMany("SonorizareGenuriMuzicale")
                        .HasForeignKey("SonorizareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GenMuzical");

                    b.Navigation("Sonorizare");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.GenMuzical", b =>
                {
                    b.Navigation("SonorizareGenuriMuzicale");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.Judet", b =>
                {
                    b.Navigation("SaliEvenimente");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.Material", b =>
                {
                    b.Navigation("Decoratiune");
                });

            modelBuilder.Entity("Licent_Ihut_Alexandra.Models.Sonorizare", b =>
                {
                    b.Navigation("SonorizareGenuriMuzicale");
                });
#pragma warning restore 612, 618
        }
    }
}
