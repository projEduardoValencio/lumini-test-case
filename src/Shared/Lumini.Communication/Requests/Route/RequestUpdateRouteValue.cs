namespace Lumini.Communication.Requests.Route;

public class RequestUpdateRouteValue
{
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public decimal NewValue { get; set; }
}