﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Infrastructure.Identity.Enums;
using TimetablesAndFlightSchedules.Infrastructure.Identity;
using TimetablesAndFlightSchedules.Web.Controllers;
using TimetablesAndFlightSchedules.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;
using TimetablesAndFlightSchedules.Application.Implementation;
using TimetablesAndFlightSchedules.Application.ViewModels;

namespace TimetablesAndFlightSchedules.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class CustomerOrderCartController : Controller
    {
        const string totalPriceString = "TotalPrice";
        const string orderItemsString = "OrderItems";


        ISecurityService secureService;
        IOrderCartService orderCartService;

        public CustomerOrderCartController(ISecurityService iSecure, IOrderCartService orderCartService)
        {
            this.secureService = iSecure;
            this.orderCartService = orderCartService;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session != null && HttpContext.Session.IsAvailable)
            {
                User currentUser = await secureService.GetCurrentUser(User);
                if (currentUser != null)
                {
                    IList<OrderItem> userOrderItems = orderCartService.GetUserOrderItems(HttpContext.Session);
                    return View(userOrderItems);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public double AddOrderItemsToSession(int? routeInstanceId)
        {
            if (HttpContext.Session != null && HttpContext.Session.IsAvailable)
            {
                return orderCartService.AddOrderItemsToSession(routeInstanceId, this.HttpContext.Session);
            }

            return 0;
        }

        public async Task<IActionResult> ApproveOrderInSession()
        {
            if (HttpContext.Session != null && HttpContext.Session.IsAvailable)
            {
                User currentUser = await secureService.GetCurrentUser(User);

                if (orderCartService.ApproveOrderInSession(currentUser.Id, HttpContext.Session) == true)
                {
                    return RedirectToAction(nameof(CustomerOrdersController.Index), nameof(CustomerOrdersController).Replace(nameof(Controller), String.Empty), new { Area = nameof(Customer) });
                }
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { Area = String.Empty });

        }

        public async Task<IActionResult> RemoveOrderInSession()
        {
            if (HttpContext.Session != null && HttpContext.Session.IsAvailable)
            {
                User currentUser = await secureService.GetCurrentUser(User);

                if (orderCartService.RemoveOrderInSession(currentUser.Id, HttpContext.Session) == true)
                {
                    return RedirectToAction(nameof(CustomerOrderCartController.Index), nameof(CustomerOrderCartController).Replace(nameof(Controller), String.Empty), new { Area = nameof(Customer) });
                }
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { Area = String.Empty });

        }
    }
}