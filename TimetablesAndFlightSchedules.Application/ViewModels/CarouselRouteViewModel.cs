using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Application.ViewModels
{
    public class CarouselRouteViewModel
    {
        public IList<Carousel> Carousels { get; set; }
        public IList<Route> Routes { get; set; }
    }
}
