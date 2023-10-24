using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class addVerlofAndShiftTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShiftTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypes", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTypes_Id",
                schema: "dbo",
                table: "ShiftTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VerlofTypes_Id",
                schema: "dbo",
                table: "VerlofTypes",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShiftTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VerlofTypes",
                schema: "dbo");
        }
    }
}
