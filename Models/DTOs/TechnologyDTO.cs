namespace CarBuilder.Models.DTOs;

public class TechnologyDTO
{
    public int Id {get; set;}
    public decimal Price {get; set;}
    public string Package {get; set;} = string.Empty;
}