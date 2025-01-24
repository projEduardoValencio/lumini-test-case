using Lumini.Application.UseCases.Route;
using Lumini.Communication.Requests.Route;
using Lumini.Exceptions.Exceptions.Route;
using Lumini.UnitTests.CommonUtilities.Domain;
using Lumini.UnitTests.CommonUtilities.Repositories.Route;
using Lumini.UnitTests.CommonUtilities.TestData;

namespace Lumini.UnitTests.Application.UseCases;

public class RouteUseCaseTests
{
    public RouteUseCaseTests() { }

    [Fact]
    public async Task LowCostTravelPath_ShouldThrowNoPathAvailableException_WhenNoRoutesAvailable()
    {

        var routeRepository = new RouteRepositoryBuilder();
        routeRepository.GetAllInitialData(RouteBuilder.InitialRoutesBuilder());
        
        var routeUseCase = new RouteUseCase(routeRepository.Build());
        
        var request = new RequestLowCostTravel { Origin = "AAA", Destination = "BBB" };

        await Assert.ThrowsAsync<NoPathAvailableException>(() => routeUseCase.LowCostTravelPath(request));
    }

    [Theory]
    [MemberData(nameof(RouteTestData.ExempleLowCostPath), MemberType = typeof(RouteTestData))]
    public async Task LowCostTravelPath_ShouldReturnCheapestPath(RequestLowCostTravel request, decimal expectedValue, List<string> expectedPath)
    {
        
        var routeRepository = new RouteRepositoryBuilder();
        routeRepository.GetAllInitialData(RouteBuilder.InitialRoutesBuilder());
        
        var routeUseCase = new RouteUseCase(routeRepository.Build());
        
        var response = await routeUseCase.LowCostTravelPath(request);

        Assert.Equal(expectedValue, response.TotalValue);
        
        Assert.Equal(expectedPath, response.Path);
    }
}