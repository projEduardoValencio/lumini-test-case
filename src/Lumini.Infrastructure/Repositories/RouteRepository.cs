using Lumini.Communication.Responses.Route;
using Lumini.Domain.Entities;
using Lumini.Domain.Interfaces.Repositories;
using Lumini.Exceptions.Exceptions.Route;
using Lumini.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Lumini.Infrastructure.Repositories;

public class RouteRepository : IRouteRepository
{
    private readonly LuminiDbContext _dbContext;
    private readonly DbSet<Route> _dbSet;
    
    public RouteRepository(LuminiDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<Route>();
    }
    
    public async Task AddRoute(Route newRoute)
    {
        Route? existentRoute = await this.GetRoute(newRoute.Origin, newRoute.Destination);
        if (existentRoute is not null)
        {
            throw new RouteAlreadyExistsException($"Route with {newRoute.Origin}-{newRoute.Destination} already exists");
        }

        await _dbSet.AddAsync(newRoute);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRoute(string origin, string destination)
    {
        Route route = await this.GetRoute(origin , destination);

        _dbSet.Remove(route);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRoute(Route updatedRoute)
    {
        Route route = await this.GetRoute(updatedRoute.Origin , updatedRoute.Destination);

        route.Value = updatedRoute.Value;

        _dbSet.Update(route);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Route>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Route> GetRoute(string origin, string destination)
    {
        Route? route = await _dbSet.FindAsync(new {origin , destination});
        if (route is null)
        {
            throw new RouteNotFoundException($"Route with {origin}-{destination} not found");
        }

        return route;
    }
    
    public async Task<List<Route>> GetRoutesByOrigin(string origin)
    {
        List<Route> routes = await _dbSet.Where(r=> r.Origin == origin).ToListAsync();
        
        if (routes.Count == 0)
        {
            throw new RouteNotFoundException($"Routes with origin {origin} not found");
        }
        
        return routes;
    }
}