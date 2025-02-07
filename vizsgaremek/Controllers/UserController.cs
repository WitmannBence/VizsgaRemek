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
        [HttpPost("Register")]
        public async Task<IActionResult> Registry(User user)
        {
            using (var context = new VizsgaremekContext())
            {
                try
                {
                    if (context.Users.FirstOrDefault(u => u.FelhasznaloNev == user.FelhasznaloNev) != null)
                    {
                        return BadRequest("A felhasználónév már foglalt");
                    }
                    if (context.Users.FirstOrDefault(u => u.Email == user.Email) != null)
                    {
                        return BadRequest("Az email cím már foglalt!");
                    }
                    user.Aktiv = 0;
                    user.Jogosultsag = 0;
                    user.Hash = Program.CreateSHA256(user.Hash);
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                    Program.SendEmail(user.Email, "Regisztráció", $"A következő linkre kattintva véglegesítse a regisztrációját: \nhttp://localhost:5000/api/Registry?felhasznaloNev={user.FelhasznaloNev}&email={user.Email}");
                    return Ok("Sikeres regisztráció! Az aktiváláshoz ellenőrizze az email fiókját!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
