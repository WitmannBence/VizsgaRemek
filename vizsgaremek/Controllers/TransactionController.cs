using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vizsgaremek.Models;
using vizsgaremek.DTOs;
using Microsoft.EntityFrameworkCore;
namespace vizsgaremek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost("purchase")]
        public async Task<IActionResult> PurchaseService(PurchaseDTO request, string uId)
        {
            using (var context = new VizsgaremekContext())
            {
                try
                {
                    if (!Program.LoggedInUsers.ContainsKey(uId))
                    {
                        return Unauthorized("Nem vagy bejelentkezve");
                    }

                    var buyer = await context.Users.FindAsync(request.BuyerId);
                    var service = await context.Services.FindAsync(request.ServiceId);

                    if (buyer == null || service == null)
                    {
                        return NotFound("Felhasználó vagy szolgáltatás nem található.");
                    }

                    var seller = await context.Users.FindAsync(service.UserId);
                    if (seller == null)
                    {
                        return NotFound("Az eladó nem található.");
                    }

                    
                    if (buyer.TimeBalance < service.TimeCost)
                    {
                        return BadRequest("Nincs elegendő időkeret a vásárláshoz.");
                    }

                    
                    buyer.TimeBalance -= service.TimeCost;
                    seller.TimeBalance += service.TimeCost;

                   
                    string transactionCode = GenerateTransactionCode();

            
                    var transaction = new Transaction
                    {
                        SenderId = buyer.UserId,
                        ReceiverId = seller.UserId,
                        ServiceId = service.ServiceId,
                        TimeAmount = service.TimeCost,
                        Description = $"Service purchased: {service.ServiceName}",
                        TransactionDate = DateTime.UtcNow,
                        TransactionCode = transactionCode
                    };

                    context.Transactions.Add(transaction);
                    await context.SaveChangesAsync(); 

                 
                    return Ok(new
                    {
                        SellerEmail = seller.Email,
                        TransactionCode = transactionCode
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet("transaction-history/{userId}")]
        public async Task<IActionResult> GetTransactionHistory(int userId)
        {
            using (var context = new VizsgaremekContext())
            {
                try
                {
                    var transactions = await context.Transactions
                        .Where(t => t.SenderId == userId || t.ReceiverId == userId)
                        .OrderByDescending(t => t.TransactionDate) 
                        .Select(t => new
                        {
                            TransactionID = t.TransactionId,
                            ServiceName = context.Services
                                            .Where(s => s.ServiceId == t.ServiceId)
                                            .Select(s => s.ServiceName)
                                            .FirstOrDefault(),
                            TimeAmount = t.TimeAmount,
                            TransactionDate = t.TransactionDate,
                            TransactionCode = t.TransactionCode,
                            Type = t.SenderId == userId ? "Purchase" : "Sale",
                            CounterpartyEmail = t.SenderId == userId
                                ? context.Users.Where(u => u.UserId == t.ReceiverId).Select(u => u.Email).FirstOrDefault()
                                : context.Users.Where(u => u.UserId == t.SenderId).Select(u => u.Email).FirstOrDefault()
                        })
                        .ToListAsync();

                    return Ok(transactions);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        private string GenerateTransactionCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
