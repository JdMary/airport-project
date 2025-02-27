using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneFk",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planes",
                table: "Planes");

            migrationBuilder.RenameTable(
                name: "Planes",
                newName: "Myplanes");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Myplanes",
                newName: "PlaneCapacity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Myplanes",
                table: "Myplanes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Myplanes_PlaneFk",
                table: "Flights",
                column: "PlaneFk",
                principalTable: "Myplanes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Myplanes_PlaneFk",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Myplanes",
                table: "Myplanes");

            migrationBuilder.RenameTable(
                name: "Myplanes",
                newName: "Planes");

            migrationBuilder.RenameColumn(
                name: "PlaneCapacity",
                table: "Planes",
                newName: "Capacity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planes",
                table: "Planes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneFk",
                table: "Flights",
                column: "PlaneFk",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
