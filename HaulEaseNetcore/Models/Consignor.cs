namespace HaulEaseNetcore.Models
{
  public partial class Consignor
  {
    public int ConsignorId { get; set; }
    public required string Username { get; set; }
    public required string Avatar {  get; set; }
    public required string Email { get; set; }
    public required string Password {  get; set; }
    public required string Address { get; set; }
    public string? Company { get; set; }
    public string? CompanyEmail { get; set; }
    public string? CompanyAddress { get; set; }
  }
}
