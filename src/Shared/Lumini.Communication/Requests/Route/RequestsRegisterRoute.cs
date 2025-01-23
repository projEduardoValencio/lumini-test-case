namespace Lumini.Communication.Requests.Route;

public class RequestsRegisterRoute
{
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public decimal Value { get; set; }
}