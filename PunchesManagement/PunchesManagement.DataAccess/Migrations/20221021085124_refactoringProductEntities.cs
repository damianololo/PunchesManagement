using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PunchesManagement.DataAccess.Migrations
{
    public partial class refactoringProductEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkingTime",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductionTime",
                table: "Products",
                newName: "ProductionTimeStop");

            migrationBuilder.AlterColumn<string>(
                name: "Series",
                table: "Products",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionTimeStart",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PunchesId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RealWorkingTime",
                table: "Products",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PunchesId",
                table: "Products",
                column: "PunchesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Punches_PunchesId",
                table: "Products",
                column: "PunchesId",
                principalTable: "Punches",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Punches_PunchesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PunchesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductionTimeStart",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PunchesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RealWorkingTime",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductionTimeStop",
                table: "Products",
                newName: "ProductionTime");

            migrationBuilder.AlterColumn<string>(
                name: "Series",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingTime",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
