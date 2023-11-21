using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Application.Abstraction
{
    public interface IRouteAdminService
    {
        IList<Route> Select();

        void Create(Route route);

        bool Delete(int id);

        void Edit(Route route);
    }
}
