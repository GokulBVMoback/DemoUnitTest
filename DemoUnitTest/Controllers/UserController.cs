using DemoUnitTest.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
