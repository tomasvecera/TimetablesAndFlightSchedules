using Microsoft.AspNetCore.Mvc;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketController : Controller
    {
        ITicketAdminService _ticketService;

        public TicketController(ITicketAdminService ticketService)
        {
            _ticketService = ticketService;
        }

        public IActionResult Index()
        {
            IList<Ticket> tickets = _ticketService.Select();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            _ticketService.Create(ticket);

            return RedirectToAction(nameof(RouteController.Index));
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _ticketService.Delete(Id);

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
            Ticket? ticket =
                DatabaseFake.Tickets.FirstOrDefault(ticket => ticket.Id == Id);

            return View(ticket);
        }

        [HttpPost]
        public IActionResult Edit(Ticket ticket)
        {
            _ticketService.Edit(ticket);
            return RedirectToAction(nameof(RouteController.Index));
        }
    }
}
