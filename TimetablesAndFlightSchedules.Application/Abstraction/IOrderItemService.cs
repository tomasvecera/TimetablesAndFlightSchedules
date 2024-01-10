using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Application.Abstraction
{
    public interface IOrderItemService
    {
        IList<OrderItem> Select();
        void Create(OrderItem orderItem);
    }
}