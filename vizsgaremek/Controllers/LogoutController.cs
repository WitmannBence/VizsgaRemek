using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vizsgaremek.DTOs;
using vizsgaremek.Models;

namespace vizsgaremek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        [HttpPost]
        public IActionResult Logout(string uID)
        {
            using (var context = new VizsgaremekContext())
            {
                try
                {
                    if (Program.LoggedInUsers.ContainsKey(uID))
                    {
                        Program.LoggedInUsers.Remove(uID);
                        return Ok("Sikeres kijelentkezés");
                    }

                    else if (!Program.LoggedInUsers.ContainsKey(uID))
                    {
                        return Unauthorized("Nem vagy bejelentkezve");
                    }

                    else
                    {
                        return BadRequest("Hiba történt");
                    }
                }


                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

    }
}