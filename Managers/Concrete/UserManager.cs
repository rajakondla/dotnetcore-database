using Data.Concrete;
using DotNetCoreWebAPI;
using Managers.Abstract;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Concrete
{
    public class UserManager: Repository<User, MyDatabaseContext>,IUserManager// where C:MyDatabaseContext
    {
        public UserManager(MyDatabaseContext dbContext):base(dbContext)
        {
            
        }


    }
}
