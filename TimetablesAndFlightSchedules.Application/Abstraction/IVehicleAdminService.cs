using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Application.Abstraction
{
    public interface IVehicleAdminService
    {
        IList<Vehicle> Select();
        
        void Create(Vehicle vehicle);
        
        bool Delete(int id);

        void Edit(Vehicle vehicle);
    }
}
