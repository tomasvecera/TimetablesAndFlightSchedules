using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class Route : Entity
    {
        [ForeignKey(nameof(CityFrom))]
        public int CityFromID { get; set; }
        public City? CityFrom { get; set; }

        [ForeignKey(nameof(CityTo))]
        public int CityToID { get; set; }
        public City? CityTo { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public int VehicleID { get; set; }
        public Vehicle? Vehicle { get; set; }

        [Required]
        public double PriceOfTicket { get; set; }

        public String? RouteName {  get; set; }
    }
}
