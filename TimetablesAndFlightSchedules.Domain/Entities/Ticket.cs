using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class Ticket : Entity
    {
        public int NumberOfTickets { get; set; }

        public double Price { get; set; }
    }
}
