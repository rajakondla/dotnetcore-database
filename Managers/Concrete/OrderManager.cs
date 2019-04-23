
using Data.Concrete;
using DotNetCoreWebAPI;
using Managers.Abstract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Concrete
{
    public class OrderManager : Repository<Orders, MySecondDatabaseContext>, IOrderManager //where C:MySecondDatabaseContext
    {
        public OrderManager(MySecondDatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
