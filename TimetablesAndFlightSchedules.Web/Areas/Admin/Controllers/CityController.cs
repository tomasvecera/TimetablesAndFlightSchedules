using Microsoft.AspNetCore.Mvc;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        ICityAdminService _cityService;

        public CityController(ICityAdminService cityService)
        {
            _cityService = cityService;
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
            _cityService.Create(city);

            return RedirectToAction(nameof(RouteController.Index));
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _cityService.Delete(Id);

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
            City? city =
                DatabaseFake.Cities.FirstOrDefault(city => city.Id == Id);

            return View(city);
        }

        [HttpPost]
        public IActionResult Edit(City city)
        {
            _cityService.Edit(city);
            return RedirectToAction(nameof(RouteController.Index));
        }
    }
}
