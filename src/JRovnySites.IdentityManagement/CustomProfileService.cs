using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using JRovnySites.IdentityManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace JRovnySites.IdentityManagement
{
    public class CustomProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;

        public CustomProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            if (context.Caller == IdentityServerConstants.ProfileDataCallers.UserInfoEndpoint)
            {
                if (int.TryParse(context.Subject.Claims.FirstOrDefault(claim => claim.Type == "sub").Value, out int id))
                {
                    var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

                    context.IssuedClaims = new List<System.Security.Claims.Claim>()
                    {
                        new Claim("display_name", $"{user.FirstName} {user.LastName}"),
                        new Claim("first_name", user.FirstName),
                        new Claim("last_name", user.LastName),
                        new Claim("email", user.Email)
                    };
                }
                else
                {
                    throw new System.Exception("Invalid user subject ID.");
                }
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.FromResult(true);
        }
    }
}