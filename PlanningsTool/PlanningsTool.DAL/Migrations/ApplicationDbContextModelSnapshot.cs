﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanningsTool.DAL.Contexts;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PlanningsTool.DAL.Models.RegimeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AantalUren")
                        .HasColumnType("decimal(3,1)");

                    b.Property<string>("Regime")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("RegimeTypes", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AantalUren = 38.0m,
                            Regime = "Voltijds"
                        },
                        new
                        {
                            Id = 2,
                            AantalUren = 30.4m,
                            Regime = "Deeltijds 4/5"
                        },
                        new
                        {
                            Id = 3,
                            AantalUren = 28.8m,
                            Regime = "Deeltijds 3/4"
                        },
                        new
                        {
                            Id = 4,
                            AantalUren = 19.0m,
                            Regime = "Halftijds"
                        });
                });

            modelBuilder.Entity("PlanningsTool.DAL.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("Eindtijd")
                        .HasColumnType("time");

                    b.Property<int>("ShiftTypeId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Starttijd")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ShiftTypeId");

                    b.ToTable("Shifts", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Eindtijd = new TimeSpan(0, 15, 0, 0, 0),
                            ShiftTypeId = 1,
                            Starttijd = new TimeSpan(0, 7, 0, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Eindtijd = new TimeSpan(0, 13, 30, 0, 0),
                            ShiftTypeId = 1,
                            Starttijd = new TimeSpan(0, 7, 0, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            Eindtijd = new TimeSpan(0, 11, 0, 0, 0),
                            ShiftTypeId = 1,
                            Starttijd = new TimeSpan(0, 7, 0, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            Eindtijd = new TimeSpan(0, 20, 30, 0, 0),
                            ShiftTypeId = 2,
                            Starttijd = new TimeSpan(0, 12, 30, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            Eindtijd = new TimeSpan(0, 20, 30, 0, 0),
                            ShiftTypeId = 2,
                            Starttijd = new TimeSpan(0, 14, 0, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            Eindtijd = new TimeSpan(0, 20, 0, 0, 0),
                            ShiftTypeId = 2,
                            Starttijd = new TimeSpan(0, 16, 0, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            Eindtijd = new TimeSpan(0, 7, 15, 0, 0),
                            ShiftTypeId = 3,
                            Starttijd = new TimeSpan(0, 20, 15, 0, 0)
                        });
                });

            modelBuilder.Entity("PlanningsTool.DAL.Models.ShiftType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Shift")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("ShiftTypes", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Shift = "Vroege"
                        },
                        new
                        {
                            Id = 2,
                            Shift = "Late"
                        },
                        new
                        {
                            Id = 3,
                            Shift = "Nacht"
                        });
                });

            modelBuilder.Entity("PlanningsTool.DAL.Models.Verlof", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Einddatum")
                        .HasColumnType("date");

                    b.Property<string>("Reden")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Startdatum")
                        .HasColumnType("date");

                    b.Property<int>("VerlofTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ZorgkundigeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("VerlofTypeId");

                    b.HasIndex("ZorgkundigeId");

                    b.ToTable("Verloven", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Einddatum = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Reden = "Verlofdagje op vrijdag.",
                            Startdatum = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VerlofTypeId = 1,
                            ZorgkundigeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Einddatum = new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Reden = "Heel de week ziek geweest.",
                            Startdatum = new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VerlofTypeId = 2,
                            ZorgkundigeId = 2
                        });
                });

            modelBuilder.Entity("PlanningsTool.DAL.Models.VerlofType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Verlof")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("VerlofTypes", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Verlof = "Verlof"
                        },
                        new
                        {
                            Id = 2,
                            Verlof = "Ziekte"
                        },
                        new
                        {
                            Id = 3,
                            Verlof = "Arbeidsduurverkorting"
                        },
                        new
                        {
                            Id = 4,
                            Verlof = "Wens"
                        },
                        new
                        {
                            Id = 5,
                            Verlof = "Andere"
                        });
                });

            modelBuilder.Entity("PlanningsTool.DAL.Models.Zorgkundige", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("IsVasteNacht")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<int>("RegimeId")
                        .HasColumnType("int");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RegimeId");

                    b.ToTable("Zorgkundigen", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Achternaam = "Woerahfa",
                            IsVasteNacht = "0",
                            RegimeId = 1,
                            Voornaam = "Amina"
                        },
                        new
                        {
                            Id = 2,
                            Achternaam = "Tamara",
                            IsVasteNacht = "0",
                            RegimeId = 1,
                            Voornaam = "Barbara"
                        },
                        new
                        {
                            Id = 3,
                            Achternaam = "Dhanitin",
                            IsVasteNacht = "0",
                            RegimeId = 1,
                            Voornaam = "Chaimae"
                        },
                        new
                        {
                            Id = 4,
                            Achternaam = "Dhiyah",
                            IsVasteNacht = "0",
                            RegimeId = 1,
                            Voornaam = "Dalila"
                        },
                        new
                        {
                            Id = 5,
                            Achternaam = "Tsridh",
                            IsVasteNacht = "0",
                            RegimeId = 2,
                            Voornaam = "Fatima"
                        },
                        new
                        {
                            Id = 6,
                            Achternaam = "Mantazoedh",
                            IsVasteNacht = "0",
                            RegimeId = 2,
                            Voornaam = "Ghizlane"
                        },
                        new
                        {
                            Id = 7,
                            Achternaam = "Hanatt",
                            IsVasteNacht = "0",
                            RegimeId = 2,
                            Voornaam = "Halima"
                        },
                        new
                        {
                            Id = 8,
                            Achternaam = "Azough",
                            IsVasteNacht = "0",
                            RegimeId = 3,
                            Voornaam = "Imane"
                        },
                        new
                        {
                            Id = 9,
                            Achternaam = "Adheswe",
                            IsVasteNacht = "0",
                            RegimeId = 3,
                            Voornaam = "Karima"
                        },
                        new
                        {
                            Id = 10,
                            Achternaam = "Adhesha",
                            IsVasteNacht = "1",
                            RegimeId = 1,
                            Voornaam = "Latifa"
                        },
                        new
                        {
                            Id = 11,
                            Achternaam = "Sariedh",
                            IsVasteNacht = "1",
                            RegimeId = 1,
                            Voornaam = "Mariem"
                        },
                        new
                        {
                            Id = 12,
                            Achternaam = "Isira",
                            IsVasteNacht = "1",
                            RegimeId = 3,
                            Voornaam = "Nasira"
                        });
                });

            modelBuilder.Entity("PlanningsTool.DAL.Models.Shift", b =>
                {
                    b.HasOne("PlanningsTool.DAL.Models.ShiftType", "ShiftType")
                        .WithMany()
                        .HasForeignKey("ShiftTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShiftType");
                });

            modelBuilder.Entity("PlanningsTool.DAL.Models.Verlof", b =>
                {
                    b.HasOne("PlanningsTool.DAL.Models.VerlofType", "VerlofType")
                        .WithMany()
                        .HasForeignKey("VerlofTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlanningsTool.DAL.Models.Zorgkundige", "Zorgkundige")
                        .WithMany()
                        .HasForeignKey("ZorgkundigeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VerlofType");

                    b.Navigation("Zorgkundige");
                });

            modelBuilder.Entity("PlanningsTool.DAL.Models.Zorgkundige", b =>
                {
                    b.HasOne("PlanningsTool.DAL.Models.RegimeType", "RegimeType")
                        .WithMany()
                        .HasForeignKey("RegimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegimeType");
                });
#pragma warning restore 612, 618
        }
    }
}
