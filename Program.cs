using Alyza_Glang__Final.Models;
using Alyza_Glang__Final.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();


// This line reads the settings from your file and stores them in a variable.
var mongoDBSettings = builder.Configuration
    .GetSection("MongoDBSettings")
    .Get<MongoDBSetting>();
builder.Services.Configure<MongoDBSetting>(
    builder.Configuration.GetSection("MongoDBSettings")
);


// Use the 'mongoDBSettings' VARIABLE here, not the class name.
builder.Services.AddDbContext<RestaurantReservationDbContext>(
    options =>
        options.UseMongoDB(mongoDBSettings.AtlasURI ?? "", mongoDBSettings.DatabaseName ?? "")
);


// Register services using their interfaces
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IReservationService, ReservationService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Restaurant/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseRouting();


app.UseAuthorization();


app.MapControllerRoute(name: "default", pattern: "{controller=Restaurant}/{action=Index}/{id?}");


app.Run();
