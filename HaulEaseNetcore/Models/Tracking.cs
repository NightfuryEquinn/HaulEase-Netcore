namespace HaulEaseNetcore.Models
{
  public partial class Tracking
  {
    public int TrackingId { get; set; }
    public required string Time { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
  }
}
