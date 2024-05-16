using Microsoft.AspNetCore.Identity;

namespace LAB1_WEB2_12201039.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
