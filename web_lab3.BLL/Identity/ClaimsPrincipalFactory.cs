using System.Security.Claims;
using System.Threading.Tasks;
using Abstractions.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BLL.Identity
{
    internal class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public ClaimsPrincipalFactory(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user);

            if (!string.IsNullOrEmpty(user.FirstName))
            {
                ((ClaimsIdentity) principal.Identity)?.AddClaims(new[]
                {
                    new Claim(ClaimTypes.GivenName, user.FirstName)
                });
            }

            if (!string.IsNullOrEmpty(user.LastName))
            {
                ((ClaimsIdentity) principal.Identity)?.AddClaims(new[]
                {
                    new Claim(ClaimTypes.GivenName, user.LastName)
                });
            }

            return principal;
        }
    }
}