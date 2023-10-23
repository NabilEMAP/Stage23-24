using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Seeding
{
    public static class ZorgkundigeSeeding
    {
        public static void Seed(this EntityTypeBuilder<Zorgkundige> modelBuilder)
        {
            modelBuilder.HasData(
                new Zorgkundige()
                {
                    Id = 1,
                    Voornaam = "Amina",
                    Achternaam = "Woerahfa",
                    RegimeId = 1,
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 2,
                    Voornaam = "Barbara",
                    Achternaam = "Tamara",
                    RegimeId = 1,
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 3,
                    Voornaam = "Chaimae",
                    Achternaam = "Dhanitin",
                    RegimeId = 1,
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 4,
                    Voornaam = "Dalila",
                    Achternaam = "Dhiyah",
                    RegimeId = 1,
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 5,
                    Voornaam = "Fatima",
                    Achternaam = "Tsridh",
                    RegimeId = 2,
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 6,
                    Voornaam = "Ghizlane",
                    Achternaam = "Mantazoedh",
                    RegimeId = 2,
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 7,
                    Voornaam = "Halima",
                    Achternaam = "Hanatt",
                    RegimeId = 2,
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 8,
                    Voornaam = "Imane",
                    Achternaam = "Azough",
                    RegimeId = 3,
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 9,
                    Voornaam = "Karima",
                    Achternaam = "Adheswe",
                    RegimeId = 3,
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 10,
                    Voornaam = "Latifa",
                    Achternaam = "Adhesha",
                    RegimeId = 1,
                    IsVasteNacht = true,
                },
                new Zorgkundige()
                {
                    Id = 11,
                    Voornaam = "Mariem",
                    Achternaam = "Sariedh",
                    RegimeId = 1,
                    IsVasteNacht = true,
                },
                new Zorgkundige()
                {
                    Id = 12,
                    Voornaam = "Nasira",
                    Achternaam = "Isira",
                    RegimeId = 3,
                    IsVasteNacht = true,
                }
            );
        }
    }
}
