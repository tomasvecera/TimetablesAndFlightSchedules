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
    public class OrderCustomerService : IOrderCustomerService
    {
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public OrderCustomerService(TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IList<Order> GetOrdersForUser(int userId)
        {
            return _timetablesAndFlightSchedulesDbContext.Orders.Where(or => or.UserId == userId)
                                                                .Include(o => o.User)
                                                                .Include(o => o.OrderItems)
                                                                .ThenInclude(oi => oi.RouteInstance)
                                                                .ToList();
        }
    }
}
