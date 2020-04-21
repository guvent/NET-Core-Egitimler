using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DomainModels;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class BaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=10.6.2.231;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=Guven__55");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }

    }
}
