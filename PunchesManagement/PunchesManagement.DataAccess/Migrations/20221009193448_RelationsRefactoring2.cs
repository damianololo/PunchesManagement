using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PunchesManagement.DataAccess.Migrations
{
    public partial class RelationsRefactoring2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Punches_Types_TypesId",
                table: "Punches");

            migrationBuilder.AddColumn<int>(
                name: "TypesId",
                table: "TabletPresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TabletPresses_TypesId",
                table: "TabletPresses",
                column: "TypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Punches_Types_TypesId",
                table: "Punches",
                column: "TypesId",
                principalTable: "Types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TabletPresses_Types_TypesId",
                table: "TabletPresses",
                column: "TypesId",
                principalTable: "Types",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Punches_Types_TypesId",
                table: "Punches");

            migrationBuilder.DropForeignKey(
                name: "FK_TabletPresses_Types_TypesId",
                table: "TabletPresses");

            migrationBuilder.DropIndex(
                name: "IX_TabletPresses_TypesId",
                table: "TabletPresses");

            migrationBuilder.DropColumn(
                name: "TypesId",
                table: "TabletPresses");

            migrationBuilder.AddForeignKey(
                name: "FK_Punches_Types_TypesId",
                table: "Punches",
                column: "TypesId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
