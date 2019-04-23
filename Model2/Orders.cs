using System;
using System.Collections.Generic;

namespace DotNetCoreWebAPI
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int? GasStationId { get; set; }
        public int? DeliveryDate { get; set; }
    }
}
