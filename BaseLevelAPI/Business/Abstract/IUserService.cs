using System;
using System.Collections.Generic;
using System.Text;
using Common.Concrete.Entities;
using Common.Utilities.Results;
using Common.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);

        IDataResult<User> GetByEmail(string email);

    }
}
