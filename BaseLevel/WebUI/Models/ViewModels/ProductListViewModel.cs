using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DomainModels;

namespace WebUI.Models.ViewModels
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
    }
}
