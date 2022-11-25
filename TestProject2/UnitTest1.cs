using DemoUnitTest.Models;
using Microsoft.EntityFrameworkCore;
using DemoUnitTest.Controllers;

namespace TestProject2
{
    public class Tests
    {

            //-------------nUnit Test--------------//

        private static DbContextOptions<OneTableContext> dbContextOptions = new DbContextOptionsBuilder<OneTableContext>()
           .UseInMemoryDatabase(databaseName: "OneTable")
           .Options;
        OneTableContext context;
        UserController userController;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new OneTableContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
            userController = new UserController(context);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        public void SeedDatabase()
        {
            var user = new List<TblUser>()
            {
                new TblUser(){Id= 1, UserName="abc" },
                new TblUser(){Id= 2, UserName="def" },
                new TblUser(){Id= 3, UserName="ghi" }
            };
            context.TblUsers.AddRange(user);
            //context.SaveChanges();
            var salary = new List<Salary>()
            {
                new Salary(){SalaryId=1, Salary1=10000, UserId=1 },
                new Salary(){SalaryId=2, Salary1=20000, UserId=2 },
                new Salary(){SalaryId=3, Salary1=30000, UserId=3 },
                new Salary(){SalaryId=4, Salary1=40000, UserId=3 }

            };
            context.Salaries.AddRange(salary);
            context.SaveChanges();
        }
        [Test]
        public void GetAll_User()
        {
            var result = userController.UserList();

            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void GetAll_Salary()
        {
            var result = userController.SalaryList();

            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void GetAll_Merged()
        {
            var result = userController.MergeList();

            Assert.AreEqual(4, result.Count);
        }
    }
}