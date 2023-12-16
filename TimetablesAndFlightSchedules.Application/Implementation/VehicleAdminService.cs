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
    public class VehicleAdminService : IVehicleAdminService
    {
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public VehicleAdminService(TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IList<Vehicle> Select()
        {
            return _timetablesAndFlightSchedulesDbContext.Vehicles.ToList();
        }

        public void Create(Vehicle vehicle)
        {
            if (_timetablesAndFlightSchedulesDbContext.Vehicles != null)
            {
                _timetablesAndFlightSchedulesDbContext.Vehicles.Add(vehicle);
                _timetablesAndFlightSchedulesDbContext.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Vehicle? vehicle =
                _timetablesAndFlightSchedulesDbContext.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);

            if (vehicle != null)
            {
                _timetablesAndFlightSchedulesDbContext.Vehicles.Remove(vehicle);
                _timetablesAndFlightSchedulesDbContext.SaveChanges();

                deleted = true;
            }

            return deleted;
        }

        public void Edit(Vehicle vehicleUpdated)
        {
            Vehicle? vehicle = 
                _timetablesAndFlightSchedulesDbContext.Vehicles.FirstOrDefault(v => v.Id == vehicleUpdated.Id);
            if (vehicle != null)
            {
                vehicle.VehicleType = vehicleUpdated.VehicleType;
                vehicle.NumberOfTickets = vehicleUpdated.NumberOfTickets;

                _timetablesAndFlightSchedulesDbContext.SaveChanges();
            }
        }

    }
}
