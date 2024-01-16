using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimetablesAndFlightSchedules.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mySQL_150_RenamedVehiclesToEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 1,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Bus; 26.01.2024; 10:00; 11:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 2,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Bus; 26.01.2024; 13:30; 15:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 3,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Bus; 26.01.2024; 15:30; 17:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 4,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Bus; 26.01.2024; 16:30; 18:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 5,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Bus; 26.01.2024; 17:00; 18:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 6,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Bus; 27.01.2024; 15:30; 17:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 7,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Bus; 28.01.2024; 15:30; 17:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 8,
                column: "RouteInstanceName",
                value: "Brno, Praha; Train; 26.01.2024; 10:00; 12:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 9,
                column: "RouteInstanceName",
                value: "Brno, Praha; Train; 26.01.2024; 12:00; 14:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 10,
                column: "RouteInstanceName",
                value: "Brno, Praha; Train; 26.01.2024; 14:00; 16:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 11,
                column: "RouteInstanceName",
                value: "Brno, Praha; Train; 27.01.2024; 12:00; 14:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 12,
                column: "RouteInstanceName",
                value: "Brno, Praha; Train; 28.01.2024; 12:00; 14:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 13,
                column: "RouteInstanceName",
                value: "Praha, Rim; Airplane; 26.01.2024; 12:00; 14:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 14,
                column: "RouteInstanceName",
                value: "Praha, Rim; Airplane; 26.01.2024; 16:00; 18:00");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "RouteName",
                value: "Zlin, Brno; Bus");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "RouteName",
                value: "Brno, Praha; Train");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "RouteName",
                value: "Uherske Hradiste, Zlin; Bus");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "RouteName",
                value: "Praha, Rim; Airplane");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "VehicleType",
                value: "Bus");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "VehicleType",
                value: "Train");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "VehicleType",
                value: "Airplane");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 1,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Autobus; 26.01.2024; 10:00; 11:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 2,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Autobus; 26.01.2024; 13:30; 15:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 3,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Autobus; 26.01.2024; 15:30; 17:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 4,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Autobus; 26.01.2024; 16:30; 18:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 5,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Autobus; 26.01.2024; 17:00; 18:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 6,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Autobus; 27.01.2024; 15:30; 17:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 7,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Autobus; 28.01.2024; 15:30; 17:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 8,
                column: "RouteInstanceName",
                value: "Brno, Praha; Vlak; 26.01.2024; 10:00; 12:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 9,
                column: "RouteInstanceName",
                value: "Brno, Praha; Vlak; 26.01.2024; 12:00; 14:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 10,
                column: "RouteInstanceName",
                value: "Brno, Praha; Vlak; 26.01.2024; 14:00; 16:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 11,
                column: "RouteInstanceName",
                value: "Brno, Praha; Vlak; 27.01.2024; 12:00; 14:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 12,
                column: "RouteInstanceName",
                value: "Brno, Praha; Vlak; 28.01.2024; 12:00; 14:30");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 13,
                column: "RouteInstanceName",
                value: "Praha, Rim; Letadlo; 26.01.2024; 12:00; 14:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 14,
                column: "RouteInstanceName",
                value: "Praha, Rim; Letadlo; 26.01.2024; 16:00; 18:00");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "RouteName",
                value: "Zlin, Brno; Autobus");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "RouteName",
                value: "Brno, Praha; Vlak");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "RouteName",
                value: "Uherske Hradiste, Zlin; Autobus");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "RouteName",
                value: "Praha, Rim; Letadlo");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "VehicleType",
                value: "Autobus");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "VehicleType",
                value: "Vlak");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "VehicleType",
                value: "Letadlo");
        }
    }
}
