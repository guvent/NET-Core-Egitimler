using System;
using System.Collections.Generic;
using System.Text;
using Common.Abstract.DataAccess;
using Common.Abstract.Entities;
using Entities.Concrete;

namespace Entities.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}
