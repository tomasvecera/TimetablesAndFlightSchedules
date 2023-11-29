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
        public RouteVehicleTicketViewModel GetHomeViewModel()
        {
            RouteVehicleTicketViewModel viewModel = new RouteVehicleTicketViewModel();

            viewModel.Vehicles = DatabaseFake.Vehicles;
            viewModel.Tickets = DatabaseFake.Tickets;
            viewModel.Routes = DatabaseFake.Routes;

            return viewModel;
        }
    }
}
