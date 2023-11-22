using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class OrderItem : Entity
    {
        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }

        [ForeignKey(nameof(Ticket))]
        public int TicketID { get; set; }

        [Required]
        public int Amount { get; set; }
        //public double Price { get; set; }

        [Required]
        public int Price { get; set; }

        public Order? Order { get; set; }
        //public Product Product { get; set; }

        public Ticket? Ticket { get; set; }
    }
}
