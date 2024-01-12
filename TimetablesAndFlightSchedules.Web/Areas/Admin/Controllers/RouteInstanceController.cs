using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;
using TimetablesAndFlightSchedules.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;

namespace TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class RouteInstanceController : Controller
    {
        IRouteInstanceAdminService _routeInstanceService;
        IRouteAdminService _routeService;
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;
        public RouteInstanceController(IRouteInstanceAdminService routeInstanceService, IRouteAdminService routeService, TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _routeInstanceService = routeInstanceService;
            _routeService = routeService;
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IActionResult Index()
        {
            IList<RouteInstance> routeInstances = _routeInstanceService.Select();
            return View(routeInstances);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetRouteSelectLists();
            return View();
        }

        [HttpPost]
        public IActionResult Create(RouteInstance routeInstances)
        {
            if (ModelState.IsValid)
            {
                _routeInstanceService.Create(routeInstances);
                return RedirectToAction(nameof(RouteInstanceController.Index));
            }
            else
            {
                SetRouteSelectLists();
                return View(routeInstances);
            }

            //_routeInstanceService.Create(routeInstances);

            //return RedirectToAction(nameof(RouteInstanceController.Index));
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _routeInstanceService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(RouteInstanceController.Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //RouteInstance? routeInstance =
            //    DatabaseFake.RouteInstances.FirstOrDefault(routeInstance => routeInstance.Id == Id);

            RouteInstance? routeInstance = _timetablesAndFlightSchedulesDbContext.RouteInstances.FirstOrDefault(ri => ri.Id == Id);

            SetRouteSelectLists();
            return View(routeInstance);
        }

        [HttpPost]
        public IActionResult Edit(RouteInstance routeInstance)
        {
            if (ModelState.IsValid)
            {
                _routeInstanceService.Edit(routeInstance);
                return RedirectToAction(nameof(RouteInstanceController.Index));
            }
            else
            {
                SetRouteSelectLists();
                return View(routeInstance);
            }

            //_routeInstanceService.Edit(routeInstance);
            //return RedirectToAction(nameof(RouteInstanceController.Index));
        }

        void SetRouteSelectLists()
        {
            IList<Domain.Entities.Route> routes = _routeService.Select();
            ViewData[nameof(RouteInstance.RouteID)] = new SelectList(routes, nameof(Domain.Entities.Route.Id), nameof(Domain.Entities.Route.RouteName));

        }
    }
}
