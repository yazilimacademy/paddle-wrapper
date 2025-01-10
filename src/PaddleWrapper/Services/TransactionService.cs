using Microsoft.Extensions.Logging;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Services
{
    /// <summary>
    /// Service for managing transactions in the Paddle system
    /// </summary>
    public class TransactionService : ITransactionService
    {
        private readonly IPaddleClient _client;
        private readonly ILogger<TransactionService> _logger;
        private const string BasePath = "/transactions";

        /// <summary>
        /// Creates a new instance of TransactionService
        /// </summary>
        public TransactionService(IPaddleClient client, ILogger<TransactionService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Transaction>>> ListTransactionsAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving list of transactions");
            return await _client.GetAsync<PaddleResponse<List<Transaction>>>(BasePath, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Transaction>> GetTransactionAsync(string transactionId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(transactionId))
            {
                throw new ArgumentException("Transaction ID must be provided", nameof(transactionId));
            }

            _logger.LogInformation("Retrieving transaction with ID: {TransactionId}", transactionId);
            return await _client.GetAsync<PaddleResponse<Transaction>>($"{BasePath}/{transactionId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Transaction>> CreateTransactionAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _logger.LogInformation("Creating new transaction for customer: {CustomerId}", transaction.CustomerId);
            return await _client.PostAsync<Transaction, PaddleResponse<Transaction>>(BasePath, transaction, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Transaction>> UpdateTransactionAsync(string transactionId, Transaction transaction, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(transactionId))
            {
                throw new ArgumentException("Transaction ID must be provided", nameof(transactionId));
            }

            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _logger.LogInformation("Updating transaction with ID: {TransactionId}", transactionId);
            return await _client.PatchAsync<Transaction, PaddleResponse<Transaction>>($"{BasePath}/{transactionId}", transaction, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Transaction>>> ListCustomerTransactionsAsync(string customerId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException("Customer ID must be provided", nameof(customerId));
            }

            _logger.LogInformation("Retrieving transactions for customer with ID: {CustomerId}", customerId);
            return await _client.GetAsync<PaddleResponse<List<Transaction>>>($"{BasePath}?customer_id={customerId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Transaction>>> ListSubscriptionTransactionsAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(subscriptionId))
            {
                throw new ArgumentException("Subscription ID must be provided", nameof(subscriptionId));
            }

            _logger.LogInformation("Retrieving transactions for subscription with ID: {SubscriptionId}", subscriptionId);
            return await _client.GetAsync<PaddleResponse<List<Transaction>>>($"{BasePath}?subscription_id={subscriptionId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Transaction>> PreviewTransactionAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _logger.LogInformation("Previewing transaction for customer: {CustomerId}", transaction.CustomerId);
            return await _client.PostAsync<Transaction, PaddleResponse<Transaction>>($"{BasePath}/preview", transaction, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Transaction>> InvoiceTransactionAsync(string transactionId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(transactionId))
            {
                throw new ArgumentException("Transaction ID must be provided", nameof(transactionId));
            }

            _logger.LogInformation("Invoicing transaction with ID: {TransactionId}", transactionId);
            return await _client.PostAsync<object, PaddleResponse<Transaction>>($"{BasePath}/{transactionId}/invoice", null, cancellationToken);
        }
    }
}