using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class HolidaySeeding
    {
        public static void Seed(this EntityTypeBuilder<Holiday> modelBuilder)
        {
            modelBuilder.HasData(
                new Holiday() { Id = 1, Name = "Pasen", Date = new DateTime(2024, 03, 31), },
                new Holiday() { Id = 2, Name = "Paasmaandag", Date = new DateTime(2024, 04, 01), },
                new Holiday() { Id = 3, Name = "Pinksteren", Date = new DateTime(2024, 05, 19), },
                new Holiday() { Id = 4, Name = "Pinkstermaandag", Date = new DateTime(2024, 05, 20), },
                new Holiday() { Id = 5, Name = "O.L.H. Hemelvaart", Date = new DateTime(2024, 05, 09), },
                new Holiday() { Id = 6, Name = "Nieuwjaar", Date = new DateTime(2024, 01, 01), },
                new Holiday() { Id = 7, Name = "Dag van de arbeid", Date = new DateTime(2024, 05, 01), },
                new Holiday() { Id = 8, Name = "Nationale feestdag", Date = new DateTime(2024, 07, 21), },
                new Holiday() { Id = 9, Name = "O.L.V. Hemelvaart", Date = new DateTime(2024, 08, 15), },
                new Holiday() { Id = 10, Name = "Allerheiligen", Date = new DateTime(2024, 11, 01), },
                new Holiday() { Id = 11, Name = "Wapenstilstand", Date = new DateTime(2024, 11, 11), },
                new Holiday() { Id = 12, Name = "Kermis", Date = new DateTime(2024, 12, 25), }
            );
        }
    }
}