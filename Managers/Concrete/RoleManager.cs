using Data.Concrete;
using DotNetCoreWebAPI;
using Managers.Abstract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Concrete
{
    public class RoleManager : Repository<Role, MyDatabaseContext>, IRoleManager //where C: MyDatabaseContext
    {
        public RoleManager(MyDatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
