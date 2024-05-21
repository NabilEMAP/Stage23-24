using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class refactorAllEntitiesFromDutchToEnglish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verloven",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ZorgkundigeShifts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VerlofTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Teamplanningen",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Zorgkundigen",
                schema: "dbo");

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

            migrationBuilder.RenameColumn(
                name: "Shift",
                schema: "dbo",
                table: "ShiftTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Starttijd",
                schema: "dbo",
                table: "Shifts",
                newName: "Starttime");

            migrationBuilder.RenameColumn(
                name: "Eindtijd",
                schema: "dbo",
                table: "Shifts",
                newName: "Endtime");

            migrationBuilder.RenameColumn(
                name: "Regime",
                schema: "dbo",
                table: "RegimeTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AantalUren",
                schema: "dbo",
                table: "RegimeTypes",
                newName: "CountHours");

            migrationBuilder.CreateTable(
                name: "Nurses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    RegimeId = table.Column<int>(type: "int", nullable: false),
                    IsFixedNight = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_RegimeTypes_RegimeId",
                        column: x => x.RegimeId,
                        principalSchema: "dbo",
                        principalTable: "RegimeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teamplans",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_Id",
                schema: "dbo",
                table: "Nurses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_RegimeId",
                schema: "dbo",
                table: "Nurses",
                column: "RegimeId");

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
                name: "NurseShifts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Vacations",
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

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "ShiftTypes",
                newName: "Shift");

            migrationBuilder.RenameColumn(
                name: "Starttime",
                schema: "dbo",
                table: "Shifts",
                newName: "Starttijd");

            migrationBuilder.RenameColumn(
                name: "Endtime",
                schema: "dbo",
                table: "Shifts",
                newName: "Eindtijd");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "RegimeTypes",
                newName: "Regime");

            migrationBuilder.RenameColumn(
                name: "CountHours",
                schema: "dbo",
                table: "RegimeTypes",
                newName: "AantalUren");

            migrationBuilder.CreateTable(
                name: "Teamplanningen",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teamplanningen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerlofTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verlof = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerlofTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zorgkundigen",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegimeId = table.Column<int>(type: "int", nullable: false),
                    Achternaam = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsVasteNacht = table.Column<string>(type: "char(1)", nullable: false),
                    Voornaam = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zorgkundigen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zorgkundigen_RegimeTypes_RegimeId",
                        column: x => x.RegimeId,
                        principalSchema: "dbo",
                        principalTable: "RegimeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verloven",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerlofTypeId = table.Column<int>(type: "int", nullable: false),
                    ZorgkundigeId = table.Column<int>(type: "int", nullable: false),
                    Einddatum = table.Column<DateTime>(type: "date", nullable: false),
                    Reden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Startdatum = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verloven", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verloven_VerlofTypes_VerlofTypeId",
                        column: x => x.VerlofTypeId,
                        principalSchema: "dbo",
                        principalTable: "VerlofTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verloven_Zorgkundigen_ZorgkundigeId",
                        column: x => x.ZorgkundigeId,
                        principalSchema: "dbo",
                        principalTable: "Zorgkundigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZorgkundigeShifts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    TeamplanningId = table.Column<int>(type: "int", nullable: false),
                    ZorgkundigeId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZorgkundigeShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZorgkundigeShifts_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalSchema: "dbo",
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZorgkundigeShifts_Teamplanningen_TeamplanningId",
                        column: x => x.TeamplanningId,
                        principalSchema: "dbo",
                        principalTable: "Teamplanningen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZorgkundigeShifts_Zorgkundigen_ZorgkundigeId",
                        column: x => x.ZorgkundigeId,
                        principalSchema: "dbo",
                        principalTable: "Zorgkundigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RegimeTypes",
                columns: new[] { "Id", "AantalUren", "Regime" },
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
                columns: new[] { "Id", "Shift" },
                values: new object[,]
                {
                    { 1, "Vroege" },
                    { 2, "Late" },
                    { 3, "Nacht" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Teamplanningen",
                columns: new[] { "Id", "Maand" },
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
                table: "VerlofTypes",
                columns: new[] { "Id", "Verlof" },
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
                table: "Shifts",
                columns: new[] { "Id", "Eindtijd", "ShiftTypeId", "Starttijd" },
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
                table: "Zorgkundigen",
                columns: new[] { "Id", "Achternaam", "IsVasteNacht", "RegimeId", "Voornaam" },
                values: new object[,]
                {
                    { 1, "Woerahfa", "0", 1, "Amina" },
                    { 2, "Tamara", "0", 1, "Barbara" },
                    { 3, "Dhanitin", "0", 1, "Chaimae" },
                    { 4, "Dhiyah", "0", 1, "Dalila" },
                    { 5, "Tsridh", "0", 2, "Fatima" },
                    { 6, "Mantazoedh", "0", 2, "Ghizlane" },
                    { 7, "Hanatt", "0", 2, "Halima" },
                    { 8, "Azough", "0", 3, "Imane" },
                    { 9, "Adheswe", "0", 3, "Karima" },
                    { 10, "Adhesha", "1", 1, "Latifa" },
                    { 11, "Sariedh", "1", 1, "Mariem" },
                    { 12, "Isira", "1", 3, "Nasira" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Verloven",
                columns: new[] { "Id", "Einddatum", "Reden", "Startdatum", "VerlofTypeId", "ZorgkundigeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verlofdagje op vrijdag.", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heel de week ziek geweest.", new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ZorgkundigeShifts",
                columns: new[] { "Id", "Datum", "ShiftId", "TeamplanningId", "ZorgkundigeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 2, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 2 },
                    { 3, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teamplanningen_Id",
                schema: "dbo",
                table: "Teamplanningen",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VerlofTypes_Id",
                schema: "dbo",
                table: "VerlofTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verloven_Id",
                schema: "dbo",
                table: "Verloven",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verloven_VerlofTypeId",
                schema: "dbo",
                table: "Verloven",
                column: "VerlofTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Verloven_ZorgkundigeId",
                schema: "dbo",
                table: "Verloven",
                column: "ZorgkundigeId");

            migrationBuilder.CreateIndex(
                name: "IX_Zorgkundigen_Id",
                schema: "dbo",
                table: "Zorgkundigen",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zorgkundigen_RegimeId",
                schema: "dbo",
                table: "Zorgkundigen",
                column: "RegimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ZorgkundigeShifts_Id",
                schema: "dbo",
                table: "ZorgkundigeShifts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZorgkundigeShifts_ShiftId",
                schema: "dbo",
                table: "ZorgkundigeShifts",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ZorgkundigeShifts_TeamplanningId",
                schema: "dbo",
                table: "ZorgkundigeShifts",
                column: "TeamplanningId");

            migrationBuilder.CreateIndex(
                name: "IX_ZorgkundigeShifts_ZorgkundigeId",
                schema: "dbo",
                table: "ZorgkundigeShifts",
                column: "ZorgkundigeId");
        }
    }
}
