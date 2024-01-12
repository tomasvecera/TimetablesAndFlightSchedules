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
    [Migration("20240111150129_mySQL_1.4.0_RenamedVehicleTypeLetadlo")]
    partial class mySQL_140_RenamedVehicleTypeLetadlo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

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
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("NOW(6)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

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

                    b.Property<string>("RouteName")
                        .HasColumnType("longtext");

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
                            RouteName = "Zlin, Brno; Autobus",
                            VehicleID = 1
                        },
                        new
                        {
                            Id = 2,
                            CityFromID = 1,
                            CityToID = 2,
                            PriceOfTicket = 140.0,
                            RouteName = "Zlin, Brno; Vlak",
                            VehicleID = 2
                        },
                        new
                        {
                            Id = 3,
                            CityFromID = 3,
                            CityToID = 1,
                            PriceOfTicket = 45.0,
                            RouteName = "Uherske Hradiste, Zlin; Autobus",
                            VehicleID = 1
                        },
                        new
                        {
                            Id = 4,
                            CityFromID = 4,
                            CityToID = 5,
                            PriceOfTicket = 2000.0,
                            RouteName = "Praha, Rim; Letadlo",
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

                    b.Property<string>("RouteInstanceName")
                        .HasColumnType("longtext");

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
                            RouteInstanceName = "Zlin, Brno; Autobus; 26.01.2024; 15:30; 18:00",
                            TravelTime = new TimeSpan(0, 2, 30, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            ArrivalTime = new TimeOnly(18, 0, 0),
                            Date = new DateOnly(2024, 1, 27),
                            DepartureTime = new TimeOnly(15, 30, 0),
                            RouteID = 1,
                            RouteInstanceName = "Zlin, Brno; Autobus; 27.01.2024; 15:30; 18:00",
                            TravelTime = new TimeSpan(0, 2, 30, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            ArrivalTime = new TimeOnly(18, 0, 0),
                            Date = new DateOnly(2024, 1, 28),
                            DepartureTime = new TimeOnly(15, 30, 0),
                            RouteID = 1,
                            RouteInstanceName = "Zlin, Brno; Autobus; 28.01.2024; 15:30; 18:00",
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
                            VehicleType = "Letadlo"
                        });
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Infrastructure.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Infrastructure.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                            Email = "admin@admin.cz",
                            EmailConfirmed = true,
                            FirstName = "Adminek",
                            LastName = "Adminovy",
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@ADMIN.CZ",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                            Email = "manager@manager.cz",
                            EmailConfirmed = true,
                            FirstName = "Managerek",
                            LastName = "Managerovy",
                            LockoutEnabled = true,
                            NormalizedEmail = "MANAGER@MANAGER.CZ",
                            NormalizedUserName = "MANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                            TwoFactorEnabled = false,
                            UserName = "manager"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("TimetablesAndFlightSchedules.Infrastructure.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("TimetablesAndFlightSchedules.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("TimetablesAndFlightSchedules.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("TimetablesAndFlightSchedules.Infrastructure.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimetablesAndFlightSchedules.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("TimetablesAndFlightSchedules.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TimetablesAndFlightSchedules.Domain.Entities.Order", b =>
                {
                    b.HasOne("TimetablesAndFlightSchedules.Infrastructure.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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
