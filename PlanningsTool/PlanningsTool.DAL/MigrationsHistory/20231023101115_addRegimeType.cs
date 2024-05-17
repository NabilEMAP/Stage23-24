using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningsTool.DAL.Migrations
{
    public partial class addRegimeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblZorgkundigen",
                schema: "Zorgkundige",
                table: "tblZorgkundigen");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "tblZorgkundigen",
                schema: "Zorgkundige",
                newName: "Zorgkundigen",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_tblZorgkundigen_Id",
                schema: "dbo",
                table: "Zorgkundigen",
                newName: "IX_Zorgkundigen_Id");

            migrationBuilder.AddColumn<int>(
                name: "RegimeId",
                schema: "dbo",
                table: "Zorgkundigen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zorgkundigen",
                schema: "dbo",
                table: "Zorgkundigen",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RegimeType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Regime = table.Column<string>(type: "varchar(100)", nullable: false),
                    AantalUren = table.Column<decimal>(type: "decimal(3,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegimeType", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RegimeType",
                columns: new[] { "Id", "AantalUren", "Regime" },
                values: new object[,]
                {
                    { 1, 38.0m, "Voltijds" },
                    { 2, 30.4m, "Deeltijds 4/5" },
                    { 3, 28.8m, "Deeltijds 3/4" },
                    { 4, 19.0m, "Halftijds" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegimeId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegimeId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegimeId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegimeId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegimeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegimeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegimeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegimeId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegimeId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegimeId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegimeId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zorgkundigen",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegimeId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Zorgkundigen_RegimeId",
                schema: "dbo",
                table: "Zorgkundigen",
                column: "RegimeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegimeType_Id",
                schema: "dbo",
                table: "RegimeType",
                column: "Id",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zorgkundigen_RegimeType_RegimeId",
                schema: "dbo",
                table: "Zorgkundigen");

            migrationBuilder.DropTable(
                name: "RegimeType",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zorgkundigen",
                schema: "dbo",
                table: "Zorgkundigen");

            migrationBuilder.DropIndex(
                name: "IX_Zorgkundigen_RegimeId",
                schema: "dbo",
                table: "Zorgkundigen");

            migrationBuilder.DropColumn(
                name: "RegimeId",
                schema: "dbo",
                table: "Zorgkundigen");

            migrationBuilder.EnsureSchema(
                name: "Zorgkundige");

            migrationBuilder.RenameTable(
                name: "Zorgkundigen",
                schema: "dbo",
                newName: "tblZorgkundigen",
                newSchema: "Zorgkundige");

            migrationBuilder.RenameIndex(
                name: "IX_Zorgkundigen_Id",
                schema: "Zorgkundige",
                table: "tblZorgkundigen",
                newName: "IX_tblZorgkundigen_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblZorgkundigen",
                schema: "Zorgkundige",
                table: "tblZorgkundigen",
                column: "Id");
        }
    }
}
