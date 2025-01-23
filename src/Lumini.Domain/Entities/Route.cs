namespace Lumini.Domain.Entities;

public class Route
{
    public String Origin { get; set; } = String.Empty;
    public String Destination { get; set; } = String.Empty;

    private decimal _value;

    public decimal Value
    {
        get => _value; 
        set => _value = Math.Round(value, 2);
    }

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