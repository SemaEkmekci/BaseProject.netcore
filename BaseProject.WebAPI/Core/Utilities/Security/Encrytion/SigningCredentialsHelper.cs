using Microsoft.IdentityModel.Tokens;

namespace BaseProject.WebAPI.Core.Utilities.Security.Encrytion
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreatSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
