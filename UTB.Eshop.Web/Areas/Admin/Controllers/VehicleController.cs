﻿using Microsoft.AspNetCore.Mvc;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleController : Controller
    {
        IVehicleAdminService _vehicleService;

        public VehicleController(IVehicleAdminService vehicleService)
        {
            _vehicleService = vehicleService;
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
            _vehicleService.Create(vehicle);

            return RedirectToAction(nameof(RouteController.Index));
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _vehicleService.Delete(Id);

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
            Vehicle? vehicle =
                DatabaseFake.Vehicles.FirstOrDefault(vehicle => vehicle.Id == Id);

            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            _vehicleService.Edit(vehicle);
            return RedirectToAction(nameof(RouteController.Index));
        }
    }
}
