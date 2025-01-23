using Lumini.Application.Interfaces.UseCases.Route;
using Lumini.Communication.Requests.Route;
using Lumini.Communication.Responses.Route;

namespace Lumini.Application.UseCases.Route;

public class RouteUseCase : IRouteUseCase
{
    public Task<ResponseLowCostTravel> LowCostTravelPath(RequestLowCostTravel request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseRouteList> ListRoutes()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseRouteCreated> CreateRoute(RequestsRegisterRoute request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseRouteCreated> UpdateRouteValue(RequestUpdateRouteValue request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRoute(RequestDeleteRoute request)
    {
        throw new NotImplementedException();
    }
}