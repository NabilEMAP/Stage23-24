using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class addTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                schema: "dbo",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Holidays",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasen" },
                    { 2, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paasmaandag" },
                    { 3, new DateTime(2024, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pinksteren" },
                    { 4, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pinkstermaandag" },
                    { 5, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.L.H. Hemelvaart" },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nieuwjaar" },
                    { 7, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dag van de arbeid" },
                    { 8, new DateTime(2024, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nationale feestdag" },
                    { 9, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.L.V. Hemelvaart" },
                    { 10, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allerheiligen" },
                    { 11, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wapenstilstand" },
                    { 12, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kermis" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NurseShifts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NurseShifts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NurseShifts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Team",
                columns: new[] { "Id", "TeamName" },
                values: new object[,]
                {
                    { 1, "Team Magribien" },
                    { 2, "Team Iromien" },
                    { 3, "New Team" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Enddate", "Startdate" },
                values: new object[] { new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Enddate", "Startdate" },
                values: new object[] { new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Enddate", "Reason", "Startdate" },
                values: new object[] { new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afwezig.", new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Enddate", "Startdate" },
                values: new object[] { new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 1,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 2,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 3,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 4,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 5,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 6,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 7,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 8,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 9,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 10,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 11,
                column: "TeamId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 12,
                column: "TeamId",
                value: 1);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Nurses",
                columns: new[] { "Id", "FirstName", "IsFixedNight", "LastName", "RegimeTypeId", "TeamId" },
                values: new object[,]
                {
                    { 13, "Alpha", "0", "Zachman", 1, 2 },
                    { 14, "Bravo", "0", "Youngblood", 1, 2 },
                    { 15, "Charlie", "0", "Xanthos", 1, 2 },
                    { 16, "Delta", "0", "Wackerman", 1, 2 },
                    { 17, "Echo", "0", "Valachovic", 2, 2 },
                    { 18, "Foxtrot", "0", "Uffelman", 2, 2 },
                    { 19, "Golf", "0", "Todd", 2, 2 },
                    { 20, "Hotel", "0", "Scott", 3, 2 },
                    { 21, "India", "0", "Richardson", 3, 2 },
                    { 22, "Julliett", "1", "Quintero", 1, 2 },
                    { 23, "Kilo", "1", "Patterson", 1, 2 },
                    { 24, "Lima", "1", "Owen", 3, 2 },
                    { 25, "Nabil", "0", "El Moussaoui", 1, 3 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Vacations",
                columns: new[] { "Id", "Enddate", "NurseId", "Reason", "Startdate", "VacationTypeId" },
                values: new object[] { 5, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Afspraak UZA Gastro", new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Vacations",
                columns: new[] { "Id", "Enddate", "NurseId", "Reason", "Startdate", "VacationTypeId" },
                values: new object[] { 6, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Afspraak plannen voor Rijbewijs terugkommoment", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_TeamId",
                schema: "dbo",
                table: "Nurses",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Id",
                schema: "dbo",
                table: "Team",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_Team_TeamId",
                schema: "dbo",
                table: "Nurses",
                column: "TeamId",
                principalSchema: "dbo",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_Team_TeamId",
                schema: "dbo",
                table: "Nurses");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Nurses_TeamId",
                schema: "dbo",
                table: "Nurses");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DropColumn(
                name: "TeamId",
                schema: "dbo",
                table: "Nurses");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NurseShifts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NurseShifts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NurseShifts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Enddate", "Startdate" },
                values: new object[] { new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Enddate", "Startdate" },
                values: new object[] { new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Enddate", "Reason", "Startdate" },
                values: new object[] { new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ik ga eens terug in de tijd :D, eens zien of ik een error kan geven.", new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Enddate", "Startdate" },
                values: new object[] { new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
