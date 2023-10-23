using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class addRegimeTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zorgkundigen_RegimeType_RegimeId",
                schema: "dbo",
                table: "Zorgkundigen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegimeType",
                schema: "dbo",
                table: "RegimeType");

            migrationBuilder.RenameTable(
                name: "RegimeType",
                schema: "dbo",
                newName: "RegimeTypes",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_RegimeType_Id",
                schema: "dbo",
                table: "RegimeTypes",
                newName: "IX_RegimeTypes_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegimeTypes",
                schema: "dbo",
                table: "RegimeTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zorgkundigen_RegimeTypes_RegimeId",
                schema: "dbo",
                table: "Zorgkundigen",
                column: "RegimeId",
                principalSchema: "dbo",
                principalTable: "RegimeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zorgkundigen_RegimeTypes_RegimeId",
                schema: "dbo",
                table: "Zorgkundigen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegimeTypes",
                schema: "dbo",
                table: "RegimeTypes");

            migrationBuilder.RenameTable(
                name: "RegimeTypes",
                schema: "dbo",
                newName: "RegimeType",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_RegimeTypes_Id",
                schema: "dbo",
                table: "RegimeType",
                newName: "IX_RegimeType_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegimeType",
                schema: "dbo",
                table: "RegimeType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zorgkundigen_RegimeType_RegimeId",
                schema: "dbo",
                table: "Zorgkundigen",
                column: "RegimeId",
                principalSchema: "dbo",
                principalTable: "RegimeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
