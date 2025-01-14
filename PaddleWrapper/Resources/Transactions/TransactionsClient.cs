using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Transactions.Operations;
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
        try
        {
            HttpResponseMessage response = await _client.GetRawAsync("/transactions", listOperation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw TransactionApiError.FromJson(root);
            }

            JsonElement data = root.GetProperty("data");
            JsonElement meta = root.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(TransactionCollection)
            );

            return TransactionCollection.FromJson(data, paginator);
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (TransactionApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }

    public async Task<Transaction> GetAsync(string id, GetTransaction getOperation = null)
    {
        try
        {
            HttpResponseMessage response = await _client.GetRawAsync($"/transactions/{id}", getOperation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw TransactionApiError.FromJson(root);
            }

            return Transaction.FromJson(root.GetProperty("data"));
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (TransactionApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }
}