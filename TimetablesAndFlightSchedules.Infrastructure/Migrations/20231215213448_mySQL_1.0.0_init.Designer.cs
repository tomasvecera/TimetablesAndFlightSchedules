﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimetablesAndFlightSchedules.Infrastructure.Database;

#nullable disable

namespace TimetablesAndFlightSchedules.Infrastructure.Migrations
{
    [DbContext(typeof(TimetablesAndFlightSchedulesDbContext))]
    [Migration("20231215213448_mySQL_1.0.0_init")]
    partial class mySQL_100_init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Zlin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Brno"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Uherske Hradiste"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Praha"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Rim"
                        });
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("RouteInstanceID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderID");

                    b.HasIndex("RouteInstanceID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CityFromID")
                        .HasColumnType("int");

                    b.Property<int>("CityToID")
                        .HasColumnType("int");

                    b.Property<double>("PriceOfTicket")
                        .HasColumnType("double");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityFromID");

                    b.HasIndex("CityToID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityFromID = 1,
                            CityToID = 2,
                            PriceOfTicket = 120.0,
                            VehicleID = 1
                        },
                        new
                        {
                            Id = 2,
                            CityFromID = 1,
                            CityToID = 2,
                            PriceOfTicket = 140.0,
                            VehicleID = 2
                        },
                        new
                        {
                            Id = 3,
                            CityFromID = 3,
                            CityToID = 1,
                            PriceOfTicket = 45.0,
                            VehicleID = 1
                        },
                        new
                        {
                            Id = 4,
                            CityFromID = 4,
                            CityToID = 5,
                            PriceOfTicket = 2000.0,
                            VehicleID = 3
                        });
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.RouteInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<TimeOnly>("ArrivalTime")
                        .HasColumnType("time(6)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("DepartureTime")
                        .HasColumnType("time(6)");

                    b.Property<int>("RouteID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TravelTime")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.HasIndex("RouteID");

                    b.ToTable("RouteInstances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalTime = new TimeOnly(18, 0, 0),
                            Date = new DateOnly(2024, 1, 26),
                            DepartureTime = new TimeOnly(15, 30, 0),
                            RouteID = 1,
                            TravelTime = new TimeSpan(0, 2, 30, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            ArrivalTime = new TimeOnly(18, 0, 0),
                            Date = new DateOnly(2024, 1, 27),
                            DepartureTime = new TimeOnly(15, 30, 0),
                            RouteID = 1,
                            TravelTime = new TimeSpan(0, 2, 30, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            ArrivalTime = new TimeOnly(18, 0, 0),
                            Date = new DateOnly(2024, 1, 28),
                            DepartureTime = new TimeOnly(15, 30, 0),
                            RouteID = 1,
                            TravelTime = new TimeSpan(0, 2, 30, 0, 0)
                        });
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("NumberOfTickets")
                        .HasColumnType("int");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NumberOfTickets = 50,
                            VehicleType = "Autobus"
                        },
                        new
                        {
                            Id = 2,
                            NumberOfTickets = 100,
                            VehicleType = "Vlak"
                        },
                        new
                        {
                            Id = 3,
                            NumberOfTickets = 200,
                            VehicleType = "Letadlo A320"
                        });
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("TimetablesAndFlightSchedules.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimetablesAndFlightSchedules.Domain.Entities.RouteInstance", "RouteInstance")
                        .WithMany()
                        .HasForeignKey("RouteInstanceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("RouteInstance");
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.Route", b =>
                {
                    b.HasOne("TimetablesAndFlightSchedules.Domain.Entities.City", "CityFrom")
                        .WithMany()
                        .HasForeignKey("CityFromID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimetablesAndFlightSchedules.Domain.Entities.City", "CityTo")
                        .WithMany()
                        .HasForeignKey("CityToID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimetablesAndFlightSchedules.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityFrom");

                    b.Navigation("CityTo");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.RouteInstance", b =>
                {
                    b.HasOne("TimetablesAndFlightSchedules.Domain.Entities.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}