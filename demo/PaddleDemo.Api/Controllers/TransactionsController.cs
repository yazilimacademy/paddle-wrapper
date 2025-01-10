using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Transactions;
using System.Threading.Tasks;

namespace PaddleDemo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var result = await _transactionService.ListTransactionsAsync();
            return Ok(result);
        }

        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetTransaction(string transactionId)
        {
            var result = await _transactionService.GetTransactionAsync(transactionId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
        {
            var result = await _transactionService.CreateTransactionAsync(transaction);
            return Ok(result);
        }

        [HttpPatch("{transactionId}")]
        public async Task<IActionResult> UpdateTransaction(string transactionId, [FromBody] Transaction transaction)
        {
            var result = await _transactionService.UpdateTransactionAsync(transactionId, transaction);
            return Ok(result);
        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> GetCustomerTransactions(string customerId)
        {
            var result = await _transactionService.ListCustomerTransactionsAsync(customerId);
            return Ok(result);
        }

        [HttpGet("subscriptions/{subscriptionId}")]
        public async Task<IActionResult> GetSubscriptionTransactions(string subscriptionId)
        {
            var result = await _transactionService.ListSubscriptionTransactionsAsync(subscriptionId);
            return Ok(result);
        }

        [HttpPost("preview")]
        public async Task<IActionResult> PreviewTransaction([FromBody] Transaction transaction)
        {
            var result = await _transactionService.PreviewTransactionAsync(transaction);
            return Ok(result);
        }

        [HttpPost("{transactionId}/invoice")]
        public async Task<IActionResult> InvoiceTransaction(string transactionId)
        {
            var result = await _transactionService.InvoiceTransactionAsync(transactionId);
            return Ok(result);
        }
    }
}
