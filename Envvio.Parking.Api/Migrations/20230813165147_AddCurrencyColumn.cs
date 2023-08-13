using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Envvio.Parking.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrencyColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "ParkingLots",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "ParkingLots");
        }
    }
}
