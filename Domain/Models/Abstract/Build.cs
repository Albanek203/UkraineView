namespace Domain.Models.Abstract;

public abstract class Build {
    public float Rating { get; set; } = 0f;

    public Address Address { get; set; } = new Address();
    public List<Review> Reviews { get; set; } = new List<Review>();
    public List<Image> Images { get; set; } = new List<Image>();
    public List<WorkTime> WorkTime { get; set; } = new List<WorkTime>();
}