using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Envvio.Parking.Api.Migrations
{
    /// <inheritdoc />
    public partial class Altermodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_ParkingLots_ParkingLotId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ParkingLotId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ParkingLotId",
                table: "Vehicles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkingLotId",
                table: "Vehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ParkingLotId",
                table: "Vehicles",
                column: "ParkingLotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_ParkingLots_ParkingLotId",
                table: "Vehicles",
                column: "ParkingLotId",
                principalTable: "ParkingLots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
