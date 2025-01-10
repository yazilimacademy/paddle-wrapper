using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Transaction;
using System.Threading.Tasks;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ITransactionService transactionService, ILogger<TransactionsController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        /// <summary>
        /// Lists all transactions
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaddleResponse<Transaction[]>>> ListTransactions()
        {
            return await _transactionService.ListTransactionsAsync();
        }

        /// <summary>
        /// Gets a specific transaction by ID
        /// </summary>
        [HttpGet("{transactionId}")]
        public async Task<ActionResult<PaddleResponse<Transaction>>> GetTransaction(string transactionId)
        {
            return await _transactionService.GetTransactionAsync(transactionId);
        }

        /// <summary>
        /// Gets customer transactions
        /// </summary>
        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<PaddleResponse<Transaction[]>>> GetCustomerTransactions(string customerId)
        {
            return await _transactionService.GetCustomerTransactionsAsync(customerId);
        }

        /// <summary>
        /// Gets subscription transactions
        /// </summary>
        [HttpGet("subscription/{subscriptionId}")]
        public async Task<ActionResult<PaddleResponse<Transaction[]>>> GetSubscriptionTransactions(string subscriptionId)
        {
            return await _transactionService.GetSubscriptionTransactionsAsync(subscriptionId);
        }

        /// <summary>
        /// Refunds a transaction
        /// </summary>
        [HttpPost("{transactionId}/refund")]
        public async Task<ActionResult<PaddleResponse<Transaction>>> RefundTransaction(string transactionId, [FromBody] decimal? amount = null)
        {
            return await _transactionService.RefundTransactionAsync(transactionId, amount);
        }

        /// <summary>
        /// Gets a transaction invoice PDF
        /// </summary>
        [HttpGet("{transactionId}/invoice")]
        public async Task<IActionResult> GetTransactionInvoice(string transactionId)
        {
            var response = await _transactionService.GetTransactionInvoiceAsync(transactionId);
            if (!response.Success)
            {
                return BadRequest(response.Error);
            }
            return File(response.Response, "application/pdf", $"invoice_{transactionId}.pdf");
        }

        /// <summary>
        /// Updates transaction notes
        /// </summary>
        [HttpPost("{transactionId}/notes")]
        public async Task<ActionResult<PaddleResponse<Transaction>>> UpdateTransactionNotes(string transactionId, [FromBody] string notes)
        {
            return await _transactionService.UpdateTransactionNotesAsync(transactionId, notes);
        }

        /// <summary>
        /// Updates transaction metadata
        /// </summary>
        [HttpPost("{transactionId}/metadata")]
        public async Task<ActionResult<PaddleResponse<Transaction>>> UpdateTransactionMetadata(string transactionId, [FromBody] Dictionary<string, string> metadata)
        {
            return await _transactionService.UpdateTransactionMetadataAsync(transactionId, metadata);
        }
    }
} 