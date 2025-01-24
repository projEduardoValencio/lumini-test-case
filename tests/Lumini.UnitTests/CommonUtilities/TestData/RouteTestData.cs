using Lumini.Communication.Requests.Route;

namespace Lumini.UnitTests.CommonUtilities.TestData;

public class RouteTestData
{
    public static IEnumerable<object[]> ExempleLowCostPath()
    {
        yield return new object[]
        {
            new RequestLowCostTravel { Origin = "BRC", Destination = "SCL" },
            5,
            new List<string> { "BRC", "SCL" }
        };
        yield return new object[]
        {
            new RequestLowCostTravel { Origin = "GRU", Destination = "CDG" },
            40,
            new List<string> { "GRU", "BRC", "SCL", "ORL", "CDG" }
        };
    }
    
}