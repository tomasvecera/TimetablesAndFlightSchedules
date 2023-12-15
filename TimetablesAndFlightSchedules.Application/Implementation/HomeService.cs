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
    public class HomeService : IHomeService
    {
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;
        public HomeService(TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public RouteVehicleTicketViewModel GetHomeViewModel()
        {
            RouteVehicleTicketViewModel viewModel = new RouteVehicleTicketViewModel();

            viewModel.Vehicles = _timetablesAndFlightSchedulesDbContext.Vehicles.ToList();
            //viewModel.Tickets = _timetablesAndFlightSchedulesDbContext.Tickets.ToList();
            viewModel.Routes = _timetablesAndFlightSchedulesDbContext.Routes.ToList();

            return viewModel;
        }
    }
}