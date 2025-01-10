using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Transactions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Interfaces
{
    /// <summary>
    /// Interface for managing transactions in the Paddle system
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Gets a list of all transactions
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Transaction>>> ListTransactionsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a transaction by its ID
        /// </summary>
        /// <param name="transactionId">The ID of the transaction</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Transaction>> GetTransactionAsync(string transactionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new transaction
        /// </summary>
        /// <param name="transaction">The transaction to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Transaction>> CreateTransactionAsync(Transaction transaction, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing transaction
        /// </summary>
        /// <param name="transactionId">The ID of the transaction to update</param>
        /// <param name="transaction">The updated transaction data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Transaction>> UpdateTransactionAsync(string transactionId, Transaction transaction, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of transactions for a customer
        /// </summary>
        /// <param name="customerId">The ID of the customer</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Transaction>>> ListCustomerTransactionsAsync(string customerId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of transactions for a subscription
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Transaction>>> ListSubscriptionTransactionsAsync(string subscriptionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Previews a transaction before creating it
        /// </summary>
        /// <param name="transaction">The transaction to preview</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Transaction>> PreviewTransactionAsync(Transaction transaction, CancellationToken cancellationToken = default);

        /// <summary>
        /// Invoices a transaction immediately
        /// </summary>
        /// <param name="transactionId">The ID of the transaction to invoice</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Transaction>> InvoiceTransactionAsync(string transactionId, CancellationToken cancellationToken = default);
    }
}