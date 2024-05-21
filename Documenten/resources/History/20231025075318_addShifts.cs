using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class addShifts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shifts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Starttijd = table.Column<TimeSpan>(type: "time", nullable: false),
                    Eindtijd = table.Column<TimeSpan>(type: "time", nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts",
                schema: "dbo");
        }
    }
}
