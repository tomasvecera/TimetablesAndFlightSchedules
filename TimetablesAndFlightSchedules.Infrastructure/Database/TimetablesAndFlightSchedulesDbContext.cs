using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Identity;
using TimetablesAndFlightSchedules.Infrastructure.Database.Configuration;

namespace TimetablesAndFlightSchedules.Infrastructure.Database
{
    public class TimetablesAndFlightSchedulesDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteInstance> RouteInstances { get; set; }
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
            modelBuilder.Entity<Vehicle>().HasData(dbInit.GetVehicles());


            //Identity - User and Role initialization
            //roles must be added first
            modelBuilder.Entity<Role>().HasData(dbInit.CreateRoles());

            //then, create users ..
            (User admin, List<IdentityUserRole<int>> adminUserRoles) = dbInit.CreateAdminWithRoles();
            (User manager, List<IdentityUserRole<int>> managerUserRoles) = dbInit.CreateManagerWithRoles();

            //.. and add them to the table
            modelBuilder.Entity<User>().HasData(admin, manager);

            //and finally, connect the users with the roles
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);

            //configuration of User entity using IUser interface property inside Order entity
            modelBuilder.Entity<Order>().HasOne<User>(e => e.User as User);

            //configure DateTimeCreated for Order entity from configuration class
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration_MySQL());
        }
    }
}
