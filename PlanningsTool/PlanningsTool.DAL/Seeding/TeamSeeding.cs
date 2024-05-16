using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Seeding
{
    public static class TeamSeeding
    {
        public static void Seed(this EntityTypeBuilder<Team> modelBuilder)
        {
            modelBuilder.HasData(
                new Team() { Id = 1, TeamName = "Team W&L" },
                new Team() { Id = 2, TeamName = "Team Red" },
                new Team() { Id = 3, TeamName = "Team Blue" },
                new Team() { Id = 4, TeamName = "Team New" }
            );
        }
    }
}