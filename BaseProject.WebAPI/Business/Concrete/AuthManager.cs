using Azure.Core;
using BaseProject.WebAPI.Business.Abstract;
using BaseProject.WebAPI.Business.Constans;
using BaseProject.WebAPI.Core.Entities.Concrete;
using BaseProject.WebAPI.Core.Utilities.Results;
using BaseProject.WebAPI.Core.Utilities.Security.Hashing;
using BaseProject.WebAPI.Core.Utilities.Security.Jwt;
using BaseProject.WebAPI.DataAccess.Concrete.EntityFramework.Context;
using BaseProject.WebAPI.Entities.Dtos;

namespace BaseProject.WebAPI.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private ITokenHelper<User, OperationClaim> _tokenHelper;

        public AuthManager(ApplicationDbContext context, IUserService userService, ITokenHelper<User, OperationClaim> tokenHelper)
        {
            _context = context;
            _userService = userService;
            _tokenHelper = tokenHelper;
        }



        public async Task<IDataResult<User>> Login(LoginDto loginDto, CancellationToken cancellationToken)
        {
            var userToCheck =  _userService.GetByMail(loginDto.email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            bool isPasswordCorrect = HashingHelper.VerifyPasswordHash(loginDto.password, userToCheck.PasswordHash, userToCheck.PasswordSalt);
            if (!isPasswordCorrect)
            {
                return new ErrorDataResult<User>(Messages.IncorrectPassword);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.LoginSuccessful);
        }


        public async Task<IDataResult<User>> Register(RegisterDto registerDto, CancellationToken cancellationToken)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerDto.password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = registerDto.email,
                FirstName = registerDto.firstname,
                LastName = registerDto.lastname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            //await _context.Users.AddAsync(user, cancellationToken); // Kullanıcıyı veritabanına ekler.
            //await _context.SaveChangesAsync(cancellationToken); // Değişiklikleri kaydeder.

            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public Core.Utilities.Results.IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UsernameAlreadyTaken);
            }
            return new SuccessResult();
        }

        public IDataResult<Core.Utilities.Security.Jwt.AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims); 

            return new SuccessDataResult<Core.Utilities.Security.Jwt.AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        //public async Task<IDataResult<User>> Register(RegisterDto registerDto, CancellationToken cancellationToken)
        //{

        //    bool isNameExists = await _context.Users.AnyAsync(u => u.FirstName == registerDto.name, cancellationToken);

        //    if (isNameExists)
        //    { 
        //        return new ErrorDataResult<User>(Messages.KullaniciAdiDahaOnceAlinmis);
        //    }

        //    User user = new()
        //    {
        //        FirstName = registerDto.name,
        //    };

        //    await _context.AddAsync(user, cancellationToken);
        //    await _context.SaveChangesAsync();

        //    return new SuccessDataResult<User>(user, Messages.KisiOlusturuldu);
        //}

        //public async Task<IDataResult<User>> Login(LoginDto loginDto, CancellationToken cancellationToken)
        //{
        //    User? user = await _context.Users.FirstOrDefaultAsync(u => u.FirstName == loginDto.email, cancellationToken);

        //    if(user is null)
        //    {
        //        return new ErrorDataResult<User>(Messages.UserNotFound);
        //    }
        //    return new SuccessDataResult<User>(user, Messages.LoginSuccessful);
        //}

    }
}
