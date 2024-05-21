using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class updateRegimeId_To_RegimeTypeId_In_Nurse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_RegimeTypes_RegimeId",
                schema: "dbo",
                table: "Nurses");

            migrationBuilder.RenameColumn(
                name: "RegimeId",
                schema: "dbo",
                table: "Nurses",
                newName: "RegimeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_RegimeId",
                schema: "dbo",
                table: "Nurses",
                newName: "IX_Nurses_RegimeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_RegimeTypes_RegimeTypeId",
                schema: "dbo",
                table: "Nurses",
                column: "RegimeTypeId",
                principalSchema: "dbo",
                principalTable: "RegimeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_RegimeTypes_RegimeTypeId",
                schema: "dbo",
                table: "Nurses");

            migrationBuilder.RenameColumn(
                name: "RegimeTypeId",
                schema: "dbo",
                table: "Nurses",
                newName: "RegimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_RegimeTypeId",
                schema: "dbo",
                table: "Nurses",
                newName: "IX_Nurses_RegimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_RegimeTypes_RegimeId",
                schema: "dbo",
                table: "Nurses",
                column: "RegimeId",
                principalSchema: "dbo",
                principalTable: "RegimeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
