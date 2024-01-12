using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Application.ViewModels;

namespace TimetablesAndFlightSchedules.Application.Abstraction
{
    public interface IHomeService
    {
        RouteVehicleCityRouteInstanceViewModel GetHomeViewModel();
    }
}
