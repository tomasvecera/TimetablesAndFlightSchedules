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
        public RouteVehicleCityViewModel GetHomeViewModel()
        {
            RouteVehicleCityViewModel viewModel = new RouteVehicleCityViewModel();

            viewModel.Vehicles = DatabaseFake.Vehicles;
            viewModel.Cities = DatabaseFake.Cities;
            viewModel.Routes = DatabaseFake.Routes;
            viewModel.RouteInstances = DatabaseFake.RouteInstances;

            return viewModel;
        }
    }
}
