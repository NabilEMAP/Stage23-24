using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class NurseSeeding
    {
        public static void Seed(this EntityTypeBuilder<Nurse> modelBuilder)
        {
            modelBuilder.HasData(
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
                new Nurse() { Id = 12, FirstName = "Zorgkundige", LastName = "12", RegimeTypeId = 3, IsFixedNight = true,  TeamId = 1, }
            );
        }
    }
}