using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

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
    }
}
