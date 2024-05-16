using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class HolidaySeeding
    {
        public static void Seed(this EntityTypeBuilder<Holiday> modelBuilder)
        {
            modelBuilder.HasData(
                new Holiday() { Id =  1, Name = "Pasen", Date = new DateTime(2022, 04, 17), },
                new Holiday() { Id =  2, Name = "Paasmaandag", Date = new DateTime(2022, 04, 18), },
                new Holiday() { Id =  3, Name = "Pinksteren", Date = new DateTime(2022, 06, 05), },
                new Holiday() { Id =  4, Name = "Pinkstermaandag", Date = new DateTime(2022, 06, 06), },
                new Holiday() { Id =  5, Name = "O.L.H. Hemelvaart", Date = new DateTime(2022, 05, 26), },
                new Holiday() { Id =  6, Name = "Nieuwjaar", Date = new DateTime(2022, 01, 01), },
                new Holiday() { Id =  7, Name = "Dag van de arbeid", Date = new DateTime(2022, 05, 01), },
                new Holiday() { Id =  8, Name = "Nationale feestdag", Date = new DateTime(2022, 07, 21), },
                new Holiday() { Id =  9, Name = "O.L.V. Hemelvaart", Date = new DateTime(2022, 08, 15), },
                new Holiday() { Id = 10, Name = "Allerheiligen", Date = new DateTime(2022, 11, 01), },
                new Holiday() { Id = 11, Name = "Wapenstilstand", Date = new DateTime(2022, 11, 11), },
                new Holiday() { Id = 12, Name = "Kermis", Date = new DateTime(2022, 12, 25), },
                new Holiday() { Id = 13, Name = "Pasen", Date = new DateTime(2023, 04, 09), },
                new Holiday() { Id = 14, Name = "Paasmaandag", Date = new DateTime(2023, 04, 10), },
                new Holiday() { Id = 15, Name = "Pinksteren", Date = new DateTime(2023, 05, 28), },
                new Holiday() { Id = 16, Name = "Pinkstermaandag", Date = new DateTime(2023, 05, 29), },
                new Holiday() { Id = 17, Name = "O.L.H. Hemelvaart", Date = new DateTime(2023, 05, 18), },
                new Holiday() { Id = 18, Name = "Nieuwjaar", Date = new DateTime(2023, 01, 01), },
                new Holiday() { Id = 19, Name = "Dag van de arbeid", Date = new DateTime(2023, 05, 01), },
                new Holiday() { Id = 20, Name = "Nationale feestdag", Date = new DateTime(2023, 07, 21), },
                new Holiday() { Id = 21, Name = "O.L.V. Hemelvaart", Date = new DateTime(2023, 08, 15), },
                new Holiday() { Id = 22, Name = "Allerheiligen", Date = new DateTime(2023, 11, 01), },
                new Holiday() { Id = 23, Name = "Wapenstilstand", Date = new DateTime(2023, 11, 11), },
                new Holiday() { Id = 24, Name = "Kermis", Date = new DateTime(2023, 12, 25), },
                new Holiday() { Id = 25, Name = "Pasen", Date = new DateTime(2024, 03, 31), },
                new Holiday() { Id = 26, Name = "Paasmaandag", Date = new DateTime(2024, 04, 01), },
                new Holiday() { Id = 27, Name = "Pinksteren", Date = new DateTime(2024, 05, 19), },
                new Holiday() { Id = 28, Name = "Pinkstermaandag", Date = new DateTime(2024, 05, 20), },
                new Holiday() { Id = 29, Name = "O.L.H. Hemelvaart", Date = new DateTime(2024, 05, 09), },
                new Holiday() { Id = 30, Name = "Nieuwjaar", Date = new DateTime(2024, 01, 01), },
                new Holiday() { Id = 31, Name = "Dag van de arbeid", Date = new DateTime(2024, 05, 01), },
                new Holiday() { Id = 32, Name = "Nationale feestdag", Date = new DateTime(2024, 07, 21), },
                new Holiday() { Id = 33, Name = "O.L.V. Hemelvaart", Date = new DateTime(2024, 08, 15), },
                new Holiday() { Id = 34, Name = "Allerheiligen", Date = new DateTime(2024, 11, 01), },
                new Holiday() { Id = 35, Name = "Wapenstilstand", Date = new DateTime(2024, 11, 11), },
                new Holiday() { Id = 36, Name = "Kermis", Date = new DateTime(2024, 12, 25), }
            );
        }
    }
}