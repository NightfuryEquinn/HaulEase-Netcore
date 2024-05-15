namespace HaulEaseNetcore.Models
{
  public partial class Cargo
  {
    public int CargoId { get; set; }
    public required string Type { get; set; }
    public double Weight { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
    public int? ShipmentId { get; set; }
  }
}
