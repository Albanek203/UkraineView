using Domain.Models.Abstract;

namespace Domain.Models;

public class Monument : Build {
    public int Id { get; set; }
    public string Name { get; set; }
}