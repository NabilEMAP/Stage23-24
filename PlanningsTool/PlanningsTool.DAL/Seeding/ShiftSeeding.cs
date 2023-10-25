using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Seeding
{
    public static class ShiftSeeding
    {
        public static void Seed(this EntityTypeBuilder<Shift> modelBuilder)
        {
            modelBuilder.HasData(
                new Shift()
                {
                    Id = 1,
                    Starttijd = new TimeSpan(07, 00, 00),
                    Eindtijd = new TimeSpan(15, 00, 00),
                    ShiftTypeId = 1
                },
                new Shift()
                {
                    Id = 2,
                    Starttijd = new TimeSpan(07, 00, 00),
                    Eindtijd = new TimeSpan(13, 30, 00),
                    ShiftTypeId = 1
                },
                new Shift()
                {
                    Id = 3,
                    Starttijd = new TimeSpan(07, 00, 00),
                    Eindtijd = new TimeSpan(11, 00, 00),
                    ShiftTypeId = 1
                },
                new Shift()
                {
                    Id = 4,
                    Starttijd = new TimeSpan(12, 30, 00),
                    Eindtijd = new TimeSpan(20, 30, 00),
                    ShiftTypeId = 2
                },
                new Shift()
                {
                    Id = 5,
                    Starttijd = new TimeSpan(14, 00, 00),
                    Eindtijd = new TimeSpan(20, 30, 00),
                    ShiftTypeId = 2
                },
                new Shift()
                {
                    Id = 6,
                    Starttijd = new TimeSpan(16, 00, 00),
                    Eindtijd = new TimeSpan(20, 00, 00),
                    ShiftTypeId = 2
                },
                new Shift()
                {
                    Id = 7,
                    Starttijd = new TimeSpan(20, 15, 00),
                    Eindtijd = new TimeSpan(07, 15, 00),
                    ShiftTypeId = 3
                }
            );
        }
    }
}
