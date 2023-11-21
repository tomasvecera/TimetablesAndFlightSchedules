using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static IList<Route> Routes { get; set; }

        public static IList<Vehicle> Vehicles { get; set; }

        public static IList<Ticket> Tickets { get; set; }

        public static IList<Carousel> Carousels { get; set; }

        static DatabaseFake()
        {
            DatabaseInit dbInit = new DatabaseInit();
            Routes = dbInit.GetRoutes();
            Tickets = dbInit.GetTickets();
            Vehicles = dbInit.GetVehicles();
            Carousels = dbInit.GetCarousels();

            /*Products = new List<Product>();
            Products.Add(new Product()
            {
                Id = 1,
                Name = "iPhone",
                Description = "mobilni telefon",
                Price = 20,
                ImageSrc = ""
            });*/
        }
    }
}
