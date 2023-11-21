using Microsoft.AspNetCore.Mvc;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Application.ViewModels;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RouteVehicleTicketController : Controller
    {
        IRouteVehicleTicketAdminService _Service;

        public RouteVehicleTicketController(IRouteVehicleTicketAdminService Service)
        {
            _Service = Service;
        }

        public IActionResult Index()
        {
            RouteVehicleTicketViewModel viewModel = _Service.GetRouteVehicleTicketViewModel();
            return View(viewModel);
        }
    }
}
