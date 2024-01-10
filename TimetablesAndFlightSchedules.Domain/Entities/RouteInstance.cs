using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class RouteInstance : Entity
    {
        [ForeignKey(nameof(Route))]
        public int RouteID { get; set; }
        public Route? Route { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TimeOnly DepartureTime { get; set; }
        [Required]
        public TimeOnly ArrivalTime { get; set; }
        public TimeSpan TravelTime { get; set; }
        public String? RouteInstanceName { get; set; }
    }
}
