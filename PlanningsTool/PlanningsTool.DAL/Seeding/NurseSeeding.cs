using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class NurseSeeding
    {
        public static void Seed(this EntityTypeBuilder<Nurse> modelBuilder)
        {
            modelBuilder.HasData(
                new Nurse()
                {
                    Id = 1,
                    FirstName = "Amina",
                    LastName = "Woerahfa",
                    RegimeId = 1,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 2,
                    FirstName = "Barbara",
                    LastName = "Tamara",
                    RegimeId = 1,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 3,
                    FirstName = "Chaimae",
                    LastName = "Dhanitin",
                    RegimeId = 1,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 4,
                    FirstName = "Dalila",
                    LastName = "Dhiyah",
                    RegimeId = 1,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 5,
                    FirstName = "Fatima",
                    LastName = "Tsridh",
                    RegimeId = 2,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 6,
                    FirstName = "Ghizlane",
                    LastName = "Mantazoedh",
                    RegimeId = 2,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 7,
                    FirstName = "Halima",
                    LastName = "Hanatt",
                    RegimeId = 2,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 8,
                    FirstName = "Imane",
                    LastName = "Azough",
                    RegimeId = 3,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 9,
                    FirstName = "Karima",
                    LastName = "Adheswe",
                    RegimeId = 3,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 10,
                    FirstName = "Latifa",
                    LastName = "Adhesha",
                    RegimeId = 1,
                    IsFixedNight = true,
                },
                new Nurse()
                {
                    Id = 11,
                    FirstName = "Mariem",
                    LastName = "Sariedh",
                    RegimeId = 1,
                    IsFixedNight = true,
                },
                new Nurse()
                {
                    Id = 12,
                    FirstName = "Nasira",
                    LastName = "Isira",
                    RegimeId = 3,
                    IsFixedNight = true,
                }
            );
        }
    }
}
