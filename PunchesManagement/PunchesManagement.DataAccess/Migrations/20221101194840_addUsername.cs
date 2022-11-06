using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PunchesManagement.DataAccess.Migrations
{
    public partial class addUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TabletPresses_TabletPressId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TabletPresses_TabletPressId",
                table: "Products",
                column: "TabletPressId",
                principalTable: "TabletPresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TabletPresses_TabletPressId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TabletPresses_TabletPressId",
                table: "Products",
                column: "TabletPressId",
                principalTable: "TabletPresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
