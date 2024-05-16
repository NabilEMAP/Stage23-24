using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class NurseSeeding
    {
        public static void Seed(this EntityTypeBuilder<Nurse> modelBuilder)
        {
            modelBuilder.HasData(
                // Team W&L
                new Nurse() { Id =  1, FirstName = "Zorgkundige", LastName = "01", RegimeTypeId = 2, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id =  2, FirstName = "Zorgkundige", LastName = "02", RegimeTypeId = 1, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id =  3, FirstName = "Zorgkundige", LastName = "03", RegimeTypeId = 1, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id =  4, FirstName = "Zorgkundige", LastName = "04", RegimeTypeId = 3, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id =  5, FirstName = "Zorgkundige", LastName = "05", RegimeTypeId = 1, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id =  6, FirstName = "Zorgkundige", LastName = "06", RegimeTypeId = 2, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id =  7, FirstName = "Zorgkundige", LastName = "07", RegimeTypeId = 1, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id =  8, FirstName = "Zorgkundige", LastName = "08", RegimeTypeId = 2, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id =  9, FirstName = "Zorgkundige", LastName = "09", RegimeTypeId = 3, IsFixedNight = false, TeamId = 1, },
                new Nurse() { Id = 10, FirstName = "Zorgkundige", LastName = "10", RegimeTypeId = 3, IsFixedNight = true,  TeamId = 1, },
                new Nurse() { Id = 11, FirstName = "Zorgkundige", LastName = "11", RegimeTypeId = 1, IsFixedNight = true,  TeamId = 1, },
                new Nurse() { Id = 12, FirstName = "Zorgkundige", LastName = "12", RegimeTypeId = 3, IsFixedNight = true,  TeamId = 1, },
                
                // Team Red
                new Nurse() { Id = 13, FirstName = "Emily", LastName = "Johnson", RegimeTypeId = 1, IsFixedNight = false,  TeamId = 2, },
                new Nurse() { Id = 14, FirstName = "Sophia", LastName = "Martinez", RegimeTypeId = 1, IsFixedNight = false,  TeamId = 2, },
                new Nurse() { Id = 15, FirstName = "Olivia", LastName = "Thompson", RegimeTypeId = 1, IsFixedNight = false,  TeamId = 2, },
                new Nurse() { Id = 16, FirstName = "Ava", LastName = "Davis", RegimeTypeId = 1, IsFixedNight = false,  TeamId = 2, },
                new Nurse() { Id = 17, FirstName = "Mia", LastName = "Rodriguez", RegimeTypeId = 1, IsFixedNight = false,  TeamId = 2, },
                new Nurse() { Id = 18, FirstName = "Isabella", LastName = "Garcia", RegimeTypeId = 1, IsFixedNight = false,  TeamId = 2, },
                new Nurse() { Id = 19, FirstName = "Charlotte", LastName = "Hernandez", RegimeTypeId = 2, IsFixedNight = false,  TeamId = 2, },
                new Nurse() { Id = 20, FirstName = "Amelia", LastName = "Wilson", RegimeTypeId = 2, IsFixedNight = false,  TeamId = 2, },
                new Nurse() { Id = 21, FirstName = "Harper", LastName = "Lopez", RegimeTypeId = 3, IsFixedNight = false,  TeamId = 2, },
                new Nurse() { Id = 22, FirstName = "Evelyn", LastName = "Lee", RegimeTypeId = 1, IsFixedNight = true,  TeamId = 2, },
                new Nurse() { Id = 23, FirstName = "Abigail", LastName = "Perez", RegimeTypeId = 1, IsFixedNight = true,  TeamId = 2, },
                new Nurse() { Id = 24, FirstName = "Ella", LastName = "Scott", RegimeTypeId = 2, IsFixedNight = true,  TeamId = 2, },

                // Team Blue
                new Nurse() { Id = 25, FirstName = "Emma", LastName = "Nguyen", RegimeTypeId = 3, IsFixedNight = false,  TeamId = 3, },
                new Nurse() { Id = 26, FirstName = "Madison", LastName = "Taylor", RegimeTypeId = 2, IsFixedNight = false,  TeamId = 3, },
                new Nurse() { Id = 27, FirstName = "Elizabeth", LastName = "Wright", RegimeTypeId = 1, IsFixedNight = false,  TeamId = 3, },
                new Nurse() { Id = 28, FirstName = "Grace", LastName = "King", RegimeTypeId = 1, IsFixedNight = true,  TeamId = 3, },
                new Nurse() { Id = 29, FirstName = "Victoria", LastName = "Adams", RegimeTypeId = 3, IsFixedNight = false,  TeamId = 3, },
                new Nurse() { Id = 30, FirstName = "Claire", LastName = "Turner", RegimeTypeId = 2, IsFixedNight = false,  TeamId = 3, },
                new Nurse() { Id = 31, FirstName = "Lily", LastName = "Parker", RegimeTypeId = 1, IsFixedNight = false,  TeamId = 3, },
                new Nurse() { Id = 32, FirstName = "Zoey", LastName = "Lewis", RegimeTypeId = 2, IsFixedNight = true,  TeamId = 3, },
                new Nurse() { Id = 33, FirstName = "Riley", LastName = "Hill", RegimeTypeId = 3, IsFixedNight = false,  TeamId = 3, },
                new Nurse() { Id = 34, FirstName = "Aria", LastName = "Ross", RegimeTypeId = 3, IsFixedNight = false,  TeamId = 3, },
                new Nurse() { Id = 35, FirstName = "Stella", LastName = "Reed", RegimeTypeId = 3, IsFixedNight = false,  TeamId = 3, },
                new Nurse() { Id = 36, FirstName = "Chloe", LastName = "Cooper", RegimeTypeId = 1, IsFixedNight = true,  TeamId = 3, },

                // Team New
                new Nurse() { Id = 37, FirstName = "Nabil", LastName = "El Moussaoui", RegimeTypeId = 1, IsFixedNight = true,  TeamId = 4, }
            );
        }
    }
}