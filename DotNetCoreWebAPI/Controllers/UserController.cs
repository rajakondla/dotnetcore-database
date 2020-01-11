using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DotNetCoreWebAPI.ViewModel;
using Managers.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserManager _userMgr;
        // added code for CI trigger
        public UserController(IUserManager userMgr)
        {
            _userMgr = userMgr;
        }

        [HttpPost("checkuser")]
        public async Task<bool> CheckUser([FromBody]UserModel userModel)
        {
            bool userExist = false;

            Action action = () =>
            {
                userExist = (from getUser in _userMgr.All()
                             select getUser).Any();
            };

            await Task.Run(action);
            return userExist;
        }

        [HttpGet("get")]
        public bool Get()
        {
            return (from get in _userMgr.All() select get.FirstName).Any();
        }


        [HttpPost("saveuser")]
        public User SaveUser([FromBody]User user)
        {
            return new User();
        }
    }
}
