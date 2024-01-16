using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using TimetablesAndFlightSchedules.Infrastructure.Identity;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TimetablesAndFlightSchedules.Infrastructure.Database
{
    internal class DatabaseInit
    {
        public IList<Vehicle> GetVehicles()
        {
            IList<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(new Vehicle()
            {
                Id = 1,
                VehicleType = "Bus",
                NumberOfTickets = 50,
            });
            vehicles.Add(new Vehicle()
            {
                Id = 2,
                VehicleType = "Train",
                NumberOfTickets = 100,
            });
            vehicles.Add(new Vehicle()
            {
                Id = 3,
                VehicleType = "Airplane",
                NumberOfTickets = 200,
            });
            return vehicles;
        }

        public IList<City> GetCities()
        {
            IList<City> cities = new List<City>();
            cities.Add(new City()
            {
                Id = 1,
                Name = "Zlin",
            });
            cities.Add(new City()
            {
                Id = 2,
                Name = "Brno",
            });
            cities.Add(new City()
            {
                Id = 3,
                Name = "Uherske Hradiste",
            });
            cities.Add(new City()
            {
                Id = 4,
                Name = "Praha",
            });
            cities.Add(new City()
            {
                Id = 5,
                Name = "Rim",
            });
            return cities;
        }

        public IList<Route> GetRoutes()
        {
            IList<Route> routes = new List<Route>();
            routes.Add(new Route()
            {
                Id = 1,
                CityFromID = 1,
                CityToID = 2,
                PriceOfTicket = 120,
                VehicleID = 1,
                RouteName = "Zlin; Brno; Bus",
            });
            routes.Add(new Route()
            {
                Id = 2,
                CityFromID = 2,
                CityToID = 4,
                PriceOfTicket = 350,
                VehicleID = 2,
                RouteName = "Brno; Praha; Train",
            });
            routes.Add(new Route()
            {
                Id = 3,
                CityFromID = 3,
                CityToID = 1,
                PriceOfTicket = 45,
                VehicleID = 1,
                RouteName = "Uherske Hradiste; Zlin; Bus",
            });
            routes.Add(new Route()
            {
                Id = 4,
                CityFromID = 4,
                CityToID = 5,
                PriceOfTicket = 1500,
                VehicleID = 3,
                RouteName = "Praha; Rim; Airplane",
            });
            return routes;
        }

        public IList<RouteInstance> GetRouteInstances()
        {
            IList<RouteInstance> routeInstances = new List<RouteInstance>();
            // Bus
            routeInstances.Add(new RouteInstance()
            {
                Id = 1,
                RouteID = 1,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(10, 00),
                ArrivalTime = new TimeOnly(11, 30),
                TravelTime = new TimeSpan(1, 30, 0),
                RouteInstanceName = "Zlin; Brno; Bus; 26.01.2024; 10:00; 11:30",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 2,
                RouteID = 1,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(13, 30),
                ArrivalTime = new TimeOnly(15, 00),
                TravelTime = new TimeSpan(1, 30, 0),
                RouteInstanceName = "Zlin; Brno; Bus; 26.01.2024; 13:30; 15:00",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 3,
                RouteID = 1,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(15, 30),
                ArrivalTime = new TimeOnly(17, 00),
                TravelTime = new TimeSpan(1, 30, 0),
                RouteInstanceName = "Zlin; Brno; Bus; 26.01.2024; 15:30; 17:00",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 4,
                RouteID = 1,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(16, 30),
                ArrivalTime = new TimeOnly(18, 00),
                TravelTime = new TimeSpan(1, 30, 0),
                RouteInstanceName = "Zlin; Brno; Bus; 26.01.2024; 16:30; 18:00",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 5,
                RouteID = 1,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(17, 00),
                ArrivalTime = new TimeOnly(18, 30),
                TravelTime = new TimeSpan(1, 30, 0),
                RouteInstanceName = "Zlin; Brno; Bus; 26.01.2024; 17:00; 18:30",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 6,
                RouteID = 1,
                Date = new DateOnly(2024, 01, 27),
                DepartureTime = new TimeOnly(15, 30),
                ArrivalTime = new TimeOnly(17, 00),
                TravelTime = new TimeSpan(1, 30, 0),
                RouteInstanceName = "Zlin; Brno; Bus; 27.01.2024; 15:30; 17:00",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 7,
                RouteID = 1,
                Date = new DateOnly(2024, 01, 28),
                DepartureTime = new TimeOnly(15, 30),
                ArrivalTime = new TimeOnly(17, 00),
                TravelTime = new TimeSpan(1, 30, 0),
                RouteInstanceName = "Zlin; Brno; Bus; 28.01.2024; 15:30; 17:00",
            });
            // Train
            routeInstances.Add(new RouteInstance()
            {
                Id = 8,
                RouteID = 2,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(10, 00),
                ArrivalTime = new TimeOnly(12, 30),
                TravelTime = new TimeSpan(2, 30, 0),
                RouteInstanceName = "Brno; Praha; Train; 26.01.2024; 10:00; 12:30",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 9,
                RouteID = 2,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(12, 00),
                ArrivalTime = new TimeOnly(14, 30),
                TravelTime = new TimeSpan(2, 30, 0),
                RouteInstanceName = "Brno; Praha; Train; 26.01.2024; 12:00; 14:30",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 10,
                RouteID = 2,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(14, 00),
                ArrivalTime = new TimeOnly(16, 30),
                TravelTime = new TimeSpan(2, 30, 0),
                RouteInstanceName = "Brno; Praha; Train; 26.01.2024; 14:00; 16:30",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 11,
                RouteID = 2,
                Date = new DateOnly(2024, 01, 27),
                DepartureTime = new TimeOnly(12, 00),
                ArrivalTime = new TimeOnly(14, 30),
                TravelTime = new TimeSpan(2, 30, 0),
                RouteInstanceName = "Brno; Praha; Train; 27.01.2024; 12:00; 14:30",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 12,
                RouteID = 2,
                Date = new DateOnly(2024, 01, 28),
                DepartureTime = new TimeOnly(12, 00),
                ArrivalTime = new TimeOnly(14, 30),
                TravelTime = new TimeSpan(2, 30, 0),
                RouteInstanceName = "Brno; Praha; Train; 28.01.2024; 12:00; 14:30",
            });
            // Airplane
            routeInstances.Add(new RouteInstance()
            {
                Id = 13,
                RouteID = 4,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(12, 00),
                ArrivalTime = new TimeOnly(14, 00),
                TravelTime = new TimeSpan(2, 00, 0),
                RouteInstanceName = "Praha; Rim; Airplane; 26.01.2024; 12:00; 14:00",
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 14,
                RouteID = 4,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(16, 00),
                ArrivalTime = new TimeOnly(18, 00),
                TravelTime = new TimeSpan(2, 00, 0),
                RouteInstanceName = "Praha; Rim; Airplane; 26.01.2024; 16:00; 18:00",
            });
            return routeInstances;
        }

        public List<Role> CreateRoles()
        {
            List<Role> roles = new List<Role>();

            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };

            Role roleManager = new Role()
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
            };

            Role roleCustomer = new Role()
            {
                Id = 3,
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };

            roles.Add(roleAdmin);
            roles.Add(roleManager);
            roles.Add(roleCustomer);

            return roles;
        }
        public (User, List<IdentityUserRole<int>>) CreateAdminWithRoles()
        {
            User admin = new User()
            {
                Id = 1,
                FirstName = "Adminek",
                LastName = "Adminovy",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.cz",
                NormalizedEmail = "ADMIN@ADMIN.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };

            return (admin, adminUserRoles);
        }

        public (User, List<IdentityUserRole<int>>) CreateManagerWithRoles()
        {
            User manager = new User()
            {
                Id = 2,
                FirstName = "Managerek",
                LastName = "Managerovy",
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@manager.cz",
                NormalizedEmail = "MANAGER@MANAGER.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> managerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };

            return (manager, managerUserRoles);
        }
    }
}