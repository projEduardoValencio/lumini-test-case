namespace Lumini.Application.Services.Route;

public class RouteCalculationService
{
    static public Dictionary<List<Domain.Entities.Route>, decimal> PossiblePaths(
        List<Domain.Entities.Route> allRoutes,
        string origin,
        string destination )
    {
        Dictionary<(List<Domain.Entities.Route> Path, HashSet<string> History), decimal> possiblePaths = new Dictionary<(List<Domain.Entities.Route>, HashSet<string>), decimal>();

        foreach (var route in allRoutes.Where(r => r.Origin == origin))
        {
            var history = new HashSet<string> { route.Origin, route.Destination };
            possiblePaths.Add((new List<Domain.Entities.Route> { route }, history), route.Value);
        }

        bool updated;
        do
        {
            updated = false;
            foreach (var path in possiblePaths.Keys.ToList())
            {
                var lastRoute = path.Path[^1];

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
                    if (path.History.Contains(nextRoute.Destination))
                    {
                        continue;
                    }

                    var newPath = new List<Domain.Entities.Route>(path.Path) { nextRoute };
                    var newHistory = new HashSet<string>(path.History) { nextRoute.Destination };
                    var newCost = possiblePaths[path] + nextRoute.Value;

                    possiblePaths.Add((newPath, newHistory), newCost);
                    updated = true;
                }

                possiblePaths.Remove(path);
            }
        } while (updated);

        return possiblePaths.ToDictionary(p => p.Key.Path, p => p.Value);
    }
}