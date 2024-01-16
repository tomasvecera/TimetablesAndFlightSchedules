using Microsoft.AspNetCore.Mvc;
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
    public class VehicleController : Controller
    {
        IVehicleAdminService _vehicleService;
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public VehicleController(IVehicleAdminService vehicleService, TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _vehicleService = vehicleService;
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IActionResult Index()
        {
            IList<Vehicle> vehicles = _vehicleService.Select();
            return View(vehicles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.Create(vehicle);
                return RedirectToAction(nameof(VehicleController.Index));
            }
            else
            {
                return View(vehicle);
            }
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _vehicleService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(VehicleController.Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Vehicle? vehicle = _timetablesAndFlightSchedulesDbContext.Vehicles.FirstOrDefault(v => v.Id == Id);

            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.Edit(vehicle);
                return RedirectToAction(nameof(VehicleController.Index));
            }
            else
            {
                return View(vehicle);
            }
        }
    }
}
