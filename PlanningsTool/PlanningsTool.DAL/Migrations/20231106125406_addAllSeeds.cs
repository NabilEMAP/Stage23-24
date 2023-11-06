using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class addAllSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RegimeTypes",
                columns: new[] { "Id", "CountHours", "Name" },
                values: new object[,]
                {
                    { 1, 38.0m, "Voltijds" },
                    { 2, 30.4m, "Deeltijds 4/5" },
                    { 3, 28.8m, "Deeltijds 3/4" },
                    { 4, 19.0m, "Halftijds" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ShiftTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vroege" },
                    { 2, "Late" },
                    { 3, "Nacht" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Teamplans",
                columns: new[] { "Id", "Month" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "VacationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Verlof" },
                    { 2, "Ziekte" },
                    { 3, "Arbeidsduurverkorting" },
                    { 4, "Wens" },
                    { 5, "Andere" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Nurses",
                columns: new[] { "Id", "FirstName", "IsFixedNight", "LastName", "RegimeId" },
                values: new object[,]
                {
                    { 1, "Amina", "0", "Woerahfa", 1 },
                    { 2, "Barbara", "0", "Tamara", 1 },
                    { 3, "Chaimae", "0", "Dhanitin", 1 },
                    { 4, "Dalila", "0", "Dhiyah", 1 },
                    { 5, "Fatima", "0", "Tsridh", 2 },
                    { 6, "Ghizlane", "0", "Mantazoedh", 2 },
                    { 7, "Halima", "0", "Hanatt", 2 },
                    { 8, "Imane", "0", "Azough", 3 },
                    { 9, "Karima", "0", "Adheswe", 3 },
                    { 10, "Latifa", "1", "Adhesha", 1 },
                    { 11, "Mariem", "1", "Sariedh", 1 },
                    { 12, "Nasira", "1", "Isira", 3 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Shifts",
                columns: new[] { "Id", "Endtime", "ShiftTypeId", "Starttime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 15, 0, 0, 0), 1, new TimeSpan(0, 7, 0, 0, 0) },
                    { 2, new TimeSpan(0, 13, 30, 0, 0), 1, new TimeSpan(0, 7, 0, 0, 0) },
                    { 3, new TimeSpan(0, 11, 0, 0, 0), 1, new TimeSpan(0, 7, 0, 0, 0) },
                    { 4, new TimeSpan(0, 20, 30, 0, 0), 2, new TimeSpan(0, 12, 30, 0, 0) },
                    { 5, new TimeSpan(0, 20, 30, 0, 0), 2, new TimeSpan(0, 14, 0, 0, 0) },
                    { 6, new TimeSpan(0, 20, 0, 0, 0), 2, new TimeSpan(0, 16, 0, 0, 0) },
                    { 7, new TimeSpan(0, 7, 15, 0, 0), 3, new TimeSpan(0, 20, 15, 0, 0) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "NurseShifts",
                columns: new[] { "Id", "Date", "NurseId", "ShiftId", "TeamplanId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 2, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 3, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7, 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Vacations",
                columns: new[] { "Id", "Enddate", "NurseId", "Reason", "Startdate", "VacationTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Verlofdagje op vrijdag.", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Heel de week ziek geweest.", new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ik ga eens terug in de tijd :D, eens zien of ik een error kan geven.", new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 4, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse fringilla nibh eu justo ullamcorper iaculis. Quisque at tellus at ex faucibus tempus ac eu nisi. In sapien sapien, pellentesque eu velit a, sodales faucibus urna. Ut est eros, efficitur eu suscipit quis, vulputate a metus. Vestibulum non ullamcorper lectus. Ut aliquam nunc sed arcu laoreet eleifend. Nam venenatis purus ipsum, ut condimentum quam vulputate id. Mauris id orci vel purus convallis volutpat ac sed nibh. Donec vitae dolor in tortor mollis consectetur. Nunc in ante tortor. Mauris sit amet semper lacus. Vivamus lacus neque, sodales id dolor vel, iaculis dictum tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Proin eu dui vel risus aliquam elementum eget id ligula.", new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NurseShifts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NurseShifts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NurseShifts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RegimeTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Shifts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Shifts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Shifts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Shifts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "VacationTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "VacationTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RegimeTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RegimeTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Shifts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Shifts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Shifts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Teamplans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "VacationTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "VacationTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "VacationTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RegimeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ShiftTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ShiftTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ShiftTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
