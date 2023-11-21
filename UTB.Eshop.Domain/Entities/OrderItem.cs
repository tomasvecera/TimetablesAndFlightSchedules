using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class OrderItem : Entity
    {
        public int OrderID { get; set; }

        public int TicketID { get; set; }

        public int Amount { get; set; }
        //public double Price { get; set; }

        public Order Order { get; set; }
        //public Product Product { get; set; }
    }
}
