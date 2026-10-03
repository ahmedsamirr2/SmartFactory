using Microsoft.EntityFrameworkCore;
using SmartFactory.Domain;

namespace SmartFactory.Infrastructure.Data;

public class SmartFactoryDbContext : DbContext
{
    public SmartFactoryDbContext(
        DbContextOptions<SmartFactoryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Machine> Machines { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Production> Productions { get; set; }
}