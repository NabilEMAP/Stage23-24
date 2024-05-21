using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class addZorgkundigeShiftsAndTeamplanningen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ZorgkundigeShifts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "date", nullable: false),
                    ZorgkundigeId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    TeamplanningId = table.Column<int>(type: "int", nullable: false)
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
                table: "ZorgkundigeShifts",
                columns: new[] { "Id", "Datum", "ShiftId", "TeamplanningId", "ZorgkundigeId" },
                values: new object[] { 1, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ZorgkundigeShifts",
                columns: new[] { "Id", "Datum", "ShiftId", "TeamplanningId", "ZorgkundigeId" },
                values: new object[] { 2, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 2 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ZorgkundigeShifts",
                columns: new[] { "Id", "Datum", "ShiftId", "TeamplanningId", "ZorgkundigeId" },
                values: new object[] { 3, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Teamplanningen_Id",
                schema: "dbo",
                table: "Teamplanningen",
                column: "Id",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZorgkundigeShifts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Teamplanningen",
                schema: "dbo");
        }
    }
}
