using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Application.ViewModels;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Application.Abstraction
{
    public interface IOrderCartService
    {
        double AddOrderItemsToSession(int? routeInstanceId, ISession session);
        bool ApproveOrderInSession(int userId, ISession session);
        bool RemoveOrderInSession(int userId, ISession session);
        IList<OrderItem> GetUserOrderItems(ISession session);
    }
}