using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class ShiftTypeSeeding
    {
        public static void Seed(this EntityTypeBuilder<ShiftType> modelBuilder)
        {
            modelBuilder.HasData(
                new ShiftType()
                {
                    Id = 1,
                    Name = "Vroege",
                },
                new ShiftType()
                {
                    Id = 2,
                    Name = "Late",
                },
                new ShiftType()
                {
                    Id = 3,
                    Name = "Nacht",
                }
            );
        }
    }
}
