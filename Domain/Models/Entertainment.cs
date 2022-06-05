using Domain.Models.Abstract;

namespace Domain.Models;

public class Entertainment : Build {
    public int Id { get; set; }
    public string Name { get; set; }
    public string EntertainmentType { get; set; }
    public bool IsChecked { get; set; }

    // Information
    public Contact? Contact { get; set; }
    public About? About { get; set; }
    public DateOnly CreateDate { get; set; }
}