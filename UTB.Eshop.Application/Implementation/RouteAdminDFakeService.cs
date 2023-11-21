using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Application.Implementation
{
    public class RouteAdminDFakeService : IRouteAdminService
    {
        public IList<Route> Select()
        {
            return DatabaseFake.Routes;
        }

        public void Create(Route route)
        {
            if (DatabaseFake.Routes != null &&
                DatabaseFake.Routes.Count > 0)
            {
                route.Id = DatabaseFake.Routes.Last().Id + 1;
            }
            else
            {
                route.Id = 1;
            }

            if (DatabaseFake.Routes != null)
                route.TravelTime = route.ArrivalTime - route.DepartureTime;
                DatabaseFake.Routes.Add(route);
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Route? route =
                DatabaseFake.Routes.FirstOrDefault(route => route.Id == id);
            
            if (route != null)
            {
                deleted = DatabaseFake.Routes.Remove(route);
            }

            return deleted;
        }

        public void Edit(Route routeUpdated)
        {
            Route? route = DatabaseFake.Routes.FirstOrDefault(r => r.Id == routeUpdated.Id);
            if(route != null)
            {
                route.Date = routeUpdated.Date;
                route.DepartureTime = routeUpdated.DepartureTime;
                route.ArrivalTime = routeUpdated.ArrivalTime;
                route.TravelTime = routeUpdated.ArrivalTime - routeUpdated.DepartureTime;
                route.To = routeUpdated.To;
                route.From = routeUpdated.From;
                route.Ticket = routeUpdated.Ticket;
                route.Vehicle = routeUpdated.Vehicle;
            }
        }

    }
}
