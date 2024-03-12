using Microsoft.AspNetCore.Identity;

namespace LAB1.Models
{
    public class UserModel : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }


        public virtual ICollection<Ticket> MyTickets { get; set; }
    }
}
