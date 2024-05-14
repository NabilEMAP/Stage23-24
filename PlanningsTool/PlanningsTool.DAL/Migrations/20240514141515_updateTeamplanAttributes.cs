using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class updateTeamplanAttributes : Migration
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
                table: "Team",
                columns: new[] { "Id", "TeamName" },
                values: new object[,]
                {
                    { 1, "Team Magribien" },
                    { 2, "Team Iromien" },
                    { 3, "New Team" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Teamplans",
                columns: new[] { "Id", "CreatedOn", "Name", "PlanFor" },
                values: new object[] { 1, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "2024-05-12-23-59-Teamplan01", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                    { 1, "Amina", "0", "Woerahfa", 1, 1 },
                    { 2, "Barbara", "0", "Tamara", 1, 1 },
                    { 3, "Chaimae", "0", "Dhanitin", 1, 1 },
                    { 4, "Dalila", "0", "Dhiyah", 1, 1 },
                    { 5, "Fatima", "0", "Tsridh", 2, 1 },
                    { 6, "Ghizlane", "0", "Mantazoedh", 2, 1 },
                    { 7, "Halima", "0", "Hanatt", 2, 1 },
                    { 8, "Imane", "0", "Azough", 3, 1 },
                    { 9, "Karima", "0", "Adheswe", 3, 1 },
                    { 10, "Latifa", "1", "Adhesha", 1, 1 },
                    { 11, "Mariem", "1", "Sariedh", 1, 1 },
                    { 12, "Nasira", "1", "Isira", 3, 1 },
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
                    { 1, new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 2, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 3, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7, 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Vacations",
                columns: new[] { "Id", "Enddate", "NurseId", "Reason", "Startdate", "VacationTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Verlofdagje op vrijdag.", new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Heel de week ziek geweest.", new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Afwezig.", new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 4, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse fringilla nibh eu justo ullamcorper iaculis. Quisque at tellus at ex faucibus tempus ac eu nisi. In sapien sapien, pellentesque eu velit a, sodales faucibus urna. Ut est eros, efficitur eu suscipit quis, vulputate a metus. Vestibulum non ullamcorper lectus. Ut aliquam nunc sed arcu laoreet eleifend. Nam venenatis purus ipsum, ut condimentum quam vulputate id. Mauris id orci vel purus convallis volutpat ac sed nibh. Donec vitae dolor in tortor mollis consectetur. Nunc in ante tortor. Mauris sit amet semper lacus. Vivamus lacus neque, sodales id dolor vel, iaculis dictum tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Proin eu dui vel risus aliquam elementum eget id ligula.", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 5, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Afspraak UZA Gastro", new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Afspraak plannen voor Rijbewijs terugkommoment", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
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
