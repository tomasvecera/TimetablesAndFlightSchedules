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
    public class VehicleAdminDFakeService : IVehicleAdminService
    {
        public IList<Vehicle> Select()
        {
            return DatabaseFake.Vehicles;
        }

        public void Create(Vehicle vehicle)
        {
            if (DatabaseFake.Vehicles != null &&
                DatabaseFake.Vehicles.Count > 0)
            {
                vehicle.Id = DatabaseFake.Vehicles.Last().Id + 1;
            }
            else
            {
                vehicle.Id = 1;
            }

            if (DatabaseFake.Vehicles != null)
                DatabaseFake.Vehicles.Add(vehicle);
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Vehicle? vehicle =
                DatabaseFake.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);

            if (vehicle != null)
            {
                deleted = DatabaseFake.Vehicles.Remove(vehicle);
            }

            return deleted;
        }

        public void Edit(Vehicle vehicleUpdated)
        {
            Vehicle? vehicle = DatabaseFake.Vehicles.FirstOrDefault(v => v.Id == vehicleUpdated.Id);
            if (vehicle != null)
            {
                //DatabaseFake.Routes.Remove(oldRoute);
                //DatabaseFake.Routes.Insert(route.Id - 1, route);
                vehicle.VehicleType = vehicleUpdated.VehicleType;
            }
        }

    }
}
