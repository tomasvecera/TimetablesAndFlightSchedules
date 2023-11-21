using Microsoft.AspNetCore.Mvc;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Application.ViewModels;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPageController : Controller
    {
        /*IRouteAdminService _routeService;
        public AdminPageController(IRouteAdminService routeService)
        {
            _routeService = routeService;
        }*/

        public IActionResult Index()
        {
            return View();
        }
    }
}
