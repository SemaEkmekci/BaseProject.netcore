using BaseProject.WebAPI.Core.Entities.Concrete;
using BaseProject.WebAPI.Core.Utilities.Results;
using BaseProject.WebAPI.Core.Utilities.Security.Jwt;
using BaseProject.WebAPI.Entities.Dtos;

namespace BaseProject.WebAPI.Business.Abstract
{
    using CoreIResult = BaseProject.WebAPI.Core.Utilities.Results.IResult;
    public interface IAuthService
    {
        Task<IDataResult<User>> Register(RegisterDto registerDto, CancellationToken cancellationToken);
        Task<IDataResult<User>> Login(LoginDto loginDto, CancellationToken cancellationToken);
        CoreIResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);


    }
}
