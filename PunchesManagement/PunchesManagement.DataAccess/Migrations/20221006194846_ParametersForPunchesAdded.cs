using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PunchesManagement.DataAccess.Migrations
{
    public partial class ParametersForPunchesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Punches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypesId",
                table: "Punches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "BatchSize",
                table: "Products",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Punches_ManufacturerId",
                table: "Punches",
                column: "ManufacturerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Punches_TypesId",
                table: "Punches",
                column: "TypesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Punches_Manufacturer_ManufacturerId",
                table: "Punches",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Punches_Types_TypesId",
                table: "Punches",
                column: "TypesId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Punches_Manufacturer_ManufacturerId",
                table: "Punches");

            migrationBuilder.DropForeignKey(
                name: "FK_Punches_Types_TypesId",
                table: "Punches");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Punches_ManufacturerId",
                table: "Punches");

            migrationBuilder.DropIndex(
                name: "IX_Punches_TypesId",
                table: "Punches");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Punches");

            migrationBuilder.DropColumn(
                name: "TypesId",
                table: "Punches");

            migrationBuilder.DropColumn(
                name: "BatchSize",
                table: "Products");
        }
    }
}
