using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DotNetCoreWebAPI
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public long? UserId { get; set; }
        public int? RoleId { get; set; }

        [JsonIgnore]
        
        public virtual Role Role { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
