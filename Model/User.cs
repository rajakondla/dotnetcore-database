using System;
using System.Collections.Generic;

namespace DotNetCoreWebAPI
{
    public partial class User
    {
        public User()
        {
            UserRole = new HashSet<UserRole>();
        }

        public long Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ProfileComplete { get; set; }
        public string Token { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
