using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class seedingMoreTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Holidays",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegimeTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    CountHours = table.Column<decimal>(type: "decimal(3,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegimeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Teamplans",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    PlanFor = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teamplans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Starttime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Endtime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ShiftTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_ShiftTypes_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalSchema: "dbo",
                        principalTable: "ShiftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    RegimeTypeId = table.Column<int>(type: "int", nullable: false),
                    IsFixedNight = table.Column<string>(type: "char(1)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_RegimeTypes_RegimeTypeId",
                        column: x => x.RegimeTypeId,
                        principalSchema: "dbo",
                        principalTable: "RegimeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nurses_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NurseShifts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    NurseId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    TeamplanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseShifts_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalSchema: "dbo",
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseShifts_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalSchema: "dbo",
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseShifts_Teamplans_TeamplanId",
                        column: x => x.TeamplanId,
                        principalSchema: "dbo",
                        principalTable: "Teamplans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Startdate = table.Column<DateTime>(type: "date", nullable: false),
                    Enddate = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NurseId = table.Column<int>(type: "int", nullable: false),
                    VacationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacations_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalSchema: "dbo",
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacations_VacationTypes_VacationTypeId",
                        column: x => x.VacationTypeId,
                        principalSchema: "dbo",
                        principalTable: "VacationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Holidays",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasen" },
                    { 2, new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paasmaandag" },
                    { 3, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pinksteren" },
                    { 4, new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pinkstermaandag" },
                    { 5, new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.L.H. Hemelvaart" },
                    { 6, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nieuwjaar" },
                    { 7, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dag van de arbeid" },
                    { 8, new DateTime(2022, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nationale feestdag" },
                    { 9, new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.L.V. Hemelvaart" },
                    { 10, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allerheiligen" },
                    { 11, new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wapenstilstand" },
                    { 12, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kermis" },
                    { 13, new DateTime(2023, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasen" },
                    { 14, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paasmaandag" },
                    { 15, new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pinksteren" },
                    { 16, new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pinkstermaandag" },
                    { 17, new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.L.H. Hemelvaart" },
                    { 18, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nieuwjaar" },
                    { 19, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dag van de arbeid" },
                    { 20, new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nationale feestdag" },
                    { 21, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.L.V. Hemelvaart" },
                    { 22, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allerheiligen" },
                    { 23, new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wapenstilstand" },
                    { 24, new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kermis" },
                    { 25, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasen" },
                    { 26, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paasmaandag" },
                    { 27, new DateTime(2024, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pinksteren" },
                    { 28, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pinkstermaandag" },
                    { 29, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.L.H. Hemelvaart" },
                    { 30, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nieuwjaar" },
                    { 31, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dag van de arbeid" },
                    { 32, new DateTime(2024, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nationale feestdag" },
                    { 33, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.L.V. Hemelvaart" },
                    { 34, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allerheiligen" },
                    { 35, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wapenstilstand" },
                    { 36, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kermis" }
                });

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
                    { 2, "Late" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ShiftTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Nacht" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Team",
                columns: new[] { "Id", "TeamName" },
                values: new object[,]
                {
                    { 1, "Team W&L" },
                    { 2, "Team Red" },
                    { 3, "Team Blue" },
                    { 4, "Team New" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Teamplans",
                columns: new[] { "Id", "CreatedOn", "Name", "PlanFor" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 15, 22, 7, 19, 0, DateTimeKind.Unspecified), "2024-05-16-00-07-19 W&L", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 5, 16, 11, 51, 59, 0, DateTimeKind.Unspecified), "2024-05-16-13-51-19 TeamRed", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 5, 16, 11, 52, 14, 0, DateTimeKind.Unspecified), "2024-05-16-13-52-19 TeamBlue", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                columns: new[] { "Id", "FirstName", "IsFixedNight", "LastName", "RegimeTypeId", "TeamId" },
                values: new object[,]
                {
                    { 1, "Zorgkundige", "0", "01", 2, 1 },
                    { 2, "Zorgkundige", "0", "02", 1, 1 },
                    { 3, "Zorgkundige", "0", "03", 1, 1 },
                    { 4, "Zorgkundige", "0", "04", 3, 1 },
                    { 5, "Zorgkundige", "0", "05", 1, 1 },
                    { 6, "Zorgkundige", "0", "06", 2, 1 },
                    { 7, "Zorgkundige", "0", "07", 1, 1 },
                    { 8, "Zorgkundige", "0", "08", 2, 1 },
                    { 9, "Zorgkundige", "0", "09", 3, 1 },
                    { 10, "Zorgkundige", "1", "10", 3, 1 },
                    { 11, "Zorgkundige", "1", "11", 1, 1 },
                    { 12, "Zorgkundige", "1", "12", 3, 1 },
                    { 13, "Emily", "1", "Johnson", 1, 2 },
                    { 14, "Sophia", "1", "Martinez", 1, 2 },
                    { 15, "Olivia", "1", "Thompson", 1, 2 },
                    { 16, "Ava", "1", "Davis", 1, 2 },
                    { 17, "Mia", "1", "Rodriguez", 1, 2 },
                    { 18, "Isabella", "1", "Garcia", 1, 2 },
                    { 19, "Charlotte", "1", "Hernandez", 2, 2 },
                    { 20, "Amelia", "1", "Wilson", 2, 2 },
                    { 21, "Harper", "1", "Lopez", 3, 2 },
                    { 22, "Evelyn", "1", "Lee", 1, 2 },
                    { 23, "Abigail", "1", "Perez", 1, 2 },
                    { 24, "Ella", "1", "Scott", 2, 2 },
                    { 25, "Emma", "1", "Nguyen", 3, 3 },
                    { 26, "Madison", "1", "Taylor", 2, 3 },
                    { 27, "Elizabeth", "1", "Wright", 1, 3 },
                    { 28, "Grace", "1", "King", 1, 3 },
                    { 29, "Victoria", "1", "Adams", 3, 3 },
                    { 30, "Claire", "1", "Turner", 2, 3 },
                    { 31, "Lily", "1", "Parker", 1, 3 },
                    { 32, "Zoey", "1", "Lewis", 2, 3 },
                    { 33, "Riley", "1", "Hill", 3, 3 },
                    { 34, "Aria", "1", "Ross", 3, 3 },
                    { 35, "Stella", "1", "Reed", 3, 3 },
                    { 36, "Chloe", "1", "Cooper", 1, 3 },
                    { 37, "Nabil", "1", "El Moussaoui", 1, 4 }
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
                    { 5, new TimeSpan(0, 20, 30, 0, 0), 2, new TimeSpan(0, 14, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Shifts",
                columns: new[] { "Id", "Endtime", "ShiftTypeId", "Starttime" },
                values: new object[] { 6, new TimeSpan(0, 20, 0, 0, 0), 2, new TimeSpan(0, 16, 0, 0, 0) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Shifts",
                columns: new[] { "Id", "Endtime", "ShiftTypeId", "Starttime" },
                values: new object[] { 7, new TimeSpan(0, 7, 15, 0, 0), 3, new TimeSpan(0, 20, 15, 0, 0) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "NurseShifts",
                columns: new[] { "Id", "Date", "NurseId", "ShiftId", "TeamplanId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 2, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 3, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 4, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 5, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 6, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 7, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 8, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 9, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 10, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 11, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 12, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 13, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 14, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 15, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 16, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 17, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 18, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 19, new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 20, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 21, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 22, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 23, new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 24, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 25, new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 26, new DateTime(2022, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 27, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 28, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 29, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 30, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 31, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 32, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 33, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 34, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 35, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 36, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 37, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 38, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 39, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 40, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 41, new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 42, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "NurseShifts",
                columns: new[] { "Id", "Date", "NurseId", "ShiftId", "TeamplanId" },
                values: new object[,]
                {
                    { 43, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 44, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 45, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 46, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 47, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 48, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 49, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 50, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 51, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 52, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 53, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 54, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 55, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 56, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 57, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 58, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 59, new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 60, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 61, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 62, new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 63, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 64, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 65, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 66, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 67, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 68, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 69, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 70, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 71, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 72, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 73, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 74, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 75, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 76, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1 },
                    { 77, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 78, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 79, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 1 },
                    { 80, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 1 },
                    { 81, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7, 1 },
                    { 82, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7, 1 },
                    { 83, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, 1 },
                    { 84, new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "NurseShifts",
                columns: new[] { "Id", "Date", "NurseId", "ShiftId", "TeamplanId" },
                values: new object[,]
                {
                    { 85, new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 1 },
                    { 86, new DateTime(2022, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 1 },
                    { 87, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 1 },
                    { 88, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 1 },
                    { 89, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, 1 },
                    { 90, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, 1 },
                    { 91, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, 1 },
                    { 92, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, 1 },
                    { 93, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 1 },
                    { 94, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 1 },
                    { 95, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 1 },
                    { 96, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 1 },
                    { 97, new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 1 },
                    { 98, new DateTime(2022, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 1 },
                    { 99, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 1 },
                    { 100, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 1 },
                    { 101, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 1 },
                    { 102, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 1 },
                    { 103, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 1 },
                    { 104, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 1 },
                    { 105, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 1 },
                    { 106, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 1 },
                    { 107, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 1 },
                    { 108, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 1 },
                    { 109, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 1 },
                    { 110, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 111, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 112, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 113, new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5, 1 },
                    { 114, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5, 1 },
                    { 115, new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 116, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 117, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 118, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 119, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5, 1 },
                    { 120, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5, 1 },
                    { 121, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5, 1 },
                    { 122, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 123, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 124, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 125, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 126, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "NurseShifts",
                columns: new[] { "Id", "Date", "NurseId", "ShiftId", "TeamplanId" },
                values: new object[,]
                {
                    { 127, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 128, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 129, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5, 1 },
                    { 130, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5, 1 },
                    { 131, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 132, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 1 },
                    { 133, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 134, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 135, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 136, new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 137, new DateTime(2022, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 138, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 139, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 140, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 141, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 142, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 143, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 144, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 145, new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 146, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 147, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 148, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 149, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 150, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 151, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 152, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 153, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 154, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 155, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 156, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 157, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 7, 1 },
                    { 158, new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 7, 1 },
                    { 159, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 7, 1 },
                    { 160, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 7, 1 },
                    { 161, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 7, 1 },
                    { 162, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 7, 1 },
                    { 163, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1, 2 },
                    { 164, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 1, 2 },
                    { 166, new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 4, 2 },
                    { 167, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 1, 3 },
                    { 168, new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 4, 3 },
                    { 169, new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 1, 3 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "NurseShifts",
                columns: new[] { "Id", "Date", "NurseId", "ShiftId", "TeamplanId" },
                values: new object[,]
                {
                    { 170, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 2, 3 },
                    { 171, new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 2, 3 },
                    { 172, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 1, 3 },
                    { 173, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 1, 2 },
                    { 174, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 1, 2 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Vacations",
                columns: new[] { "Id", "Enddate", "NurseId", "Reason", "Startdate", "VacationTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "", new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "", new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "", new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "", new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "", new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "", new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "", new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "", new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "", new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "", new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "", new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 23, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Family Matters", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 24, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Watching Husband Stephen Thompson fight in the UFC.", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 25, new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "Training brother Alex Perez in training camp.", new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, "Docters appointment.", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 27, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Visiting grandparents in Vietnam.", new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 28, new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, "Hiking with the homies.", new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_Id",
                schema: "dbo",
                table: "Holidays",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_Id",
                schema: "dbo",
                table: "Nurses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_RegimeTypeId",
                schema: "dbo",
                table: "Nurses",
                column: "RegimeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_TeamId",
                schema: "dbo",
                table: "Nurses",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseShifts_Id",
                schema: "dbo",
                table: "NurseShifts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NurseShifts_NurseId",
                schema: "dbo",
                table: "NurseShifts",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseShifts_ShiftId",
                schema: "dbo",
                table: "NurseShifts",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseShifts_TeamplanId",
                schema: "dbo",
                table: "NurseShifts",
                column: "TeamplanId");

            migrationBuilder.CreateIndex(
                name: "IX_RegimeTypes_Id",
                schema: "dbo",
                table: "RegimeTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_Id",
                schema: "dbo",
                table: "Shifts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ShiftTypeId",
                schema: "dbo",
                table: "Shifts",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTypes_Id",
                schema: "dbo",
                table: "ShiftTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_Id",
                schema: "dbo",
                table: "Team",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teamplans_Id",
                schema: "dbo",
                table: "Teamplans",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_Id",
                schema: "dbo",
                table: "Vacations",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_NurseId",
                schema: "dbo",
                table: "Vacations",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_VacationTypeId",
                schema: "dbo",
                table: "Vacations",
                column: "VacationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationTypes_Id",
                schema: "dbo",
                table: "VacationTypes",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NurseShifts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Vacations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Shifts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Teamplans",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Nurses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VacationTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShiftTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RegimeTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "dbo");
        }
    }
}
