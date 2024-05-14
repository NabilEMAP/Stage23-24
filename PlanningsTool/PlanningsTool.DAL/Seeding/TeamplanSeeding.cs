using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class TeamplanSeeding
    {
        public static void Seed(this EntityTypeBuilder<Teamplan> modelBuilder)
        {
            modelBuilder.HasData(
                new Teamplan() { Id = 1, Name = "2024-05-14-16-00-Teamplan01", PlanFor = new DateTime(2024, 05, 01), CreatedOn = new DateTime(2024, 05, 14, 16, 00, 00) }
            );
        }
    }
}