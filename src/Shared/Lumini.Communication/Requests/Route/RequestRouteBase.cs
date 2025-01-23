namespace Lumini.Communication.Requests.Route;

public abstract class RequestRouteBase
{
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
}