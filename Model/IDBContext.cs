using DotNetCoreWebAPI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IDBContext
    {
        DbSet<Demo> Demo { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserRole> UserRole { get; set; }
    }
}
