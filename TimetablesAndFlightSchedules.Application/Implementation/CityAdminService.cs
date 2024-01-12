using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Application.Implementation
{
    public class CityAdminService : ICityAdminService
    {
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public CityAdminService(TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IList<City> Select()
        {
            return _timetablesAndFlightSchedulesDbContext.Cities.ToList();
        }

        public void Create(City city)
        {
            if (_timetablesAndFlightSchedulesDbContext.Cities != null)
            {
                bool contains = false;
                foreach(City c in _timetablesAndFlightSchedulesDbContext.Cities)
                {
                    if(c.Name == city.Name)
                    {
                        contains = true;
                    }
                }
                if (!contains)
                {
                    _timetablesAndFlightSchedulesDbContext.Cities.Add(city);
                    _timetablesAndFlightSchedulesDbContext.SaveChanges();
                }
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            City? city =
                _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(city => city.Id == id);

            if (city != null)
            {
                _timetablesAndFlightSchedulesDbContext.Cities.Remove(city);
                _timetablesAndFlightSchedulesDbContext.SaveChanges();

                deleted = true;
            }

            return deleted;
        }

        public void Edit(City cityUpdated)
        {
            City? city = 
                _timetablesAndFlightSchedulesDbContext.Cities.FirstOrDefault(c => c.Id == cityUpdated.Id);
            if (city != null)
            {
                bool contains = false;
                foreach (City c in _timetablesAndFlightSchedulesDbContext.Cities)
                {
                    if (c.Name == cityUpdated.Name)
                    {
                        contains = true;
                    }
                }
                if (!contains)
                {
                    city.Name = cityUpdated.Name;
                    _timetablesAndFlightSchedulesDbContext.SaveChanges();
                }


                //city.Name = cityUpdated.Name;

                //_timetablesAndFlightSchedulesDbContext.SaveChanges();
            }
        }

    }
}
