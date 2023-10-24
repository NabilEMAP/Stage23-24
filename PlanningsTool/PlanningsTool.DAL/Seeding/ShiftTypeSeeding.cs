using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Seeding
{
    public static class ShiftTypeSeeding
    {
        public static void Seed(this EntityTypeBuilder<ShiftType> modelBuilder)
        {
            modelBuilder.HasData(
                new ShiftType()
                {
                    Id = 1,
                    Shift = "Vroege",
                },
                new ShiftType()
                {
                    Id = 2,
                    Shift = "Late",
                },
                new ShiftType()
                {
                    Id = 3,
                    Shift = "Nacht",
                }
            );
        }
    }
}
