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
    public class RouteInstanceAdminService : IRouteInstanceAdminService
    {
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public RouteInstanceAdminService(TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IList<RouteInstance> Select()
        {
            return _timetablesAndFlightSchedulesDbContext.RouteInstances.ToList();
        }

        public void Create(RouteInstance routeInstance)
        {
            if (_timetablesAndFlightSchedulesDbContext.RouteInstances != null)
            {
                routeInstance.TravelTime = routeInstance.ArrivalTime - routeInstance.DepartureTime;

                _timetablesAndFlightSchedulesDbContext.RouteInstances.Add(routeInstance);
                _timetablesAndFlightSchedulesDbContext.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            RouteInstance? routeInstance =
                _timetablesAndFlightSchedulesDbContext.RouteInstances.FirstOrDefault(routeInstance => routeInstance.Id == id);

            if (routeInstance != null)
            {
                _timetablesAndFlightSchedulesDbContext.RouteInstances.Remove(routeInstance);
                _timetablesAndFlightSchedulesDbContext.SaveChanges();

                deleted = true;
            }

            return deleted;
        }

        public void Edit(RouteInstance routeInstanceUpdated)
        {
            RouteInstance? routeInstance = 
                _timetablesAndFlightSchedulesDbContext.RouteInstances.FirstOrDefault(r => r.Id == routeInstanceUpdated.Id);
            if (routeInstance != null)
            {
                routeInstance.RouteID = routeInstanceUpdated.RouteID;
                routeInstance.Date = routeInstanceUpdated.Date;
                routeInstance.DepartureTime = routeInstanceUpdated.DepartureTime;
                routeInstance.ArrivalTime = routeInstanceUpdated.ArrivalTime;
                routeInstance.TravelTime = routeInstanceUpdated.ArrivalTime - routeInstanceUpdated.DepartureTime;

                _timetablesAndFlightSchedulesDbContext.SaveChanges();
            }
        }

    }
}