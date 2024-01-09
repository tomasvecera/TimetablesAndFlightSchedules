using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities.Interfaces;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class Order : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateTimeCreated { get; protected set; }

        [Required]
        public string? OrderNumber { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public IUser? User { get; set; }

        public IList<OrderItem>? OrderItems { get; set; }
    }
}
