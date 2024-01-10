using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Application.Implementation
{
    public class OrderItemService : IOrderItemService
    {
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public OrderItemService(TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IList<OrderItem> Select()
        {
            return _timetablesAndFlightSchedulesDbContext.OrderItems
                                                          .Include(oi => oi.RouteInstance)
                                                          .Include(oi => oi.Order)
                                                          .ThenInclude(o => o.User)
                                                          .OrderBy(oi => oi.Id)
                                                          .ToList();
        }

        public void Create(OrderItem orderItem)
        {
            if (_timetablesAndFlightSchedulesDbContext.OrderItems != null)
            {
                Order? order = _timetablesAndFlightSchedulesDbContext.Orders.FirstOrDefault(o => o.Id == orderItem.OrderID);
                if (order != null)
                {
                    order.TotalPrice += orderItem.Price;
                    _timetablesAndFlightSchedulesDbContext.OrderItems.Add(orderItem);
                    _timetablesAndFlightSchedulesDbContext.SaveChanges();
                }
            }
        }

    }
}