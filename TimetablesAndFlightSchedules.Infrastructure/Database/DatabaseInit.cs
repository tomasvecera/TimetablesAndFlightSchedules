using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                NumberOfTickets = 100,
                Price = 50,
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
            return cities;
        }

        public IList<Route> GetRoutes()
        {
            IList<Route> products = new List<Route>();
            products.Add(new Route()
            {
                Id = 1,
                Date = new DateOnly(2023, 10, 25),
                DepartureTime = new TimeOnly(15, 30),
                ArrivalTime = new TimeOnly(18, 00),
                TravelTime = new TimeSpan(2, 30, 0),
                //To = "Praha",
                //From = "Brno",
                //Ticket = GetTickets()[0],
                //Ticket = new Ticket() { Id = 1, NumberOfTickets = 60, Price = 50 },
                //Vehicle = vehicles,
                //Vehicle = new Vehicle() { Id = 1, VehicleType = "Bus" },
            });
            return products;
        }
    }
}
