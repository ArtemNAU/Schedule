using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public int Type { get; set; }
    public ApplicationUser() { }
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        userIdentity.AddClaim(new Claim("id", this.Name));
        userIdentity.AddClaim(new Claim("type", this.Type.ToString()));
        return userIdentity;
    }
}