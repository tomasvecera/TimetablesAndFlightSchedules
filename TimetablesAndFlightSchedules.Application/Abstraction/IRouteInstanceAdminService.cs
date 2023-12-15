using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Application.Abstraction
{
    public interface IRouteInstanceAdminService
    {
        IList<RouteInstance> Select();

        void Create(RouteInstance routeInstance);

        bool Delete(int id);

        void Edit(RouteInstance routeInstance);
    }
}
