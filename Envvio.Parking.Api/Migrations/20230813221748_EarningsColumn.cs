using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Envvio.Parking.Api.Migrations
{
    /// <inheritdoc />
    public partial class EarningsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Earnings",
                table: "ParkingLots",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Earnings",
                table: "ParkingLots");
        }
    }
}
