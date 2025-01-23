using Lumini.Infrastructure.DataAccess;

namespace Lumini.Infrastructure.Interfaces;

public interface IDbContextFactory
{
    LuminiDbContext CreateSqliteDbContext();
}