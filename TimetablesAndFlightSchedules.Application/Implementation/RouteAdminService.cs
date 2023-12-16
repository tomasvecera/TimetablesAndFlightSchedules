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
    public class RouteAdminService : IRouteAdminService
    {
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public RouteAdminService(TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IList<Route> Select()
        {
            return _timetablesAndFlightSchedulesDbContext.Routes.ToList();
        }

        public void Create(Route route)
        {
            if (_timetablesAndFlightSchedulesDbContext.Routes != null)
            {
                _timetablesAndFlightSchedulesDbContext.Routes.Add(route);
                _timetablesAndFlightSchedulesDbContext.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Route? route =
                _timetablesAndFlightSchedulesDbContext.Routes.FirstOrDefault(route => route.Id == id);

            if (route != null)
            {
                _timetablesAndFlightSchedulesDbContext.Routes.Remove(route);
                _timetablesAndFlightSchedulesDbContext.SaveChanges();

                deleted = true;
            }

            return deleted;
        }

        public void Edit(Route routeUpdated)
        {
            Route? route = 
                   _timetablesAndFlightSchedulesDbContext.Routes.FirstOrDefault(r => r.Id == routeUpdated.Id);
            if (route != null)
            {
                route.CityFromID = routeUpdated.CityFromID;
                route.CityToID = routeUpdated.CityToID;
                //route.TicketID = routeUpdated.TicketID;
                route.VehicleID = routeUpdated.VehicleID;
                route.PriceOfTicket = routeUpdated.PriceOfTicket;

                _timetablesAndFlightSchedulesDbContext.SaveChanges();
                //route.CityFrom = routeUpdated.CityFrom;
                //route.Ticket = routeUpdated.Ticket;
                //route.Vehicle = routeUpdated.Vehicle;
            }
        }
    }
}