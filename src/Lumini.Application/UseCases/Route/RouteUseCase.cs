using System.Diagnostics;
using Lumini.Application.Interfaces.UseCases.Route;
using Lumini.Application.Services.Route;
using Lumini.Communication.Requests.Route;
using Lumini.Communication.Responses.Route;
using Lumini.Domain.Interfaces.Repositories;
using Lumini.Exceptions.Exceptions.Route;

namespace Lumini.Application.UseCases.Route;

public class RouteUseCase : IRouteUseCase
{
    private readonly IRouteRepository _routeRepository;
    
    public RouteUseCase(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }
    
    public async Task<ResponseLowCostTravel> LowCostTravelPath(RequestLowCostTravel request)
    {
        try
        {
            List<Domain.Entities.Route> allRoutes = await _routeRepository.GetAll();

            Dictionary<List<Domain.Entities.Route>, decimal> possiblePaths = RouteCalculationService.PossiblePaths(
                allRoutes,
                request.Origin,
                request.Destination
            );

            var cheapestPath = possiblePaths
                .MinBy(p => p.Value);

            var cheapestPathStringList = cheapestPath
                .Key
                .Select(r => r.Origin)
                .ToList();
            cheapestPathStringList.Add(request.Destination);

            var cheapestPathValue = cheapestPath.Value;

            return new ResponseLowCostTravel
            {
                Path = cheapestPathStringList,
                TotalValue = cheapestPathValue
            };
        }
        catch (Exception e)
        {
            throw new UnreachableException("Error calculating low cost travel path", e);
        }
    }

    public async Task<ResponseRouteList> ListRoutes()
    {
        try
        {
            List<Domain.Entities.Route> routes = await _routeRepository.GetAll();
            
            return new ResponseRouteList
            {
                Routes = routes.Select(route => new ResponseRouteCreated()
                {
                    Destination = route.Destination,
                    Origin = route.Origin,
                    Value = route.Value
                }).ToList()
            };
        } catch (Exception e)
        {
            throw new UnreachableException("Error creating route", e);
        }
    }

    public async Task CreateRoute(RequestsRegisterRoute request)
    {
        try
        {
            await _routeRepository.AddRoute(new Domain.Entities.Route
            {
                Destination = request.Destination,
                Origin = request.Origin,
                Value = request.Value
            });
        }
        catch (RouteAlreadyExistsException e)
        {
            throw;
        } catch (Exception e)
        {
            throw new UnreachableException("Error creating route", e);
        }
    }

    public async Task UpdateRouteValue(RequestUpdateRouteValue request)
    {
        try
        {
            await _routeRepository.UpdateRoute(new Domain.Entities.Route
            {
                Origin = request.Origin,
                Destination = request.Destination,
                Value = request.NewValue
            });
        }catch (RouteNotFoundException e)
        {
            throw;
        } catch (Exception e)
        {
            throw new UnreachableException("Error updating route", e);
        }
    }

    public async Task DeleteRoute(RequestDeleteRoute request)
    {
        try
        {
            await _routeRepository.DeleteRoute(request.Origin, request.Destination);
        } catch (RouteNotFoundException e)
        {
            throw;
        } catch (Exception e)
        {
            throw new UnreachableException("Error deleting route", e);
        }
    }
}