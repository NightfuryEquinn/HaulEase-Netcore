namespace HaulEaseNetcore.Models
{
  public partial class Shipment
  {
    public int ShipmentId { get; set; }
    public required string Status { get; set; }
    public required string Origin { get; set; }
    public required string Destination { get; set; }
    public required string ReceiverName { get; set; }
    public required string ReceiverContact {  get; set; }
    public int? PaymentId { get; set; }
    public int? TrackingId { get; set; }
  }
}
