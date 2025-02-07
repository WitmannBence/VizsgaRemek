using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using vizsgaremek.DTOs;
using vizsgaremek.Models;

namespace vizsgaremek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateService(Service service, string uId)
        {
            using (var context = new VizsgaremekContext())
            {
                try
                {
                    if (!Program.LoggedInUsers.ContainsKey(uId))
                    {
                        return Unauthorized("Nem vagy bejelentkezve");
                    }
                    if (service == null)
                    {
                        return BadRequest("Üres objektum");
                    }


                    context.Services.Add(service);
                    await context.SaveChangesAsync();
                    return Ok("Sikeres rögzítés");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            
        }
    }
}


