using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Application.Abstraction
{
    public interface IOrderCartService
    {
        double AddOrderItemsToSession(int? routeInstanceId, ISession session);
        bool ApproveOrderInSession(int userId, ISession session);
    }
}