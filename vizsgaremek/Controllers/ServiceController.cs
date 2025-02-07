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
        private readonly VizsgaremekContext _context;

        public ServiceController(VizsgaremekContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Service>> CreateService([FromBody] CreateServiceDto dto)
        {
            var username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("notloggedin.");
            }
            var user = await _context.Users
                .Where(u => u.FelhasznaloNev == username)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("how did u do this");
            }

            var service = new Service
            {
                ServiceName = dto.ServiceName,
                Description = dto.Description,
                Category = dto.Category,
                CreatedAt = DateTime.UtcNow,  
                UserId = user.UserId         
            };
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            var userService = new UserService
            {
                UserId = user.UserId,
                ServiceId = service.ServiceId
            };
            _context.UserServices.Add(userService);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateService), new { id = service.ServiceId }, service);
        }
    }
}


