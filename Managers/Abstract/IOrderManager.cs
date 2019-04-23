using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreWebAPI;

namespace Managers.Abstract
{
    public interface IOrderManager : IRepository<Orders>
    {
    }
}
