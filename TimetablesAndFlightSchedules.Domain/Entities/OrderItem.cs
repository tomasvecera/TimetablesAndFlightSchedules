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
        public Order? Order { get; set; }

        [ForeignKey(nameof(RouteInstance))]
        public int RouteInstanceID { get; set; }
        public RouteInstance? RouteInstance { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
