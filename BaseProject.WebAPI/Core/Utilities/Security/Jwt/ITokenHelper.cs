using System.Security.Claims;

namespace BaseProject.WebAPI.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper<TUser, TClaim>
    {
        AccessToken CreateToken(TUser user, List<TClaim> operationClaims);
    }

}
