using Data.Concrete;
using DotNetCoreWebAPI;
using Managers.Abstract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Concrete
{
    public class UserRoleManager:Repository<UserRole, MyDatabaseContext>, IUserRoleManager //where C:MyDatabaseContext
    {
        public UserRoleManager(MyDatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
