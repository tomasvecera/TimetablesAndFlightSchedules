using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;

namespace TimetablesAndFlightSchedules.Infrastructure.Database
{
    public class TimetablesAndFlightSchedulesDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteInstance> RouteInstances { get; set; }
        //public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public TimetablesAndFlightSchedulesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DatabaseInit dbInit = new DatabaseInit();
            modelBuilder.Entity<City>().HasData(dbInit.GetCities());
            modelBuilder.Entity<Route>().HasData(dbInit.GetRoutes());
            modelBuilder.Entity<RouteInstance>().HasData(dbInit.GetRouteInstances());
            //modelBuilder.Entity<Ticket>().HasData(dbInit.GetTickets());
            modelBuilder.Entity<Vehicle>().HasData(dbInit.GetVehicles());
        }
    }
}
