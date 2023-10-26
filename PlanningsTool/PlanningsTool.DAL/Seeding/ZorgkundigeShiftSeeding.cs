using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Seeding
{
    public static class ZorgkundigeShiftSeeding
    {
        public static void Seed(this EntityTypeBuilder<ZorgkundigeShift> modelBuilder)
        {
            modelBuilder.HasData(
                new ZorgkundigeShift() 
                {
                    Id = 1,
                    Datum = new DateTime(2024, 01, 08),
                    ZorgkundigeId = 1,
                    ShiftId = 1,
                    TeamplanningId = 1,
                },
                new ZorgkundigeShift()
                {
                    Id = 2,
                    Datum = new DateTime(2024, 01, 08),
                    ZorgkundigeId = 2,
                    ShiftId = 4,
                    TeamplanningId = 1,
                },
                new ZorgkundigeShift()
                {
                    Id = 3,
                    Datum = new DateTime(2024, 01, 08),
                    ZorgkundigeId = 3,
                    ShiftId = 7,
                    TeamplanningId = 1,
                }
            );
        }
    }
}
