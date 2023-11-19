using RestaurantAPI;
using RestaurantAPI.Restaurant;
using RestaurantAPI.Sellstorm;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped< IweatherForecastService, weatherForecastService >();
builder.Services.AddTransient<ISelectedAtributesRanking, SelectedAtributesRanking >();
builder.Services.AddTransient<IWarehouseService, WarehouseService >();
builder.Services.AddDbContext<RestaurantDbContext>();
builder.Services.AddScoped<RestaurantSeeder>();


var app = builder.Build();

app.Services.GetRequiredService<RestaurantSeeder>().Seed();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
