using API2.Models;

namespace API2.Interface
{
    public interface ITokenService
    {
        String createToken(AppUser user);
    }
}
