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
    public class RouteAdminService : IRouteAdminService
    {
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public RouteAdminService(TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IList<Route> Select()
        {
            return _timetablesAndFlightSchedulesDbContext.Routes
                                                            .Include(r => r.Vehicle)
                                                            .Include(r => r.CityFrom)
                                                            .Include(r => r.CityTo)
                                                            .OrderBy(r => r.Id)
                                                            .ToList();
        }

        public void Create(Route route)
        {
            if (_timetablesAndFlightSchedulesDbContext.Routes != null)
            {
                City? cityF = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == route.CityFromID);
                City? cityT = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == route.CityToID);
                Vehicle? vehicle = _timetablesAndFlightSchedulesDbContext.Vehicles.FirstOrDefault(v => v.Id == route.VehicleID);
                route.RouteName = cityF.Name + ", " + cityT.Name + "; " + vehicle.VehicleType;

                bool contains = false;
                foreach (Route r in _timetablesAndFlightSchedulesDbContext.Routes)
                {
                    if (r.RouteName == route.RouteName)
                    {
                        contains = true;
                    }
                }
                if (!contains)
                {
                    _timetablesAndFlightSchedulesDbContext.Routes.Add(route);
                    _timetablesAndFlightSchedulesDbContext.SaveChanges();
                }


                //City? cityF = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == route.CityFromID);
                //City? cityT = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == route.CityToID);
                //Vehicle? vehicle = _timetablesAndFlightSchedulesDbContext.Vehicles.FirstOrDefault(v => v.Id == route.VehicleID);
                //route.RouteName = cityF.Name + ", " + cityT.Name + "; " + vehicle.VehicleType;

                //_timetablesAndFlightSchedulesDbContext.Routes.Add(route);
                //_timetablesAndFlightSchedulesDbContext.SaveChanges();
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
                City? cityF = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == routeUpdated.CityFromID);
                City? cityT = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == routeUpdated.CityToID);
                Vehicle? vehicle = _timetablesAndFlightSchedulesDbContext.Vehicles.FirstOrDefault(v => v.Id == route.VehicleID);
                routeUpdated.RouteName = cityF.Name + ", " + cityT.Name + "; " + vehicle.VehicleType;

                bool contains = false;
                foreach (Route r in _timetablesAndFlightSchedulesDbContext.Routes)
                {
                    if (r.RouteName == routeUpdated.RouteName)
                    {
                        contains = true;
                    }
                }
                if (!contains)
                {
                    route.CityFromID = routeUpdated.CityFromID;
                    route.CityToID = routeUpdated.CityToID;
                    route.VehicleID = routeUpdated.VehicleID;
                    route.PriceOfTicket = routeUpdated.PriceOfTicket;

                    //City? cityF = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == routeUpdated.CityFromID);
                    //City? cityT = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == routeUpdated.CityToID);
                    //Vehicle? vehicle = _timetablesAndFlightSchedulesDbContext.Vehicles.FirstOrDefault(v => v.Id == route.VehicleID);
                    //route.RouteName = cityF.Name + ", " + cityT.Name + "; " + vehicle.VehicleType;
                    route.RouteName = routeUpdated.RouteName;

                    _timetablesAndFlightSchedulesDbContext.SaveChanges();
                }


                /*route.CityFromID = routeUpdated.CityFromID;
                route.CityToID = routeUpdated.CityToID;
                route.VehicleID = routeUpdated.VehicleID;
                route.PriceOfTicket = routeUpdated.PriceOfTicket;

                City? cityF = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == routeUpdated.CityFromID);
                City? cityT = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == routeUpdated.CityToID);
                Vehicle? vehicle = _timetablesAndFlightSchedulesDbContext.Vehicles.FirstOrDefault(v => v.Id == route.VehicleID);
                route.RouteName = cityF.Name + ", " + cityT.Name + "; " + vehicle.VehicleType;

                _timetablesAndFlightSchedulesDbContext.SaveChanges();*/
            }
        }
    }
}