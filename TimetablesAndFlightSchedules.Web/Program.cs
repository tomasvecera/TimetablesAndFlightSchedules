using Microsoft.EntityFrameworkCore;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Application.Implementation;
using TimetablesAndFlightSchedules.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string? connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.34");

builder.Services.AddDbContext<TimetablesAndFlightSchedulesDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));


builder.Services.AddScoped<IRouteAdminService, RouteAdminService>();
builder.Services.AddScoped<IRouteInstanceAdminService, RouteInstanceAdminService>();
builder.Services.AddScoped<IVehicleAdminService, VehicleAdminService>();
//builder.Services.AddScoped<ITicketAdminService, TicketAdminService>();
builder.Services.AddScoped<ICityAdminService, CityAdminService>();
builder.Services.AddScoped<IHomeService, HomeService>();

/*builder.Services.AddScoped<IRouteAdminService, RouteAdminDFakeService>();
builder.Services.AddScoped<IRouteInstanceAdminService, RouteInstanceAdminDFakeService>();
builder.Services.AddScoped<IVehicleAdminService, VehicleAdminDFakeService>();
builder.Services.AddScoped<ITicketAdminService, TicketAdminDFakeService>();
builder.Services.AddScoped<ICityAdminService, CityAdminDFakeService>();
builder.Services.AddScoped<IHomeService, HomeDFakeService>();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
