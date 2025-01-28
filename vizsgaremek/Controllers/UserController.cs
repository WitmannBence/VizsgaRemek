using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vizsgaremek.Models;

namespace vizsgaremek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers() 
        {
            using (var context = new VizsgaremekContext())
            {
                try
                {
                    List<User> userList = new List<User>();
                    {
                        userList = context.Users.ToList();

                    }
                    return Ok(userList);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
