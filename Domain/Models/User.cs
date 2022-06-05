using Microsoft.AspNetCore.Identity;

namespace Domain.Models {
    public class User : IdentityUser {
        public string NickName { get; set; }
        public Image? Image { get; set; }
        public DateTime BirthDay { get; set; }
        public bool isMale { get; set; }
        public List<Entertainment>? Entertainments { get; set; }
    }
}