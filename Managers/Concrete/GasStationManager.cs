
using Data.Concrete;
using DotNetCoreWebAPI;
using Managers.Abstract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Concrete
{
    public class GasStationManager : Repository<GasStations, MySecondDatabaseContext>, IGasStationManager //where C : MySecondDatabaseContext
    {
        public GasStationManager(MySecondDatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
