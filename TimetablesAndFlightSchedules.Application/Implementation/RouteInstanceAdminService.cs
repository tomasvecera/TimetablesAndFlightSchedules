using Microsoft.EntityFrameworkCore;
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
            return _timetablesAndFlightSchedulesDbContext.RouteInstances
                                                          .Include(r => r.Route)
                                                          .OrderBy(r => r.Id)
                                                          .ToList();
        }

        public void Create(RouteInstance routeInstance)
        {
            if (_timetablesAndFlightSchedulesDbContext.RouteInstances != null)
            {
                Route? route = _timetablesAndFlightSchedulesDbContext.Routes.FirstOrDefault(r => r.Id == routeInstance.RouteID);
                routeInstance.RouteInstanceName = route.RouteName + "; " + routeInstance.Date + "; " + routeInstance.DepartureTime + "; " + routeInstance.ArrivalTime;
               
                bool contains = false;
                foreach (RouteInstance ri in _timetablesAndFlightSchedulesDbContext.RouteInstances)
                {
                    if (ri.RouteInstanceName == routeInstance.RouteInstanceName)
                    {
                        contains = true;
                    }
                }
                if (!contains)
                {
                    _timetablesAndFlightSchedulesDbContext.RouteInstances.Add(routeInstance);
                    _timetablesAndFlightSchedulesDbContext.SaveChanges();
                }


                //routeInstance.TravelTime = routeInstance.ArrivalTime - routeInstance.DepartureTime;

                //_timetablesAndFlightSchedulesDbContext.RouteInstances.Add(routeInstance);
                //_timetablesAndFlightSchedulesDbContext.SaveChanges();
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
                Route? route = _timetablesAndFlightSchedulesDbContext.Routes.FirstOrDefault(r => r.Id == routeInstanceUpdated.RouteID);
                routeInstanceUpdated.RouteInstanceName = route.RouteName + "; " + routeInstanceUpdated.Date + "; " + routeInstanceUpdated.DepartureTime + "; " + routeInstanceUpdated.ArrivalTime;

                bool contains = false;
                foreach (RouteInstance ri in _timetablesAndFlightSchedulesDbContext.RouteInstances)
                {
                    if (ri.RouteInstanceName == routeInstanceUpdated.RouteInstanceName)
                    {
                        contains = true;
                    }
                }
                if (!contains)
                {
                    routeInstance.RouteID = routeInstanceUpdated.RouteID;
                    routeInstance.Date = routeInstanceUpdated.Date;
                    routeInstance.DepartureTime = routeInstanceUpdated.DepartureTime;
                    routeInstance.ArrivalTime = routeInstanceUpdated.ArrivalTime;
                    routeInstance.TravelTime = routeInstanceUpdated.ArrivalTime - routeInstanceUpdated.DepartureTime;

                    //Route? route = _timetablesAndFlightSchedulesDbContext.Routes.FirstOrDefault(r => r.Id == routeInstanceUpdated.RouteID);
                    //routeInstance.RouteInstanceName = route.RouteName + "; " + routeInstanceUpdated.Date + "; " + routeInstanceUpdated.DepartureTime + "; " + routeInstanceUpdated.ArrivalTime;
                    routeInstance.RouteInstanceName = routeInstanceUpdated.RouteInstanceName;

                    _timetablesAndFlightSchedulesDbContext.SaveChanges();
                }
                //_timetablesAndFlightSchedulesDbContext.SaveChanges();
            }
        }

    }
}