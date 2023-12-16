using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static List<Route> Routes { get; set; }

        public static List<RouteInstance> RouteInstances { get; set; }

        public static List<Vehicle> Vehicles { get; set; }

        //public static List<Ticket> Tickets { get; set; }

        public static List<City> Cities { get; set; }

        static DatabaseFake()
        {
            DatabaseInit dbInit = new DatabaseInit();
            Routes = dbInit.GetRoutes().ToList();
            RouteInstances = dbInit.GetRouteInstances().ToList();
            //Tickets = dbInit.GetTickets().ToList();
            Vehicles = dbInit.GetVehicles().ToList();
            Cities = dbInit.GetCities().ToList();
        }
    }
}
