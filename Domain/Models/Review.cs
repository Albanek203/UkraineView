namespace Domain.Models;

public class Review {
    public int Id { get; set; }
    public string Message { get; set; }
    public int IdentityUserId { get; set; }
    public int LikeCount { get; set; }
    public DateTime PublishTime { get; set; }
    public List<Image> Images { get; set; }
    public Entertainment Entertainment { get; set; }
    public Monument Monument { get; set; }
}