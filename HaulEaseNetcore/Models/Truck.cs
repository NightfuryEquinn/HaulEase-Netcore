namespace HaulEaseNetcore.Models
{
  public partial class Truck
  {
    public int TruckId { get; set; }
    public required string Status { get; set; }
    public required string DriverName { get; set; }
    public required string LicensePlate { get; set; }
  }
}
