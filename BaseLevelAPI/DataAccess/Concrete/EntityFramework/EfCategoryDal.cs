using System;
using System.Collections.Generic;
using System.Text;
using Common.Concrete.DataAccess;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,BaseContext>,ICategoryDal
    {
    }
}
