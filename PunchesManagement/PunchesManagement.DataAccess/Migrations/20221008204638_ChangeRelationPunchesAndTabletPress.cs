using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PunchesManagement.DataAccess.Migrations
{
    public partial class ChangeRelationPunchesAndTabletPress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Punches_TabletPresses_TabletPressId",
                table: "Punches");

            migrationBuilder.DropIndex(
                name: "IX_Punches_TabletPressId",
                table: "Punches");

            migrationBuilder.DropColumn(
                name: "TabletPressId",
                table: "Punches");

            migrationBuilder.CreateTable(
                name: "PunchesTabletPress",
                columns: table => new
                {
                    PunchesId = table.Column<int>(type: "int", nullable: false),
                    TabletPressesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunchesTabletPress", x => new { x.PunchesId, x.TabletPressesId });
                    table.ForeignKey(
                        name: "FK_PunchesTabletPress_Punches_PunchesId",
                        column: x => x.PunchesId,
                        principalTable: "Punches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PunchesTabletPress_TabletPresses_TabletPressesId",
                        column: x => x.TabletPressesId,
                        principalTable: "TabletPresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PunchesTabletPress_TabletPressesId",
                table: "PunchesTabletPress",
                column: "TabletPressesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PunchesTabletPress");

            migrationBuilder.AddColumn<int>(
                name: "TabletPressId",
                table: "Punches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Punches_TabletPressId",
                table: "Punches",
                column: "TabletPressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Punches_TabletPresses_TabletPressId",
                table: "Punches",
                column: "TabletPressId",
                principalTable: "TabletPresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
