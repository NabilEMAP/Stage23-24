using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class NurseShiftSeeding
    {
        public static void Seed(this EntityTypeBuilder<NurseShift> modelBuilder)
        {
            modelBuilder.HasData(
                new NurseShift() 
                {
                    Id = 1,
                    Date = new DateTime(2024, 05, 08),
                    NurseId = 1,
                    ShiftId = 1,
                    TeamplanId = 1,
                },
                new NurseShift()
                {
                    Id = 2,
                    Date = new DateTime(2024, 05, 06),
                    NurseId = 2,
                    ShiftId = 4,
                    TeamplanId = 1,
                },
                new NurseShift()
                {
                    Id = 3,
                    Date = new DateTime(2024, 05, 07),
                    NurseId = 3,
                    ShiftId = 7,
                    TeamplanId = 1,
                }
            );
        }
    }
}
