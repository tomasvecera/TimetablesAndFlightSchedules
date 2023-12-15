using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RouteController : Controller
    {
        IRouteAdminService _routeService;
        IVehicleAdminService _vehicleService;
        ICityAdminService _cityService;
        ITicketAdminService _ticketService;
        
        public RouteController(IRouteAdminService routeService, IVehicleAdminService vehicleAdminService, ICityAdminService cityService, ITicketAdminService ticketService)
        {
            _routeService = routeService;
            _vehicleService = vehicleAdminService;
            _cityService = cityService;
            _ticketService = ticketService;
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

            //_routeService.Create(route);

            //return RedirectToAction(nameof(RouteController.Index));
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
            Domain.Entities.Route? route =
                DatabaseFake.Routes.FirstOrDefault(route => route.Id == Id);

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

            //_routeService.Edit(route);
            //return RedirectToAction(nameof(RouteController.Index));
        }
        void SetSelectLists()
        {
            IList<Vehicle> vehicles = _vehicleService.Select();
            ViewData[nameof(Domain.Entities.Route.VehicleID)] = new SelectList(vehicles, nameof(Vehicle.Id), nameof(Vehicle.VehicleType));
            IList<City> citiesFrom = _cityService.Select();
            ViewData[nameof(Domain.Entities.Route.CityFromID)] = new SelectList(citiesFrom, nameof(City.Id), nameof(City.Name));
            IList<City> citiesTo = _cityService.Select();
            ViewData[nameof(Domain.Entities.Route.CityToID)] = new SelectList(citiesTo, nameof(City.Id), nameof(City.Name));
            IList<Ticket> tickets = _ticketService.Select();
            ViewData[nameof(Domain.Entities.Route.TicketID)] = new SelectList(tickets, nameof(Ticket.Id), nameof(Ticket.Price));
        }
    }
}
