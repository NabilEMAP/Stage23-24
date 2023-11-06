using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class VacationTypeSeeding
    {
        public static void Seed(this EntityTypeBuilder<VacationType> modelBuilder)
        {
            modelBuilder.HasData(
                new VacationType()
                {
                    Id = 1,
                    Name = "Verlof",
                },
                new VacationType()
                {
                    Id = 2,
                    Name = "Ziekte",
                },
                new VacationType()
                {
                    Id = 3,
                    Name = "Arbeidsduurverkorting",
                },
                new VacationType()
                {
                    Id = 4,
                    Name = "Wens",
                },
                new VacationType()
                {
                    Id = 5,
                    Name = "Andere",
                }
            );
        }
    }
}
