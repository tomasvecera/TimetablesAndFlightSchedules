using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Domain.Entities
{
    public class Carousel : Entity
    {
        public string ImageSrc { get; set; }
        public string ImageAlt { get; set; }
    }
}
