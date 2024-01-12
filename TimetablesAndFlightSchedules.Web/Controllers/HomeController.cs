using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Application.ViewModels;
using TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers;
using TimetablesAndFlightSchedules.Web.Models;

namespace TimetablesAndFlightSchedules.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            RouteVehicleCityRouteInstanceViewModel viewModel = _homeService.GetHomeViewModel();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Submit(string vehicle, string from, string to, DateOnly date, TimeOnly time)
        {
            if(vehicle == null || from == null || to == null || date == null || time == null)
            {
                return RedirectToAction(nameof(HomeController.Index));
            }

            HttpContext.Session.SetString("InputVehicle", vehicle);
            HttpContext.Session.SetString("InputFrom", from);
            HttpContext.Session.SetString("InputTo", to);
            HttpContext.Session.SetString("InputDate", date.ToString("dd-MM-yyyy"));
            HttpContext.Session.SetString("InputTime", time.ToString("HH:mm"));
            
            return RedirectToAction(nameof(HomeController.Results));
        }

        public IActionResult Results()
        {
            string inputVehicle = HttpContext.Session.GetString("InputVehicle");
            string inputFrom = HttpContext.Session.GetString("InputFrom");
            string inputTo = HttpContext.Session.GetString("InputTo");
            string inputDate = HttpContext.Session.GetString("InputDate");
            string inputTime = HttpContext.Session.GetString("InputTime");

            RouteVehicleCityRouteInstanceViewModel viewModel = _homeService.GetHomeViewModel();
            return View(viewModel);
        }
    }
}