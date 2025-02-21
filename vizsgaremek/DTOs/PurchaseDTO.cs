using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace vizsgaremek.DTOs
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDTO : ControllerBase
    {
        public int BuyerId { get; set; }  
        public int ServiceId { get; set; } 
    }
}
