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
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 2,
                    Voornaam = "Barbara",
                    Achternaam = "Tamara",
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 3,
                    Voornaam = "Chaimae",
                    Achternaam = "Dhanitin",
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 4,
                    Voornaam = "Dalila",
                    Achternaam = "Dhiyah",
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 5,
                    Voornaam = "Fatima",
                    Achternaam = "Tsridh",
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 6,
                    Voornaam = "Ghizlane",
                    Achternaam = "Mantazoedh",
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 7,
                    Voornaam = "Halima",
                    Achternaam = "Hanatt",
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 8,
                    Voornaam = "Imane",
                    Achternaam = "Azough",
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 9,
                    Voornaam = "Karima",
                    Achternaam = "Adheswe",
                    IsVasteNacht = false,
                },
                new Zorgkundige()
                {
                    Id = 10,
                    Voornaam = "Latifa",
                    Achternaam = "Adhesha",
                    IsVasteNacht = true,
                },
                new Zorgkundige()
                {
                    Id = 11,
                    Voornaam = "Mariem",
                    Achternaam = "Sariedh",
                    IsVasteNacht = true,
                },
                new Zorgkundige()
                {
                    Id = 12,
                    Voornaam = "Nasira",
                    Achternaam = "Isira",
                    IsVasteNacht = true,
                }
            );
        }
    }
}
