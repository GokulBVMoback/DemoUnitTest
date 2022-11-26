using DemoUnitTest.Controllers;
using DemoUnitTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{

    [Collection("Database collection")]
    public class DatabaseTestClass2
    {
        DatabaseFixture _fixture;
        private readonly UserController userController;
        public DatabaseTestClass2(DatabaseFixture fixture)
        {
            _fixture = fixture;
            userController = new UserController(_fixture.context);
        }
        [Fact]
        public void GetAll_Test()
        {

            var result = (userController.UserList());

            var items = Assert.IsType<List<TblUser>>(result);

            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetAll_Salary_Test()
        {

            var result = userController.SalaryList();

            var items = Assert.IsType<List<Salary>>(result);

            Assert.Equal(4, items.Count);
        }

    }
}
