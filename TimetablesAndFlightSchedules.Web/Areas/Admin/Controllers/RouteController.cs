using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;
using TimetablesAndFlightSchedules.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;

namespace TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class RouteController : Controller
    {
        IRouteAdminService _routeService;
        IVehicleAdminService _vehicleService;
        ICityAdminService _cityService;
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public RouteController(IRouteAdminService routeService, IVehicleAdminService vehicleAdminService, ICityAdminService cityService, TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _routeService = routeService;
            _vehicleService = vehicleAdminService;
            _cityService = cityService;
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IActionResult Index()
        {
            IList<Domain.Entities.Route> routes = _routeService.Select();
            return View(routes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetSelectLists();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Domain.Entities.Route route)
        {
            if (ModelState.IsValid) {
                _routeService.Create(route);
                return RedirectToAction(nameof(RouteController.Index));
            }
            else
            {
                SetSelectLists();
                return View(route);
            }
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _routeService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(RouteController.Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Domain.Entities.Route? route = _timetablesAndFlightSchedulesDbContext.Routes.FirstOrDefault(r => r.Id == Id);

            SetSelectLists();
            return View(route);
        }

        [HttpPost]
        public IActionResult Edit(Domain.Entities.Route route)
        {

            if (ModelState.IsValid)
            {
                _routeService.Edit(route);
                return RedirectToAction(nameof(RouteController.Index));
            }
            else
            {
                SetSelectLists();
                return View(route);
            }
        }
        void SetSelectLists()
        {
            IList<Vehicle> vehicles = _vehicleService.Select();
            ViewData[nameof(Domain.Entities.Route.VehicleID)] = new SelectList(vehicles, nameof(Vehicle.Id), nameof(Vehicle.VehicleType));
            IList<City> citiesFrom = _cityService.Select();
            ViewData[nameof(Domain.Entities.Route.CityFromID)] = new SelectList(citiesFrom, nameof(City.Id), nameof(City.Name));
            IList<City> citiesTo = _cityService.Select();
            ViewData[nameof(Domain.Entities.Route.CityToID)] = new SelectList(citiesTo, nameof(City.Id), nameof(City.Name));
        }
    }
}
