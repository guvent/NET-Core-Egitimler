using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Common.Concrete.Entities;
using Common.Utilities.Results;
using Common.Utilities.Results.Abstract;
using Common.Utilities.Results.Concrete;
using Entities.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaim(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(ResultMessages.UserAdded);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(user=>user.Email==email));
        }
    }
}
