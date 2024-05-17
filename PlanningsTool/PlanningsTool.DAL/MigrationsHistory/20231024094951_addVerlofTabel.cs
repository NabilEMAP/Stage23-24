using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class addVerlofTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verloven",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Startdatum = table.Column<DateTime>(type: "date", nullable: false),
                    Einddatum = table.Column<DateTime>(type: "date", nullable: false),
                    Reden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZorgkundigeId = table.Column<int>(type: "int", nullable: false),
                    VerlofTypeId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Verloven",
                columns: new[] { "Id", "Einddatum", "Reden", "Startdatum", "VerlofTypeId", "ZorgkundigeId" },
                values: new object[] { 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verlofdagje op vrijdag.", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Verloven",
                columns: new[] { "Id", "Einddatum", "Reden", "Startdatum", "VerlofTypeId", "ZorgkundigeId" },
                values: new object[] { 2, new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heel de week ziek geweest.", new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verloven",
                schema: "dbo");
        }
    }
}
