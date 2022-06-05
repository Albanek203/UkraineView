namespace Domain.Models;

public class Review {
    public int Id { get; set; }
    public string Message { get; set; }
    public int UserId { get; set; }
    public int LikeCount { get; set; } = 0;
    public DateOnly PublishTime { get; set; }
    public List<Image> Images { get; set; } = new List<Image>();
    public Entertainment? Entertainment { get; set; }
    public Monument? Monument { get; set; }
}