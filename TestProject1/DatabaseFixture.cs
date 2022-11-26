using DemoUnitTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class DatabaseFixture : IDisposable
    {
        private static DbContextOptions<OneTableContext> dbContextOptions = new DbContextOptionsBuilder<OneTableContext>()
          .UseInMemoryDatabase(databaseName: "OneTable")
          .Options;
        public OneTableContext context;
        public DatabaseFixture()
        {
            context = new OneTableContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
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
    }
}
