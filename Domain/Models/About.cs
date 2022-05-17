namespace Domain.Models;

public class About {
    public int Id { get; set; }
    // Service Information
    public bool FoodInRestaurant { get; set; }
    public bool FoodWithYou { get; set; }
    public bool Delivery { get; set; }
    public bool DrivingService { get; set; }
    public bool ContactlessDelivery { get; set; }
    public bool SummerPlayground { get; set; }

    // Amenities
    public bool Toilet { get; set; }
    public bool FreeWiFi { get; set; }
    public bool ChildrenSuitable { get; set; }
}