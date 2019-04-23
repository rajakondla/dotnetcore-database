
using Data.Concrete;
using DotNetCoreWebAPI;
using Managers.Abstract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Concrete
{
    public class OrderProductManager : Repository<OrderProducts, MySecondDatabaseContext>, IOrderProductManager //where C : MySecondDatabaseContext
    {
        public OrderProductManager(MySecondDatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
