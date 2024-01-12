using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Application.ViewModels;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Application.Implementation
{
    public class HomeDFakeService : IHomeService
    {
        public RouteVehicleCityRouteInstanceViewModel GetHomeViewModel()
        {
            RouteVehicleCityRouteInstanceViewModel viewModel = new RouteVehicleCityRouteInstanceViewModel();

            viewModel.Vehicles = DatabaseFake.Vehicles;
            viewModel.Cities = DatabaseFake.Cities;
            viewModel.Routes = DatabaseFake.Routes;
            viewModel.RouteInstances = DatabaseFake.RouteInstances;

            return viewModel;
        }
    }
}
