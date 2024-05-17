using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class removedRegimeTypeIdDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RegimeTypeId",
                schema: "dbo",
                table: "Nurses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RegimeTypeId",
                schema: "dbo",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
