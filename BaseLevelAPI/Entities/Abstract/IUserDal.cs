using System;
using System.Collections.Generic;
using System.Text;
using Common.Abstract.DataAccess;
using Common.Concrete.Entities;
using Entities.Concrete;

namespace Entities.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaim(User user);
    }
}
