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
    public class CityController : Controller
    {
        ICityAdminService _cityService;
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public CityController(ICityAdminService cityService, TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _cityService = cityService;
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IActionResult Index()
        {
            IList<City> cities = _cityService.Select();
            return View(cities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                _cityService.Create(city);
                return RedirectToAction(nameof(CityController.Index));
            }
            else
            {
                return View(city);
            }


            //_cityService.Create(city);

            //return RedirectToAction(nameof(RouteController.Index));
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _cityService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(CityController.Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //City? city =
            //    DatabaseFake.Cities.FirstOrDefault(city => city.Id == Id);
            City? city = _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(city => city.Id == Id);

            return View(city);
        }

        [HttpPost]
        public IActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                _cityService.Edit(city);
                return RedirectToAction(nameof(CityController.Index));
            }
            else
            {
                return View(city);
            }
        }
    }
}
