using Lumini.Infrastructure.DataAccess;
using Lumini.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lumini.Infrastructure.Factories;

public class DbContextFactory : IDbContextFactory
{
    private readonly string _connectionString = String.Empty;
    
    public DbContextFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public LuminiDbContext CreateSqliteDbContext()
    {
        var options = new DbContextOptionsBuilder<LuminiDbContext>()
            .UseSqlite(_connectionString)
            .Options;
        
        return new LuminiDbContext(options);
    }
}