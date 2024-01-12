using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimetablesAndFlightSchedules.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mySQL_143_AddedMoreRouteInstances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(11, 30, 0), "Zlin, Brno; Autobus; 26.01.2024; 10:00; 11:30", new TimeSpan(0, 1, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(15, 0, 0), "Zlin, Brno; Autobus; 26.01.2024; 13:30; 15:00", new TimeSpan(0, 1, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(17, 0, 0), "Zlin, Brno; Autobus; 26.01.2024; 15:30; 17:00", new TimeSpan(0, 1, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(18, 0, 0), "Zlin, Brno; Autobus; 26.01.2024; 16:30; 18:00", new TimeSpan(0, 1, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(18, 30, 0), "Zlin, Brno; Autobus; 26.01.2024; 17:00; 18:30", new TimeSpan(0, 1, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(17, 0, 0), "Zlin, Brno; Autobus; 27.01.2024; 15:30; 17:00", new TimeSpan(0, 1, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(17, 0, 0), "Zlin, Brno; Autobus; 28.01.2024; 15:30; 17:00", new TimeSpan(0, 1, 30, 0, 0) });

            migrationBuilder.InsertData(
                table: "RouteInstances",
                columns: new[] { "Id", "ArrivalTime", "Date", "DepartureTime", "RouteID", "RouteInstanceName", "TravelTime" },
                values: new object[,]
                {
                    { 8, new TimeOnly(12, 30, 0), new DateOnly(2024, 1, 26), new TimeOnly(10, 0, 0), 2, "Brno, Praha; Vlak; 26.01.2024; 10:00; 12:30", new TimeSpan(0, 2, 30, 0, 0) },
                    { 9, new TimeOnly(14, 30, 0), new DateOnly(2024, 1, 26), new TimeOnly(12, 0, 0), 2, "Brno, Praha; Vlak; 26.01.2024; 12:00; 14:30", new TimeSpan(0, 2, 30, 0, 0) },
                    { 10, new TimeOnly(16, 30, 0), new DateOnly(2024, 1, 26), new TimeOnly(14, 0, 0), 2, "Brno, Praha; Vlak; 26.01.2024; 14:00; 16:30", new TimeSpan(0, 2, 30, 0, 0) },
                    { 11, new TimeOnly(14, 30, 0), new DateOnly(2024, 1, 27), new TimeOnly(12, 0, 0), 2, "Brno, Praha; Vlak; 27.01.2024; 12:00; 14:30", new TimeSpan(0, 2, 30, 0, 0) },
                    { 12, new TimeOnly(14, 30, 0), new DateOnly(2024, 1, 28), new TimeOnly(12, 0, 0), 2, "Brno, Praha; Vlak; 28.01.2024; 12:00; 14:30", new TimeSpan(0, 2, 30, 0, 0) },
                    { 13, new TimeOnly(14, 0, 0), new DateOnly(2024, 1, 26), new TimeOnly(12, 0, 0), 4, "Praha, Rim; Letadlo; 26.01.2024; 12:00; 14:00", new TimeSpan(0, 2, 0, 0, 0) },
                    { 14, new TimeOnly(18, 0, 0), new DateOnly(2024, 1, 26), new TimeOnly(16, 0, 0), 4, "Praha, Rim; Letadlo; 26.01.2024; 16:00; 18:00", new TimeSpan(0, 2, 0, 0, 0) }
                });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CityFromID", "CityToID", "PriceOfTicket", "RouteName" },
                values: new object[] { 2, 4, 350.0, "Brno, Praha; Vlak" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PriceOfTicket",
                value: 1500.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(12, 30, 0), "Zlin, Brno; Autobus; 26.01.2024; 10:00; 12:30", new TimeSpan(0, 2, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(16, 0, 0), "Zlin, Brno; Autobus; 26.01.2024; 13:30; 16:00", new TimeSpan(0, 2, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(18, 0, 0), "Zlin, Brno; Autobus; 26.01.2024; 15:30; 18:00", new TimeSpan(0, 2, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(19, 0, 0), "Zlin, Brno; Autobus; 26.01.2024; 16:30; 19:00", new TimeSpan(0, 2, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(19, 30, 0), "Zlin, Brno; Autobus; 26.01.2024; 17:00; 19:30", new TimeSpan(0, 2, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(18, 0, 0), "Zlin, Brno; Autobus; 27.01.2024; 15:30; 18:00", new TimeSpan(0, 2, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteInstances",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalTime", "RouteInstanceName", "TravelTime" },
                values: new object[] { new TimeOnly(18, 0, 0), "Zlin, Brno; Autobus; 28.01.2024; 15:30; 18:00", new TimeSpan(0, 2, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CityFromID", "CityToID", "PriceOfTicket", "RouteName" },
                values: new object[] { 1, 2, 140.0, "Zlin, Brno; Vlak" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PriceOfTicket",
                value: 2000.0);
        }
    }
}
