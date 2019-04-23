using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetCoreWebAPI;
using DotNetCoreWebAPI.Controllers;
using NUnit.Framework;
using Moq;
using Managers.Concrete;
using Microsoft.EntityFrameworkCore;

namespace NUnitTesting
{
    public class Class1
    {
       // public DbContextOptions<MyDatabaseContext> DummyOptions { get; } = new DbContextOptionsBuilder<MyDatabaseContext>().Options;

        [Test]
        public void Test()
        {
            // Arrange
            var userData = new List<User> {
            new User { FirstName="Raja", LastName="Kondla", UserId="Raja@king", Password="Raja@king123", IsDeleted=false },
            new User { FirstName="Sheri", LastName="Begum", UserId="Raja@king", Password="Raja@king123", IsDeleted=false },
             }.AsQueryable();

            //var mockContext = new DbContextMock<MyDatabaseContext>(DummyOptions);
            //var userDbSet = mockContext.CreateDbSetMock(u=>u.User, userData);
            var userDbSet = new Mock<DbSet<User>>();
            userDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            userDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            userDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            userDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            var mockContext = new Mock<MyDatabaseContext>();
            mockContext.Setup(c => c.Set<User>()).Returns(userDbSet.Object);

            var userMgr = new UserManager(mockContext.Object);
          
            UserController controller = new UserController(userMgr);
            var result = controller.Get();

            Assert.AreEqual(typeof(bool), result.GetType());

            //var mockDbSetUser = new Mock<DbSet<User>>();
            //mockContext.Setup(m => m.Set<User>()).Returns(mockDbSetUser.Object);
            //mockDbSetUser.Setup(m => m.Add(It.IsAny<User>())).Returns(userData);

        }
    }
}
