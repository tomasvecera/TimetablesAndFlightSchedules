using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Application.Implementation;
using TimetablesAndFlightSchedules.Infrastructure.Database;
using TimetablesAndFlightSchedules.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

//culture settings for server side if needed (it uses czech currency and uses decimal comma)
var cultInfo = new CultureInfo("cs-cz");
CultureInfo.DefaultThreadCurrentCulture = cultInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultInfo;

// Add services to the container.
builder.Services.AddControllersWithViews();

string? connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.34");

builder.Services.AddDbContext<TimetablesAndFlightSchedulesDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));



builder.Services.AddIdentity<User, Role>()
             .AddEntityFrameworkStores<TimetablesAndFlightSchedulesDbContext>()
             .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Security/Account/Login";
    options.LogoutPath = "/Security/Account/Logout";
    options.SlidingExpiration = true;
});



//configuration of session
builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    // Make the session cookie essential
    options.Cookie.IsEssential = true;
});



builder.Services.AddScoped<IAccountService, AccountIdentityService>();


builder.Services.AddScoped<ISecurityService, SecurityIdentityService>();

builder.Services.AddScoped<IOrderCartService, OrderCartService>();
builder.Services.AddScoped<IOrderCustomerService, OrderCustomerService>();


//builder.Services.AddScoped<ICustomerCartService, CustomerCartService>();


builder.Services.AddScoped<IRouteAdminService, RouteAdminService>();
builder.Services.AddScoped<IRouteInstanceAdminService, RouteInstanceAdminService>();
builder.Services.AddScoped<IVehicleAdminService, VehicleAdminService>();
builder.Services.AddScoped<ICityAdminService, CityAdminService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();

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

//activation of session
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
