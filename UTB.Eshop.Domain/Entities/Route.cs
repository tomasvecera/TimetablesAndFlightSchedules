using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class Route : Entity
    {
        public DateOnly Date { get; set; }
        public TimeOnly DepartureTime { get; set; }
        public TimeOnly ArrivalTime { get; set; }
        public TimeSpan TravelTime { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public Ticket Ticket { get; set; }  
        public Vehicle Vehicle { get; set; }
        //TODO postredek 
    }
}
