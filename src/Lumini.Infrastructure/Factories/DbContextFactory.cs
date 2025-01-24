using Lumini.Infrastructure.DataAccess;
using Lumini.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lumini.Infrastructure.Factories;

public class LuminiDesignTimeDbContextFactory : IDesignTimeDbContextFactory<LuminiDbContext>
{
    public LuminiDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LuminiDbContext>()
            .UseSqlite("Data Source=lumini.db"); // Configuração independente

        return new LuminiDbContext(optionsBuilder.Options);
    }
}
