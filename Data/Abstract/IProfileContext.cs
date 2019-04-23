﻿using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Abstract
{
    public interface IProfileContext
    {
        DbSet<User> User { get; set; }
        DbSet<Role> Role { get; set; }

        DbSet<UserRole> UserRole { get; set; }
    }
}
