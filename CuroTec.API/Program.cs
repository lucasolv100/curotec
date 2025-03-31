using CuroTec.API.DTOs;
using CuroTec.Domain.Entities;
using CuroTec.Domain.Interfaces;
using CuroTec.Infrastructure;
using CuroTec.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<CuroTecContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

var app = builder.Build();

app.MapGet("/vehicles", async (IVehicleRepository vehicleRepository) =>
{
    var vehicles = await vehicleRepository.GetAllAsync();
    return Results.Ok(vehicles);
});


app.MapGet("/vehicles/{id:int}", async (int id, IVehicleRepository vehicleRepository) =>
{
    var vehicle = await vehicleRepository.GetByIdAsync(id);
    return vehicle is not null ? Results.Ok(vehicle) : Results.NotFound();
});


app.MapPost("/vehicles", async (VehicleDto dto, IVehicleRepository vehicleRepository) =>
{
    var newVehicle = new Vehicle(
        vehicleType: dto.VehicleType,
        color: dto.Color
    );

    await vehicleRepository.AddAsync(newVehicle);

    return Results.Created($"/vehicles/{newVehicle.Id}", newVehicle);
});


app.MapPut("/vehicles/{id:int}", async (int id, VehicleDto dto, IVehicleRepository vehicleRepository) =>
{
    var vehicle = await vehicleRepository.GetByIdAsync(id);
    if (vehicle is null) return Results.NotFound();

    vehicle.Update(dto.VehicleType, dto.Color);

    return Results.Ok(vehicle);
});


app.MapDelete("/vehicles/{id:int}", async (int id, IVehicleRepository vehicleRepository) =>
{
    var vehicle = await vehicleRepository.GetByIdAsync(id);
    if (vehicle is null) return Results.NotFound();

    vehicle.Delete();
    return Results.NoContent();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


