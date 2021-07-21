using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_InterView.Data;

namespace Test_InterView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Baitap2Controller : ControllerBase
    {
        private readonly DpContext _context;
        public Baitap2Controller(DpContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult login(string password, int userphone= 0,string useremail=null)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserPhone == userphone || x.UserEmail == useremail);
            if (user != null)
            {
                if (user.UserPassword == password)
                    return Ok("Login success");
            }
            return BadRequest("Not found user");

        }
    }
}
