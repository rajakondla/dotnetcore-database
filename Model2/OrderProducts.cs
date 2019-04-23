using System;
using System.Collections.Generic;

namespace DotNetCoreWebAPI
{
    public partial class OrderProducts
    {
        public int Id { get; set; }
        public int? GasStationTankId { get; set; }
        public int? Quantity { get; set; }
    }
}
