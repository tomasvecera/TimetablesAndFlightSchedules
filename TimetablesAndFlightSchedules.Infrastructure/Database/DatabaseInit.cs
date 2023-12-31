﻿using System;
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

namespace TimetablesAndFlightSchedules.Infrastructure.Database
{
    internal class DatabaseInit
    {        
        /*public IList<Ticket> GetTickets()
        {
            IList<Ticket> tickets = new List<Ticket>();
            tickets.Add(new Ticket()
            {
                Id = 1,
                TicketType = "Autobus classic Zlin Brno",
                NumberOfTickets = 50,
                Price = 45,
            });
            tickets.Add(new Ticket()
            {
                Id = 2,
                TicketType = "Autobus classic Zlin Uherske Hradiste",
                NumberOfTickets = 50,
                Price = 20,
            });
            tickets.Add(new Ticket()
            {
                Id = 3,
                TicketType = "Vlak classic Praha Brno",
                NumberOfTickets = 150,
                Price = 155,
            });
            tickets.Add(new Ticket()
            {
                Id = 4,
                TicketType = "Vlak classic Zlin Brno",
                NumberOfTickets = 150,
                Price = 100,
            });
            tickets.Add(new Ticket()
            {
                Id = 5,
                TicketType = "Letadlo A320 Praha Rim",
                NumberOfTickets = 200,
                Price = 2500,
            });
            return tickets;
        }*/
        
        public IList<Vehicle> GetVehicles()
        {
            IList<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(new Vehicle()
            {
                Id = 1,
                VehicleType = "Autobus",
                NumberOfTickets = 50,
            });
            vehicles.Add(new Vehicle()
            {
                Id = 2,
                VehicleType = "Vlak",
                NumberOfTickets = 100,
            });
            vehicles.Add(new Vehicle()
            {
                Id = 3,
                VehicleType = "Letadlo A320",
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
            });
            routes.Add(new Route()
            {
                Id = 2,
                CityFromID = 1,
                CityToID = 2,
                PriceOfTicket = 140,
                VehicleID = 2,
            });
            routes.Add(new Route()
            {
                Id = 3,
                CityFromID = 3,
                CityToID = 1,
                PriceOfTicket = 45,
                VehicleID = 1,
            });
            routes.Add(new Route()
            {
                Id = 4,
                CityFromID = 4,
                CityToID = 5,
                PriceOfTicket = 2000,
                VehicleID = 3,
            });
            return routes;
        }

        public IList<RouteInstance> GetRouteInstances()
        {
            IList<RouteInstance> routeInstances = new List<RouteInstance>();
            routeInstances.Add(new RouteInstance()
            {
                Id = 1,
                RouteID = 1,
                Date = new DateOnly(2024, 01, 26),
                DepartureTime = new TimeOnly(15, 30),
                ArrivalTime = new TimeOnly(18, 00),
                TravelTime = new TimeSpan(2, 30, 0),
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 2,
                RouteID = 1,
                Date = new DateOnly(2024, 01, 27),
                DepartureTime = new TimeOnly(15, 30),
                ArrivalTime = new TimeOnly(18, 00),
                TravelTime = new TimeSpan(2, 30, 0),
            });
            routeInstances.Add(new RouteInstance()
            {
                Id = 3,
                RouteID = 1,
                Date = new DateOnly(2024, 01, 28),
                DepartureTime = new TimeOnly(15, 30),
                ArrivalTime = new TimeOnly(18, 00),
                TravelTime = new TimeSpan(2, 30, 0),
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

        public (User, List<IdentityUserRole<int>>) CreateCtustomerWithRoles()
        {
            User customer = new User()
            {
                Id = 2,
                FirstName = "Customerek",
                LastName = "Customerovky",
                UserName = "customer",
                NormalizedUserName = "CUSTOMER",
                Email = "customer@customer.cz",
                NormalizedEmail = "CUSTOMER@CUSTOMER.CZ",
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

            List<IdentityUserRole<int>> customerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 3,
                    RoleId = 3
                }
            };

            return (customer, customerUserRoles);
        }
    }
}