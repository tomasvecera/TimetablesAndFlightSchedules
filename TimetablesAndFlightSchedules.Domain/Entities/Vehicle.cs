using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class Vehicle : Entity
    {
        [Required]
        public string? VehicleType { get; set; }

        [Required]
        public int NumberOfTickets { get; set; }
    }
}
