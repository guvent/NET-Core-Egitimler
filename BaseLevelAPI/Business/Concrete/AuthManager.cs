using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Common.Concrete.Entities;
using Common.Utilities.Results.Abstract;
using Common.Utilities.Results.Concrete;
using Common.Utilities.Security.Helpers;
using Common.Utilities.Security.Helpers.AccessToken;
using Common.Utilities.Security.Helpers.Hashing;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName= userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);

            return new SuccessDataResult<User>(user,ResultMessages.RegisterSuccess);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(ResultMessages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash,
                userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(ResultMessages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data, ResultMessages.LoginSuccess);
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetByEmail(email).Data != null)
            {
                return new SuccessResult(ResultMessages.UserExist);
            }
            return new SuccessResult(ResultMessages.RegisterPossible);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken,ResultMessages.TokenCreated);
        }
    }
}
