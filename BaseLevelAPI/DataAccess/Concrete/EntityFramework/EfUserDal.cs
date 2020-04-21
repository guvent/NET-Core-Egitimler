using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Concrete.DataAccess;
using Common.Concrete.Entities;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BaseContext>, IUserDal
    {
        public List<OperationClaim> GetClaim(User user)
        {
            using (var context = new BaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.Id
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
