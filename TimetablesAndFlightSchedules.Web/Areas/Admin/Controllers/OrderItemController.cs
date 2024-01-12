using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;
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
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public OrderItemController(IOrderItemService orderItemService, IRouteInstanceAdminService routeInstanceService, IOrderService orderService, TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _orderItemService = orderItemService;
            _routeInstanceService = routeInstanceService;
            _orderService = orderService;
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
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

        public IActionResult Delete(int Id)
        {
            bool deleted = _orderItemService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(OrderItemController.Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            OrderItem? orderItem = _timetablesAndFlightSchedulesDbContext.OrderItems.FirstOrDefault(oi => oi.Id == Id);

            return View(orderItem);
        }

        [HttpPost]
        public IActionResult Edit(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _orderItemService.Edit(orderItem);
                return RedirectToAction(nameof(OrderItemController.Index));
            }
            else
            {
                return View(orderItem);
            }
            //return RedirectToAction(nameof(RouteController.Index));
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