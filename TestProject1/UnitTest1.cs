using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DemoUnitTest.Models;
using DemoUnitTest.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging.Abstractions;
//using Microsoft.AspNetCore.Http;

namespace TestProject1
{
    public class UnitTest1
    {
        private static DbContextOptions<OneTableContext> dbContextOptions = new DbContextOptionsBuilder<OneTableContext>()
          .UseInMemoryDatabase(databaseName: "OneTable")
          .Options;
        OneTableContext context;
        UserController userController;
  
        public UnitTest1()
        {
            context = new OneTableContext(dbContextOptions);
            context.Database.EnsureCreated();
            //SeedDatabase();
            userController= new UserController(context);
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
            context.SaveChanges();

            var salary = new List<Salary>()
            {
                new Salary(){SalaryId=1, Salary1=10000, UserId=1 },
                new Salary(){SalaryId=2, Salary1=10000, UserId=2 },
                new Salary(){SalaryId=3, Salary1=10000, UserId=3 },
                new Salary(){SalaryId=4, Salary1=10000, UserId=3 }

            };
            context.Salaries.AddRange(salary);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Fact]
        public void GetAll_Test()
        {
            SeedDatabase();

            var result = userController.UserList();
            
            var items = Assert.IsType<List<TblUser>>(result);
            
            Assert.Equal(3, items.Count);
            Dispose();
        }
        
        [Fact]
        public void GetAll_Salary_Test()
        {
            SeedDatabase();

            var result = userController.SalaryList();
            
            var items = Assert.IsType<List<Salary>>(result);

            Assert.Equal(4, items.Count);
            Dispose();
        }
        //~UnitTest1()
        //{
        //    context.Database.EnsureDeleted();
        //}
    }
}