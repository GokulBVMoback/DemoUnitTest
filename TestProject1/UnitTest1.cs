using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DemoUnitTest.Models;
using DemoUnitTest.Controllers;
using Microsoft.AspNetCore.Routing;
namespace TestProject1
{

    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    [Collection("Database collection")]
    public class DatabaseTestClass1
    {
        DatabaseFixture _fixture;
        private readonly UserController userController;
        public DatabaseTestClass1(DatabaseFixture fixture)
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
        public void GetAll_Merged()
        {
            var result = userController.MergeList();

            var items = Assert.IsType<List<MergedTable>>(result);


            Assert.Equal(4, items.Count);
        }


    }



    //public class UnitTest1:IClassFixture<DatabaseFixture>//,IDisposable
    //{
    //    private readonly UserController userController;

    //    DatabaseFixture _fixture;
    //    public UnitTest1(DatabaseFixture fixture)
    //    {
    //        _fixture = fixture;
    //        userController = new UserController(_fixture.context);

    //    }

    //    [Fact]
    //    public void GetAll_Test()
    //    {
    //        //SeedDatabase();

    //        var result = (userController.UserList());

    //        var items = Assert.IsType<List<TblUser>>(result);

    //        Assert.Equal(3, items.Count);
    //        //Dispose();
    //    }

    //    [Fact]
    //    public void GetAll_Salary_Test()
    //    {
    //        //SeedDatabase();

    //        var result = userController.SalaryList();

    //        var items = Assert.IsType<List<Salary>>(result);

    //        Assert.Equal(4, items.Count);
    //        //Dispose();
    //    }

    //    [Fact]
    //    public void GetAll_Merged()
    //    {
    //        //SeedDatabase();
    //        var result = userController.MergeList();

    //        var items = Assert.IsType<List<MergedTable>>(result);


    //        Assert.Equal(4, items.Count);
    //    }
}
