using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace JRovnySites.IdentityManagement
{
    public class CustomProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            if (context.Caller == IdentityServerConstants.ProfileDataCallers.UserInfoEndpoint)
            {

            }

            return Task.FromResult(true);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.FromResult(true);
        }
    }
}