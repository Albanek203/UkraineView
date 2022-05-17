using Microsoft.AspNetCore.Identity;

namespace Domain.Models {
    public class User : IdentityUser {
        public string Nickname { get; set; }
        public Image Image { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
