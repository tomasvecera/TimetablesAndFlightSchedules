using Microsoft.AspNetCore.Mvc;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RouteController : Controller
    {
        IRouteAdminService _routeService;
        
        public RouteController(IRouteAdminService routeService)
        {
            _routeService = routeService;
        }
            
        public IActionResult Index()
        {
            IList<Domain.Entities.Route> routes = _routeService.Select();
            return View(routes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Domain.Entities.Route route)
        {
            _routeService.Create(route);

            return RedirectToAction(nameof(RouteController.Index));
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

            return View(route);
        }

        [HttpPost]
        public IActionResult Edit(Domain.Entities.Route route)
        {
            _routeService.Edit(route);
            return RedirectToAction(nameof(RouteController.Index));
        }
    }
}
