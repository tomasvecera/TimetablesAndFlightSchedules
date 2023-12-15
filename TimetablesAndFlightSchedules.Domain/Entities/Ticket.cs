using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class Ticket : Entity
    {
        [Required]
        public string TicketType { get; set; }

        [Required]
        public int NumberOfTickets { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
