using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class VacationSeeding
    {
        public static void Seed(this EntityTypeBuilder<Vacation> modelBuilder)
        {
            modelBuilder.HasData(
                new Vacation() { Id =  1, Startdate = new DateTime(2022, 03, 01), Enddate = new DateTime(2022, 03, 01), Reason = "", NurseId =  1, VacationTypeId = 1 },
                new Vacation() { Id =  2, Startdate = new DateTime(2022, 03, 03), Enddate = new DateTime(2022, 03, 04), Reason = "", NurseId =  1, VacationTypeId = 1 },
                new Vacation() { Id =  3, Startdate = new DateTime(2022, 03, 03), Enddate = new DateTime(2022, 03, 03), Reason = "", NurseId =  2, VacationTypeId = 1 },
                new Vacation() { Id =  4, Startdate = new DateTime(2022, 03, 16), Enddate = new DateTime(2022, 03, 16), Reason = "", NurseId =  2, VacationTypeId = 1 },
                new Vacation() { Id =  5, Startdate = new DateTime(2022, 03, 01), Enddate = new DateTime(2022, 03, 09), Reason = "", NurseId =  3, VacationTypeId = 2 },
                new Vacation() { Id =  6, Startdate = new DateTime(2022, 03, 10), Enddate = new DateTime(2022, 04, 01), Reason = "", NurseId =  3, VacationTypeId = 2 },
                new Vacation() { Id =  7, Startdate = new DateTime(2022, 03, 01), Enddate = new DateTime(2022, 03, 11), Reason = "", NurseId =  4, VacationTypeId = 2 },
                new Vacation() { Id =  8, Startdate = new DateTime(2022, 03, 12), Enddate = new DateTime(2022, 04, 01), Reason = "", NurseId =  4, VacationTypeId = 1 },
                new Vacation() { Id =  9, Startdate = new DateTime(2022, 03, 16), Enddate = new DateTime(2022, 03, 23), Reason = "", NurseId =  5, VacationTypeId = 1 },
                new Vacation() { Id = 10, Startdate = new DateTime(2022, 03, 21), Enddate = new DateTime(2022, 03, 22), Reason = "", NurseId =  6, VacationTypeId = 1 },
                new Vacation() { Id = 11, Startdate = new DateTime(2022, 03, 24), Enddate = new DateTime(2022, 03, 25), Reason = "", NurseId =  7, VacationTypeId = 1 },
                new Vacation() { Id = 12, Startdate = new DateTime(2022, 03, 28), Enddate = new DateTime(2022, 04, 01), Reason = "", NurseId =  7, VacationTypeId = 1 },
                new Vacation() { Id = 13, Startdate = new DateTime(2022, 03, 01), Enddate = new DateTime(2022, 03, 01), Reason = "", NurseId =  8, VacationTypeId = 1 },
                new Vacation() { Id = 14, Startdate = new DateTime(2022, 03, 03), Enddate = new DateTime(2022, 03, 04), Reason = "", NurseId =  8, VacationTypeId = 1 },
                new Vacation() { Id = 15, Startdate = new DateTime(2022, 03, 23), Enddate = new DateTime(2022, 03, 24), Reason = "", NurseId = 10, VacationTypeId = 1 },
                new Vacation() { Id = 16, Startdate = new DateTime(2022, 03, 02), Enddate = new DateTime(2022, 03, 02), Reason = "", NurseId = 11, VacationTypeId = 1 },
                new Vacation() { Id = 17, Startdate = new DateTime(2022, 03, 11), Enddate = new DateTime(2022, 03, 11), Reason = "", NurseId = 11, VacationTypeId = 1 },
                new Vacation() { Id = 18, Startdate = new DateTime(2022, 03, 21), Enddate = new DateTime(2022, 03, 21), Reason = "", NurseId = 11, VacationTypeId = 1 },
                new Vacation() { Id = 19, Startdate = new DateTime(2022, 03, 03), Enddate = new DateTime(2022, 03, 04), Reason = "", NurseId = 12, VacationTypeId = 1 },
                new Vacation() { Id = 20, Startdate = new DateTime(2022, 03, 15), Enddate = new DateTime(2022, 03, 18), Reason = "", NurseId = 12, VacationTypeId = 1 },
                new Vacation() { Id = 21, Startdate = new DateTime(2022, 03, 29), Enddate = new DateTime(2022, 03, 29), Reason = "", NurseId = 12, VacationTypeId = 1 },
                new Vacation() { Id = 22, Startdate = new DateTime(2022, 04, 01), Enddate = new DateTime(2022, 04, 01), Reason = "", NurseId = 12, VacationTypeId = 1 }
            );
        }
    }
}
