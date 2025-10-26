using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication52.Application.Dto;
using WebApplication52.Domain.Interfaces;

namespace WebApplication52.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionActions transactionService;
        private readonly ILogger<TransactionController> logger;
        public TransactionController(ITransactionActions transactionService, ILogger<TransactionController> logger)
        {
            this.logger = logger;
            this.transactionService = transactionService;
        }
        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderProductDto request)
        {
            if (request == null)
            {
                logger.LogWarning("Received null order request.");
                return BadRequest("Invalid request.");
            }

            await transactionService.CreateOrderAsync(request);

            return Ok(new 
            { 
                Message = "Order successfully processes."
            });
        }
    }
}
