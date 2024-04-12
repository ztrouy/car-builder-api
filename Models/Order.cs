namespace CarBuilder.Models;

public class Order
{
    public int Id {get; set;}
    public DateTime Timestamp {get; set;}
    public bool IsFulfilled {get; set;}
    public int PaintId {get; set;}
    public int InteriorId {get; set;}
    public int TechnologyId {get; set;}
    public int WheelsId {get; set;}
    public int StyleId {get; set;}
}