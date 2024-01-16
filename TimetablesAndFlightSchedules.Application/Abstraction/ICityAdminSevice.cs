using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Application.Abstraction
{
    public interface ICityAdminService
    {
        IList<City> Select();

        Task Create(City city);

        bool Delete(int id);

        void Edit(City city);
    }
}
