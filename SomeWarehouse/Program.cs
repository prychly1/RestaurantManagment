using SomeWarehouse.WarehouseDB;
using SomeWarehouse.warehousesLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IProductAddService, ProductAddService>();
builder.Services.AddDbContext<WarehoudeDbContext>();
builder.Services.AddScoped<SomeWarehouse.WarehouseDB.WarehouseFeeder>();

var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetRequiredService<WarehouseFeeder>();
//app.Services.GetRequiredService<WarehouseFeeder>().Feed();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
