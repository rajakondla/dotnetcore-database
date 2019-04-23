using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNetCoreWebAPI.HelperMethods;
using Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;
using StackExchange.Redis;
using vModel = DotNetCoreWebAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    // [ApiController]
    public class ValuesController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IUserRoleManager _userRoleManager;
        private readonly IRoleManager _roleManager;
        private readonly IOrderManager _orderManager;
        private readonly IOrderProductManager _orderProdManager;

        public ValuesController(IUserManager userManager, IRoleManager roleManager, IUserRoleManager userRoleManager, IOrderManager orderManager, IOrderProductManager orderProdManager)
        {
            _userManager = userManager;
            _userRoleManager = userRoleManager;
            _roleManager = roleManager;
            _orderManager = orderManager;
            _orderProdManager = orderProdManager;
        }

        // GET api/values
        [HttpGet("getuser")]
        // [Route("getuser")]
        public Result Get()
        {
            var data = (from user in _userManager.All()
                        join userRole in _userRoleManager.All() on user.Id equals userRole.UserId
                        join role in _roleManager.All() on userRole.RoleId equals role.Id
                        select new { user.FirstName, RoleName = role.Name, user.LastName }).ToList();

            var orderData = (from getOrder in _orderManager.All()
                             join getOrdProd in _orderProdManager.All() on getOrder.Id equals getOrdProd.Id
                             select new { getOrder.Id, getOrder.GasStationId, getOrdProd.Quantity }
                             ).ToList();

            //Thread.Sleep(10000);

            return new Result { Data = orderData, IsSuccess = true };
            //return _userManager.All().Select(u=>new { u.Id,u.UserId,u.FirstName,u.LastName}).ToList();
            //return new List<SampleJson> { new SampleJson { Id = 1, Name = "Raja" }, new SampleJson { Id=2,Name="Kondla" } };
        }

        public class Result
        {
            public object Data { get; set; }
            public bool IsSuccess { get; set; }
        }

        // GET api/values/5
        // [HttpGet("{id}")]
        [HttpGet("get/{id}")]
        //[Route("get/{id}")]
        public object Get(int id)
        {
            //var users = new RedisDictionary<int, vModel.User>("Users");

            //if(users!=null && users[id]!=null)
            //{
            //    return new { IsSuccess=true,result=users[id]};
            //}
            //else
            //{
            var data = (from user in _userManager.All().Include(u => u.UserRole)
                        where user.Id == id
                        select new vModel.User { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, IsDeleted = user.IsDeleted, Password = user.Password, ProfileComplete = user.ProfileComplete, Token = user.Token, UserId = user.UserId, UserRole = user.UserRole }).SingleOrDefault();
            //  if (data != null)
            {
                //    users.Add(id, data);
                return new { IsSuccess = true, result = data };
            }
            //else
            //{
            //    return new { IsSuccess = false, message="User does not exists!" };
            //}
        }

        //IDatabase db= RedisConnection.Connection.GetDatabase();

        //string name = db.StringGet("Name");

        //if(name==null)
        //{
        //    name = "Sheri Begum Kondla";
        //    db.StringSet("Name", name, TimeSpan.FromMinutes(5));
        //}
        //return name;

        //using (RedisClient rdsClient = new RedisClient("localhost"))
        //{
        //    rdsClient.Set<string>("Name", "Raja Kondla");
        //}

        //using (RedisClient rdsClient = new RedisClient("localhost"))
        //{
        //    //Console.WriteLine(rdsClient.Get<string>("Name"));
        //    //Console.ReadLine();
        //    return rdsClient.Get<string>("Name");
        //}

    }

    //// POST api/values
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //    // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
    //}

    //// PUT api/values/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //    // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
    //}

    //// DELETE api/values/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //    // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
    //}

}


