using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Seeding
{
    public static class TeamplanningSeeding
    {
        public static void Seed(this EntityTypeBuilder<Teamplanning> modelBuilder)
        {
            modelBuilder.HasData(
                new Teamplanning() { Id = 1, Maand = 1 },
                new Teamplanning() { Id = 2, Maand = 2 },
                new Teamplanning() { Id = 3, Maand = 3 },
                new Teamplanning() { Id = 4, Maand = 4 },
                new Teamplanning() { Id = 5, Maand = 5 },
                new Teamplanning() { Id = 6, Maand = 6 },
                new Teamplanning() { Id = 7, Maand = 7 },
                new Teamplanning() { Id = 8, Maand = 8 },
                new Teamplanning() { Id = 9, Maand = 9 },
                new Teamplanning() { Id = 10, Maand = 10 },
                new Teamplanning() { Id = 11, Maand = 11 },
                new Teamplanning() { Id = 12, Maand = 12 }
            );
        }
    }
}
