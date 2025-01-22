namespace Lumini.Domain.Entities;

public class Route
{
    public String Origin { get; set; } = String.Empty;
    public String Destination { get; set; } = String.Empty;
    public decimal Value { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        return Origin == ((Route) obj).Origin && Destination == ((Route) obj).Destination;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Origin, Destination);
    }
}