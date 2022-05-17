namespace Domain.Models;

public class City {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Region { get; set; }
    public string ZIPCode { get; set; }
    public string Description { get; set; }
    public List<Entertainment> Entertainment { get; set; }
    public List<Monument> Monument { get; set; }
}