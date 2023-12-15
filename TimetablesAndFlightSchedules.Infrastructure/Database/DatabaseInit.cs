using System;
using System.Collections.Generic;
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
        public IList<Ticket> GetTickets()
        {
            IList<Ticket> tickets = new List<Ticket>();
            tickets.Add(new Ticket()
            {
                Id = 1,
                TicketType = "Autobus classic",
                NumberOfTickets = 50,
                Price = 45,
            });
            return tickets;
        }
        
        public IList<Vehicle> GetVehicles()
        {
            IList<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(new Vehicle()
            {
                Id = 1,
                VehicleType = "Autobus",
            });
            vehicles.Add(new Vehicle()
            {
                Id = 2,
                VehicleType = "Vlak",
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
            return cities;
        }

        public IList<Route> GetRoutes()
        {
            IList<Route> routes = new List<Route>();
            routes.Add(new Route()
            {
                Id = 1,
               /* Date = new DateOnly(2024, 01, 28),
                DepartureTime = new TimeOnly(15, 30),
                ArrivalTime = new TimeOnly(18, 00),
                TravelTime = new TimeSpan(2, 30, 0),*/
                //CityTo = ,
                //CityFrom = "Brno",
                //Ticket = GetTickets()[0],
                //Ticket = new Ticket() { Id = 1, NumberOfTickets = 60, Price = 50 },
                //Vehicle = ,
                //Vehicle = new Vehicle() { Id = 1, VehicleType = "Bus" },
            });
            return routes;
        }

        public IList<RouteInstance> GetRouteInstances()
        {
            IList<RouteInstance> routeInstances = new List<RouteInstance>();
            routeInstances.Add(new RouteInstance()
            {
                Id = 1,
                Date = new DateOnly(2024, 01, 28),
                DepartureTime = new TimeOnly(15, 30),
                ArrivalTime = new TimeOnly(18, 00),
                TravelTime = new TimeSpan(2, 30, 0),
            });
            return routeInstances;
        }
    }
}
