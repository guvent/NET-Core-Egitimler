using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Common.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DomainModels;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal :EfEntityRepositoryBase<Product,BaseContext>, IProductDal
    {
    }
}
