using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Transactions;

namespace PaddleWrapperDemo.Controllers
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
            PaddleWrapper.Models.Common.PaddleResponse<List<Transaction>> result = await _transactionService.ListTransactionsAsync();
            return Ok(result);
        }

        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetTransaction(string transactionId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Transaction> result = await _transactionService.GetTransactionAsync(transactionId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Transaction> result = await _transactionService.CreateTransactionAsync(transaction);
            return Ok(result);
        }

        [HttpPatch("{transactionId}")]
        public async Task<IActionResult> UpdateTransaction(string transactionId, [FromBody] Transaction transaction)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Transaction> result = await _transactionService.UpdateTransactionAsync(transactionId, transaction);
            return Ok(result);
        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> GetCustomerTransactions(string customerId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<Transaction>> result = await _transactionService.ListCustomerTransactionsAsync(customerId);
            return Ok(result);
        }

        [HttpGet("subscriptions/{subscriptionId}")]
        public async Task<IActionResult> GetSubscriptionTransactions(string subscriptionId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<Transaction>> result = await _transactionService.ListSubscriptionTransactionsAsync(subscriptionId);
            return Ok(result);
        }

        [HttpPost("preview")]
        public async Task<IActionResult> PreviewTransaction([FromBody] Transaction transaction)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Transaction> result = await _transactionService.PreviewTransactionAsync(transaction);
            return Ok(result);
        }

        [HttpPost("{transactionId}/invoice")]
        public async Task<IActionResult> InvoiceTransaction(string transactionId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Transaction> result = await _transactionService.InvoiceTransactionAsync(transactionId);
            return Ok(result);
        }
    }
}
