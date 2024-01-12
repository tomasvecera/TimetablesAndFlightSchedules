using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimetablesAndFlightSchedules.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mySQL_140_RenamedVehicleTypeLetadlo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "RouteName",
                value: "Praha, Rim; Letadlo");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "VehicleType",
                value: "Letadlo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "RouteName",
                value: "Praha, Rim; Letadlo A320");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "VehicleType",
                value: "Letadlo A320");
        }
    }
}
