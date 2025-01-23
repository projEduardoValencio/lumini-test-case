namespace Lumini.Communication.Responses.Route;

public abstract class ResponseRouteBase
{
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
}