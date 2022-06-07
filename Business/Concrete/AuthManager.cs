using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.DTOs;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(RegisterDto registerDto)
        {
            var result = BusinessRules.Run(CheckIfEmailIsAlreadyRegistered(registerDto.Email));
            if (!result.Success) return new ErrorDataResult<User>(result.Message);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            var addUserResult = _userService.Add(user);
            if (!addUserResult.Success) return new ErrorDataResult<User>(addUserResult.Message);

            return new SuccessDataResult<User>(user, Messages.RegistrationSuccessful);
        }

        public IDataResult<User> Login(LoginDto loginDto)
        {
            var userResult = _userService.GetByEmail(loginDto.Email);
            if (userResult.Data == null) return new ErrorDataResult<User>(Messages.EmailNotFound);

            var passwordVerificationResult = HashingHelper.VerifyPasswordHash(loginDto.Password, userResult.Data.PasswordHash, userResult.Data.PasswordSalt);
            if (!passwordVerificationResult) return new ErrorDataResult<User>(Messages.PasswordIsIncorrect);

            return new SuccessDataResult<User>(userResult.Data, Messages.LoginSuccessful);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateAccessToken(user, operationClaims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfEmailIsAlreadyRegistered(string email)
        {
            var userResult = _userService.GetByEmail(email);
            if (userResult.Data != null) return new ErrorResult(Messages.EmailIsAlreadyRegistered);

            return new SuccessResult();
        }

        public IDataResult<User> Register(RegisterDto RegisterDto, string password)
        {
            throw new NotImplementedException();
        }
    }
}
