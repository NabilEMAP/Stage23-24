using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Seeding
{
    public static class RegimeTypeSeeding
    {
        public static void Seed(this EntityTypeBuilder<RegimeType> modelBuilder)
        {
            modelBuilder.HasData(
                new RegimeType()
                {
                    Id = 1,
                    Regime = "Voltijds",
                    AantalUren = 38.0M,
                },
                new RegimeType()
                {
                    Id = 2,
                    Regime = "Deeltijds 4/5",
                    AantalUren = 30.4M,
                },
                new RegimeType()
                {
                    Id = 3,
                    Regime = "Deeltijds 3/4",
                    AantalUren = 28.8M,
                },
                new RegimeType()
                {
                    Id = 4,
                    Regime = "Halftijds",
                    AantalUren = 19.0M,
                }
            );
        }
    }
}
