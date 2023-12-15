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
    public class RouteInstanceAdminDFakeService : IRouteInstanceAdminService
    {
        public IList<RouteInstance> Select()
        {
            return DatabaseFake.RouteInstances;
        }

        public void Create(RouteInstance routeInstance)
        {
            if (DatabaseFake.RouteInstances != null &&
                DatabaseFake.RouteInstances.Count > 0)
            {
                routeInstance.Id = DatabaseFake.RouteInstances.Last().Id + 1;
            }
            else
            {
                routeInstance.Id = 1;
            }

            if (DatabaseFake.RouteInstances != null)
            {
                routeInstance.TravelTime = routeInstance.ArrivalTime - routeInstance.DepartureTime;
                DatabaseFake.RouteInstances.Add(routeInstance);
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            RouteInstance? routeInstance =
                DatabaseFake.RouteInstances.FirstOrDefault(routeInstance => routeInstance.Id == id);

            if (routeInstance != null)
            {
                deleted = DatabaseFake.RouteInstances.Remove(routeInstance);
            }

            return deleted;
        }

        public void Edit(RouteInstance routeInstanceUpdated)
        {
            RouteInstance? routeInstance = DatabaseFake.RouteInstances.FirstOrDefault(r => r.Id == routeInstanceUpdated.Id);
            if (routeInstance != null)
            {
                routeInstance.RouteID = routeInstanceUpdated.RouteID;
                routeInstance.Date = routeInstanceUpdated.Date;
                routeInstance.DepartureTime = routeInstanceUpdated.DepartureTime;
                routeInstance.ArrivalTime = routeInstanceUpdated.ArrivalTime;
                routeInstance.TravelTime = routeInstanceUpdated.ArrivalTime - routeInstanceUpdated.DepartureTime;
            }
        }

    }
}