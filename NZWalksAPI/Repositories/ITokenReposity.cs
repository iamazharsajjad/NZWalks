using Microsoft.AspNetCore.Identity;

namespace NZWalksAPI.Repositories
{
    public interface ITokenReposity
    {
        string CreateJWTToken(IdentityUser user, List<string> role);
    }
}
