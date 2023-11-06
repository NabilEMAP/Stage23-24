using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

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
                    Name = "Voltijds",
                    CountHours = 38.0M,
                },
                new RegimeType()
                {
                    Id = 2,
                    Name = "Deeltijds 4/5",
                    CountHours = 30.4M,
                },
                new RegimeType()
                {
                    Id = 3,
                    Name = "Deeltijds 3/4",
                    CountHours = 28.8M,
                },
                new RegimeType()
                {
                    Id = 4,
                    Name = "Halftijds",
                    CountHours = 19.0M,
                }
            );
        }
    }
}
