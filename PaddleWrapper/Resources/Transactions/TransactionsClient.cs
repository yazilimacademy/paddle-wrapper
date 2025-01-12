using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.Transactions.Operations;
using PaddleWrapper.Resources.Transactions.Operations.List;

namespace PaddleWrapper.Resources.Transactions
{
    public class TransactionsClient
    {
        private readonly Client _client;

        public TransactionsClient(Client client)
        {
            _client = client;
        }

        public async Task<TransactionCollection> ListAsync(ListTransactions listOperation = null)
        {
            listOperation ??= new ListTransactions();
            return await _client.Get<TransactionCollection>("/transactions", listOperation);
        }

        public async Task<Transaction> GetAsync(string id, Includes[] includes = null)
        {
            var parameters = includes != null && includes.Length > 0
                ? new { include = string.Join(",", includes).ToLower() }
                : null;

            return await _client.Get<Transaction>($"/transactions/{id}", parameters);
        }

        public async Task<Transaction> CreateAsync(CreateTransaction createOperation, Includes[] includes = null)
        {
            var parameters = includes != null && includes.Length > 0
                ? new { include = string.Join(",", includes).ToLower() }
                : null;

            return await _client.Post<Transaction>("/transactions", createOperation, parameters);
        }

        public async Task<Transaction> UpdateAsync(string id, UpdateTransaction operation)
        {
            return await _client.Patch<Transaction>($"/transactions/{id}", operation);
        }

        public async Task<TransactionPreview> PreviewAsync(PreviewTransaction operation)
        {
            return await _client.Post<TransactionPreview>("/transactions/preview", operation);
        }

        public async Task<TransactionData> GetInvoicePdfAsync(string id, GetTransactionInvoice getOperation = null)
        {
            getOperation ??= new GetTransactionInvoice();
            return await _client.Get<TransactionData>($"/transactions/{id}/invoice", getOperation);
        }
    }
}