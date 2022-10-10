using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PunchesManagement.DataAccess.Migrations
{
    public partial class RelationsRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PunchesTabletPress_TabletPresses_TabletPressesId",
                table: "PunchesTabletPress");

            migrationBuilder.DropIndex(
                name: "IX_Punches_ManufacturerId",
                table: "Punches");

            migrationBuilder.DropIndex(
                name: "IX_Punches_TypesId",
                table: "Punches");

            migrationBuilder.DropColumn(
                name: "UsingDate",
                table: "Punches");

            migrationBuilder.RenameColumn(
                name: "TabletPressesId",
                table: "PunchesTabletPress",
                newName: "TabletPressId");

            migrationBuilder.RenameIndex(
                name: "IX_PunchesTabletPress_TabletPressesId",
                table: "PunchesTabletPress",
                newName: "IX_PunchesTabletPress_TabletPressId");

            migrationBuilder.CreateIndex(
                name: "IX_Punches_ManufacturerId",
                table: "Punches",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Punches_TypesId",
                table: "Punches",
                column: "TypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PunchesTabletPress_TabletPresses_TabletPressId",
                table: "PunchesTabletPress",
                column: "TabletPressId",
                principalTable: "TabletPresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PunchesTabletPress_TabletPresses_TabletPressId",
                table: "PunchesTabletPress");

            migrationBuilder.DropIndex(
                name: "IX_Punches_ManufacturerId",
                table: "Punches");

            migrationBuilder.DropIndex(
                name: "IX_Punches_TypesId",
                table: "Punches");

            migrationBuilder.RenameColumn(
                name: "TabletPressId",
                table: "PunchesTabletPress",
                newName: "TabletPressesId");

            migrationBuilder.RenameIndex(
                name: "IX_PunchesTabletPress_TabletPressId",
                table: "PunchesTabletPress",
                newName: "IX_PunchesTabletPress_TabletPressesId");

            migrationBuilder.AddColumn<DateTime>(
                name: "UsingDate",
                table: "Punches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                name: "FK_PunchesTabletPress_TabletPresses_TabletPressesId",
                table: "PunchesTabletPress",
                column: "TabletPressesId",
                principalTable: "TabletPresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
