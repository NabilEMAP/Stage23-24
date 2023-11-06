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
                    RegimeTypeId = 1,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 2,
                    FirstName = "Barbara",
                    LastName = "Tamara",
                    RegimeTypeId = 1,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 3,
                    FirstName = "Chaimae",
                    LastName = "Dhanitin",
                    RegimeTypeId = 1,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 4,
                    FirstName = "Dalila",
                    LastName = "Dhiyah",
                    RegimeTypeId = 1,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 5,
                    FirstName = "Fatima",
                    LastName = "Tsridh",
                    RegimeTypeId = 2,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 6,
                    FirstName = "Ghizlane",
                    LastName = "Mantazoedh",
                    RegimeTypeId = 2,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 7,
                    FirstName = "Halima",
                    LastName = "Hanatt",
                    RegimeTypeId = 2,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 8,
                    FirstName = "Imane",
                    LastName = "Azough",
                    RegimeTypeId = 3,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 9,
                    FirstName = "Karima",
                    LastName = "Adheswe",
                    RegimeTypeId = 3,
                    IsFixedNight = false,
                },
                new Nurse()
                {
                    Id = 10,
                    FirstName = "Latifa",
                    LastName = "Adhesha",
                    RegimeTypeId = 1,
                    IsFixedNight = true,
                },
                new Nurse()
                {
                    Id = 11,
                    FirstName = "Mariem",
                    LastName = "Sariedh",
                    RegimeTypeId = 1,
                    IsFixedNight = true,
                },
                new Nurse()
                {
                    Id = 12,
                    FirstName = "Nasira",
                    LastName = "Isira",
                    RegimeTypeId = 3,
                    IsFixedNight = true,
                }
            );
        }
    }
}
