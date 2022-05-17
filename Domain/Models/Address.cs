namespace Domain.Models;

public class Address {
    public int Id { get; set; }
    public string Region { get; set; }
    public City City { get; set; }
    public string Street { get; set; }
    public int Built { get; set; }
    public string ZIPCode { get; set; }
}