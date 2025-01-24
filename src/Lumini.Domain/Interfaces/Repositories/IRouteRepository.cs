using Lumini.Communication.Responses.Route;
using Lumini.Domain.Entities;

namespace Lumini.Domain.Interfaces.Repositories;

public interface IRouteRepository
{
    public Task AddRoute(Route newRoute);
    public Task DeleteRoute(string origin, string destination);
    public Task UpdateRoute(Route updatedRoute);
    public Task<List<Route>> GetAll();
    public Task<Route> GetRoute(string origin, string destination);
    public Task<List<Route>> GetRoutesByOrigin(string origin);
}