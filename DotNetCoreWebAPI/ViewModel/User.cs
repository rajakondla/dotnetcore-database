using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.ViewModel
{
    public class User
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ProfileComplete { get; set; }
        public string Token { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<DotNetCoreWebAPI.UserRole> UserRole { get; set; }
    }
    
    public class UserModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
