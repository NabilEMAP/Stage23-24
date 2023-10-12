using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class addZorgkundigeTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Zorgkundige");

            migrationBuilder.CreateTable(
                name: "tblZorgkundigen",
                schema: "Zorgkundige",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "varchar(100)", nullable: false),
                    Achternaam = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsVasteNacht = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblZorgkundigen", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Zorgkundige",
                table: "tblZorgkundigen",
                columns: new[] { "Id", "Achternaam", "IsVasteNacht", "Voornaam" },
                values: new object[,]
                {
                    { 1, "Woerahfa", "0", "Amina" },
                    { 2, "Tamara", "0", "Barbara" },
                    { 3, "Dhanitin", "0", "Chaimae" },
                    { 4, "Dhiyah", "0", "Dalila" },
                    { 5, "Tsridh", "0", "Fatima" },
                    { 6, "Mantazoedh", "0", "Ghizlane" },
                    { 7, "Hanatt", "0", "Halima" },
                    { 8, "Azough", "0", "Imane" },
                    { 9, "Adheswe", "0", "Karima" },
                    { 10, "Adhesha", "1", "Latifa" },
                    { 11, "Sariedh", "1", "Mariem" },
                    { 12, "Isira", "1", "Nasira" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblZorgkundigen_Id",
                schema: "Zorgkundige",
                table: "tblZorgkundigen",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblZorgkundigen",
                schema: "Zorgkundige");
        }
    }
}
