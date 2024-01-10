using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Identity.Enums;
using TimetablesAndFlightSchedules.Infrastructure.Identity;

namespace TimetablesAndFlightSchedules.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class CustomerOrdersController : Controller
    {

        ISecurityService iSecure;
        IOrderCustomerService orderCustomerService;

        public CustomerOrdersController(ISecurityService iSecure, IOrderCustomerService orderCustomerService)
        {
            this.iSecure = iSecure;
            this.orderCustomerService = orderCustomerService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                User currentUser = await iSecure.GetCurrentUser(User);
                if (currentUser != null)
                {
                    IList<Order> userOrders = orderCustomerService.GetOrdersForUser(currentUser.Id);
                    return View(userOrders);
                }
            }

            return NotFound();
        }
    }
}