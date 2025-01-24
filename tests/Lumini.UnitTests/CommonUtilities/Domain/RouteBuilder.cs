using Lumini.Domain.Entities;

namespace Lumini.UnitTests.CommonUtilities.Domain;

public static class RouteBuilder
{

    public static List<Route> InitialRoutesBuilder()
    {
        return new List<Route>
        {
            new Route { Origin = "GRU", Destination = "BRC", Value = 10 },
            new Route { Origin = "BRC", Destination = "SCL", Value = 5 },
            new Route { Origin = "GRU", Destination = "CDG", Value = 75 },
            new Route { Origin = "GRU", Destination = "SCL", Value = 20 },
            new Route { Origin = "GRU", Destination = "ORL", Value = 56 },
            new Route { Origin = "ORL", Destination = "CDG", Value = 5 },
            new Route { Origin = "SCL", Destination = "ORL", Value = 20 }
        };
    }
    
    public static Route Build(string origin, string destination, decimal value)
    {
        return new Route { Origin = origin, Destination = destination, Value = value };
    }
}