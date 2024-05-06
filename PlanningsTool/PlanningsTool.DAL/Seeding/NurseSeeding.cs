using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class NurseSeeding
    {
        public static void Seed(this EntityTypeBuilder<Nurse> modelBuilder)
        {
            modelBuilder.HasData(
                new Nurse() { Id = 1, FirstName = "Amina", LastName = "Woerahfa", RegimeTypeId = 1, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id = 2, FirstName = "Barbara", LastName = "Tamara", RegimeTypeId = 1, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id = 3, FirstName = "Chaimae", LastName = "Dhanitin", RegimeTypeId = 1, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id = 4, FirstName = "Dalila", LastName = "Dhiyah", RegimeTypeId = 1, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id = 5, FirstName = "Fatima", LastName = "Tsridh", RegimeTypeId = 2, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id = 6, FirstName = "Ghizlane", LastName = "Mantazoedh", RegimeTypeId = 2, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id = 7, FirstName = "Halima", LastName = "Hanatt", RegimeTypeId = 2, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id = 8, FirstName = "Imane", LastName = "Azough", RegimeTypeId = 3, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id = 9, FirstName = "Karima", LastName = "Adheswe", RegimeTypeId = 3, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id = 10, FirstName = "Latifa", LastName = "Adhesha", RegimeTypeId = 1, IsFixedNight = true, TeamId = 1, },
                new Nurse() { Id = 11, FirstName = "Mariem", LastName = "Sariedh", RegimeTypeId = 1, IsFixedNight = true, TeamId = 1, },
                new Nurse() { Id = 12, FirstName = "Nasira", LastName = "Isira", RegimeTypeId = 3, IsFixedNight = true, TeamId = 1, },

                new Nurse() { Id = 13, FirstName = "Alpha", LastName = "Zachman", RegimeTypeId = 1, IsFixedNight = false, TeamId = 2, },
                new Nurse() { Id = 14, FirstName = "Bravo", LastName = "Youngblood", RegimeTypeId = 1, IsFixedNight = false, TeamId = 2, },
                new Nurse() { Id = 15, FirstName = "Charlie", LastName = "Xanthos", RegimeTypeId = 1, IsFixedNight = false, TeamId = 2, },
                new Nurse() { Id = 16, FirstName = "Delta", LastName = "Wackerman", RegimeTypeId = 1, IsFixedNight = false, TeamId = 2, },
                new Nurse() { Id = 17, FirstName = "Echo", LastName = "Valachovic", RegimeTypeId = 2, IsFixedNight = false, TeamId = 2, },
                new Nurse() { Id = 18, FirstName = "Foxtrot", LastName = "Uffelman", RegimeTypeId = 2, IsFixedNight = false, TeamId = 2, },
                new Nurse() { Id = 19, FirstName = "Golf", LastName = "Todd", RegimeTypeId = 2, IsFixedNight = false, TeamId = 2, },
                new Nurse() { Id = 20, FirstName = "Hotel", LastName = "Scott", RegimeTypeId = 3, IsFixedNight = false, TeamId = 2, },
                new Nurse() { Id = 21, FirstName = "India", LastName = "Richardson", RegimeTypeId = 3, IsFixedNight = false, TeamId = 2, },
                new Nurse() { Id = 22, FirstName = "Julliett", LastName = "Quintero", RegimeTypeId = 1, IsFixedNight = true, TeamId = 2, },
                new Nurse() { Id = 23, FirstName = "Kilo", LastName = "Patterson", RegimeTypeId = 1, IsFixedNight = true, TeamId = 2, },
                new Nurse() { Id = 24, FirstName = "Lima", LastName = "Owen", RegimeTypeId = 3, IsFixedNight = true, TeamId = 2, },

                new Nurse() { Id = 25, FirstName = "Nabil", LastName = "El Moussaoui", RegimeTypeId = 1, IsFixedNight = false, TeamId = 3, }
            );
        }
    }
}