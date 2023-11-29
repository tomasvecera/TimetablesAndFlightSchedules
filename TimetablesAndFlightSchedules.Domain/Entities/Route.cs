using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class Route : Entity
    {
        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public TimeOnly DepartureTime { get; set; }

        [Required]
        public TimeOnly ArrivalTime { get; set; }

        public TimeSpan TravelTime { get; set; }

        [Required]
        public City? From { get; set; }

        [Required]
        public City? To { get; set; }

        //public IEnumerable<City>? Cities { get; set; }

        [Required]
        public Ticket? Ticket { get; set; }

        [Required]
        public Vehicle? Vehicle { get; set; }
    }
}
