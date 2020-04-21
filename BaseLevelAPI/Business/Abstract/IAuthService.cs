using System;
using System.Collections.Generic;
using System.Text;
using Common.Concrete.Entities;
using Common.Utilities.Results.Abstract;
using Common.Utilities.Security.Helpers.AccessToken;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
