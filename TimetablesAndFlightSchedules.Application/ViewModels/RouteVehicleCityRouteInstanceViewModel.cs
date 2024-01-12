using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Application.ViewModels
{
    public class RouteVehicleCityRouteInstanceViewModel
    {
        public IList<Route>? Routes { get; set; }
        public IList<Vehicle>? Vehicles { get; set; }

        public IList<City>? Cities { get; set; }

        public IList<RouteInstance>? RouteInstances { get; set; }
    }
}
