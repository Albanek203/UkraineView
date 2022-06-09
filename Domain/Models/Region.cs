namespace Domain.Models;

public class Region {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Identifier { get; set; }
    public float Area { get; set; }
    public DateTime Formed { get; set; }
    public Image MapImage { get; set; }
    public List<Image> Images { get; set; } = new List<Image>();
    public List<Entertainment> Entertainments { get; set; } = new List<Entertainment>();
    public List<Monument> Monuments { get; set; } = new List<Monument>();
}