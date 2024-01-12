using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimetablesAndFlightSchedules.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mySQL_141_AddedMoreRouteInstances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime", "RouteInstanceName" },
                values: new object[] { new TimeOnly(12, 30, 0), new TimeOnly(10, 0, 0), "Zlin, Brno; Autobus; 26.01.2024; 10:00; 12:30" });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "Date", "DepartureTime", "RouteInstanceName" },
                values: new object[] { new TimeOnly(16, 0, 0), new DateOnly(2024, 1, 26), new TimeOnly(13, 30, 0), "Zlin, Brno; Autobus; 26.01.2024; 13:30; 16:00" });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "RouteInstanceName" },
                values: new object[] { new DateOnly(2024, 1, 26), "Zlin, Brno; Autobus; 26.01.2024; 15:30; 18:00" });

            migrationBuilder.InsertData(
                table: "RouteInstances",
                columns: new[] { "Id", "ArrivalTime", "Date", "DepartureTime", "RouteID", "RouteInstanceName", "TravelTime" },
                values: new object[,]
                {
                    { 4, new TimeOnly(18, 0, 0), new DateOnly(2024, 1, 27), new TimeOnly(15, 30, 0), 1, "Zlin, Brno; Autobus; 27.01.2024; 15:30; 18:00", new TimeSpan(0, 2, 30, 0, 0) },
                    { 5, new TimeOnly(18, 0, 0), new DateOnly(2024, 1, 28), new TimeOnly(15, 30, 0), 1, "Zlin, Brno; Autobus; 28.01.2024; 15:30; 18:00", new TimeSpan(0, 2, 30, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime", "RouteInstanceName" },
                values: new object[] { new TimeOnly(18, 0, 0), new TimeOnly(15, 30, 0), "Zlin, Brno; Autobus; 26.01.2024; 15:30; 18:00" });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "Date", "DepartureTime", "RouteInstanceName" },
                values: new object[] { new TimeOnly(18, 0, 0), new DateOnly(2024, 1, 27), new TimeOnly(15, 30, 0), "Zlin, Brno; Autobus; 27.01.2024; 15:30; 18:00" });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "RouteInstanceName" },
                values: new object[] { new DateOnly(2024, 1, 28), "Zlin, Brno; Autobus; 28.01.2024; 15:30; 18:00" });
        }
    }
}
