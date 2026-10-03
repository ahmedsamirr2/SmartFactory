using SmartFactory.Application.Interfaces;
using SmartFactory.Application.Services;
using SmartFactory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using SmartFactory.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SmartFactoryDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddScoped<IMachineRepository, MachineRepository>();
builder.Services.AddScoped<MachineService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

