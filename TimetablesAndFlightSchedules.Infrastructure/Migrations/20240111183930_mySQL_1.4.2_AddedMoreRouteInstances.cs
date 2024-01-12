using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimetablesAndFlightSchedules.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mySQL_142_AddedMoreRouteInstances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "Date", "DepartureTime", "RouteInstanceName" },
                values: new object[] { new TimeOnly(19, 0, 0), new DateOnly(2024, 1, 26), new TimeOnly(16, 30, 0), "Zlin, Brno; Autobus; 26.01.2024; 16:30; 19:00" });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "Date", "DepartureTime", "RouteInstanceName" },
                values: new object[] { new TimeOnly(19, 30, 0), new DateOnly(2024, 1, 26), new TimeOnly(17, 0, 0), "Zlin, Brno; Autobus; 26.01.2024; 17:00; 19:30" });

            migrationBuilder.InsertData(
                table: "RouteInstances",
                columns: new[] { "Id", "ArrivalTime", "Date", "DepartureTime", "RouteID", "RouteInstanceName", "TravelTime" },
                values: new object[,]
                {
                    { 6, new TimeOnly(18, 0, 0), new DateOnly(2024, 1, 27), new TimeOnly(15, 30, 0), 1, "Zlin, Brno; Autobus; 27.01.2024; 15:30; 18:00", new TimeSpan(0, 2, 30, 0, 0) },
                    { 7, new TimeOnly(18, 0, 0), new DateOnly(2024, 1, 28), new TimeOnly(15, 30, 0), 1, "Zlin, Brno; Autobus; 28.01.2024; 15:30; 18:00", new TimeSpan(0, 2, 30, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "Date", "DepartureTime", "RouteInstanceName" },
                values: new object[] { new TimeOnly(18, 0, 0), new DateOnly(2024, 1, 27), new TimeOnly(15, 30, 0), "Zlin, Brno; Autobus; 27.01.2024; 15:30; 18:00" });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "Date", "DepartureTime", "RouteInstanceName" },
                values: new object[] { new TimeOnly(18, 0, 0), new DateOnly(2024, 1, 28), new TimeOnly(15, 30, 0), "Zlin, Brno; Autobus; 28.01.2024; 15:30; 18:00" });
        }
    }
}
