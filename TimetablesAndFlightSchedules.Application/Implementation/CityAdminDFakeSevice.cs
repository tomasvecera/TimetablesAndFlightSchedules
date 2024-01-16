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
    public class CityAdminDFakeService : ICityAdminService
    {
        public IList<City> Select()
        {
            return DatabaseFake.Cities;
        }

        public async Task Create(City city)
        {
            if (DatabaseFake.Cities != null &&
                DatabaseFake.Cities.Count > 0)
            {
                city.Id = DatabaseFake.Cities.Last().Id + 1;
            }
            else
            {
                city.Id = 1;
            }

            if (DatabaseFake.Cities != null)
                DatabaseFake.Cities.Add(city);

            //return Task.CompletedTask;
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            City? city =
                DatabaseFake.Cities.FirstOrDefault(city => city.Id == id);

            if (city != null)
            {
                deleted = DatabaseFake.Cities.Remove(city);
            }

            return deleted;
        }

        public void Edit(City cityUpdated)
        {
            City? city = DatabaseFake.Cities.FirstOrDefault(c => c.Id == cityUpdated.Id);
            if (city != null)
            {
                city.Name = cityUpdated.Name;
            }
        }

    }
}
