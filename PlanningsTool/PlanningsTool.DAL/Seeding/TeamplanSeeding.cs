using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class TeamplanSeeding
    {
        public static void Seed(this EntityTypeBuilder<Teamplan> modelBuilder)
        {
            modelBuilder.HasData(
                new Teamplan() { Id = 1, Month = 1 },
                new Teamplan() { Id = 2, Month = 2 },
                new Teamplan() { Id = 3, Month = 3 },
                new Teamplan() { Id = 4, Month = 4 },
                new Teamplan() { Id = 5, Month = 5 },
                new Teamplan() { Id = 6, Month = 6 },
                new Teamplan() { Id = 7, Month = 7 },
                new Teamplan() { Id = 8, Month = 8 },
                new Teamplan() { Id = 9, Month = 9 },
                new Teamplan() { Id = 10, Month = 10 },
                new Teamplan() { Id = 11, Month = 11 },
                new Teamplan() { Id = 12, Month = 12 }
            );
        }
    }
}
