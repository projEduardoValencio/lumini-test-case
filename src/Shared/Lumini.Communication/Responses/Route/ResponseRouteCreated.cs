namespace Lumini.Communication.Responses.Route;

public class ResponseRouteCreated
{
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public decimal Value { get; set; }
}