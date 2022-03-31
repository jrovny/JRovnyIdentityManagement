using Microsoft.AspNetCore.Identity;

namespace JRovnySites.IdentityManagement.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}