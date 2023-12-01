using SomeWarehouse.WarehouseDB;
using SomeWarehouse.warehousesLogic;
using AutoMapper;
using System.Runtime.CompilerServices;
using SomeWarehouse.Controllers;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IProductAddService, ProductAddService>();
builder.Services.AddDbContext<WarehoudeDbContext>();
builder.Services.AddScoped<SomeWarehouse.WarehouseDB.WarehouseFeeder>();
builder.Services.AddScoped<WarehouseController>();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());


var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetRequiredService<WarehouseFeeder>();

//app.Services.GetRequiredService<WarehouseFeeder>().Feed();  dzia³a w startupie/ .net 5


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
