using System.ComponentModel.DataAnnotations;
using Domain.Models.Abstract;

namespace Domain.Models;

public class Entertainment : Build {
    public int Id { get; set; }
    public string Name { get; set; }
    [Display(Name = "Type")]
    public string EntertainmentType { get; set; }
    [Display(Name = "Active")]
    public bool IsChecked { get; set; }

    // Information
    public Contact? Contact { get; set; }
    public About? About { get; set; }
    public DateTime CreateDate { get; set; }
}