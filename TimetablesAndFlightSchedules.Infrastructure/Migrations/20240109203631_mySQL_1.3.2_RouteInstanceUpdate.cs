using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimetablesAndFlightSchedules.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mySQL_132_RouteInstanceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouteInstanceName",
                table: "RouteInstances",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 1,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Autobus; 26.01.2024; 15:30; 18:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 2,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Autobus; 27.01.2024; 15:30; 18:00");

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 3,
                column: "RouteInstanceName",
                value: "Zlin, Brno; Autobus; 28.01.2024; 15:30; 18:00");

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
                value: "Zlin, Brno; Vlak");

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
                value: "Praha, Rim; Letadlo A320");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteInstanceName",
                table: "RouteInstances");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "RouteName",
                value: "Zlin, Brno, Autobus");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "RouteName",
                value: "Zlin, Brno, Vlak");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "RouteName",
                value: "Uherske Hradiste, Zlin, Autobus");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "RouteName",
                value: "Praha, Rim, Letadlo A320");
        }
    }
}
