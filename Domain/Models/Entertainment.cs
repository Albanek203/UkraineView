using System.Diagnostics.CodeAnalysis;

namespace Domain.Models;

public class Entertainment {
    public int Id { get; set; }
    public string Name { get; set; }
    public float Rating { get; set; }
    public List<WorkTime> WorkTime { get; set; }
    public Address Address { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Image> Images { get; set; }
    public string EntertainmentType { get; set; }
    public bool IsChecked { get; set; }

    // Information
    public Contact Contact { get; set; }
    public About About { get; set; }
    public DateTime AddedDate { get; set; }
}