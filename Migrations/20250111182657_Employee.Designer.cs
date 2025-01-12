﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Medii_ZOO.Data;

#nullable disable

namespace Proiect_Medii_ZOO.Migrations
{
    [DbContext(typeof(Proiect_Medii_ZOOContext))]
    [Migration("20250111182657_Employee")]
    partial class Employee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("EnclosureID")
                        .HasColumnType("int");

                    b.Property<int?>("KeeperID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.HasIndex("EnclosureID");

                    b.HasIndex("KeeperID");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.AnimalDiet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AnimalID")
                        .HasColumnType("int");

                    b.Property<int>("DietID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AnimalID");

                    b.HasIndex("DietID");

                    b.ToTable("AnimalDiet");
                });

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.Diet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DietName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Diet");
                });

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.Enclosure", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("EnclosureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Enclosure");
                });

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.Keeper", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("KeeperName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Keeper");
                });

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.Animal", b =>
                {
                    b.HasOne("Proiect_Medii_ZOO.Models.Enclosure", "Enclosure")
                        .WithMany("Animals")
                        .HasForeignKey("EnclosureID");

                    b.HasOne("Proiect_Medii_ZOO.Models.Keeper", "Keeper")
                        .WithMany("Animals")
                        .HasForeignKey("KeeperID");

                    b.Navigation("Enclosure");

                    b.Navigation("Keeper");
                });

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.AnimalDiet", b =>
                {
                    b.HasOne("Proiect_Medii_ZOO.Models.Animal", "Animal")
                        .WithMany("AnimalDiets")
                        .HasForeignKey("AnimalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Medii_ZOO.Models.Diet", "Diet")
                        .WithMany("AnimalDiets")
                        .HasForeignKey("DietID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Diet");
                });

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.Animal", b =>
                {
                    b.Navigation("AnimalDiets");
                });

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.Diet", b =>
                {
                    b.Navigation("AnimalDiets");
                });

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.Enclosure", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Proiect_Medii_ZOO.Models.Keeper", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
