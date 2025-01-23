using Lumini.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lumini.Infrastructure.DataAccess;

public class LuminiDbContext : DbContext
{
    public LuminiDbContext(DbContextOptions<LuminiDbContext> options) : base(options)
    {
    }

    internal DbSet<Route> Routes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Route>().HasData(
            new Route { Origin = "GRU", Destination = "BRC", Value = 10 }, 
            new Route { Origin = "BRC", Destination = "SCL", Value = 5 },
            new Route { Origin = "GRU", Destination = "CDG", Value = 75 },
            new Route { Origin = "GRU", Destination = "SCL", Value = 20 },
            new Route { Origin = "GRU", Destination = "ORL", Value = 56 },
            new Route { Origin = "ORL", Destination = "CDG", Value = 5 },
            new Route { Origin = "SCL", Destination = "ORL", Value = 20 }
        );
    }
}