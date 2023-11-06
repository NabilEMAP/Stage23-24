using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

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
                    Starttime = new TimeSpan(07, 00, 00),
                    Endtime = new TimeSpan(15, 00, 00),
                    ShiftTypeId = 1
                },
                new Shift()
                {
                    Id = 2,
                    Starttime = new TimeSpan(07, 00, 00),
                    Endtime = new TimeSpan(13, 30, 00),
                    ShiftTypeId = 1
                },
                new Shift()
                {
                    Id = 3,
                    Starttime = new TimeSpan(07, 00, 00),
                    Endtime = new TimeSpan(11, 00, 00),
                    ShiftTypeId = 1
                },
                new Shift()
                {
                    Id = 4,
                    Starttime = new TimeSpan(12, 30, 00),
                    Endtime = new TimeSpan(20, 30, 00),
                    ShiftTypeId = 2
                },
                new Shift()
                {
                    Id = 5,
                    Starttime = new TimeSpan(14, 00, 00),
                    Endtime = new TimeSpan(20, 30, 00),
                    ShiftTypeId = 2
                },
                new Shift()
                {
                    Id = 6,
                    Starttime = new TimeSpan(16, 00, 00),
                    Endtime = new TimeSpan(20, 00, 00),
                    ShiftTypeId = 2
                },
                new Shift()
                {
                    Id = 7,
                    Starttime = new TimeSpan(20, 15, 00),
                    Endtime = new TimeSpan(07, 15, 00),
                    ShiftTypeId = 3
                }
            );
        }
    }
}
