using DemoUnitTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoUnitTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OneTableContext _context;

        public UserController(OneTableContext context)
        {
            _context = context;
        }


        // GET: api/<UserController>
        [HttpGet]
        public List<TblUser> UserList()
        {
            return _context.TblUsers.ToList();
        }

        [HttpGet]
        [Route("Salary")]
        public List<Salary> SalaryList()
        {
            return _context.Salaries.ToList();
        }
        [HttpGet]
        [Route("Merge")]
        public List<MergedTable> MergeList()
        {
            List<MergedTable> result = (from salary in _context.Salaries
                                        join user in _context.TblUsers on salary.UserId equals user.Id
                                        orderby user.Id
                                        select new MergedTable
                                        {
                                            Salary1=salary.Salary1,
                                           User= user.UserName,
                                           SalaryId=salary.SalaryId,
                                           UserId=user.Id

                                        }).ToList();
            return result.ToList();
        }
    }
}
