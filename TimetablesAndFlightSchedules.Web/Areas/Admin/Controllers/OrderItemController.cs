using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Identity.Enums;

namespace TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class OrderItemController : Controller
    {
        IOrderItemService _orderItemService;
        IRouteInstanceAdminService _routeInstanceService;
        IOrderService _orderService;
        public OrderItemController(IOrderItemService orderItemService, IRouteInstanceAdminService routeInstanceService, IOrderService orderService)
        {
            _orderItemService = orderItemService;
            _routeInstanceService = routeInstanceService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            IList<OrderItem> orderItems = _orderItemService.Select();
            return View(orderItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetOrderAndRouteInstanceSelectLists();
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _orderItemService.Create(orderItem);
                return RedirectToAction(nameof(OrderItemController.Index));
            }
            else
            {
                SetOrderAndRouteInstanceSelectLists();
                return View(orderItem);
            }
        }

        void SetOrderAndRouteInstanceSelectLists()
        {
            IList<RouteInstance> routeInstances = _routeInstanceService.Select();
            ViewData[nameof(OrderItem.RouteInstanceID)] = new SelectList(routeInstances, nameof(RouteInstance.Id), nameof(RouteInstance.RouteInstanceName));

            IList<Order> orders = _orderService.Select();
            ViewData[nameof(OrderItem.OrderID)] = new SelectList(orders, nameof(Order.Id), nameof(Order.OrderNumber));
        }
    }
}