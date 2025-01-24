namespace Lumini.Application.Services.Route;

public class RouteCalculationService
{
    static public Dictionary<List<Domain.Entities.Route>, decimal> PossiblePaths(
        List<Domain.Entities.Route> allRoutes,
        string origin, 
        string destination )
    {
        Dictionary<List<Domain.Entities.Route>, decimal> possiblePaths = new Dictionary<List<Domain.Entities.Route>, decimal>();
        
        foreach (var route in allRoutes.Where(r => r.Origin == origin))
        {
            possiblePaths.Add(new List<Domain.Entities.Route> { route }, route.Value);
        }

        bool updated;
        do
        {
            updated = false;
            foreach (var path in possiblePaths.Keys.ToList())
            {
                var lastRoute = path[^1];

                if (lastRoute.Destination == destination)
                {
                    continue;
                }

                var nextRoutes = allRoutes.Where(r => r.Origin == lastRoute.Destination).ToList();

                if (nextRoutes.Count == 0)
                {
                    possiblePaths.Remove(path);
                    continue;
                }

                foreach (var nextRoute in nextRoutes)
                {
                    var newPath = new List<Domain.Entities.Route>(path) { nextRoute };
                    var newCost = possiblePaths[path] + nextRoute.Value;

                    possiblePaths.Add(newPath, newCost);
                    updated = true;
                }

                possiblePaths.Remove(path);
            }
        } while (updated);

        return possiblePaths;
    }
}