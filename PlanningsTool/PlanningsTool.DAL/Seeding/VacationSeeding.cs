using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class VacationSeeding
    {
        public static void Seed(this EntityTypeBuilder<Vacation> modelBuilder)
        {
            modelBuilder.HasData(
                new Vacation()
                {
                    Id = 1,
                    Startdate = new DateTime(2024, 05, 03),
                    Enddate = new DateTime(2024, 05, 03),
                    Reason = "Verlofdagje op vrijdag.",
                    NurseId = 1,
                    VacationTypeId = 1
                },
                new Vacation()
                {
                    Id = 2,
                    Startdate = new DateTime(2024, 04, 29),
                    Enddate = new DateTime(2024, 05, 03),
                    Reason = "Heel de week ziek geweest.",
                    NurseId = 2,
                    VacationTypeId = 2
                },
                new Vacation()
                {
                    Id = 3,
                    Startdate = new DateTime(2024, 05, 14),
                    Enddate = new DateTime(2024, 05, 14),
                    Reason = "Afwezig.",
                    NurseId = 3,
                    VacationTypeId = 5
                },
                new Vacation()
                {
                    Id = 4,
                    Startdate = new DateTime(2024, 05, 25),
                    Enddate = new DateTime(2024, 05, 1),
                    Reason = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse fringilla nibh eu justo ullamcorper iaculis. Quisque at tellus at ex faucibus tempus ac eu nisi. In sapien sapien, pellentesque eu velit a, sodales faucibus urna. Ut est eros, efficitur eu suscipit quis, vulputate a metus. Vestibulum non ullamcorper lectus. Ut aliquam nunc sed arcu laoreet eleifend. Nam venenatis purus ipsum, ut condimentum quam vulputate id. Mauris id orci vel purus convallis volutpat ac sed nibh. Donec vitae dolor in tortor mollis consectetur. Nunc in ante tortor. Mauris sit amet semper lacus. Vivamus lacus neque, sodales id dolor vel, iaculis dictum tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Proin eu dui vel risus aliquam elementum eget id ligula.",
                    NurseId = 4,
                    VacationTypeId = 5
                },
                new Vacation()
                {
                    Id = 5,
                    Startdate = new DateTime(2024, 05, 13),
                    Enddate = new DateTime(2024, 05, 13),
                    Reason = "Afspraak UZA Gastro",
                    NurseId = 25,
                    VacationTypeId = 2
                },
                new Vacation()
                {
                    Id = 6,
                    Startdate = new DateTime(2024, 06, 01),
                    Enddate = new DateTime(2024, 06, 05),
                    Reason = "Afspraak plannen voor Rijbewijs terugkommoment",
                    NurseId = 25,
                    VacationTypeId = 4
                }
            );
        }
    }
}
