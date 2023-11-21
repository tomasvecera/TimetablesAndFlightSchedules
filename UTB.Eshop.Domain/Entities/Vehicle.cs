using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class Vehicle : Entity
    {
        public string VehicleType { get; set; } //bus, train, plane
    }
}
