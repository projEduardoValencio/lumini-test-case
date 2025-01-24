using Lumini.Communication.Requests.Route;
using Lumini.Communication.Responses.Route;

namespace Lumini.Application.Interfaces.UseCases.Route;

public interface IRouteUseCase
{
    public Task<ResponseLowCostTravel> LowCostTravelPath(RequestLowCostTravel request);
    public Task<ResponseRouteList> ListRoutes();
    public Task CreateRoute(RequestsRegisterRoute request);
    public Task UpdateRouteValue(RequestUpdateRouteValue request);
    public Task DeleteRoute(RequestDeleteRoute request);
}