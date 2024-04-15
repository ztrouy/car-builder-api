namespace CarBuilder.Models.DTOs;

public class OrderDTO
{
    public int Id {get; set;}
    public DateTime Timestamp {get; set;}
    public bool IsFulfilled {get; set;}
    public int PaintId {get; set;}
    public PaintColorDTO PaintColor {get; set;}
    public int InteriorId {get; set;}
    public InteriorDTO Interior {get; set;}
    public int TechnologyId {get; set;}
    public TechnologyDTO Technology {get; set;}
    public int WheelsId {get; set;}
    public WheelsDTO Wheels {get; set;}
    public int StyleId {get; set;}
    public StyleDTO Style {get; set;}
    public decimal Price {
        get {
            decimal sum = (PaintColor.Price + Interior.Price + Technology.Price + Wheels.Price) * Style.PriceMultiplier;
            return sum;
        }
    }
}