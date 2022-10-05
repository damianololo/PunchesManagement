using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PunchesManagement.DataAccess.Migrations
{
    public partial class FirstEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabletPresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfStation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabletPresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Output = table.Column<int>(type: "int", nullable: false),
                    WorkingTime = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TabletPressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_TabletPresses_TabletPressId",
                        column: x => x.TabletPressId,
                        principalTable: "TabletPresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Punches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineHour = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    InInspection = table.Column<bool>(type: "bit", nullable: false),
                    TabletPressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punches_TabletPresses_TabletPressId",
                        column: x => x.TabletPressId,
                        principalTable: "TabletPresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TabletPressId",
                table: "Products",
                column: "TabletPressId");

            migrationBuilder.CreateIndex(
                name: "IX_Punches_TabletPressId",
                table: "Punches",
                column: "TabletPressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Punches");

            migrationBuilder.DropTable(
                name: "TabletPresses");
        }
    }
}
