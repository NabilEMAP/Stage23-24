using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class TeamplanSeeding
    {
        public static void Seed(this EntityTypeBuilder<Teamplan> modelBuilder)
        {
            modelBuilder.HasData(
                new Teamplan() { Id = 1, Name = "2024-05-16-00-07-19 W&L", PlanFor = new DateTime(2022, 03, 01), CreatedOn = new DateTime(2024, 05, 15, 22, 07, 19) }
            );
        }
    }
}
