using System.Security;
using Lumini.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Lumini.Application.Data;

public static class DataAccess
{
    private static LuminiDbContext? _dbCOntext;
    
    public static void SetDbContext(DbContextOptions<LuminiDbContext> options)
    {
        _dbCOntext = new LuminiDbContext(options);
    }
    
    public static LuminiDbContext GetDbContext()
    {
        if (_dbCOntext is null)
        {
            throw new VerificationException("DbContext not set");
        }
        
        return _dbCOntext;
    }

}