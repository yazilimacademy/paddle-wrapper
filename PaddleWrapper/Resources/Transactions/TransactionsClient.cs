using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Transactions.Operations;
using PaddleWrapper.Resources.Transactions.Operations.List;
using System.Text.Json;

namespace PaddleWrapper.Resources.Transactions;

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
        HttpResponseMessage response = await _client.GetRawAsyncAsync("/transactions", listOperation);
        JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
        JsonElement data = jsonElement.GetProperty("data");
        JsonElement meta = jsonElement.GetProperty("meta");

        Paginator paginator = new(
            _client.HttpClient,
            Pagination.FromJson(meta),
            typeof(TransactionCollection)
        );

        return TransactionCollection.FromJson(data, paginator);
    }

    public async Task<Transaction> GetAsync(string id, Includes[] includes = null)
    {
        includes ??= Array.Empty<Includes>();
        var parameters = includes.Length == 0
            ? null
            : new { include = string.Join(",", includes.Select(x => x.ToString())) };

        JsonDocument response = await _client.Get($"/transactions/{id}", parameters);
        return Transaction.FromJson(response.RootElement.GetProperty("data"));
    }

    public async Task<Transaction> CreateAsync(CreateTransaction createOperation, Includes[] includes = null)
    {
        includes ??= Array.Empty<Includes>();
        var parameters = includes.Length == 0
            ? null
            : new { include = string.Join(",", includes.Select(x => x.ToString())) };

        JsonDocument response = await _client.Post("/transactions", createOperation, parameters);
        return Transaction.FromJson(response.RootElement.GetProperty("data"));
    }

    public async Task<Transaction> UpdateAsync(string id, UpdateTransaction operation)
    {
        JsonDocument response = await _client.Patch($"/transactions/{id}", operation);
        return Transaction.FromJson(response.RootElement.GetProperty("data"));
    }

    public async Task<TransactionPreview> PreviewAsync(PreviewTransaction operation)
    {
        JsonDocument response = await _client.Post("/transactions/preview", operation);
        return TransactionPreview.FromJson(response.RootElement.GetProperty("data"));
    }

    public async Task<TransactionData> GetInvoicePdfAsync(string id, GetTransactionInvoice getOperation = null)
    {
        getOperation ??= new GetTransactionInvoice();
        JsonDocument response = await _client.Get($"/transactions/{id}/invoice", getOperation);
        return TransactionData.FromJson(response.RootElement.GetProperty("data"));
    }
}